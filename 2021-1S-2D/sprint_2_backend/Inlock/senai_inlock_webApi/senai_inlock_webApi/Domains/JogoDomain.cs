using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) jogos
    /// </summary>
    public class JogoDomain
    {
        public int idJogo { get; set; }

        //Define que o campo é obrigatório
        [Required(ErrorMessage = "O nome do jogo é obrigatório")]
        public string nomeJogo { get; set; }

        public string descricao { get; set; }

        //Required: define que o campo é obrigatório
        //DataType: não valida o campo, apenas específica o tipo do campo que vai armazenar
        [Required(ErrorMessage = "Informe a data de lançamento")]
        [DataType(DataType.Date)]
        public DateTime dataLancamento { get; set; }

        //Defini que o campo é obrigatório
        [Required(ErrorMessage = "O valor do jogo é obrigatório")]
        public decimal valor { get; set; }

        //Define que o campo é obrigatório
        [Required(ErrorMessage = "O identificador do estudio criador do jogo é obrigatório")]
        public int idEstudio { get; set; }
    }
}
