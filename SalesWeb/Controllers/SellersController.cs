using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesWeb.Data;
using SalesWeb.Models;
using SalesWeb.Services;

namespace SalesWeb.Controllers
{
    public class SellersController : Controller
    {
        //Criado atributo para utilizar a dependencia Context com baco de dados 
        private readonly SalesWebContext _context;

        //Dependencia para acessar o SellerService 
        private SellerService _sellerService;

        //Criado construtor para injetar as dependências 
        public SellersController(SalesWebContext context, SellerService sellerService)
        {
            _context = context;
            _sellerService = sellerService;
        }

        //Método Index que vai chamar a operação FindAll da pasta Services
        public IActionResult Index()
        {
            //Vai retornar uma lista de Seller
            var lista = _sellerService.FindAll();
            return View(lista);//Vai retornar o resultado da lista pela view no Html
        }
        
        public IActionResult Create() {
            return View();
        }

        [HttpPost]//Método POST para criar 
        [ValidateAntiForgeryToken]//Evita de ter ataques DDOs
        //Método create, vai criar um vendedor 
        public IActionResult Create(Seller seller) 
        {
            //Usou o método criado no serviceSaller para inserir um vendedor novo no banco
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index)); //Vai redirecionar para a página Index quando for criado
        }

        //Método TESTE de remoção de vendedor
        [HttpDelete]//Método Delete para remoção
        public IActionResult Delete(Seller seller)
        {
            _sellerService.Remove(seller);
            return RedirectToAction(nameof(Index));
        }







    }

    /*CONTROLLER GERADO AUTOMATICAMENTE PELO VISUAL STUDIO POR MEIO DO MVC
     * IREI FAZER O CONTROLLER MANUAL CONFORME FOI PEDIDO NA AULA 
     * 
     * 
     * 
    // GET: Sellers
    public async Task<IActionResult> Index()
    {
        return View(await _context.Seller.ToListAsync());
    }

    // GET: Sellers/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var seller = await _context.Seller
            .FirstOrDefaultAsync(m => m.Id == id);
        if (seller == null)
        {
            return NotFound();
        }

        return View(seller);
    }

    // GET: Sellers/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Sellers/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Email,BirthDate,BaseSalary")] Seller seller)
    {
        if (ModelState.IsValid)
        {
            _context.Add(seller);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(seller);
    }

    // GET: Sellers/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var seller = await _context.Seller.FindAsync(id);
        if (seller == null)
        {
            return NotFound();
        }
        return View(seller);
    }

    // POST: Sellers/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,BirthDate,BaseSalary")] Seller seller)
    {
        if (id != seller.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellerExists(seller.Id))
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
        return View(seller);
    }

    // GET: Sellers/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var seller = await _context.Seller
            .FirstOrDefaultAsync(m => m.Id == id);
        if (seller == null)
        {
            return NotFound();
        }

        return View(seller);
    }

    // POST: Sellers/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var seller = await _context.Seller.FindAsync(id);
        _context.Seller.Remove(seller);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool SellerExists(int id)
    {
        return _context.Seller.Any(e => e.Id == id);
    }
    */

}
