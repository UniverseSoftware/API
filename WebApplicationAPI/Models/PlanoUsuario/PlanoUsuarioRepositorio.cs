using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationAPI.Models.PlanoUsuario
{
    public class PlanoUsuarioRepositorio : IRepositorio<PlanoUsuario>
    {

        public void Delete(PlanoUsuario item)
        {
            PlanoUsuarioDAL.DeletePlanoUsuario(item.IdPlano);
        }

        public IEnumerable<PlanoUsuario> GetAll()
        {
            return PlanoUsuarioDAL.GetPlanoUsuarios();
        }

        public PlanoUsuario GetById(int id)
        {
            return PlanoUsuarioDAL.GetPlanoUsuario(id);
        }

        public void Insert(PlanoUsuario item)
        {
            PlanoUsuarioDAL.InsertPlanoUsuario(item);
        }

        public void Update(PlanoUsuario item)
        {
            PlanoUsuarioDAL.UpdatePlanoUsuario(item);
        }
    }
}