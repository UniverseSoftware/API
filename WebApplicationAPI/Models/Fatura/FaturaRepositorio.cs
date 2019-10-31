using System.Collections.Generic;


namespace WebApplicationAPI.Models.Fatura
{
    public class FaturaRepositorio : IRepositorio<Fatura>
    {

        public void Delete(Fatura item)
        {
            FaturaDAL.DeleteFatura(item.IdFatura);
        }

        public IEnumerable<Fatura> GetAll()
        {
            return FaturaDAL.GetFaturas();
        }

        public Fatura GetById(int id)
        {
            return FaturaDAL.GetFatura(id);
        }

        public void Insert(Fatura item)
        {
            FaturaDAL.InsertFatura(item);
        }

        public void Update(Fatura item)
        {
            FaturaDAL.UpdateFatura(item);
        }

    }
}