using senai_inlock_webApi.Domains;
using senai_inlock_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        /// <summary>
        /// Váriavel criada para ter a conexão com o banco de dados, recebendo os parâmetros
        /// </summary>
        private string stringConexao = "Data Source=ROBERT-025; initial catalog=Inlock_Games_Tarde; user id=sa; pwd=senai@132";

        public void AtualizarIdUrl(int id, EstudioDomain estudio)
        {
            //Declara a SqlConnection con passando como parâmetro a stringConexao
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara o comando que vai ser executado
                string queryUpdateIdUrl = "UPDATE estudios SET nomeEstudio = @nomeEstudio WHERE idEstudio = @id";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    //Pega os valores da query e passa para os parâmetros
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nomeEstudio", estudio.nomeEstudio);

                    //Abre conexão com o banco de dados
                    con.Open();

                    //Executa o comando(query) indicado na criação do SqlCommand
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public EstudioDomain BuscarPorId(int id)
        {
            //Declara a SqlConnection passando a stringConexao como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara o comando que vai ser executado
                string querySelectById = "SELECT idEstudio, nomeEstudio FROM estudios WHERE idEstudio = @id";

                //Abre conexão com o banco de dados
                con.Open();

                //Declara a variável que vai receber os dados do banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand passando o comando(query) que vai ser executado e a conexão(con) como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    //Passa o valor do id para o parâmetro @id
                    cmd.Parameters.AddWithValue("@id", id);

                    //Executa a query e armazena no rdr
                    rdr = cmd.ExecuteReader();

                    //Verifica se o resultado da query retornou algum registro com o id colocado
                    if (rdr.Read())
                    {
                        //Intaciamos um objeto estudio
                        EstudioDomain estudioBuscado = new EstudioDomain()
                        {
                            //Atribui às propriedades do estudio aos valores da tabela do banco de dados 
                            idEstudio = Convert.ToInt32(rdr["idEstudio"]),
                            nomeEstudio = rdr["nomeEstudio"].ToString()
                        };

                        //Caso  if seja verdadeiro e execute, retorna o estudio buscado
                        return estudioBuscado;
                    }

                    //Caso o if não execute, retorna null
                    return null;
                }
            }
        }

        public void Cadastrar(EstudioDomain novoEstudio)
        {
            //Declara a SqlConnection con passando a stringConexao como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara o comando(query) que vai ser executado
                string queryInsert = "INSERT INTO estudios(nomeEstudio) VALUES(@nomeEstudio)";

                //Declara o SqlCommand(cmd) passando o comando(query) e a conexão(con) como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //Passa o valor para o parâmetro @nomeEstudio
                    cmd.Parameters.AddWithValue("nomeEstudio", novoEstudio.nomeEstudio);

                    //Abre conexão com o banco de dados
                    con.Open();

                    //Executa a query passada na SqlCommand
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            //Declara a SqlConnection con passando a stringConexao como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara o comando(query) que vai ser executada passando como parâmetro @id
                string queryDelete = "DELETE FROM estudios WHERE idEstudio= @id";

                //Declara o SqlCommand passando o comando(query) que vai ser executad e a conexão(con) como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    //Define o valor que foi recebido como o valor do parâmetro @id
                    cmd.Parameters.AddWithValue("@id", id);

                    //Abre conexão com banco de dados
                    con.Open();

                    //Executa a query passada no SqlCommand
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EstudioDomain> ListarTodos()
        {
            //Cria uma lista pra armazenar os dados
            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();

            //Declara a SqlConnection con passando a stringConexao como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara o que vai ser executado
                string querySelectAll = "SELECT idEstudio, nomeEstudio FROM estudios";

                //Abre conexão com o banco de dados
                con.Open();

                //Declara o rdr pra percorrer a tablea no banco de dados
                SqlDataReader rdr;

                //Delcara o cmd passando o que vai ser executado(query) e a conexão(con) como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //Executa a query e armazena no rdr
                    rdr = cmd.ExecuteReader();

                    //Enquanto tiver linhas pra ler, o laço repete
                    while (rdr.Read())
                    {
                        //Instancia um objeto do tipo EstudioDomain
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            //Atribui as propriedades do estudio aos valores da tabela do banco de dados
                            idEstudio = Convert.ToInt32(rdr["idEstudio"]),
                            nomeEstudio = rdr["nomeEstudio"].ToString()
                        };

                        //Atribui o objeto estudio a listaEstudio já criada
                        listaEstudios.Add(estudio);
                    }
                }
            }
            return listaEstudios;
        }
    }
}
