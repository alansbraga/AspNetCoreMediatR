using System;
using System.Threading;
using System.Threading.Tasks;

namespace Site.Domain.Despesas.Repository
{
    public interface IFuncionarioRead
    {
        Task<Funcionario> ObterPorId(string id, CancellationToken cancellationToken);
    }
}
