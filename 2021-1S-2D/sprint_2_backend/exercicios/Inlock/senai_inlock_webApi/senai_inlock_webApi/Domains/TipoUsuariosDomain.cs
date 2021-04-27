using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) TiposUsuario
    /// </summary>
    public class TipoUsuariosDomain
    {
        public int idTipoUsuario { get; set; }
        public string titulo { get; set; }
    }
}
