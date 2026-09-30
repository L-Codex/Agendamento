using Agendamento.Models;
using Agendamento.Services;
using Microsoft.AspNetCore.Mvc;

namespace Agendamento.Controllers
{
    public class MedicoController : Controller
    {

        private readonly MedicoService _medicoService;

        public MedicoController(MedicoService medicicoService)
        {
            _medicoService = medicicoService;
        }


        public IActionResult Index()
        {
            var listaMedicos = _medicoService.Listar();
            return View(listaMedicos);
        }

        public IActionResult Inserir()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Inserir(Medico medico)
        {
            _medicoService.Inserir(medico);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhar(int? id)
        {
            // Verifica se um identificador foi informado na requisição.
            // Caso não tenha sido informado, retorna uma resposta 404.
            if (id == null)
            {
                return NotFound();
            }

            // Solicita ao serviço a busca do médico pelo identificador recebido.
            var obj = _medicoService.EncontrarId(id.Value);

            // Verifica se algum médico foi encontrado.
            // Caso não exista, retorna uma resposta 404.
            if (obj == null)
            {
                return NotFound();
            }

            // Envia o médico encontrado para a view Detalhar.
            return View(obj);
        }

        // Recebe o identificador do médico selecionado e apresenta
        // seus dados no formulário de edição.
        public IActionResult Editar(int? id)
        {
            // Verifica se um identificador foi informado na requisição.
            // Caso não tenha sido informado, retorna uma resposta 404.
            if (id == null)
            {
                return NotFound();
            }

            // Solicita ao serviço a busca do médico que será editado.
            var obj = _medicoService.EncontrarId(id.Value);

            // Verifica se o médico foi encontrado no banco de dados.
            // Caso não exista, retorna uma resposta 404.
            if (obj == null)
            {
                return NotFound();
            }

            // Envia o médico encontrado para a view Editar,
            // permitindo que o formulário seja preenchido com seus dados.
            return View(obj);
        }


        // Indica que esta ação será executada quando o formulário
        // de edição enviar os dados utilizando o método HTTP POST.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Medico medico)
        {
            // Recebe o objeto Medico preenchido com os dados enviados
            // pelo formulário e solicita sua atualização ao serviço.
            _medicoService.Atualizar(medico);

            // Redireciona o usuário para a ação Index(), carregando
            // novamente a listagem após a atualização.
            return RedirectToAction(nameof(Index));
        }

        // Recebe o identificador do médico selecionado e apresenta
        // seus dados na página de confirmação da remoção.
        public IActionResult Remover(int? id)
        {
            // Verifica se um identificador foi informado na requisição.
            // Caso não tenha sido informado, retorna uma resposta 404.
            if (id == null)
            {
                return NotFound();
            }

            // Solicita ao serviço a busca do médico que será removido.
            var obj = _medicoService.EncontrarId(id.Value);

            // Verifica se o médico foi encontrado no banco de dados.
            // Caso não exista, retorna uma resposta 404.
            if (obj == null)
            {
                return NotFound();
            }

            // Envia o médico encontrado para a view Remover,
            // permitindo que o usuário confira os dados antes da exclusão.
            return View(obj);
        }


        // Indica que esta ação será executada quando o formulário
        // de confirmação enviar os dados utilizando o método HTTP POST.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remover(int id)
        {
            // Recebe o identificador enviado pelo formulário e solicita
            // ao serviço a remoção do médico correspondente.
            _medicoService.Remover(id);

            // Redireciona o usuário para a ação Index(), carregando
            // novamente a listagem após a remoção.
            return RedirectToAction(nameof(Index));
        }

    }
}
