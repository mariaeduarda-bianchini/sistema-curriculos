using Microsoft.AspNetCore.Mvc;
using SistemaCurriculoMVC.DAO;
using SistemaCurriculoMVC.Models;
using System;
using System.Collections.Generic;

namespace SistemaCurriculoMVC.Controllers
{
    public class CurriculoController : Controller
    {
        public IActionResult Index()
        {
            CurriculoDAO dao = new CurriculoDAO();
            List<CurriculoViewModel> lista = dao.Listagem();
            return View(lista);
        }

        // Exibir formulário de cadastro
        public IActionResult Create()
        {
            CurriculoViewModel curriculo = new CurriculoViewModel();
            curriculo.DataNascimento = DateTime.Now; 
            return View("Form", curriculo);
        }

        
        [HttpPost]
        public IActionResult Salvar(CurriculoViewModel curriculo)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", curriculo); 
            }

            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                dao.Inserir(curriculo);
                return RedirectToAction("Index"); 
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Erro ao salvar no banco: " + ex.Message);
                return View("Create", curriculo);
            }
        }

        public IActionResult Details(int id)
        {
            CurriculoDAO dao = new CurriculoDAO();
            CurriculoViewModel curriculo = dao.Consulta(id);

            if (curriculo == null)
            {
                return NotFound(); 
            }

            return View(curriculo);
        }

    }
}
