using senai_inlock_webApi.Domains;
using senai_inlock_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string stringConexao = "Data Source=ROBERT-025; initial catalog=Inlock_Games_Tarde; user id=sa; pwd=senai@132";

        public void AtualizarIdUrlPut(int id, JogoDomain jogo)
        {
            //Declara um SqlConnection con passando a conexão com o banco de dados(stringConexao)
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara o comando que vai ser executado
                string queryUpdateIdUrl = "UPDATE jogos SET nomeJogo = @nomeJogo,  descricao = @descricao, dataLancamento = @data, valor = @valor, idEstudio = @idEstudio WHERE idJogo = @idJogo";

                //Declara o SqlCOmmand cmd passando como parâmetro o comando(query) que vai ser executado e a conexão(con)
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    //Atribui os valores passados para as variáveis do jogo, criado no começo
                    cmd.Parameters.AddWithValue("@nomeJogo", jogo.nomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", jogo.descricao);
                    cmd.Parameters.AddWithValue("@data", jogo.dataLancamento);
                    cmd.Parameters.AddWithValue("@valor", jogo.valor);
                    cmd.Parameters.AddWithValue("@idEstudio", jogo.idEstudio);
                    cmd.Parameters.AddWithValue("@idJogo", id);

                    //Abre conexão com o banco de dados
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public JogoDomain BuscarPorId(int id)
        {
            //Declara a SqlConnection con passando a conexão(stringConexao) com o banco de dados como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara o comando que vai ser executado
                string querySelectById = "SELECT nomeJogo, descricao, dataLancamento, valor, idEstudio FROM jogos WHERE idJogo = @idJogo";

                //Abre conxão com o banco de dados
                con.Open();

                //Declara o SqlDataReader para ler e armazenar as informações que vem do banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand cmd passando o comando(query) que vai ser executado e a conexão(stringConexao)
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    //Atribui o valor do id passado ao parâmtro @idJogo
                    cmd.Parameters.AddWithValue("@idJogo", id);

                    //Armazena os valores no rdr
                    rdr = cmd.ExecuteReader();

                    //Verifica se existe algum jogo com o id passado
                    if (rdr.Read())
                    {
                        //Caso tenha, instancia um objeto do tipo JogoDomain
                        JogoDomain jogoBuscado = new JogoDomain()
                        {
                            //Atribui às propriedades do jogo que estavam no rdr aos valores da tabela do banco de dados 
                            nomeJogo = rdr["nomeJogo"].ToString(),
                            descricao = rdr["descricao"].ToString(),
                            dataLancamento = Convert.ToDateTime(rdr["dataLancamento"]),
                            valor = Convert.ToDecimal(rdr["valor"]),
                            idEstudio = Convert.ToInt32(rdr["idEstudio"])
                        };

                        //Caso o if execute, retorna com o jogo buscado
                        return jogoBuscado;
                    }

                    //Caso não tenha nenhum jogo com o id pedido e não execute o if, retorna null
                    return null;
                }
            }
        }

        public void Cadastrar(JogoDomain jogo)
        {
            //Declara uma SqlConnection con passando a conexão com o banco(stringConexao) como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara o comando que vai ser executado
                string queryInsert = "INSERT INTO jogos(nomeJogo, descricao, dataLancamento, valor, idEstudio) VALUES(@nomeJogo, @descricao, @dataLancamento, @valor, @idEstudio)";

                //Declara uma SqlCommand cmd passando o comando(query) que vai ser executado e a conexão(con) com o banco de dados
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //Passa os valores passados para os parâmetros
                    cmd.Parameters.AddWithValue("@nomeJogo", jogo.nomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", jogo.descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", jogo.dataLancamento);
                    cmd.Parameters.AddWithValue("@valor", jogo.valor);
                    cmd.Parameters.AddWithValue("@idEstudio", jogo.idEstudio);

                    //Abre conexão com o banco de dados
                    con.Open();

                    //Executa a query 
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            //Declara a SqlConnection con passando a stringConexao como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara o comando que vai ser executado
                string queryDelete = "DELETE FROM jogos WHERE idjogo = @id";

                //Declara o SqlCommand cmd passando o comnado(query) e a conexão(con) como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    //Atribui o id Colocado na url ao parâmetro @id da query
                    cmd.Parameters.AddWithValue("@id", id);

                    //Abre conexão com o banco de dados
                    con.Open();

                    //Executa o comando(query) passado no SqlCommand
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> ListarTodos()
        {
            //Cria uma lista para amazenar os dados
            List<JogoDomain> listaJogos = new List<JogoDomain>();

            //Cria uma SqlConnection con passando a stringConexao como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara o comando que vai ser executado
                string querySelectAll = "SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, idEstudio FROM jogos";

                //Declara um SqlDataReader que vai receber os dados pedidos do banco de dados
                SqlDataReader rdr;

                //Abre conexão com o baco de dados
                con.Open();

                //Declara o SqlCommand cmd passando o comando(query) que vai ser executado e a conexão(con) com o banco de dados
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //Executa a query e armazena no rdr
                    rdr = cmd.ExecuteReader();

                    //Enquanto tiver linhas para ler
                    while (rdr.Read())
                    {
                        //Instancia um objeto do tipo JogoDomain para receber as informações 
                        JogoDomain jogo = new JogoDomain()
                        {
                            //Atribui as propriedades do Jogo aos valores do banco de dados
                            idJogo = Convert.ToInt32(rdr["idJogo"]),
                            nomeJogo = rdr["nomeJogo"].ToString(),
                            descricao = rdr["descricao"].ToString(),
                            dataLancamento = Convert.ToDateTime(rdr["dataLancamento"]),
                            valor = Convert.ToDecimal(rdr["valor"]),
                            idEstudio = Convert.ToInt32(rdr["idEstudio"])
                        };

                        //Adiciona o jogo com as informações na listaJogos criada no começo
                        listaJogos.Add(jogo);
                    }

                    //Retorna a lista com todos os jogos
                    return listaJogos;
                }
            }    
        }
    }
}
