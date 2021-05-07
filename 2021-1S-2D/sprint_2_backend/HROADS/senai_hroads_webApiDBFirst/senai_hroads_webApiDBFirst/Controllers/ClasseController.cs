using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai_hroads_webApiDBFirst.Domains;
using senai_hroads_webApiDBFirst.Interfaces;
using senai_hroads_webApiDBFirst.Repositories;

namespace senai_hroads_webApiDBFirst.Controllers
{
    //Define que a respota da API vai ser em JSON
    [Produces("application/json")]

    //Define a rota padrão da API -> dominio/api/nomeController
    [Route("api/[controller]")]

    //Define que é um controlador API
    [ApiController]
    public class ClasseController : ControllerBase
    {
        /// <summary>
        /// Objeto que instancia IClasseRepository que receberá os métodos definidos na interface
        /// </summary>
        private IClasseRepository _classeRepository { get; set; }

        /// <summary>
        /// Instancia o objeto classeRepository para que haja referências dos métodos implementados no ClasseRepository
        /// </summary>
        public ClasseController()
        {
            _classeRepository = new ClasseRepository();
        }

        /// <summary>
        /// Lista as classes do jogo
        /// </summary>
        /// <returns>Um status code 200 - OK com as classes</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_classeRepository.Listar());
        }
        /// <summary>
        /// Busca uma classe atraves do seu ID
        /// </summary>
        /// <param name="id">Id da classe que será buscada</param>
        /// <returns>Uma classe encontrada e um status code 200 - Ok </returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_classeRepository.BuscarPorId(id));
        }
        /// <summary>
        /// Cadastra uma nova classe 
        /// </summary>
        /// <param name="novaClasse">Objeto novaclasse que sera cadastrado </param>
        /// <returns>Um status code 201 - Created </returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Classe novaClasse)
        {
            // Faz a chamada para o metodo 
            _classeRepository.Cadastrar(novaClasse);

            // Retorna um status code
            return StatusCode(201);
        }


        /// <summary>
        /// Atualiza uma classe existente
        /// </summary>
        /// <param name="id">Id do estudio que será atualizado</param>
        /// <param name="classeAtualizada">Objeto classeAtualizada com as novas informações </param>
        /// <returns>retorna um status code</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Classe classeAtualizada)
        {
            //faz a chamada para o método 
            _classeRepository.Atualizar(id, classeAtualizada);
            //retorna o status code
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta uma classe existente
        /// </summary>
        /// <param name="id">ID da classe que será deletada</param>
        /// <returns>Status code </returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Faz a chamada para um método 
            _classeRepository.Deletar(id);
            //Retorna um Status code
            return StatusCode(204);
        }

        /// <summary>
        /// Lista todas as classes com seus respectivos Personagens
        /// </summary>
        /// <returns>Uma lista de Classes com os Personagens e um status code 200 - OK</returns>
        [HttpGet("personagems")]
        public IActionResult GetPersonagems()
        {
            return Ok(_classeRepository.ListarPersonagems());
        }
    }
}
