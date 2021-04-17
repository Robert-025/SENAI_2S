using senai_TPeoples_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_TPeoples_webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório funcionario
    /// </summary>
    public interface IFuncionarioRepository
    {
        //TipoRetorno NomeMetodo(TipoParametro NomeParametro)

        /// <summary>
        /// Lista todos os funcionarios
        /// </summary>
        /// <returns>Uma lista de funcionarios</returns>
        List<FuncionarioDomain> ListarTodos();

        /// <summary>
        /// Busca o funcionario pelo seu id
        /// </summary>
        /// <param name="id">Id do funcionario desejado</param>
        /// <returns>O funcionario buscado pelo id</returns>
        FuncionarioDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo funcionario
        /// </summary>
        /// <param name="novoFuncionario">Funcionario que sera cadastrado</param>
        void Cadastrar(FuncionarioDomain novoFuncionario);

        /// <summary>
        /// Atualiza um funcionario existente passando o id na requisição
        /// </summary>
        /// <param name="funcionario">Funcionario com as novas informações</param>
        void AtualizarIdCorpo(FuncionarioDomain funcionario);

        /// <summary>
        /// Atualiza o funcionario existente passando o id na url da requisição
        /// </summary>
        /// <param name="id">Id do funcionario que sera atualizado</param>
        /// <param name="funcionario">Funcionario com as novas informações</param>
        void AtualizarIdUrl(int id, FuncionarioDomain funcionario);

        /// <summary>
        /// Deleta um funcionario existente
        /// </summary>
        /// <param name="id">Id do funcionario a ser deletado</param>
        void Deletar(int id);
    }
}
