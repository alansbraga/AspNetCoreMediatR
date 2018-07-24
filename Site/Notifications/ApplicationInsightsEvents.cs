using MediatR;
using Microsoft.ApplicationInsights;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Atualizar = Site.Domain.Despesas.Commands.Atualizar;
using Inserir = Site.Domain.Despesas.Commands.Inserir;

namespace Site.Notifications
{
    public class ApplicationInsightsEvents : INotificationHandler<Inserir.Notification>,
                                             INotificationHandler<Atualizar.Notification>
    {
        private readonly TelemetryClient telemetry = new TelemetryClient();

        public async Task Handle(Inserir.Notification notification, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                telemetry.TrackEvent("Reembolso.Inserir", new Dictionary<string, string>
                {
                    ["NomeFuncionario"] = notification.NomeFuncionario,
                    ["Valor"] = notification.Valor.ToString(),
                    ["Descricao"] = notification.Descricao,
                    ["DataHora"] = notification.DataHora.ToString(),
                });
            });

        }

        public async Task Handle(Atualizar.Notification notification, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                telemetry.TrackEvent("Reembolso.Atualizar", new Dictionary<string, string>
                {
                    ["NomeFuncionario"] = notification.NomeFuncionario,
                    ["Valor"] = notification.Valor.ToString(),
                    ["ValorAntigo"] = notification.ValorAntigo.ToString(),
                    ["Descricao"] = notification.Descricao,
                    ["DescricaoAntiga"] = notification.DescricaoAntiga,
                    ["DataHora"] = notification.DataHora.ToString(),
                });
            });
        }
    }
}
