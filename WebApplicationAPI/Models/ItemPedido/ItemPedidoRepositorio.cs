using System.Collections.Generic;

namespace WebApplicationAPI.Models.ItemPedido
{
    public class ItemPedidoRepositorio : IRepositorio<ItemPedido>
    {

        public void Delete(ItemPedido item)
        {
            ItemPedidoDAL.DeleteItemPedido(item.IdItemPedido);
        }

        public IEnumerable<ItemPedido> GetAll()
        {
            return ItemPedidoDAL.GetItemPedidos();
        }

        public ItemPedido GetById(int id)
        {
            return ItemPedidoDAL.GetItemPedido(id);
        }

        public void Insert(ItemPedido item)
        {
            ItemPedidoDAL.InsertItemPedido(item);
        }

        public void Update(ItemPedido item)
        {
            ItemPedidoDAL.UpdateItemPedido(item);
        }

    }
}