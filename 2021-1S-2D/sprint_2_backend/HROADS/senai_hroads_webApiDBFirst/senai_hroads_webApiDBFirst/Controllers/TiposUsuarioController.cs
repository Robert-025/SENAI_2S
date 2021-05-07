using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_hroads_webApiDBFirst.Domains;
using senai_hroads_webApiDBFirst.Interfaces;
using senai_hroads_webApiDBFirst.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_webApiDBFirst.Controllers
{
    //Define que a resposta da API será em JSON
    [Produces("application/json")]

    //Define uma rota padrão da requisição - dominio/api/nomeController
    [Route("api/[controller]")]

    //Define que é um controlador API
    [ApiController]
    public class TiposUsuarioController : ControllerBase
    {
        ITiposUsuarioRepository _tiposUsuarioRepository { get; set; }

        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os tipos de usuarios
        /// </summary>
        /// <returns>Retorna um status code 200 - Ok com a lista de usuarios</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna o status code chamando o método de listar
            return Ok(_tiposUsuarioRepository.Listar());
        }

        /// <summary>
        /// Busca o tipo de usuario pelo seu id
        /// </summary>
        /// <param name="id">Id do tipo de usuario que será buscado</param>
        /// <returns>Um status code 200 - Ok com o tipo de usuario buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_tiposUsuarioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo tipo de usuario
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto com as informações que serão cadastradas</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TiposUsuario novoTipoUsuario)
        {
            //Chama o método de cadastrar
            _tiposUsuarioRepository.Cadastrar(novoTipoUsuario);

            //Retorna o status code 201 - Created
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza todos os campos do TiposUsuario passando seu id na url
        /// </summary>
        /// <param name="id">ID do tipoUsuario que vai ser atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto com as informações que serão atualizado</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposUsuario tipoUsuarioAtualizado)
        {
            //Chama o método de atualizar passando o id e o objeto com as novas informações
            _tiposUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);

            //Retorna um status code - 204 NoContent
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um tipo de usuario pelo seu id
        /// </summary>
        /// <param name="id">ID do tipo de usuario que vai ser deletado</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Chama o método deletar com o id informado
            _tiposUsuarioRepository.Deletar(id);

            //Retorna um status code 204 - NoContent
            return StatusCode(204);
        }

        /// <summary>
        /// Lista todos os tipos de usuarios com seus usuarios
        /// </summary>
        /// <returns>Um status code 200 - Ok com a lista de tipos de usuarios e seus usuarios</returns>
        [HttpGet("usuarios")]
        public IActionResult GetUsuarios()
        {
            //Retorna a resposta da requisição chamando o método de listar os tipos de usuarios junto com seus usuarios
            return Ok(_tiposUsuarioRepository.ListarUsuario());
        }
    }
}
