﻿using System.Collections.Generic;

namespace WebApplicationAPI.Models.Plano
{
    public class PlanoRepositorio : IRepositorio<Plano>
    {

        public void Delete(Plano item)
        {
            PlanoDAL.DeletePlano(item.IdPlano);
        }

        public IEnumerable<Plano> GetAll()
        {
            return PlanoDAL.GetPlanos();
        }

        public Plano GetById(int id)
        {
            return PlanoDAL.GetPlano(id);
        }

        public void Insert(Plano item)
        {
            PlanoDAL.InsertPlano(item);
        }

        public void Update(Plano item)
        {
            PlanoDAL.UpdatePlano(item);
        }
    }
}