using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puc.CartaoDeCredito.Entidades
{
    public class PagamentoOutput
    {
        public int Id { get; set; }
        public StatusPagamento Status { get; set; }
        public string Mensagem { get; set; }
    }

    public enum StatusPagamento
    {
        Autorizado,
        Reprovado,
        Erro,
    }
}
