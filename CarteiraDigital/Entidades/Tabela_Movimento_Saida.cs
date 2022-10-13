using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarteiraDigital.Entidades
{
    public class Tabela_Movimento_Saida
    {
        public virtual int SAI_CODIGO { get; set; }
        public virtual int PES_CODIGO { get; set; }
        public virtual string SAI_DATA { get; set; }
        public virtual string SAI_DESCRICAO { get; set; }
        public virtual decimal SAI_VALOR { get; set; }
    }
}
