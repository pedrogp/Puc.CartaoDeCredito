using Puc.CartaoDeCredito.Entidades;
using Puc.CartaoDeCredito.Negocio.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puc.CartaoDeCredito.Negocio
{
    public class PagamentoBll
    {
        private StatusPagamento EnviarPagamentoOperadoraCartao(PagamentoInput dadosPagamento)
        {
            //Simula a chamada aos serviços da operadora de cartão
            var random = new Random();
            var randomNumber = random.Next(1, 100);

            if (randomNumber < 30)
            {
                //Simula a reprovação do pagamento
                return StatusPagamento.Reprovado;
            }
            else if (randomNumber < 50)
            {
                //Simula erro na comunicação com a operadora
                return StatusPagamento.Erro;
            }
            else
            {
                //Simula a aprovação do pagamento
                return StatusPagamento.Autorizado;
            }
        }

        public IEnumerable<PagamentoOutput> ListarPagamentos()
        {
            return PagamentosMock.Pagamentos;
        }

        public PagamentoOutput EfetuarPagamento(PagamentoInput dadosPagamento)
        {
            //Realiza o pagamento junto à operadora de cartão
            var status = EnviarPagamentoOperadoraCartao(dadosPagamento);

            var mensagem = string.Empty;
            switch(status)
            {
                case StatusPagamento.Autorizado:
                    mensagem = "Pagamento autorizado";
                    break;
                case StatusPagamento.Reprovado:
                    mensagem = "Pagamento não autorizado";
                    break;
                case StatusPagamento.Erro:
                    mensagem = "Erro ao efetuar o pagamento";
                    break;
                default:
                    break;
            }

            var idPagamento = PagamentosMock.Pagamentos.Any() ? PagamentosMock.Pagamentos.Max(p => p.Id) + 1 : 1;

            var pagamento = new PagamentoOutput
            {
                Id = idPagamento,
                Mensagem = mensagem,
                Status = status,
            };

            PagamentosMock.Pagamentos.Add(pagamento);

            return pagamento;
        }
    }
}
