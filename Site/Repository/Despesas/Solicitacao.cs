using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Site.Domain.Despesas.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Site.Repository.Despesas
{
    public class Solicitacao : RepositoryBase<Domain.Despesas.Solicitacao>, ISolicitacaoWrite, ISolicitacaoRead
    {
        public Solicitacao(IConfiguration configuration)
            : base(configuration) { }

        public async Task Atualizar(Guid id, decimal valor, string descricao, CancellationToken cancellationToken)
        {
            var update = Builders<Domain.Despesas.Solicitacao>
                                .Update
                                .Set(s => s.Valor, valor)
                                .Set(s=> s.Descricao, descricao);

            await Collection.UpdateOneAsync(o => o.Id == id, update, cancellationToken: cancellationToken);
        }

        public async Task Inserir(Domain.Despesas.Solicitacao solicitacao, CancellationToken cancellationToken)
            => await Collection.InsertOneAsync(solicitacao, cancellationToken: cancellationToken);

        public async Task<IList<Domain.Despesas.Solicitacao>> ListarPorFuncionarioId(string id, CancellationToken cancellationToken)
        {
            var filter = Builders<Domain.Despesas.Solicitacao>.Filter.Eq(s => s.Funcionario.Id, id);
            var despesas = await Collection.Find(filter).ToListAsync(cancellationToken);
            return despesas;
        }

        public async Task<IList<Domain.Despesas.Solicitacao>> ListarPorStatus(Domain.Despesas.Status status, CancellationToken cancellationToken)
        {
            var filter = Builders<Domain.Despesas.Solicitacao>.Filter.Eq(s => s.Status, status);
            var despesas = await Collection.Find(filter).ToListAsync(cancellationToken);
            return despesas;
        }

        public async Task<Domain.Despesas.Solicitacao> ObterPorId(Guid id, CancellationToken cancellationToken)
        {
            var filter = Builders<Domain.Despesas.Solicitacao>.Filter.Eq(s => s.Id, id);
            var results = await Collection.Find(filter).ToListAsync(cancellationToken);
            return results.FirstOrDefault();
        }
    }
}