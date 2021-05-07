using senai_hroads_webApiDBFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_webApiDBFirst.Interfaces
{
    /// <summary>
    /// Interface responsável pela classe HabilidadeRepository
    /// </summary>
    interface IHabilidadeRepository
    {
        /// <summary>
        /// LIsta de todas as Habildades
        /// </summary>
        /// <returns>Uma lista com as habilidades das classes </returns>
        List<Habilidade> Listar();

        /// <summary>
        /// Lista todas as habilidades com seus tipos
        /// </summary>
        /// <returns>Uma lista com as habilidades e seus tipos</returns>
        List<Habilidade> ListarTipoHabilidade();


        /// <summary>
        /// Busca uma Habilidade pelo seu id
        /// </summary>
        /// <param name="id">Id habilidade que será buscada</param>
        /// <returns>A Habilidade buscada</returns>
        Habilidade BuscarPorId(int id);

        /// <summary>
        /// Deletar uma Habilidade existente
        /// </summary>
        /// <param name="id">Id da habilidade que serpa deletada</param>
        void Deletar(int id);

        /// <summary>
        /// Cadastra uma nova Habildade
        /// </summary>
        /// <param name="novaHabilidade">Objeto com as informações que sera cadastradas</param>
        void Cadastrar(Habilidade novaHabilidade);

        /// <summary>
        /// Atualiza uma Habilidade passando o seu id na url da requisição
        /// </summary>
        /// <param name="id">Id da Habilidade que será atualizada</param>
        /// <param name="habilidadeAtualizada">Objeto com as informações que serão atualizadas</param>
        void Atualizar(int id, Habilidade habilidadeAtualizada);
    }
}
