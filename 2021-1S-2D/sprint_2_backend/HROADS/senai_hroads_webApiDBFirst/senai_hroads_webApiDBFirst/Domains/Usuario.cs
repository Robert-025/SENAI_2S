using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_hroads_webApiDBFirst.Domains
{
    public partial class Usuario
    {
        public int IdUsuarios { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo senha deve ser informado")]
        [StringLength(50, MinimumLength = 5, ErrorMessage ="A senha deverá conter de 5 a 50 caracteres.")]

        public string Senha { get; set; }
        public int? IdTiposUsuarios { get; set; }

        public virtual TiposUsuario IdTiposUsuariosNavigation { get; set; }
    }
}
