using CarteiraDigital.Entidades;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarteiraDigital.Mapping
{
    public class MovimentoSaidaMap : ClassMapping<Tabela_Movimento_Saida>
    {
        public MovimentoSaidaMap()
        {
            Id(x => x.SAI_CODIGO, x =>
            {
                x.Generator(Generators.Increment);
                x.Type(NHibernateUtil.Int32);
                x.Column("SAI_CODIGO");
            });

            Property(b => b.PES_CODIGO, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });
            Property(b => b.SAI_DATA, x =>
            {
                x.Type(NHibernateUtil.DateTime);
                x.NotNullable(true);
            });
            Property(b => b.SAI_DESCRICAO, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
            });
            Property(b => b.SAI_VALOR, x =>
            {
                x.Type(NHibernateUtil.Decimal);
            });
            Table("Tabela_Movimento_Saida");
        }
    }
}