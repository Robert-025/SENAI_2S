﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) estudios
    /// </summary>
    public class EstudioDomain
    {
        public int idEstudio { get; set; }

        [Required(ErrorMessage  = "O nome do estudio é obrigatório")]
        public string nomeEstudio { get; set; }
    }
}
