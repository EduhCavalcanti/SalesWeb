using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesWeb.Data;
using SalesWeb.Models;
using SalesWeb.Models.ViewModels;
using SalesWeb.Services;
using SalesWeb.Services.Exception;

namespace SalesWeb.Controllers
{
    public class SellersController : Controller
    {
       
        //Dependencia para acessar o SellerService 
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        //Criado construtor para injetar as dependências 
        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        //Método Index que vai chamar a operação FindAll da pasta Services
        public IActionResult Index()
        {
            //Vai retornar uma lista de Seller
            var lista = _sellerService.FindAll();
            return View(lista);//Vai retornar o resultado da lista pela view no Html
        }
        
        //Método que vai abri o formulário pra cadastrar o vendedor
        public IActionResult Create() {
            //Vai buscar do banco de dados todos os departamentos
            var departaments = _departmentService.FindAll();
            //Vai instanciar o obj do viewModel
            var viewModel = new SellerFormViewModel { Departments = departaments };//Já vai iniciar com a lista de departamentos    
            return View(viewModel);//Vai receber a viewModel
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

        //Método de confirmação do Delete no front
        public IActionResult Delete(int? id)//Vai receber um parâmetro opcional 
        {
            //Primeiro vai verificar se o id é null
            if(id == null)
            {
                return NotFound();
            }
            //Vai buscar o seller no bannco de dados de acordo com id que foi fornecido
            var obj = _sellerService.FindById(id.Value);//Tem que colocar o "Value" pq ele é um nullable

            //Pode retornar null, se for null
            if(obj == null)
            {
                return NotFound();
            }
            //Se não for null vai passar um view passando o obj como argumeto
            return View(obj);
        }

        //Método para delete do seller de fato
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        //Método para mostrar os detalhes do seller 
        public IActionResult Details(int? id)
        {
            //Vai verificar se od é null
            if(id == null)
            {
                return NotFound();
            }
            //Vai buscar o seller no banco de dados de acordo com id passado
            var obj = _sellerService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }
            //Vai retonar uma página com os detalhes do seller
            return View(obj);
        }
        //Método para interação do usuário para tela de edição
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Vai buscar o vendedor pelo id passado
            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            //Vai carregar a lista de departamento para aparecer na tela 
            List<Department> departments = _departmentService.FindAll();
            //Vai criar um objeto de tipo SellerViewModel > formulário com os dados do seller e departamento
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };
            //Vai retonar a view passando o viewModel
            return View(viewModel);
        }
        //Método de edição do seller 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id ,Seller seller)
        {
            //Vai verificar se o id que foi passado pela url da requisição vai ser o mesmo id do Seller
            if(id != seller.Id)
            {
                return BadRequest();
            }
            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {

                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }

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
