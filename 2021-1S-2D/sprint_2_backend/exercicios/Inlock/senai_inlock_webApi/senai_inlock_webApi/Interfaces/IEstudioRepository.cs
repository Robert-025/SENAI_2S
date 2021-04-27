using senai_inlock_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webApi.Interfaces
{
    interface IEstudioRepository
    {
        /// <summary>
        /// Lista todos os estudios cadastrados
        /// </summary>
        /// <returns>A lista com todos os estudios</returns>
        List<EstudioDomain> ListarTodos();

        /// <summary>
        /// Busca um estúdio pelo seu id
        /// </summary>
        /// <param name="id">Id do estúdio procurado</param>
        /// <returns>O estúdio procurado</returns>
        EstudioDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="novoEstudio">Estúdio que será cadastrado</param>
        void Cadastrar(EstudioDomain novoEstudio);

        /// <summary>
        /// Atualiza um estúdio existente passando seu id na url da requisição
        /// </summary>
        /// <param name="id">Id do estúdio a ser atualizado</param>
        /// <param name="estudio">Estúdio com as novas informações</param>
        void AtualizarIdUrl(int id, EstudioDomain estudio);

        /// <summary>
        /// Deleta um estúdio existente
        /// </summary>
        /// <param name="id">Id do estúdio que vai ser deletado</param>
        void Deletar(int id);
    }
}
