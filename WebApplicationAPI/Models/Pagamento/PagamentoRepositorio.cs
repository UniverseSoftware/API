using System.Collections.Generic;

namespace WebApplicationAPI.Models.Pagamento
{
    public class PagamentoRepositorio : IRepositorio<Pagamento>
    {

        public void Delete(Pagamento item)
        {
            PagamentoDAL.DeletePagamento(item.IdPagamento);
        }

        public IEnumerable<Pagamento> GetAll()
        {
            return PagamentoDAL.GetPagamentos();
        }

        public Pagamento GetById(int id)
        {
            return PagamentoDAL.GetPagamento(id);
        }

        public void Insert(Pagamento item)
        {
            PagamentoDAL.InsertPagamento(item);
        }

        public void Update(Pagamento item)
        {
            PagamentoDAL.UpdatePagamento(item);
        }
    }
}