using senai_hroads_webApiDBFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_webApiDBFirst.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        List<Usuario> Listar();

        /// <summary>
        /// Lista todos os usuarios com seus tipos de usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios com os tipos de usuarios</returns>
        List<Usuario> ListarTipoUsuario();

        /// <summary>
        /// Busca um usuario pelo seu id
        /// </summary>
        /// <param name="id">Id do usuario que será buscado</param>
        /// <returns>O usuario buscado</returns>
        Usuario BuscarPorId(int id);

        /// <summary>
        /// Atualiza um usuario existente passando o id na sua url
        /// </summary>
        /// <param name="id">Id do usuario que vai ser atualizado</param>
        /// <param name="usuarioAtualizado">Objeto com as informações que serão atualizadas</param>
        void Atualizar(int id, Usuario usuarioAtualizado);

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto com as informações que serão cadastradas</param>
        void Cadastrar(Usuario novoUsuario);

        /// <summary>
        /// Deleta um usuario existente
        /// </summary>
        /// <param name="id">Id do usuario que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Valida o usuario
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns>Um objeto do tipo usuario que foi buscado</returns>
        Usuario Login(string email, string senha);
    }
}
