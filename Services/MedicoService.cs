using Agendamento.Data;
using Agendamento.Models;

namespace Agendamento.Services
{
    public class MedicoService
    {
        private readonly AppDbContext _context;

        public MedicoService (AppDbContext context)
        {
            _context = context;
        }

        public List<Medico> Listar()
        {
            return _context.Medicos.ToList();
        }

        public void Inserir(Medico medico)
        {
            _context.Medicos.Add(medico);
            _context.SaveChanges();
        }

        public Medico? EncontrarId(int id)
        {
            // O método Find() procura um registro pela chave primária.
            // Retorna o médico encontrado ou null caso ele não exista.
            return _context.Medicos.Find(id);
        }

        // Atualiza os dados de um médico no banco de dados.
        // O parâmetro obj representa o médico recebido pela controller.
        public void Atualizar(Medico obj)
        {
            // Marca o objeto como modificado no contexto.
            // A alteração ainda não foi gravada definitivamente no banco.
            _context.Medicos.Update(obj);

            // Confirma as alterações pendentes.
            // O Entity Framework Core gera e executa o comando UPDATE.
            _context.SaveChanges();
        }

        // Remove um médico do banco de dados.
        // O parâmetro id representa o identificador do médico que será removido.
        public void Remover(int id)
        {
            // Procura o médico no banco de dados utilizando sua chave primária.
            var obj = _context.Medicos.Find(id);

            // Verifica se foi encontrado um médico com o identificador informado.
            // Caso não exista, encerra o método sem realizar nenhuma operação.
            if (obj == null)
            {
                return;
            }

            // Marca o médico encontrado para remoção.
            // A alteração ainda não foi gravada definitivamente no banco.
            _context.Medicos.Remove(obj);

            // Confirma as alterações pendentes.
            // O Entity Framework Core gera e executa o comando DELETE.
            _context.SaveChanges();
        }

    }
}
