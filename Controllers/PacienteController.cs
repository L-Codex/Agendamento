using Agendamento.Models;
using Agendamento.Services;
using Microsoft.AspNetCore.Mvc;

namespace Agendamento.Controllers
{
    public class PacienteController : Controller
    {
        private readonly PacienteService _pacienteService;

        public PacienteController(PacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        public IActionResult Index()
        {
            var listaPacientes = _pacienteService.Listar();
            return View(listaPacientes);
        }

        // Exibe o formulário de cadastro.
        public IActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Inserir(Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return View(paciente);
            }

            _pacienteService.Inserir(paciente);
            return RedirectToAction(nameof(Index));
        }

        // Exibe os dados do paciente.
        public IActionResult Detalhar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = _pacienteService.EncontrarId(id.Value);

            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // Exibe o formulário preenchido para edição.
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = _pacienteService.EncontrarId(id.Value);

            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return View(paciente);
            }

            _pacienteService.Atualizar(paciente);
            return RedirectToAction(nameof(Index));
        }

        // Exibe a confirmação de remoção.
        public IActionResult Remover(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = _pacienteService.EncontrarId(id.Value);

            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remover(int id)
        {
            _pacienteService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}