using senai_hroads_webApiDBFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_webApiDBFirst.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório TiposUsuarioRepositoy
    /// </summary>
    interface ITiposUsuarioRepository
    {
        /// <summary>
        ///Lista todos os TiposUsuario
        /// </summary>
        /// <returns>Uma lista como todos os tipoUsuario</returns>
        List<TiposUsuario> Listar();

        /// <summary>
        /// Listar o Usuario pelo seu TipoUsuario
        /// </summary>
        /// <return>Uma Lista de TipoUsuario com seus usuarios</return>
        List<TiposUsuario> ListarUsuario();

        /// <summary>
        /// Buscar um TipoUsuario pelo seu id 
        /// </summary>
        /// <return>Os TiposUsuario buscado</return>
        TiposUsuario BuscarPorId(int id);

        /// <summary>
        /// Deleta um TipoUsuario existente
        /// </summary>
        /// <param name="id">Id dos TiposUsuario buscado</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza um TipoUsuario passando seu id na url da requisição
        /// </summary>
        /// <param name="id">Id dos TiposUsuario que vai ser atualizado</param>
        /// <param name="tUsuarioAtualizada">Objeto com as novas informações que serão atualizadas</param>
        void Atualizar(int id, TiposUsuario tUsuarioAtualizada);

        /// <summary>
        /// Cadastra um novo TiposUsuario
        /// </summary>
        /// <param name="novoTiposUsuarios">Objetos com as informações para serem cadastradas</param>
        void Cadastrar(TiposUsuario novoTiposUsuarios);
    }

}
