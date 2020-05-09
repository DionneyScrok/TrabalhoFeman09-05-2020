using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PROJETO_FUP_Brasil.Data;
using Remake_FUP.Models;

namespace PROJETO_FUP_Brasil.Controllers
{
    public class TelefonesController : Controller
    {
        private readonly PROJETO_FUP_BrasilContext _context;

        public TelefonesController(PROJETO_FUP_BrasilContext context)
        {
            _context = context;
        }

        // GET: Telefones
        public async Task<IActionResult> Index()
        {
            var pROJETO_FUP_BrasilContext = _context.Telefone.Include(t => t.Aluno).Include(t => t.Funcionario);
            return View(await pROJETO_FUP_BrasilContext.ToListAsync());
        }

        // GET: Telefones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefone = await _context.Telefone
                .Include(t => t.Aluno)
                .Include(t => t.Funcionario)
                .FirstOrDefaultAsync(m => m.Id_Telefone == id);
            if (telefone == null)
            {
                return NotFound();
            }

            return View(telefone);
        }

        // GET: Telefones/Create
        public IActionResult Create()
        {
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id_Matricula", "Cpf");
            ViewData["AlunoId"] = new SelectList(_context.Funcionario, "FuncionarioId", "FuncionarioId");
            return View();
        }

        // POST: Telefones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Telefone,_Telefone,AlunoId,FuncionarioID")] Telefone telefone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telefone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id_Matricula", "Cpf", telefone.AlunoId);
            ViewData["AlunoId"] = new SelectList(_context.Funcionario, "FuncionarioId", "FuncionarioId", telefone.AlunoId);
            return View(telefone);
        }

        // GET: Telefones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefone = await _context.Telefone.FindAsync(id);
            if (telefone == null)
            {
                return NotFound();
            }
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id_Matricula", "Cpf", telefone.AlunoId);
            ViewData["AlunoId"] = new SelectList(_context.Funcionario, "FuncionarioId", "FuncionarioId", telefone.AlunoId);
            return View(telefone);
        }

        // POST: Telefones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Telefone,_Telefone,AlunoId,FuncionarioID")] Telefone telefone)
        {
            if (id != telefone.Id_Telefone)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefoneExists(telefone.Id_Telefone))
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
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id_Matricula", "Cpf", telefone.AlunoId);
            ViewData["AlunoId"] = new SelectList(_context.Funcionario, "FuncionarioId", "FuncionarioId", telefone.AlunoId);
            return View(telefone);
        }

        // GET: Telefones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefone = await _context.Telefone
                .Include(t => t.Aluno)
                .Include(t => t.Funcionario)
                .FirstOrDefaultAsync(m => m.Id_Telefone == id);
            if (telefone == null)
            {
                return NotFound();
            }

            return View(telefone);
        }

        // POST: Telefones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telefone = await _context.Telefone.FindAsync(id);
            _context.Telefone.Remove(telefone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefoneExists(int id)
        {
            return _context.Telefone.Any(e => e.Id_Telefone == id);
        }
    }
}
