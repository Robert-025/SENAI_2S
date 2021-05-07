using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Repositories;
using senai_hroads_webApiDBFirst.Domains;
using senai_hroads_webApiDBFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_webApiDBFirst.Controllers
{
    /// <summary>
    /// Define que a resposta da API será em JSON
    /// </summary>
    [Produces("application/json")]

    //Define uma rota padrão para a requisição - dominio/api/NomeController
    [Route("api/[controller]")]

    //Define que é um controlador API
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        /// <summary>
        /// Objeto que instancia IUsuarioRepository que receberá os métodos definidos na interface
        /// </summary>
        IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto usuarioRepository para que haja referências dos métodos implementados no ClasseRepository
        /// </summary>
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista os usuarios
        /// </summary>
        /// <returns>Um status code 200 - OK com as classes</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_usuarioRepository.Listar());
        }

        /// <summary>
        /// Busca um usuario através do seu ID
        /// </summary>
        /// <param name="id">Id do usuario que será buscado</param>
        /// <returns>Um usuario encontrado e um status code 200 - Ok </returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_usuarioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Lista todos os usuariso com seus respectivos tipos de usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios com os seus tipos e um status code 200 - OK</returns>
        [HttpGet("tiposusuarios")]
        public IActionResult GetTiposUsuarios()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_usuarioRepository.ListarTipoUsuario());
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto com as informações que serão cadastradas</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            //Chama o método criado no repositorio
            _usuarioRepository.Cadastrar(novoUsuario);

            //Retorna o status code
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um usuario
        /// </summary>
        /// <param name="id">Id do usuario que será deletado</param>
        /// <returns>U  status code 204 - NoContent</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Chama o método criado no repositório
            _usuarioRepository.Deletar(id);

            //Retorna o status code
            return StatusCode(204);
        }

        /// <summary>
        /// Atualiza um usuario existente
        /// </summary>
        /// <param name="id">Id do usuario que vai ser atualizado</param>
        /// <param name="usuarioAtualizado">Objeto com as informações que serão atualizadas</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuarioAtualizado)
        {
            _usuarioRepository.Atualizar(id, usuarioAtualizado);

            return StatusCode(204);
        }
    }
}
