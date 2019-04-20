using Puc.CartaoDeCredito.Entidades;
using Puc.CartaoDeCredito.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Puc.CartaoDeCredito.Controllers
{
    public class PagamentosController : ApiController
    {
        PagamentoBll _pagamentosBll = new PagamentoBll();

        public IEnumerable<PagamentoOutput> Get()
        {
            //Método criado apenas para efeitos de testes. Estes dados não seriam expostos em uma aplicação real.
            return _pagamentosBll.ListarPagamentos();
        }

        public PagamentoOutput Post([FromBody]PagamentoInput dadosPagamento)
        {
            return _pagamentosBll.EfetuarPagamento(dadosPagamento);
        }
    }
}
