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
    // Defini que a resposta da API será em JSON
    [Produces("application/json")]

    //Define a rota da requisição
    [Route("api/[controller]")]

    //Define que é um controlador API
    [ApiController]
    public class TipoHabilidadeController : ControllerBase
    {
        /// <summary>
        /// Objeto que instancia a interface ITipoHabilidadeRepository para ter acesso aos métodos lá criados
        /// </summary>
        private ITipoHabilidadeRepository _tipoHabilidadeRepository { get; set; }

        /// <summary>
        /// Cria um método construtor que para ter a referência aos métodos implementados no TipoHabilidadeRepository
        /// </summary>
        public TipoHabilidadeController()
        {
            _tipoHabilidadeRepository = new TipoHabilidadeRepository();
        }

        /// <summary>
        /// Lista todos os tipos de habilidades
        /// </summary>
        /// <returns>Um status code 200 - OK e a lista de TipoHabilidade</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição chamando o método de listar
            return Ok(_tipoHabilidadeRepository.Listar());
        }

        /// <summary>
        /// Busca um tipo de habilidade pelo seu id
        /// </summary>
        /// <param name="id">Id do tipo de habilidade que será buscado</param>
        /// <returns>Um status code 200 - Ok com o Tipo de habilidade buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna a resposta da requisição chamando o método de buscar por id
            return Ok(_tipoHabilidadeRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo tipo de habilidade
        /// </summary>
        /// <param name="novoTipoHabilidade">Objeto novoTipoHabilidade que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TipoHabilidade novoTipoHabilidade)
        {
            //Chama o método de cadastrar
            _tipoHabilidadeRepository.Cadastrar(novoTipoHabilidade);

            //Retorna um status code 201 - Created
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um Tipo de habilidade 
        /// </summary>
        /// <param name="id">Id do TipoHabilidade que será atualizado</param>
        /// <param name="tipoHabilidadeAtualizado">Objeto com as informa~ções que serão atualizadas</param>
        /// <returns>Retorna um status 204 - NoContent</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoHabilidade tipoHabilidadeAtualizado)
        {
            //Faz a chamada para o método atualizar
            _tipoHabilidadeRepository.Atualizar(id, tipoHabilidadeAtualizado);

            //Retorna um NoContent
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um tipo de habilidade pelo seu id
        /// </summary>
        /// <param name="id">Id do tipo de habilidade que vai ser deletado</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Faz a chamada para o método de deletar
            _tipoHabilidadeRepository.Deletar(id);

            //Retorna o status code NoContent
            return StatusCode(204);
        }

        /// <summary>
        /// Lista todos os tipos de habilidades e suas respectivas habilidades
        /// </summary>
        /// <returns>Um status code 200 - Ok com a lista de TiposHabilidades e suas habilidades</returns>
        [HttpGet("habilidades")]
        public IActionResult GetHabilidades()
        {
            // Retorna a resposta da requisição chamando o método de listar os tipos de habilidades junto com suas habilidades
            return Ok(_tipoHabilidadeRepository.ListarHabilidades());
        }
    }
}
