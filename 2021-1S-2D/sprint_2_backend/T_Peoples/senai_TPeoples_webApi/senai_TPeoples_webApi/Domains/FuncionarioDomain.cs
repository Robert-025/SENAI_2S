﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_TPeoples_webApi.Domains
{
    /// <summary>
    /// Classe representando a entidade (tabela) Funcionarios
    /// </summary>
    public class FuncionarioDomain
    {
        public int idFuncionario { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }   
    }
}
