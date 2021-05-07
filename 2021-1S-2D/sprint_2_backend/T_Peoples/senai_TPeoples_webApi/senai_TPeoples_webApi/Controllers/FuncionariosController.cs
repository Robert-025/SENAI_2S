using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_TPeoples_webApi.Domains;
using senai_TPeoples_webApi.Interfaces;
using senai_TPeoples_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controller responsável pelos endpoints dos funcionarios
/// </summary>
namespace senai_TPeoples_webApi.Controllers
{
    //Define que a resposta da API será me JSON
    [Produces("application/json")]

    //Define que a rota da requisição vai ser: dominio/api/nomeController
    //ex: http://localhost:5000/api/funcionarios
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]

    public class FuncionariosController : ControllerBase
    {
        /// <summary>
        /// Objeto que vai receber os métodos definidos na interface IFuncionarioRepository
        /// </summary>
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        /// <summary>
        /// Instancia o FuncionarioRepository pra ter referência aos métodos no repositório
        /// </summary>
        public FuncionariosController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        /// <summary>
        /// Lista todos os funcionarios
        /// </summary>
        /// <returns>A lista de funcionarios e um status code</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Cria a lista chamada listaFuncionarios para receber os dados
            List<FuncionarioDomain> listaFuncionarios = _funcionarioRepository.ListarTodos();

            //Retorna o status code (Ok) com a lista de funcionarios no formato JSON, definido no começo
            return Ok(listaFuncionarios);
        }

        /// <summary>
        /// Busca o funcionário pelo seu id
        /// </summary>
        /// <param name="id">Id do funcionário desejado</param>
        /// <returns>O funcionário buscado ou um NotFound</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Cria um objeto que irá receber o funcionário buscado no banco de dados
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            //Verifica se nenhum funcionário foi encontrado
            if (funcionarioBuscado == null)
            {
                //Caso não seja encontrado, retorna um status code 404 Not Found
                return NotFound("Nenhum funcionário encontrado");
            }

            //Caso seja encontrado, retorna um status code 200, com o funcionário buscado
            return Ok(funcionarioBuscado);
        }

        /// <summary>
        /// Cadastra um novo funcionário
        /// </summary>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(FuncionarioDomain novoFuncionario)
        {
            //Chama o método .Cadastrar definido no FuncionarioRepository
            _funcionarioRepository.Cadastrar(novoFuncionario);

            //Retorna um status code 201 - created
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza todos os parâmetros do funcionário passando o id pela url da requisiçaõ
        /// </summary>
        /// <param name="id">Id do funcionário que será atualizado</param>
        /// <param name="Funcionario">Objeto funcionario com as novas informações</param>
        /// <returns>Um status code</returns>
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, FuncionarioDomain funcionario)
        {
            //Cria um objeto que irá receber o funcionario buscado no banco de dados
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            // Caso não seja encontrado, retorna NotFound 
            if (funcionarioBuscado == null)
            {
                return NotFound("Funcionário não encontrado");
            }

            //Tenta atualizar o registro pedido
            try
            {
                //Chamamos o método .AtualizarIdUrl()
                _funcionarioRepository.AtualizarIdUrl(id, funcionario);


                return NoContent();
            }
            catch (Exception codErro)
            {
                return BadRequest(codErro);
            }
        }

        /// <summary>
        /// Deleta o funcionario existente
        /// </summary>
        /// <param name="id">Id do funcionario que será deletado</param>
        /// <returns>Retorna um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Faz a chamada para o método .Deletar
            _funcionarioRepository.Deletar(id);

            //Retorna um status code 204 - No Content
            return NoContent();
        }
    }
}
