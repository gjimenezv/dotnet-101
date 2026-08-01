// Shared live-SQL practice widget for teach workspace lessons.
// Runs real SQLite (via sql.js/WASM) in the browser against a seed script
// embedded in a <script type="application/sql" id="sql-seed"> tag.
// Dialect note: SQLite, not T-SQL — good enough for JOIN/GROUP BY/subquery
// logic, but syntax like TOP, GETDATE(), or stored procedures differs.

const SQL_JS_BASE = "https://cdnjs.cloudflare.com/ajax/libs/sql.js/1.14.1/";

function loadScript(src) {
  return new Promise((resolve, reject) => {
    const s = document.createElement("script");
    s.src = src;
    s.onload = resolve;
    s.onerror = () => reject(new Error(`No se pudo cargar ${src}`));
    document.head.appendChild(s);
  });
}

function renderResult(resultEl, res) {
  resultEl.innerHTML = "";
  if (res.length === 0) {
    resultEl.innerHTML = '<p class="sql-empty">Sin resultados (0 filas).</p>';
    return;
  }
  const { columns, values } = res[0];
  const table = document.createElement("table");
  const thead = document.createElement("tr");
  columns.forEach((c) => {
    const th = document.createElement("th");
    th.textContent = c;
    thead.appendChild(th);
  });
  table.appendChild(thead);
  values.forEach((row) => {
    const tr = document.createElement("tr");
    row.forEach((v) => {
      const td = document.createElement("td");
      td.textContent = v === null ? "NULL" : v;
      tr.appendChild(td);
    });
    table.appendChild(tr);
  });
  resultEl.appendChild(table);
  const count = document.createElement("p");
  count.className = "sql-row-count";
  count.textContent = `${values.length} fila(s)`;
  resultEl.appendChild(count);
}

async function initSqlRunner() {
  const statusEls = document.querySelectorAll(".sql-engine-status");
  statusEls.forEach((el) => (el.textContent = "Cargando motor SQL (SQLite/WASM)…"));

  await loadScript(SQL_JS_BASE + "sql-wasm.js");
  const SQL = await window.initSqlJs({ locateFile: (f) => SQL_JS_BASE + f });
  const db = new SQL.Database();

  const seedEl = document.getElementById("sql-seed");
  if (seedEl) db.run(seedEl.textContent);

  statusEls.forEach((el) => (el.textContent = "Motor SQL listo — datos de ejemplo cargados."));
  document.querySelectorAll(".sql-run-btn").forEach((btn) => (btn.disabled = false));

  document.querySelectorAll(".sql-exercise").forEach((ex) => {
    const input = ex.querySelector(".sql-input");
    const runBtn = ex.querySelector(".sql-run-btn");
    const resultEl = ex.querySelector(".sql-result");
    if (!input || !runBtn || !resultEl) return;

    runBtn.addEventListener("click", () => {
      try {
        const res = db.exec(input.value);
        renderResult(resultEl, res);
      } catch (err) {
        resultEl.innerHTML = `<p class="sql-error">Error: ${err.message}</p>`;
      }
    });
  });

  document.querySelectorAll(".sql-reveal-btn").forEach((btn) => {
    const ex = btn.closest(".sql-exercise");
    const sol = ex.querySelector(".sql-solution");
    if (!sol) return;
    btn.addEventListener("click", () => {
      sol.hidden = !sol.hidden;
      btn.textContent = sol.hidden ? "Ver solución" : "Ocultar solución";
    });
  });
}

document.addEventListener("DOMContentLoaded", () => {
  document.querySelectorAll(".sql-run-btn").forEach((b) => (b.disabled = true));
  initSqlRunner().catch(() => {
    document.querySelectorAll(".sql-engine-status").forEach((el) => {
      el.textContent =
        "No se pudo cargar el motor SQL (¿sin conexión a internet?). Podés seguir escribiendo las queries y comparar directamente con la solución.";
    });
  });
});
