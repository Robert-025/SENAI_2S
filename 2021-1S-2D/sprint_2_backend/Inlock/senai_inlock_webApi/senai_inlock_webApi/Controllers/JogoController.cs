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

    //Define uma rota patrão : dominio/api/nomeController
    [Route("api/[controller]")]

    //Define que é um controlador API
    [ApiController]
    public class JogoController : ControllerBase
    {
        /// <summary>
        /// Instancia um objeto do tipo IJogoRepository para ter acesso aos métodos criados na interface
        /// </summary>
        private IJogoRepository _jogoRepository { get; set; }

        /// <summary>
        /// Instancia o JogoRepository para poder usar os métodos do repositório
        /// </summary>
        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        /// <summary>
        /// Lista todos os jogos 
        /// </summary>
        /// <returns>Um status code junto com a lista</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Cria uma lista para receber as informações do método
            List<JogoDomain> listaJogos = _jogoRepository.ListarTodos();

            //Retorna um status code 200 - ok com a listaJogos
            return Ok(listaJogos);
        }

        /// <summary>
        /// Cria um novo jogo
        /// </summary>
        /// <param name="jogo">Jogo com as informações que serão cadastradas</param>
        /// <returns>Um status code</returns>
        [HttpPost]
        public IActionResult Post(JogoDomain jogo)
        {
            //Chama o método .Cadastrar definido no repository
            _jogoRepository.Cadastrar(jogo);

            //Retorna um status code 201 - created
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um jogo passando o id pela url da requisiçao
        /// </summary>
        /// <param name="id">Id do jogo que será deletado</param>
        /// <returns>Um staus code 204 - NoContent</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Chama o método .Deletar com o id que foi passado na url e deleta o jogo
            _jogoRepository.Deletar(id);

            //Retorna um status code 204 - NoContent
            return NoContent();
        }

        /// <summary>
        /// Busca um jogo pelo seu id
        /// </summary>
        /// <param name="id">Id do jogo que será buscado</param>
        /// <returns>Um status code com o jogo</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Instacia um objeto para armazenar o jogo buscado pelo id
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

            //Verifica se o jogo foi encontrado, e se não for executa
            if (jogoBuscado == null)
            {
                //Caso não seja encontrado um jogo com o id passado, retorna um status code 404 - NotFound
                return NotFound("Jogo não encontrado");
            }

            //Caso seja encontrado, retorna um status code 200 - Ok com o jogo pedido
            return Ok(jogoBuscado);

        }

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, JogoDomain jogo)
        {
            //Cria um objeto que vai receber o jogo buscado no banco de dados
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

            //Verifica se o jogo existe, e se não existir executa
            if (jogoBuscado == null)
            {
                //Retorna um status code 404 - NoFound com uma mensagem
                return NotFound("Jogo não encontrado");
            }

            //Caso encontre, pula o if e tenta executar
            try
            {
                //Tenta atualizar o jogo
                _jogoRepository.AtualizarIdUrlPut(id, jogo);

                //Caso ocorra tudo certo, retorna um status code 204 - NoContent
                return NoContent();
            }
            //Caso dê algum erro, executa; Instancia um objeto do tipo Exception para criar um código de erro
            catch (Exception codErro)
            {
                //Retorna um status code 400 - BadRequest com o codErro como parâmetro
                return BadRequest(codErro);
            }
        }
    }
}
