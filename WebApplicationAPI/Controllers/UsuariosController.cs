﻿using System.Collections.Generic;
using System.Web.Http;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Controllers
{
    public class UsuariosController : ApiController
    {
        // GET: Usuarios
        private readonly UsuarioRepositorio _usuariosRepositorio;

        public UsuariosController()
        {
            _usuariosRepositorio = new UsuarioRepositorio();
        }

        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<Usuario> List()
        {
            return _usuariosRepositorio.GetAll();
        }

        // GET: api/Clientes/5
        public Usuario GetUsuario(int id)
        {
            var Usuario = _usuariosRepositorio.GetById(id);


            return Usuario;
        }

        // POST: api/Clientes   
        [HttpPost()]
        public void Post([FromBody]Usuario usuario)
        {
            _usuariosRepositorio.Insert(usuario);
        }

        // PUT: api/Clientes/5
        [HttpPut()]
        public void Put([FromBody]Usuario usuario)
        {
            _usuariosRepositorio.Update(usuario);
        }

        // DELETE: api/Clientes/5
        [HttpDelete()]
        public void Delete(int id)
        {
            Usuario u = new Usuario();
            u.IdUsuario = id;
            _usuariosRepositorio.Delete(u);
        }

    }

}