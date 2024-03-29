﻿using System.Collections.Generic;
using System.Web.Http;
using WebApplicationAPI.Models.SubEspecie;

namespace WebApplicationAPI.Controllers
{
    public class SubEspeciesController : ApiController
    {
        // GET: Usuarios
        private readonly SubEspecieRepositorio _subespeciesRepositorio;

        public SubEspeciesController()
        {
            _subespeciesRepositorio = new SubEspecieRepositorio();
        }

        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<SubEspecie> List()
        {
            return _subespeciesRepositorio.GetAll();
        }

        // GET: api/Clientes/5
        public SubEspecie GetSubEspecie(int id)
        {
            var SubEspecie = _subespeciesRepositorio.GetById(id);


            return SubEspecie;
        }
        [Route("api/SubEsp/Especie/{id}")]
        [HttpGet]
        public IEnumerable<SubEspecie> ListE(int id)
        {
            return _subespeciesRepositorio.GetByIdEspecies(id);
        }

        // POST: api/Clientes   
        [HttpPost()]
        public void Post([FromBody]SubEspecie subespecie)
        {
            _subespeciesRepositorio.Insert(subespecie);
        }

        // PUT: api/Clientes/5
        [HttpPut()]
        public void Put([FromBody]SubEspecie subespecie)
        {
            _subespeciesRepositorio.Update(subespecie);
        }

        // DELETE: api/Clientes/5
        [HttpDelete()]
        public void Delete(int id)
        {
            SubEspecie s = new SubEspecie();
            s.IdSubEspecie = id;
            _subespeciesRepositorio.Delete(s);
        }

    }

}