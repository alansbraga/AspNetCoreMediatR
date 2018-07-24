using System;

namespace Site.Domain.Despesas
{
    public class Solicitacao
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DataHora { get; set; } = DateTime.Now;
        public Funcionario Funcionario { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public Status Status { get; set; }

        public Solicitacao() { }

        public Solicitacao(Funcionario funcionario, decimal valor, string descricao)
        {
            this.Funcionario = funcionario;
            this.Valor = valor;
            this.Descricao = descricao;
            this.Status = Status.EmAberto;
        }
    }
}
