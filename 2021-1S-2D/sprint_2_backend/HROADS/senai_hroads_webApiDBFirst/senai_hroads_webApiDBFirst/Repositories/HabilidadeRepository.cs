using Microsoft.EntityFrameworkCore;
using senai_hroads_webApiDBFirst.Contexts;
using senai_hroads_webApiDBFirst.Domains;
using senai_hroads_webApiDBFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_webApiDBFirst.Repositories
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza uma habilidade
        /// </summary>
        /// <param name="id">Id da habilidade que vai ser atualizada</param>
        /// <param name="habilidadeAtualizada">Objeto com as informações que vão ser atualizadas</param>
        public void Atualizar(int id, Habilidade habilidadeAtualizada)
        {
            //Cria um objeto que recebe o resultado da busca da habilidade pelo id
            Habilidade habilidadeBuscada = ctx.Habilidades.Find(id);

            //Verifica se existe algum nome informado
            if (habilidadeAtualizada.Nome != null)
            {
                //Caso haja, passa as informações para a habilidadeBuscada
                habilidadeBuscada.Nome = habilidadeAtualizada.Nome;
            }

            //Verifica se existe algum idTipo informado
            if (habilidadeAtualizada.IdTipo > 0)
            {
                //Caso haja, passa as informações para a habilidadeBuscada
                habilidadeBuscada.IdTipo = habilidadeAtualizada.IdTipo;
            }

            //Atualiza a habilidadeBuscada
            ctx.Habilidades.Update(habilidadeBuscada);

            //Salva as informações para mandar para o banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista uma habilidade buscando pelo seu id
        /// </summary>
        /// <param name="id">Id da habilidade que será buscada</param>
        /// <returns>A habilidade buscada</returns>
        public Habilidade BuscarPorId(int id)
        {
            // Retorna a primeira informação encontrada para o ID informado
            return ctx.Habilidades.FirstOrDefault(h => h.IdHabilidade == id);
        }

        public void Cadastrar(Habilidade novaHabilidade)
        {
            //Adiciona a novaHabilidade 
            ctx.Habilidades.Add(novaHabilidade);

            //Salva as informações para serem inseridas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma habilidade 
        /// </summary>
        /// <param name="id">Id da habilidade que será deletada</param>
        public void Deletar(int id)
        {
            //Cria um objeto recebendo a informação buscada pelo ctx
            Habilidade habilidadeBuscada = ctx.Habilidades.Find(id);

            //Remove a habilidade buscada
            ctx.Habilidades.Remove(habilidadeBuscada);

            //Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista uma lista com as habilidades
        /// </summary>
        /// <returns>Uma lista de habilidades</returns>
        public List<Habilidade> Listar()
        {
            //Retorna o comando para listar as habilidades
            return ctx.Habilidades.ToList();
        }

        /// <summary>
        /// Lista as habilidade mjunto com os seus tipos 
        /// </summary>
        /// <returns>Uma lista de habilidade com seus tipos de habilidades</returns>
        public List<Habilidade> ListarTipoHabilidade()
        {
            return ctx.Habilidades.Include(h => h.IdTipoNavigation).ToList();
        }
    }
}
