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
    }
}
