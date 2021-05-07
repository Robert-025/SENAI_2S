using senai_hroads_webApiDBFirst.Domains;
using System.Collections.Generic;

namespace senai_hroads_webApiDBFirst.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório TipoHabilidadeRepositoy
    /// </summary>
    interface ITipoHabilidadeRepository
    {
        /// <summary>
        /// Lista todos os tipos de habilidades
        /// </summary>
        /// <returns>Uma lista com todos od tipos de habilidades</returns>
        List<TipoHabilidade> Listar();

        /// <summary>
        /// Lista as habilidades pelo seu TipoHabilidade
        /// </summary>
        /// <returns>Uma lista de TipoHabilidades</returns>
        List<TipoHabilidade> ListarHabilidades();

        /// <summary>
        /// Busca um TipoHabilidade pelo seu id
        /// </summary>
        /// <returns>O TipoHabilidade buscado</returns>
        TipoHabilidade BuscarPorId(int id);

        /// <summary>
        /// Deleta um TipoHabilidade existente
        /// </summary>
        /// <param name="id">Id do TipoHabilidade buscado</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza um TipoHabilidade passando seu id na url da requisição
        /// </summary>
        /// <param name="id">Id do TipoHabilidade que vai ser atualizado</param>
        /// <param name="tHabilidadeAtualizada">Objeto com as novas informações que serão atualizadas</param>
        void Atualizar(int id, TipoHabilidade tHabilidadeAtualizada);

        /// <summary>
        /// Cadastra um novo TipoHabilidade
        /// </summary>
        /// <param name="novoTipoHabilidade">Objeto com as informações para serem cadastradas.</param>
        void Cadastrar(TipoHabilidade novoTipoHabilidade);
    }
}
