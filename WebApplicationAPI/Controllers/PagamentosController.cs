using System.Collections.Generic;
using System.Web.Http;
using WebApplicationAPI.Models.Pagamento;

namespace WebApplicationAPI.Controllers
{
    public class PagamentosController : ApiController
    {
        // GET: Usuarios
        private readonly PagamentoRepositorio _pagamentosRepositorio;

        public PagamentosController()
        {
            _pagamentosRepositorio = new PagamentoRepositorio();
        }

        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<Pagamento> List()
        {
            return _pagamentosRepositorio.GetAll();
        }

        // GET: api/Clientes/5
        public Pagamento GetPagamento(int id)
        {
            var Pagamento = _pagamentosRepositorio.GetById(id);


            return Pagamento;
        }

        // POST: api/Clientes   
        [HttpPost()]
        public void Post([FromBody]Pagamento pagamento)
        {
            _pagamentosRepositorio.Insert(pagamento);
        }

        // PUT: api/Clientes/5
        [HttpPut()]
        public void Put([FromBody]Pagamento pagamento)
        {
            _pagamentosRepositorio.Update(pagamento);
        }

        // DELETE: api/Clientes/5
        [HttpDelete()]
        public void Delete(int id)
        {
            Pagamento p = new Pagamento();
            p.IdPagamento = id;
            _pagamentosRepositorio.Delete(p);
        }

    }

}