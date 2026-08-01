// Shared quiz widget for teach workspace lessons.
// Two patterns:
//   .quiz-mc      multiple choice with instant feedback, data-correct = 0-based index of .quiz-opt
//   .quiz-recall  click-to-reveal retrieval practice card

document.addEventListener("DOMContentLoaded", () => {
  document.querySelectorAll(".quiz-mc").forEach((quiz) => {
    const correctIndex = Number(quiz.dataset.correct);
    const opts = Array.from(quiz.querySelectorAll(".quiz-opt"));
    const feedback = quiz.querySelector(".quiz-feedback");

    opts.forEach((opt, i) => {
      opt.addEventListener("click", () => {
        opts.forEach((o) => (o.disabled = true));
        if (i === correctIndex) {
          opt.classList.add("correct");
          feedback.textContent = "Correcto.";
          feedback.className = "quiz-feedback ok";
        } else {
          opt.classList.add("incorrect");
          opts[correctIndex].classList.add("correct");
          feedback.textContent = "No — la correcta está marcada en verde.";
          feedback.className = "quiz-feedback bad";
        }
      });
    });
  });

  document.querySelectorAll(".quiz-recall").forEach((card) => {
    const btn = card.querySelector(".quiz-reveal-btn");
    const answer = card.querySelector(".quiz-answer");
    if (!btn || !answer) return;
    btn.addEventListener("click", () => {
      answer.hidden = !answer.hidden;
      btn.textContent = answer.hidden ? "Mostrar respuesta" : "Ocultar respuesta";
    });
  });
});
