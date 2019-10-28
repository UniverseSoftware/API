using System.Collections.Generic;

namespace WebApplicationAPI.Models.ServicoEmpresa
{
    public class ServicoRepositorio : IRepositorio<Servico>
    {

        public void Delete(Servico item)
        {
            ServicoDAL.DeleteServico(item.IdServico);
        }

        public IEnumerable<Servico> GetAll()
        {
            return ServicoDAL.GetServicos();
        }

        public Servico GetById(int id)
        {
            return ServicoDAL.GetServico(id);
        }

        public void Insert(Servico item)
        {
            ServicoDAL.InsertServico(item);
        }

        public void Update(Servico item)
        {
            ServicoDAL.UpdateServico(item);
        }
    }
}