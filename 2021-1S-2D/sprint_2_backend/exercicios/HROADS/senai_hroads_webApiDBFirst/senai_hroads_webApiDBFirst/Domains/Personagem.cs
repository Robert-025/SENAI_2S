using System;
using System.Collections.Generic;

#nullable disable

namespace senai_hroads_webApiDBFirst.Domains
{
    public partial class Personagem
    {
        public int IdPersonagem { get; set; }
        public int? IdClasse { get; set; }
        public string Nome { get; set; }
        public byte MáxVida { get; set; }
        public byte MáxMana { get; set; }
        public DateTime DataAtualização { get; set; }
        public DateTime DataCriação { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
    }
}
