using System;
using System.Collections.Generic;

#nullable disable

namespace senai_hroads_webApiDBFirst.Domains
{
    public partial class Classe
    {
        public Classe()
        {
            Personagems = new HashSet<Personagem>();
        }

        public int IdClasse { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Personagem> Personagems { get; set; }
    }
}
