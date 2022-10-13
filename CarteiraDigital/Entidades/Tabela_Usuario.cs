using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarteiraDigital.Entidades
{
    public class Tabela_Usuario
    {
        public virtual int Id { get; set; }
        public virtual string Usuario { get; set; }
        public virtual string Email { get; set; }
        public virtual string Senha { get; set; }
    }
}
