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
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza um TipoHabilidade passando seu id na url da requisição
        /// </summary>
        /// <param name="id">Id do TipoHabilidade que vai ser atualizado</param>
        /// <param name="tHabilidadeAtualizada">Objeto com as novas informações que serão atualizadas</param>
        public void Atualizar(int id, TipoHabilidade tHabilidadeAtualizada)
        {
            //Busca um tipo de habilidade através do id
            TipoHabilidade tipoBuscado = ctx.TipoHabilidades.Find(id);

            //Verifica se o nome do tipoHabilidade foi informado
            if (tipoBuscado.Nome != null)
            {
                //Atribui o novo valore ao campo
                tipoBuscado.Nome = tHabilidadeAtualizada.Nome;
            }

            //Atualiza o tipoHabilidade que foi buscado
            ctx.TipoHabilidades.Update(tipoBuscado);

            //Salva as informações pra serem gravadas no banco de dados 
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um TipoHabilidade pelo seu id
        /// </summary>
        /// <returns>O TipoHabilidade busc ado</returns>
        public TipoHabilidade BuscarPorId(int id)
        {
            //Retorna o primeiro Tipo de habilidade encontrado para o ID informado
            return ctx.TipoHabilidades.FirstOrDefault(t => t.IdTipo == id);
        }

        /// <summary>
        /// Cadastra um novo TipoHabilidade
        /// </summary>
        /// <param name="novoTipoHabilidade">Objeto com as informações para serem cadastradas.</param>
        public void Cadastrar(TipoHabilidade novoTipoHabilidade)
        {
            //Chama o método do EF Core que adiciona o novoTipoHabilidade
            ctx.TipoHabilidades.Add(novoTipoHabilidade);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um TipoHabilidade existente
        /// </summary>
        /// <param name="id">Id do TipoHabilidade buscado</param>
        public void Deletar(int id)
        {
            //Busca o tipo de habilidade pelo seu id
            TipoHabilidade tipoBuscado = ctx.TipoHabilidades.Find(id);

            //Remove o tipo de habilidade que foi buscado
            ctx.TipoHabilidades.Remove(tipoBuscado);

            //Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os tipos de habilidades
        /// </summary>
        /// <returns>Uma lista com todos od tipos de habilidades</returns>
        public List<TipoHabilidade> Listar()
        {
            //Retorna uma lista com todas as informações dos TipoHabilidades
            return ctx.TipoHabilidades.ToList();
        }

        /// <summary>
        /// Lista as habilidades pelo seu TipoHabilidade
        /// </summary>
        /// <returns>Uma lista de TipoHabilidades</returns>
        public List<TipoHabilidade> ListarHabilidades()
        {
            //Retorna uma lista de tipos de habilidades com suas habilidades
            return ctx.TipoHabilidades.Include(t => t.Habilidades).ToList();
        }
    }
}
