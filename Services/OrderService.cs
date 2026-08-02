using dotnet_101.DTOs;
using dotnet_101.Models;
using dotnet_101.Repositories;

namespace dotnet_101.Services
{
    public class OrderService : IOrderService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrderService(IProductRepository productRepository, IOrderRepository orderRepository, ICustomerRepository customerRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        public async Task<Order> PlaceOrderAsync(CreateOrderRequest request)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);

            if (customer is null) throw new InvalidOperationException($"Invalid CustomerId");

            var items = new List<OrderItem>();
            var products = await _productRepository.ListByIdsAsync(request.Items.Select(i => i.ProductId).ToList());

            foreach (var item in request.Items)
            {

                var product = products.Find(p => p.Id == item.ProductId);

                if (product is null) throw new InvalidOperationException($"Product {item.ProductId} do not exist"); 

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