using System.Collections.Generic;

namespace WebApplicationAPI.Models.ServicoEmpresa
{
    public class ServicoEmpresaRepositorio : IRepositorio<ServicoEmpresa>
    {

        public void Delete(ServicoEmpresa item)
        {
            ServicoEmpresaDAL.DeleteServicoEmpresa(item.IdServicoEmpresa);
        }

        public IEnumerable<ServicoEmpresa> GetAll()
        {
            return ServicoEmpresaDAL.GetServicoEmpresas();
        }

        public ServicoEmpresa GetById(int id)
        {
            return ServicoEmpresaDAL.GetServicoEmpresa(id);
        }

        public IEnumerable<ServicoEmpresa> GetAllServ(int id)
        {
            return ServicoEmpresaDAL.GetServicosEmpresas(id);
        }

        public void Insert(ServicoEmpresa item)
        {
            ServicoEmpresaDAL.InsertServicoEmpresa(item);
        }

        public void Update(ServicoEmpresa item)
        {
            ServicoEmpresaDAL.UpdateServicoEmpresa(item);
        }
    }
}