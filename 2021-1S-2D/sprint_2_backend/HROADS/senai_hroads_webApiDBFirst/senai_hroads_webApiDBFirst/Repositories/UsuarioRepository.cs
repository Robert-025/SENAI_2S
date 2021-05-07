using Microsoft.EntityFrameworkCore;
using senai_hroads_webApiDBFirst.Contexts;
using senai_hroads_webApiDBFirst.Domains;
using senai_hroads_webApiDBFirst.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai.hroads.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Instancia o HroadsContext para ter acesso aos métodos do EF Core
        /// </summary>
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza um usuario passando seu id na url da requisição
        /// </summary>
        /// <param name="id">Id do usuario que vai ser atualizado</param>
        /// <param name="novoUsuario">Objeto com as novas informações que serão atualizadas</param>
        public void Atualizar(int id, Usuario novoUsuario)
        {
            //Cria um objeto com o resultado da informação da busca de um usuario com o id
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            //Verifica se existe algum parâmetro incrito no campo email
            if (novoUsuario.Email != null)
            {
                //Atribui o novo valor ao campo
                usuarioBuscado.Email = novoUsuario.Email;
            }

            //Verifica se existe algum parâmetro incrito no campo email
            if (novoUsuario.Senha != null)
            {
                //Atribui o novo valor ao campo
                usuarioBuscado.Senha = novoUsuario.Senha;
            }

            //Atualiza o usuario buscado
            ctx.Usuarios.Update(usuarioBuscado);

            //Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Buscar um usuario pelo seu id 
        /// </summary>
        /// <return>O usuario buscado</return>
        public Usuario BuscarPorId(int id)
        {
            //Retorna a primeira classe encontrada para o ID informado
            return ctx.Usuarios.FirstOrDefault(e => e.IdUsuarios == id);
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario">Objetos com as informações para serem cadastradas</param>
        public void Cadastrar(Usuario novoUsuario)
        {
            //Adiciona esse novoUsuario
            ctx.Usuarios.Add(novoUsuario);

            //Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um usuario existente
        /// </summary>
        /// <param name="id">Id do usuario buscado</param>
        public void Deletar(int id)
        {
            //Busca a classe que tem o ID informado
            Usuario UsuarioBuscado = ctx.Usuarios.Find(id);
            
            //Remove de usuarios
            ctx.Usuarios.Remove(UsuarioBuscado);

            //Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            //Retorna uma lista com todas as informações das classes
            return ctx.Usuarios.ToList();
        }

        /// <summary>
        /// Listar o TipoUsuario pelo seu Usuario
        /// </summary>
        /// <return>Uma Lista de Usuario com seu tipoUsuario</return>
        public List<Usuario> ListarTipoUsuario()
        {
            //Retorna uma lista de classes com seus personagens
            return ctx.Usuarios.Include(e => e.IdTiposUsuariosNavigation).ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.Email == email && e.Senha == senha);
        }
    }
}