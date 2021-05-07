using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Repositories;
using senai_hroads_webApi.Interfaces;
using senai_hroads_webApiDBFirst.Domains;
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
    public class PersonagemController : ControllerBase
    {
        /// <summary>
        /// Objeto que instancia IPersonagemRepository que receberá os métodos definidos na interface
        /// </summary>
        IPersonagemRepository _personagemRepository { get; set; }

        /// <summary>
        /// Instancia o objeto PersonagemRepository para que haja referências dos métodos implementados no PersonagemRepository
        /// </summary>
        public PersonagemController()
        {
            _personagemRepository = new PersonagemRepository();
        }

        /// <summary>
        /// Lista todas as habilidades
        /// </summary>
        /// <returns>Um status code 200 - OK com a lista de habilidades</returns>
        [Authorize(Roles = "1, 2")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personagemRepository.Listar());
        }

        /// <summary>
        /// Lista todos os personagens e a classes que elas pertencem
        /// </summary>
        /// <returns>Um status code 200 - OK com os personagens e as classes</returns>
        [HttpGet("classes")]
        public IActionResult GetClasse()
        {
            return Ok(_personagemRepository.ListarClasses());
        }

        /// <summary>
        /// Lista um personagem pelo seu id
        /// </summary>
        /// <param name="id">Id do personagem que vai ser buscado</param>
        /// <returns>Um status code 200 - OK com o personagem buscada</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_personagemRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo personagem
        /// </summary>
        /// <param name="novoPersonagem">Objeto com as informações que serão cadastradas</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Post(Personagem novoPersonagem)
        {
            //Chama o método
            _personagemRepository.Cadastrar(novoPersonagem);

            //Retorna o status code
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um personagem existente 
        /// </summary>
        /// <param name="id">Id do personagem que será deletado</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personagemRepository.Deletar(id);

            return StatusCode(204);
        }

        /// <summary>
        /// Atualiza um persongame passando seu id na url
        /// </summary>
        /// <param name="id">Id do personagem que vai ser atualizado</param>
        /// <param name="personagemAtualizado">Objeto com as informações que serão atualizadas</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [Authorize(Roles = "2")]
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Personagem personagemAtualizado)
        {
            //Chama o método de atualizar passando os parâmetros id e o objeto com as informações
            _personagemRepository.Atualizar(id, personagemAtualizado);

            //Retorna o status code
            return StatusCode(204);
        }
    }
}
