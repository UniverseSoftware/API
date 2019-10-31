using System.Collections.Generic;
using System.Web.Http;
using WebApplicationAPI.Models.ItemPedido;

namespace WebApplicationAPI.Controllers
{
    public class ItemPedidosController : ApiController
    {
        // GET: Usuarios
        private readonly ItemPedidoRepositorio _ItempedidosRepositorio;

        public ItemPedidosController()
        {
            _ItempedidosRepositorio = new ItemPedidoRepositorio();
        }

        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<ItemPedido> List()
        {
            return _ItempedidosRepositorio.GetAll();
        }

        // GET: api/Clientes/5
        public ItemPedido GetItemPedido(int id)
        {
            var ItemPedido = _ItempedidosRepositorio.GetById(id);


            return ItemPedido;
        }

        // POST: api/Clientes   
        [HttpPost()]
        public void Post([FromBody]ItemPedido itempedido)
        {
            _ItempedidosRepositorio.Insert(itempedido);
        }

        // PUT: api/Clientes/5
        [HttpPut()]
        public void Put([FromBody]ItemPedido itempedido)
        {
            _ItempedidosRepositorio.Update(itempedido);
        }

        // DELETE: api/Clientes/5
        [HttpDelete()]
        public void Delete(int id)
        {
            ItemPedido ip = new ItemPedido();
            ip.IdItemPedido = id;
            _ItempedidosRepositorio.Delete(ip);
        }

    }

}