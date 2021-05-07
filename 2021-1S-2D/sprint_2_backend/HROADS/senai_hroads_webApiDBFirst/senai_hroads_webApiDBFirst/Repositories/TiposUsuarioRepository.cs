using Microsoft.EntityFrameworkCore;
using senai_hroads_webApiDBFirst.Contexts;
using senai_hroads_webApiDBFirst.Domains;
using senai_hroads_webApiDBFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace senai_hroads_webApiDBFirst.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        /// <summary>
        /// Instancia o HroadsContext para ter acesso aos métodos do EF Core
        /// </summary>
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza um TipoUsuario passando seu id na url da requisição
        /// </summary>
        /// <param name="id">Id dos TiposUsuario que vai ser atualizado</param>
        /// <param name="tUsuarioAtualizado">Objeto com as novas informações que serão atualizadas</param>
        public void Atualizar(int id, TiposUsuario tUsuarioAtualizado)
        {
            //Busca um tipo de usuario pelo seu id
            TiposUsuario usuarioBuscado = ctx.TiposUsuarios.Find(id);

            //Verifica se a descricao do tipoUsuario foi informado
            if (usuarioBuscado.Descricao != null)
            {
                //Atribui o novo valor ao campo
                usuarioBuscado.Descricao = tUsuarioAtualizado.Descricao;
            }

            //Atualiza o usuarioBuscado que foi buscado
            ctx.TiposUsuarios.Update(usuarioBuscado);

            //Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Buscar um TipoUsuario pelo seu id 
        /// </summary>
        /// <return>Os TiposUsuario buscado</return>
        public TiposUsuario BuscarPorId(int id)
        {
            //Retorna o primeiro tipo de usuario encontrado para o ID informado
            return ctx.TiposUsuarios.FirstOrDefault(t => t.IdTipoUsuario == id);
        }

        /// <summary>
        /// Cadastra um novo TiposUsuario
        /// </summary>
        /// <param name="novoTipoUsuario">Objetos com as informações para serem cadastradas</param>
        public void Cadastrar(TiposUsuario novoTipoUsuario)
        {
            //Chama o método do EF Core que adiciona o novoTipoUsuario
            ctx.TiposUsuarios.Add(novoTipoUsuario);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um TipoUsuario existente
        /// </summary>
        /// <param name="id">Id dos TiposUsuario buscado</param>
        public void Deletar(int id)
        {
            //Busca o tipo de usuario pelo seu id
            TiposUsuario usuarioBuscado = ctx.TiposUsuarios.Find(id);

            //Deleta o tipo de usuario que foi buscado
            ctx.TiposUsuarios.Remove(usuarioBuscado);

            //Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        ///Lista todos os TiposUsuario
        /// </summary>
        /// <returns>Uma lista como todos os tipoUsuario</returns>
        public List<TiposUsuario> Listar()
        {
            //Retorna uma lista com todas as informações dos TiposUsuarios
            return ctx.TiposUsuarios.ToList();
        }

        /// <summary>
        /// Listar o Usuario pelo seu TipoUsuario
        /// </summary>
        /// <return>Uma Lista de TipoUsuario com seus usuarios</return>
        public List<TiposUsuario> ListarUsuario()
        {
            //Retorna uma lista de tipos de usuarios com seus usuarios
            return ctx.TiposUsuarios.Include(t => t.Usuarios).ToList();
        }
    }
}
