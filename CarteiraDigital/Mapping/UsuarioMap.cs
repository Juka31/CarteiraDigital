using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NHibernate;
using NHibernate.Mapping.ByCode;
using CarteiraDigital.Entidades;

namespace CarteiraDigital.Mapping
{
    public class UsuariosMap : ClassMapping<Tabela_Usuario>
    {
        public UsuariosMap()
        {
            Id(x => x.Id, x =>
            {
                x.Generator(Generators.Increment);
                x.Type(NHibernateUtil.Int32);
                x.Column("Id");

            });
            Property(b => b.Usuario, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);

            });
            Property(b => b.Email, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Property(b => b.Senha, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });

        }
    }
}
