using Agendamento.Models;

namespace Agendamento.Data
{
    public class SeedingService
    {
        private readonly AppDbContext _context;

        public SeedingService(AppDbContext context)
        {
            _context = context;
        }

        public void Popula()
        {
            if (_context.Medicos.Any())
            {
                return;
            }
            else
            {
                Medico m1 = new Medico
                {
                    Nome = "Luiza",
                    Crm = "123456",
                    Especialidade = "Vascular"
                };

                Medico m2 = new Medico
                {
                    Nome = "João",
                    Crm = "654321",
                    Especialidade = "Ortopedista"
                };

                _context.Medicos.AddRange(m1, m2);
                _context.SaveChanges();


            }
        }

        public void PopulaPacientes()
        {
            if (_context.Paciente.Any())
            {
                return;
            }

            Paciente p1 = new Paciente
            {
                Nome = "Clara Silva",
                CPF = "11111111111",
                Telefone = "11999998888",
                Endereco = "Rua das Luzes, 123",
                DataNascimento = new DateOnly(1999, 11, 11)
            };

            Paciente p2 = new Paciente
            {
                Nome = "Lucas Oliveira",
                CPF = "11123456789",
                Telefone = "14999998888",
                Endereco = "Avenida Retro, 500",
                DataNascimento = new DateOnly(1999, 12, 12)
            };

            _context.Paciente.AddRange(p1, p2);
            _context.SaveChanges();
        }


    }
}
