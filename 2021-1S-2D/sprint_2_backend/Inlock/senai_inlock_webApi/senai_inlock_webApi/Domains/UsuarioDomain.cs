using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) usuarios
    /// </summary>
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }
        public string nome { get; set; }

        //Define que o campo é obrigatório
        [Required(ErrorMessage = "Informe o e-mail")]
        public string email { get; set; }

        //Define que o campo é obrigatório, e que tem que ter entre 3 e 20 caracteres
        [Required(ErrorMessage ="Informe a senha")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "A senha precisa ter entre 3 e 20 caracteres")]
        public string senha { get; set; }
        public int idTipoUsuario { get; set; }
    }
}
