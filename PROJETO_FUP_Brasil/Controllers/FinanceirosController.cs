using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PROJETO_FUP_Brasil.Data;
using PROJETO_FUP_Brasil.Models;

namespace PROJETO_FUP_Brasil.Controllers
{
    public class FinanceirosController : Controller
    {
        private readonly PROJETO_FUP_BrasilContext _context;

        public FinanceirosController(PROJETO_FUP_BrasilContext context)
        {
            _context = context;
        }

        // GET: Financeiros
        public async Task<IActionResult> Index()
        {
            var pROJETO_FUP_BrasilContext = _context.Financeiro.Include(f => f.Aluno).Include(f => f.Funcionario);
            return View(await pROJETO_FUP_BrasilContext.ToListAsync());
        }

        // GET: Financeiros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financeiro = await _context.Financeiro
                .Include(f => f.Aluno)
                .Include(f => f.Funcionario)
                .FirstOrDefaultAsync(m => m.FinanceiroId == id);
            if (financeiro == null)
            {
                return NotFound();
            }

            return View(financeiro);
        }

        // GET: Financeiros/Create
        public IActionResult Create()
        {
            ViewData["AlunoID"] = new SelectList(_context.Aluno, "Id_Matricula", "Cpf");
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "FuncionarioId");
            return View();
        }

        // POST: Financeiros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FinanceiroId,AlunoID,FuncionarioId")] Financeiro financeiro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(financeiro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlunoID"] = new SelectList(_context.Aluno, "Id_Matricula", "Cpf", financeiro.AlunoID);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "FuncionarioId", financeiro.FuncionarioId);
            return View(financeiro);
        }

        // GET: Financeiros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financeiro = await _context.Financeiro.FindAsync(id);
            if (financeiro == null)
            {
                return NotFound();
            }
            ViewData["AlunoID"] = new SelectList(_context.Aluno, "Id_Matricula", "Cpf", financeiro.AlunoID);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "FuncionarioId", financeiro.FuncionarioId);
            return View(financeiro);
        }

        // POST: Financeiros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FinanceiroId,AlunoID,FuncionarioId")] Financeiro financeiro)
        {
            if (id != financeiro.FinanceiroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(financeiro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinanceiroExists(financeiro.FinanceiroId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlunoID"] = new SelectList(_context.Aluno, "Id_Matricula", "Cpf", financeiro.AlunoID);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "FuncionarioId", financeiro.FuncionarioId);
            return View(financeiro);
        }

        // GET: Financeiros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financeiro = await _context.Financeiro
                .Include(f => f.Aluno)
                .Include(f => f.Funcionario)
                .FirstOrDefaultAsync(m => m.FinanceiroId == id);
            if (financeiro == null)
            {
                return NotFound();
            }

            return View(financeiro);
        }

        // POST: Financeiros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var financeiro = await _context.Financeiro.FindAsync(id);
            _context.Financeiro.Remove(financeiro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinanceiroExists(int id)
        {
            return _context.Financeiro.Any(e => e.FinanceiroId == id);
        }
    }
}
