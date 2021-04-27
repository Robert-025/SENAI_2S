using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_hroads_webApiDBFirst.Interfaces;
using senai_hroads_webApiDBFirst.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

    }
}
