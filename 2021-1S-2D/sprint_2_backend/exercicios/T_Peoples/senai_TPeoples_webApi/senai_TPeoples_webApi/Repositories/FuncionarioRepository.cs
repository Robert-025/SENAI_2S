using senai_TPeoples_webApi.Domains;
using senai_TPeoples_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_TPeoples_webApi.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {

        /// <summary>
        /// Variável criada para ter a conexão com o banco de dados, recebendo os parâmetros
        /// Data Source = Nome do servido
        /// initial catalog : Nome do banco de dados
        /// user id = Login do usuário do SQL; pwd = Senha do usuário do SQL; Os dois fazem a autenticação com o SQL server
        /// </summary>
        private string stringConexao = "Data Source=ROBERT-025; initial catalog=T_Peoples; user id=sa; pwd=senai@132";

        public void AtualizarIdCorpo(FuncionarioDomain funcionario)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Atualiza um funcionario passando o id na url
        /// </summary>
        /// <param name="id">Id do funcionário que será atualizado</param>
        /// <param name="funcionario">Objeto com as novas informações</param>
        public void AtualizarIdUrl(int id, FuncionarioDomain funcionario)
        {
            //Declara a conexão con passando a stringConexao como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query que será executada
                string queryUpdateIdUrl = "UPDATE funcionarios SET nome = @nome, sobrenome = @sobrenome WHERE idFuncionario = @idFuncionario";

                //Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    //Pega os valores da query e passa para os parâmetros
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nome", funcionario.nome);
                    cmd.Parameters.AddWithValue("sobrenome", funcionario.sobrenome);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca o funcionario pelo seu id
        /// </summary>
        /// <param name="id">Id do funcionario que vai ser buscado</param>
        /// <returns>Retorna o funcionario buscado ou null</returns>
        public FuncionarioDomain BuscarPorId(int id)
        {
            //Declara a conexão con passando a stringConexao como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query que será executada
                string querySelectById = "SELECT idFuncionario, nome, sobrenome FROM funcionarios WHERE idFuncionario = @id";

                //Abrimos a conexão com o banco de dados
                con.Open();
                
                //Declara o SqlDataReader rdr para receber os valores do banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    //Passa o valor para o parâmetro @id
                    cmd.Parameters.AddWithValue("@id", id);

                    //Executa a query e armazena no rdr
                    rdr = cmd.ExecuteReader();

                    //Verifica se o resultado da query retornou algum registro
                    if (rdr.Read())
                    {
                        //Instaciamos um novo objeto funcionario
                        FuncionarioDomain funcionarioBuscado = new FuncionarioDomain()
                        {
                            //Atribui às propriedades do funcionario os valores da tabela do banco de dados
                            idFuncionario = Convert.ToInt32(rdr["idFuncionario"]),
                            nome = rdr["nome"].ToString(),
                            sobrenome = rdr["sobrenome"].ToString()
                        };

                        //Caso o if execute, retorna o funcionario buscado
                        return funcionarioBuscado;
                    }

                    //Caso não entre no if, retorna null
                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastra um novo funcionario
        /// </summary>
        /// <param name="novoFuncionario">Obbjeto novoFuncionario com as informações que serão cadastradas</param>
        public void Cadastrar(FuncionarioDomain novoFuncionario)
        {
            //Declara a conexão con passando a stringConexao como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query que sera executada passando os parâmetros como valores que serão inseridos
                string queryInsert = "INSERT INTO funcionarios(nome, sobrenome) VALUES(@nome, @sobrenome)";

                //Declara o SqlCommand cmd passando a query que será executando e a conexão con como parâmetro
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //Passa o valor para o parâmetro @nome
                    cmd.Parameters.AddWithValue("@nome", novoFuncionario.nome);

                    //Passa o valor para o parâmetro @sobrenome 
                    cmd.Parameters.AddWithValue("@sobrenome", novoFuncionario.sobrenome);

                    //Abre a conexão com a banco de dados
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }   
        }
          
        /// <summary>
        /// Deleta um funcionário pelo seu id
        /// </summary>
        /// <param name="id">Id do funcionário que será deletado</param>
        public void Deletar(int id)
        {
            //Declarando a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query que vai ser executada passando o parâmetro @id
                string queryDelete = "DELETE FROM funcionarios WHERE idFuncionario = @id";

                //Declara o SqlCommand passando a query e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    //Define o valor que foi recebido como o valor do parâmetro @id
                    cmd.Parameters.AddWithValue("@id", id);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Executa a query desejada
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FuncionarioDomain> ListarTodos()
        {
            //Cria uma lista para armazenar os dados
            List<FuncionarioDomain> listaFuncionarios = new List<FuncionarioDomain>();

            //Declarando a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a instrução que vai ser executada
                string querySelectAll = "SELECT idFuncionario, nome, sobrenome FROM funcionarios";

                //Abre a conexão com o banco de dados
                con.Open();

                //Declara o SqlDataReader rdr pra percorrer a tabela no banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand passando a query e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //Enquanto houver linhas pra ser lidas, o laço se repete
                    while (rdr.Read())
                    {
                        //Instancia um objeto do tipo FuncionarioDomain
                        FuncionarioDomain funcionario = new FuncionarioDomain()
                        {
                            //Atribui às propriedades do funcionario os valores da tabela do banco de dados
                            idFuncionario = Convert.ToInt32(rdr["idFuncionario"]),
                            nome = rdr["nome"].ToString(),
                            sobrenome = rdr["sobrenome"].ToString()
                        };

                        //Atribui o objeto funcionario a listaFuncionarios já criada
                        listaFuncionarios.Add(funcionario);

                        
                    }
                }
            }

            return listaFuncionarios;
        }
    }
}

