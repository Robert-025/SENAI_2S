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
    
    public class UsuarioController : ControllerBase
    {
        /// <summary>
        /// Instancia um IUsuarioRepository para ter acesso aos métodos criados na interface
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Método construtor que atribui o _usuarioRepository a um novo UsuarioRepositoy, fazendo ele ter acesso completo sobre todos os métodod do UsuarioRepository
        /// </summary>
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();        
        }

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Retorna um status code 200 - ok com a lista</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Cria uma lista pra receber a lista que for buscada pelo método
            List<UsuarioDomain> listaUsuarios = _usuarioRepository.ListarTodos();

            //Retorna com a lista
            return Ok(listaUsuarios);
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario">Usuario com os parâmetros que serão cadastrados</param>
        /// <returns>Um status code 201 - created</returns>
        [HttpPost]
        public IActionResult Post(UsuarioDomain usuario)
        {
            //Cadastra o novo usuario 
            _usuarioRepository.Cadastrar(usuario);

            //Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um usuario passando o id na url da requisição
        /// </summary>
        /// <param name="id">Id do usuario que será deletado</param>
        /// <returns>Retorna um status code 204 - NoContent</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Deleta um usuario pelo seu id
            _usuarioRepository.Deletar(id);

            //Retorna um status code
            return NoContent();
        }

        /// <summary>
        /// Lista um usuario pelo seu id
        /// </summary>
        /// <param name="id">Id do usuario  que vai ser listado</param>
        /// <returns>Um status code 200 - Ok com o usuario</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Cria um UsuarioDomain para armazenar o usuario buscado no banco de dados
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            //Verifica se o usuario buscado foi encontrado
            if (usuarioBuscado == null)
            {
                //Se não for encontrado, retorna um status code 404 - NotFound com uma mensagem personalizada
                return NotFound("Usuario não encontrado");
            }

            //Caso seja encontrado um usuario, retorna um status code 200 - Ok com o usuario
            return Ok(usuarioBuscado);
        }

        /// <summary>
        /// Atualiza um usuario existente
        /// </summary>
        /// <param name="id">Id do usuario que será atualizao</param>
        /// <param name="usuario">Objeto com as novas informações que serão cadastradas</param>
        /// <returns>Um status code 204 - NoContent caso não dê erro. Caso dê erro retorna um status code 400 - BadRequest com o código de erro</returns>
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, UsuarioDomain usuario)
        {
            //Instancia um UsuarioDomain para armazenar o usuarioBuscado pelo seu id 
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            //Verifica se existe algum usuario armazenado no usuarioBuscado
            if (usuarioBuscado == null)
            {
                //Caso não tenha, retorna um NotFound com uma mensagem personalizada
                return NotFound("Usuario não encontrado");
            }

            //Caso tenha, tenta fazer o seguinte comando
            try
            {
                //Atualiza o usuario passando o seu id e o objeto usuario com as novas informações
                _usuarioRepository.AtualizarPorId(id, usuario);

                //Retorna um NoContent
                return NoContent();
            }
            //Caso tente e não consiga, executa 
            catch (Exception codErro)
            {
                //Retorna um BadRequest com um código de erro
                return BadRequest(codErro);
            }
        }
    }
}
