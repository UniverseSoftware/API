using System.Collections.Generic;
using System.Web.Http;
using WebApplicationAPI.Models.ServicoEmpresa;

namespace WebApplicationAPI.Controllers
{
    public class ServicosController : ApiController
    {
        // GET: Usuarios
        private readonly ServicoRepositorio _servicosRepositorio;

        public ServicosController()
        {
            _servicosRepositorio = new ServicoRepositorio();
        }

        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<Servico> List()
        {
            return _servicosRepositorio.GetAll();
        }

        // GET: api/Clientes/5
        public Servico GetServico(int id)
        {
            var Servico = _servicosRepositorio.GetById(id);


            return Servico;
        }

        // POST: api/Clientes   
        [HttpPost()]
        public void Post([FromBody]Servico servico)
        {
            _servicosRepositorio.Insert(servico);
        }

        // PUT: api/Clientes/5
        [HttpPut()]
        public void Put([FromBody]Servico servico)
        {
            _servicosRepositorio.Update(servico);
        }

        // DELETE: api/Clientes/5
        [HttpDelete()]
        public void Delete(int id)
        {
            Servico s = new Servico();
            s.IdServico = id;
            _servicosRepositorio.Delete(s);
        }
    }
}