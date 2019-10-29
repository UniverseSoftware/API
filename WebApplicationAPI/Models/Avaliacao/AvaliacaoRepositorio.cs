using System.Collections.Generic;

namespace WebApplicationAPI.Models.Avaliacao
{
    public class AvaliacaoRepositorio : IRepositorio<Avaliacao>
    {

        public void Delete(Avaliacao item)
        {
            AvaliacaoDAL.DeleteAvaliacao(item.IdAvaliacao);
        }

        public IEnumerable<Avaliacao> GetAll()
        {
            return AvaliacaoDAL.GetAvaliacoes();
        }

        public Avaliacao GetById(int id)
        {
            return AvaliacaoDAL.GetAvaliacao(id);
        }

        public void Insert(Avaliacao item)
        {
            AvaliacaoDAL.InsertAvaliacao(item);
        }

        public void Update(Avaliacao item)
        {
            AvaliacaoDAL.UpdateAvaliacao(item);
        }

    }
}