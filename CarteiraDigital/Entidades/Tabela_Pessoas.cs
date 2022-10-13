using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CarteiraDigital.Entidades
{
    public class Tabela_Pessoas
    {

        [DisplayName("#ID")]
        public virtual int PES_CODIGO { get; set; }
        [DisplayName("Nome")]
        public virtual string PES_NOME { get; set; }
        [DisplayName("Email")]
        public virtual string PES_EMAIL { get; set; }
        [DisplayName("Salário")]
        public virtual decimal PES_SALARIO { get; set; }
        [DisplayName("Limite de Segurança")]
        public virtual decimal PES_LIMITE { get; set; }
        [DisplayName("Mínimo")]
        public virtual decimal PES_MINIMO { get; set; }
        [DisplayName("Saldo")]
        public virtual decimal PES_SALDO { get; set; }
    }
}
