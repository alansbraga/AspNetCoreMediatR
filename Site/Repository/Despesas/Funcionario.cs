using Site.Domain.Despesas.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Site.Repository.Despesas
{
    public class Funcionario : IFuncionarioRead
    {
        private static List<Domain.Despesas.Funcionario> FUNCIONARIOS = new List<Domain.Despesas.Funcionario>
        {
            new Domain.Despesas.Funcionario
            {
                Nome = "Angelo Belchior",
                Id = "live.com#angelobelchior@hotmail.com"
            },

            new Domain.Despesas.Funcionario
            {
                Nome = "Maria da Silva",
                Id = ""
            }
        };

        public async Task<Domain.Despesas.Funcionario> ObterPorId(string id, CancellationToken cancellation)
            => await Task.Run(() => FUNCIONARIOS.FirstOrDefault(f => f.Id == id));
    }
}
