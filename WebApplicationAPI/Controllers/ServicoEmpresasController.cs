using System.Collections.Generic;
using System.Web.Http;
using WebApplicationAPI.Models.ServicoEmpresa;

namespace WebApplicationAPI.Controllers
{
    public class ServicoEmpresasController : ApiController
    {
        // GET: Usuarios
        private readonly ServicoEmpresaRepositorio _servicoempresasRepositorio;

        public ServicoEmpresasController()
        {
            _servicoempresasRepositorio = new ServicoEmpresaRepositorio();
        }

        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<ServicoEmpresa> List()
        {
            return _servicoempresasRepositorio.GetAll();
        }

        // GET: api/Clientes/5
        [HttpGet]
        public ServicoEmpresa GetServicoEmpresa(int id)
        {
            var ServicoEmpresa = _servicoempresasRepositorio.GetById(id);


            return ServicoEmpresa;
        }

        [HttpGet]
        [Route("api/ServicosEmpresa/{id}")]
        public IEnumerable<ServicoEmpresa> List(int id)
        {
            return _servicoempresasRepositorio.GetAllServ(id);
        }
        
        // POST: api/Clientes   
        [HttpPost()]
        public void Post([FromBody]ServicoEmpresa servicoempresa)
        {
            _servicoempresasRepositorio.Insert(servicoempresa);
        }

        // PUT: api/Clientes/5
        [HttpPut()]
        public void Put([FromBody]ServicoEmpresa servicoempresa)
        {
            _servicoempresasRepositorio.Update(servicoempresa);
        }

        // DELETE: api/Clientes/5
        [HttpDelete()]
        public void Delete(int id)
        {
            ServicoEmpresa se = new ServicoEmpresa();
            se.IdServicoEmpresa = id;
            _servicoempresasRepositorio.Delete(se);
        }
    }
}