using System.Collections.Generic;
using System.Web.Http;
using WebApplicationAPI.Models.Plano;

namespace WebApplicationAPI.Controllers
{
    public class PlanosController : ApiController
    {
        // GET: Usuarios
        private readonly PlanoRepositorio _planosRepositorio;

        public PlanosController()
        {
            _planosRepositorio = new PlanoRepositorio();
        }

        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<Plano> List()
        {
            return _planosRepositorio.GetAll();
        }

        // GET: api/Clientes/5
        public Plano GetPlano(int id)
        {
            var Plano = _planosRepositorio.GetById(id);


            return Plano;
        }

        // POST: api/Clientes   
        [HttpPost()]
        public void Post([FromBody]Plano plano)
        {
            _planosRepositorio.Insert(plano);
        }

        // PUT: api/Clientes/5
        [HttpPut()]
        public void Put([FromBody]Plano plano)
        {
            _planosRepositorio.Update(plano);
        }

        // DELETE: api/Clientes/5
        [HttpDelete()]
        public void Delete(int id)
        {
            Plano p = new Plano();
            p.IdPlano = id;
            _planosRepositorio.Delete(p);
        }

    }

}