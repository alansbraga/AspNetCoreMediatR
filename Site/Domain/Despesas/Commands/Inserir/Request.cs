using MediatR;

namespace Site.Domain.Despesas.Commands.Inserir
{
    public class Request : Validatable, IRequest<Result>
    {
        public string IdFuncionario { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(IdFuncionario))
                AddNotification("IdFuncionario", "Funcionário inválido");

            if (Valor <= 0)
                AddNotification("Valor", "Valor inválido");

            if (string.IsNullOrEmpty(Descricao))
                AddNotification("Descricao", "Descrição é obrigatória");
        }
    }
}
