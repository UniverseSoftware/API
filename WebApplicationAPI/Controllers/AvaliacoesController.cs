using System.Collections.Generic;
using System.Web.Http;
using WebApplicationAPI.Models.Avaliacao;

namespace WebApplicationAPI.Controllers
{
    public class AvaliacoesController : ApiController
    {
        // GET: Usuarios
        private readonly AvaliacaoRepositorio _avaliacoesRepositorio;

        public AvaliacoesController()
        {
            _avaliacoesRepositorio = new AvaliacaoRepositorio();
        }

        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<Avaliacao> List()
        {
            return _avaliacoesRepositorio.GetAll();
        }

        // GET: api/Clientes/5
        public Avaliacao GetAvaliacao(int id)
        {
            var Avaliacao = _avaliacoesRepositorio.GetById(id);


            return Avaliacao;
        }

        // POST: api/Clientes   
        [HttpPost()]
        public void Post([FromBody]Avaliacao avaliacao)
        {
            _avaliacoesRepositorio.Insert(avaliacao);
        }

        // PUT: api/Clientes/5
        [HttpPut()]
        public void Put([FromBody]Avaliacao avaliacao)
        {
            _avaliacoesRepositorio.Update(avaliacao);
        }

        // DELETE: api/Clientes/5
        [HttpDelete()]
        public void Delete(int id)
        {
            Avaliacao a = new Avaliacao();
            a.IdAvaliacao = id;
            _avaliacoesRepositorio.Delete(a);
        }

    }

}