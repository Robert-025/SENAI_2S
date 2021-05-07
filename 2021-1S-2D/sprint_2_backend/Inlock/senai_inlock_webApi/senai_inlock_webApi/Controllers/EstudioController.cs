using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_inlock_webApi.Domains;
using senai_inlock_webApi.Interfaces;
using senai_inlock_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webApi.Controllers
{
    //Define que a resposta da API vai ser em JSON
    [Produces("application/json")]

    //Define que a rota da requisição vai ser: dominio/api/nomeController
    [Route("api/[controller]")]

    //Define que é um controlador API
    [ApiController]
    public class EstudioController : ControllerBase
    {
        /// <summary>
        /// Objeto que vai receber os métodos definidos na interface IEstudioRepository
        /// </summary>
        private IEstudioRepository _estudioRepository { get; set; }

        /// <summary>
        /// Instancia o EstudioRepository pra ter referência aos métodos no repositório
        /// </summary>
        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        /// <summary>
        /// Lista todos os estudios
        /// </summary>
        /// <returns>Um status code junto com a lista</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Cria a listaEstudios para receber os dados e executar o método ListarTodos
            List<EstudioDomain> listaEstudios = _estudioRepository.ListarTodos();

            //Retona o status code (ok) com a lista de estúdios no formato JSON, definido na Interface
            return Ok(listaEstudios);
        }

        /// <summary>
        /// Busca o estudio pelo seu id
        /// </summary>
        /// <param name="id">Id do estudio desejado</param>
        /// <returns>O estudio buscado ou um status code</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Cria o objeto que vai receber o estudio buscado no banco de dados
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            //Verifica se existe algum estudio com o id inserido
            if (estudioBuscado == null)
            {
                //Caso não encontre, retorna um status code com uma mensagem
                return NotFound("Nenhum estudio encontrado");
            }

            //Caso encontre, retorna o status code e o estudio buscado
            return Ok(estudioBuscado);
        }

        /// <summary>
        /// Cria um novo estudio
        /// </summary>
        /// <param name="novoEstudio">Estudio que vai ser cadastrado</param>
        /// <returns>Um status code 201 - created</returns>
        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            //Chama o método .Cadastrar através do _estudioRepository definido no repositorio
            _estudioRepository.Cadastrar(novoEstudio);

            //Retorna o status code
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza todos os parâmetros de um estudio já existente passando seu id na url
        /// </summary>
        /// <param name="id">Id do estudio qu vai ser atualizado</param>
        /// <param name="estudio">Objeto que obterá as novas informações</param>
        /// <returns>Um status code</returns>
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, EstudioDomain estudio)
        {
            //Cria um objeto que vai receber o estudio buscado no banco de dados
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            //Verifica se existe algum estudio o id passado, e caso não tenha, retorna um NotFound
            if (estudioBuscado == null)
            {
                return NotFound("Estudio não encontrado");
            }

            //Tenta atualizar o registro pedido
            try
            {
                //Chamamos o método .AtualizarIdUrl passando o id e o estudio definidos como parâmetros
                _estudioRepository.AtualizarIdUrl(id, estudio);

                return NoContent();
            }
            //Caso não consiga atualizar, retorna um BadRequest com o código de erro
            catch (Exception codErro)
            {
                return BadRequest(codErro);
            }
        }

        /// <summary>
        /// Deleta o usuario passando o id pela url da requisição
        /// </summary>
        /// <param name="id">Id do estudio que será deletado</param>
        /// <returns>Um status code NoContent();</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _estudioRepository.Deletar(id);

            return NoContent();
        }
    }
}
