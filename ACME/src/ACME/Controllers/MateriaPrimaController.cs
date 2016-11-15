using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ACME.Models;
using ACME.Repositories;
using ACME.ViewModel.MateriaPrima;

namespace ACME.Controllers
{
    public class MateriaPrimaController : Controller
    {
        private readonly AcmeContext _context;

        public MateriaPrimaController(AcmeContext context)
        {
            _context = context;    
        }

        // GET: MateriaPrimas
        public async Task<IActionResult> Index()
        {
            var materiasPrimas = await _context.MateriasPrimas
                .OrderBy(x => x.Nome)
                .Select(x => new MateriaPrimaListaViewModel
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    EstoqueAtual = x.EstoqueAtual,
                    EstoqueEstaAbaixoDoMinimo = x.EstoqueAtual <= x.EstoqueMinimo
                })
                .ToListAsync();

            return View(materiasPrimas);
        }

        // GET: MateriaPrimas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaPrima = await _context.MateriasPrimas.SingleOrDefaultAsync(m => m.Id == id);
            if (materiaPrima == null)
            {
                return NotFound();
            }

            return View(materiaPrima);
        }

        // GET: MateriaPrimas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MateriaPrimas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EstoqueAtual,EstoqueMinimo,Nome")] MateriaPrima materiaPrima)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materiaPrima);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(materiaPrima);
        }

        // GET: MateriaPrimas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaPrima = await _context.MateriasPrimas.SingleOrDefaultAsync(m => m.Id == id);
            if (materiaPrima == null)
            {
                return NotFound();
            }
            return View(materiaPrima);
        }

        // POST: MateriaPrimas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EstoqueAtual,EstoqueMinimo,Nome")] MateriaPrima materiaPrima)
        {
            if (id != materiaPrima.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materiaPrima);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriaPrimaExists(materiaPrima.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(materiaPrima);
        }

        // GET: MateriaPrimas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaPrima = await _context.MateriasPrimas.SingleOrDefaultAsync(m => m.Id == id);
            if (materiaPrima == null)
            {
                return NotFound();
            }

            return View(materiaPrima);
        }

        // POST: MateriaPrimas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materiaPrima = await _context.MateriasPrimas.SingleOrDefaultAsync(m => m.Id == id);
            _context.MateriasPrimas.Remove(materiaPrima);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MateriaPrimaExists(int id)
        {
            return _context.MateriasPrimas.Any(e => e.Id == id);
        }
    }
}
