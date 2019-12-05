using System.Collections.Generic;

namespace WebApplicationAPI.Models.Pedido
{
    public class PedidoRepositorio : IRepositorio<Pedido>
    {

        public void Delete(Pedido item)
        {
            PedidoDAL.DeletePedido(item.IdPedido);
        }

        public IEnumerable<Pedido> GetAll()
        {
            return PedidoDAL.GetPedidos();
        }

        public Pedido GetById(int id)
        {
            return PedidoDAL.GetPedido(id);
        }

        public void Insert(Pedido item)
        {
            PedidoDAL.InsertPedido(item);
        }

        public void Update(Pedido item)
        {
            PedidoDAL.UpdatePedido(item);
        }

        public IEnumerable<Pedido> GetAllP(int id)
        {
            return PedidoDAL.GetPedidosPessoa(id);
        }

    }
}