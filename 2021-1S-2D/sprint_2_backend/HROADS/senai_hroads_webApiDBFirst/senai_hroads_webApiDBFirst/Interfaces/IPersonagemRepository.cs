using senai_hroads_webApiDBFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_webApi.Interfaces
{
    interface IPersonagemRepository
    {
        /// <summary>
        /// Lista todas os Personagens
        /// </summary>
        /// <returns>Retorna uma lista de personagens </returns>
        List<Personagem> Listar();

        /// <summary>
        /// Lista todos os personagems com suas classes
        /// </summary>
        /// <returns>Uma lista com os personagems e suas classes</returns>
        List<Personagem> ListarClasses();

        /// <summary>
        /// Busca um personagem pelo id
        /// </summary>
        /// <param name="id">Id do personagem que vai ser buscado</param>
        /// <returns>O personagem buscado</returns>
        Personagem BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo personagem
        /// </summary>
        /// <param name="novoPersonagem">id do personagem que será atualizado</param>
        void Cadastrar(Personagem novoPersonagem);


        /// <summary>
        /// Atualiza um personagem já existente
        /// </summary>
        /// <param name="id">id do personagem que será atualizado</param>
        /// <param name="personagemAtualizado"> objeto personagemAtualizado com as novas informações</param>
        void Atualizar(int id, Personagem personagemAtualizado);

        /// <summary>
        /// Deleta um personagem existente
        /// </summary>
        /// <param name="id">Id do personagem que será deletado</param>
        void Deletar(int id);
    }
}