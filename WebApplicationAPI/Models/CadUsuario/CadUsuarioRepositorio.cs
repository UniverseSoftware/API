﻿using System.Collections.Generic;

namespace WebApplicationAPI.Models.CadUsuario
{
    public class CadUsuarioRepositorio
    {
        /*
        public void Delete(CadUsuario item)
        {
            CadUsuarioDAL.DeleteCadUsuario(item.IdPessoa);
        }
        */
        public IEnumerable<CadUsuario> GetAll()
        {
            return CadUsuarioDAL.GetCadUsuarios();
        }

        public CadUsuario GetById(int id)
        {
            return CadUsuarioDAL.GetCadUsuario(id);
        }

        public CadUsuario GetByLogin(string userusuario)
        {
            return CadUsuarioDAL.GetLogin(userusuario);
        }

        public void Insert(CadUsuario item,int tpuser)
        {
            CadUsuarioDAL.InsertCadUsuario(item,tpuser);
        }

        public void Update(CadUsuario item,int tpuser)
        {
            CadUsuarioDAL.UpdateCadUsuario(item,tpuser);
        }

    }
}