using senai_inlock_webApi.Domains;
using senai_inlock_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=ROBERT-025; initial catalog=Inlock_Games_Tarde; user id=sa; pwd=senai@132";

        /// <summary>
        /// Atualiza um usuario existente pelo seu Id
        /// </summary>
        /// <param name="id">Id do usuario que será atualizado</param>
        /// <param name="usuario">Objeto com as informações que serão atualizadas</param>
        public void AtualizarPorId(int id, UsuarioDomain usuario)
        {
            //Declara um SqlConnection passando a stringConexao como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara o comando que vai ser executado
                string queryUpdate = "UPDATE usuarios SET nome = @nome, email = @email, senha = @senha, idTipoUsuario = @idTipoUsuario WHERE idUsuario = @idUsuario";

                //Declara o SqlCommand passando o comando(query) que vai ser executado e a conexão(con)
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    //Atribui os parâmetros aos atributos passados
                    cmd.Parameters.AddWithValue("@nome", usuario.nome);
                    cmd.Parameters.AddWithValue("@email", usuario.email);
                    cmd.Parameters.AddWithValue("@senha", usuario.senha);
                    cmd.Parameters.AddWithValue("@idTipoUsuario", usuario.idTipoUsuario);
                    cmd.Parameters.AddWithValue("@idUsuario", id);

                    //Abre conexão com o banco de dados
                    con.Open(); 

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um usuario pelo seu ID
        /// </summary>
        /// <param name="id">Id do usuario que será buscado</param>
        /// <returns>O usuario buscado</returns>
        public UsuarioDomain BuscarPorId(int id)
        {
            //Declara um SqlConnection passando a stringConexao como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara o comando que vai ser executado
                string querySelectById = "SELECT nome, email, senha, idTipoUsuario FROM usuarios WHERE idUsuario = @id";

                //Declara o rdr pra armazenar as informações que vem do banco de dados
                SqlDataReader rdr;

                //Abre conexão com o banco de dados
                con.Open();

                //Declara o SqlCommand passando o comando(query) que vai ser executado e a conexão(con)
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    //Atribui o valor do id passado ao parâmetro @id
                    cmd.Parameters.AddWithValue("@id", id);

                    //Executa a query e armazena no rdr
                    rdr = cmd.ExecuteReader();

                    //Verifica se tem algum usuario para ler no rdr
                    if (rdr.Read())
                    {
                        //Instancia um usuario para receber os atributos
                        UsuarioDomain usuarioBuscado = new UsuarioDomain()
                        {
                            //Atribui as informações do rdr aos parâmetros do usuario
                            nome = rdr["nome"].ToString(),
                            email = rdr["email"].ToString(),
                            senha = rdr["senha"].ToString(),
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"])
                        };

                        //Retorna o usuario buscado caso execute 
                        return usuarioBuscado;
                    }

                    //Retorna nulo, somente se não houver usuario com o id passado
                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario">Usuario com as informações</param>
        public void Cadastrar(UsuarioDomain usuario)
        {
            //Declara um SqlConnection passando a stringConexao como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara o comando que vai ser executado
                string queryInsert = "INSERT INTO usuarios(nome, email, senha, idTipoUsuario) VALUES(@nome, @email, @senha, @idTipoUsuario)";

                //Declara o SqlCommand passando o comando(query) que vai ser executado e a conexão(con)
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //Atribui os parâmetros aos atributos passados
                    cmd.Parameters.AddWithValue("@nome", usuario.nome);
                    cmd.Parameters.AddWithValue("@email", usuario.email);
                    cmd.Parameters.AddWithValue("@senha", usuario.senha);
                    cmd.Parameters.AddWithValue("@idTipoUsuario", usuario.idTipoUsuario);

                    //Abre conexão com o banco de dados
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um usuario pelo seu id
        /// </summary>
        /// <param name="id">Id do usuario que vai ser deletado</param>
        public void Deletar(int id)
        {
            //Declara um SqlConnection passando a stringConexao como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara o comando que vai ser executado
                string queryDelete = "DELETE FROM usuarios WHERE idUsuario = @id";

                //Declara o SqlCommand passando o comando(query) que vai ser executado e a conexão(con)
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    //Atribui o valor do id passado ao parâmetro @id
                    cmd.Parameters.AddWithValue("@id", id);

                    //Abre conexão com o banco de dados
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        public List<UsuarioDomain> ListarTodos()
        {
            //Declara uma lista que vai receber os usuarios e mostrar no final
            List<UsuarioDomain> listaUsuarios = new List<UsuarioDomain>();

            //Declara uma SqlConnection passando a stringConexao como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara o comando que vai ser executado
                string querySelectAll = "SELECT idUsuario, nome, email, senha, idTipoUsuario FROM usuarios";

                //Declara o rdr pra armazenar as informações que vem do banco de dados
                SqlDataReader rdr;

                //Abre conexão com o banco de dados
                con.Open();

                //Declara um SqlCommand passando o comando(query) que vai ser executado e a conexão(con)
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //Executa a query e armazena no rdr
                    rdr = cmd.ExecuteReader();

                    //Enquanto tiver usuario para ler
                    while (rdr.Read())
                    {
                        //Atribui as informações do rdr aos parâmetros do usuario
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            nome = rdr["nome"].ToString(),
                            email = rdr["email"].ToString(),
                            senha = rdr["senha"].ToString(),
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"])
                        };

                        //Adiciona o usuario com as informações na lista de usuarios criada no começo
                        listaUsuarios.Add(usuario);
                    }

                    //Retorna uma lista de usuario
                    return listaUsuarios;
                }
            }


        }

        /// <summary>
        /// Valida o usuario
        /// </summary>
        /// <param name="email">Email do usuario</param>
        /// <param name="senha">Senha do usuario</param>
        /// <returns>O usuario buscado</returns>
        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            //Define a conexão con passando a stringConexao
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Define o comando que será executada
                string querySelect = "SELECT idUsuario, nome, email, senha, idTipoUsuario FROM usuarios WHERE email = @email AND senha = @senha";

                //Declara um SqlCommand passando o comando(query) que vai ser executado e a conexão(con)
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Executa o comando e armazena os dados no objeto rd
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        //Cria um objeto usuarioBuscado
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            //Atribui os valores das colunas as prorpiedades
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            nome = rdr["nome"].ToString(),
                            email = rdr["email"].ToString(),
                            senha = rdr["senha"].ToString(),
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"])
                        };

                        //Retorna o objeto usuarioBuscado
                        return usuarioBuscado;
                    }

                    //Caso não encontre um email e senh correspondentes, retorna null
                    return null;
                }
            }
        }
    }
}
