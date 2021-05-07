using senai_hroads_webApiDBFirst.Domains;
using System.Collections.Generic;

namespace senai_hroads_webApiDBFirst.Interfaces
{
    /// <summary>
    /// Interface responsável pela classe ClasseRepository
    /// </summary>
    interface IClasseRepository
    {
        /// <summary>
        /// LIsta todas as classes
        /// </summary>
        /// <returns>Uma lista com as classes do jogo</returns>
        List<Classe> Listar();

        /// <summary>
        /// Lista os jogos pela sua classe
        /// </summary>
        /// <returns>Uma lista de classe</returns>
        List<Classe> ListarPersonagems();

        /// <summary>
        /// Busca uma classe pelo seu id
        /// </summary>
        /// <param name="id">Id da classe que será buscada</param>
        /// <returns>A classe buscada</returns>
        Classe BuscarPorId(int id);

        /// <summary>
        /// Deleta uma classe existente
        /// </summary>
        /// <param name="id">Id da classe que seráa deletada</param>
        void Deletar(int id);

        /// <summary>
        /// Cadastra uma nova classe
        /// </summary>
        /// <param name="novaClasse">Objeto com as informações que serão cadastradas</param>
        void Cadastrar(Classe novaClasse);

        /// <summary>
        /// Atualiza uma classe passando o seu id na url da requisição
        /// </summary>
        /// <param name="id">Id da classe que será atualizada</param>
        /// <param name="classeAtualizada">Objeto com as informações que serão atualizadas</param>
        void Atualizar(int id, Classe classeAtualizada);
    }
}
