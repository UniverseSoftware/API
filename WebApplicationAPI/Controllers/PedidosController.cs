using System.Collections.Generic;
using System.Web.Http;
using WebApplicationAPI.Models.Pedido;

namespace WebApplicationAPI.Controllers
{
    public class PedidosController : ApiController
    {
        // GET: Usuarios
        private readonly PedidoRepositorio _pedidosRepositorio;

        public PedidosController()
        {
            _pedidosRepositorio = new PedidoRepositorio();
        }

        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<Pedido> List()
        {
            return _pedidosRepositorio.GetAll();
        }

        // GET: api/Clientes/5
        public Pedido GetPedido(int id)
        {
            var Pedido = _pedidosRepositorio.GetById(id);


            return Pedido;
        }

        // POST: api/Clientes   
        [HttpPost()]
        public void Post([FromBody]Pedido pedido)
        {
            _pedidosRepositorio.Insert(pedido);
        }

        // PUT: api/Clientes/5
        [HttpPut()]
        public void Put([FromBody]Pedido pedido)
        {
            _pedidosRepositorio.Update(pedido);
        }

        // DELETE: api/Clientes/5
        [HttpDelete()]
        public void Delete(int id)
        {
            Pedido p = new Pedido();
            p.IdPedido = id;
            _pedidosRepositorio.Delete(p);
        }

    }

}