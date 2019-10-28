using System.Collections.Generic;
using System.Web.Http;
using WebApplicationAPI.Models.PlanoUsuario;

namespace WebApplicationAPI.Controllers
{
    public class PlanoUsuariosController : ApiController
    {
        // GET: Usuarios
        private readonly PlanoUsuarioRepositorio _planousuariosRepositorio;

        public PlanoUsuariosController()
        {
            _planousuariosRepositorio = new PlanoUsuarioRepositorio();
        }

        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<PlanoUsuario> List()
        {
            return _planousuariosRepositorio.GetAll();
        }

        // GET: api/Clientes/5
        public PlanoUsuario GetPlanoUsuario(int id)
        {
            var PlanoUsuario = _planousuariosRepositorio.GetById(id);


            return PlanoUsuario;
        }

        // POST: api/Clientes   
        [HttpPost()]
        public void Post([FromBody]PlanoUsuario planousuario)
        {
            _planousuariosRepositorio.Insert(planousuario);
        }

        // PUT: api/Clientes/5
        [HttpPut()]
        public void Put([FromBody]PlanoUsuario planousuario)
        {
            _planousuariosRepositorio.Update(planousuario);
        }

        // DELETE: api/Clientes/5
        [HttpDelete()]
        public void Delete(int id)
        {
            PlanoUsuario pu = new PlanoUsuario();
            pu.IdUsuarioPlano = id;
            _planousuariosRepositorio.Delete(pu);
        }
    }
}