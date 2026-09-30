using Agendamento.Data;
using Agendamento.Models;

namespace Agendamento.Services
{
    public class PacienteService
    {
        private readonly AppDbContext _context;

        public PacienteService(AppDbContext context)
        {
            _context = context;
        }

        // Lista todos os pacientes.
        public List<Paciente> Listar()
        {
            return _context.Paciente.ToList();
        }

        // Insere um paciente no banco de dados.
        public void Inserir(Paciente paciente)
        {
            _context.Paciente.Add(paciente);
            _context.SaveChanges();
        }

        // Busca pela chave primária ou retorna null se não encontrar.
        public Paciente? EncontrarId(int id)
        {
            return _context.Paciente.Find(id);
        }

        // Atualiza os dados de um paciente.
        public void Atualizar(Paciente obj)
        {
            _context.Paciente.Update(obj);
            _context.SaveChanges();
        }

        // Remove um paciente pelo identificador.
        public void Remover(int id)
        {
            var obj = _context.Paciente.Find(id);

            if (obj == null)
            {
                return;
            }

            _context.Paciente.Remove(obj);
            _context.SaveChanges();
        }
    }
}