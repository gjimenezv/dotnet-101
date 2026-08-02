using dotnet_101.DTOs;
using dotnet_101.Models;
using dotnet_101.Repositories;

namespace dotnet_101.Services
{
    public class OrderService : IOrderService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public async Task<Order> PlaceOrderAsync(CreateOrderRequest request)
        {
            if(request.Items is null || request.Items.Count() == 0) throw new InvalidOperationException($"Items are empty"); 

            var items = new List<OrderItem>();
            var products = await _productRepository.GetByIdsAsync(request.Items.Select(i => i.ProductId).ToList());

            foreach (var item in request.Items)
            {

                var product = products.Find(p => p.Id == item.ProductId);

                if (product is null) throw new InvalidOperationException($"Product {item.ProductId} do not exist"); 

                if (item.Quantity <= 0) throw new InvalidOperationException($"Item with product id {item.ProductId} should have Quantity > 0"); 

                items.Add(new OrderItem
                {
                     ProductId = item.ProductId,
                     Quantity = item.Quantity,
                     UnitPrice = product.Price
                });
            }

            var order = new Order
            {
                CustomerId = request.CustomerId,
                OrderDate = DateTime.UtcNow,
                Status = "Pending",
                OrderItems = items
            };

            return await _orderRepository.CreateAsync(order);
        }
    }
}