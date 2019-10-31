using System.Collections.Generic;
using System.Web.Http;
using WebApplicationAPI.Models.Fatura;

namespace WebApplicationAPI.Controllers
{
    public class FaturasController : ApiController
    {
        // GET: Usuarios
        private readonly FaturaRepositorio _faturaRepositorio;

        public FaturasController()
        {
            _faturaRepositorio = new FaturaRepositorio();
        }

        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<Fatura> List()
        {
            return _faturaRepositorio.GetAll();
        }

        // GET: api/Clientes/5
        public Fatura GetFatura(int id)
        {
            var Fatura = _faturaRepositorio.GetById(id);


            return Fatura;
        }

        // POST: api/Clientes   
        [HttpPost()]
        public void Post([FromBody]Fatura fatura)
        {
            _faturaRepositorio.Insert(fatura);
        }

        // PUT: api/Clientes/5
        [HttpPut()]
        public void Put([FromBody]Fatura fatura)
        {
            _faturaRepositorio.Update(fatura);
        }

        // DELETE: api/Clientes/5
        [HttpDelete()]
        public void Delete(int id)
        {
            Fatura f = new Fatura();
            f.IdFatura = id;
            _faturaRepositorio.Delete(f);
        }

    }

}