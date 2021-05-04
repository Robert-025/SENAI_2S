using senai_inlock_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo UsuarioRepository
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        List<UsuarioDomain> ListarTodos();

        /// <summary>
        /// Busca um usuario pelo seu ID
        /// </summary>
        /// <param name="id">Id do usuario que será buscado</param>
        /// <returns>O usuario buscado</returns>
        UsuarioDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario">Usuario com as informações</param>
        void Cadastrar(UsuarioDomain usuario);

        /// <summary>
        /// Atualiza um usuario existente pelo seu Id
        /// </summary>
        /// <param name="id">Id do usuario que será atualizado</param>
        void AtualizarPorId(int id, UsuarioDomain usuario);

        /// <summary>
        /// Deleta um usuario pelo seu id
        /// </summary>
        /// <param name="id">Id do usuario que vai ser deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Valida o usuario
        /// </summary>
        /// <param name="email">Email do usuario</param>
        /// <param name="senha">Senha do usuario</param>
        /// <returns>O usuario buscado</returns>
        UsuarioDomain BuscarPorEmailSenha(string email, string senha); 
    }
}
