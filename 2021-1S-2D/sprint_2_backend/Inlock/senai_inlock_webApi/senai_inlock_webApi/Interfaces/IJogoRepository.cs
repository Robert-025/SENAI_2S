using senai_inlock_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webApi.Interfaces
{
    interface IJogoRepository
    {
        /// <summary>
        /// Lista todos os jogos cadastrados
        /// </summary>
        /// <returns>A lista com todos os jogos</returns>
        List<JogoDomain> ListarTodos();

        /// <summary>
        /// Busca um jogo pelo seu id
        /// </summary>
        /// <param name="id">Id do jogo que será buscado</param>
        /// <returns>O jogo buscado</returns>
        JogoDomain BuscarPorId(int id);

        /// <summary>
        /// Atualiza todos os parâmetros de um jogo pelo seu id
        /// </summary>
        /// <param name="id">Id do jogo que será atualizado</param>
        /// <param name="jogo">Objeto que terá as novas informações</param>
        void AtualizarIdUrlPut(int id, JogoDomain jogo);

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="jogo">Jogo que será cadastrado</param>
        void Cadastrar(JogoDomain jogo);

        /// <summary>
        /// Deleta um jogo existente pelo seu id
        /// </summary>
        /// <param name="id">Id do jogo que será deletado</param>
        void Deletar(int id);
    }
}
