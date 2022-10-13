using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using NHibernate;
using CarteiraDigital.Ropositorio;
using CarteiraDigital.Entidades;

namespace CarteiraDigital.Repositorio
{
    public class PessoasRepositorio: IRepository<Tabela_Pessoas>
    {
        private ISession _session;
        public PessoasRepositorio(ISession session) => _session = session;

        internal static object tolist()
        {
            throw new NotImplementedException();
        }

        public async Task Add(Tabela_Pessoas item)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                await _session.SaveAsync(item);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await transaction?.RollbackAsync();
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        internal static object AsQueryable()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tabela_Pessoas> FindAll() => _session.Query<Tabela_Pessoas>().ToList();

        public async Task<Tabela_Pessoas> FindByID(int pes_codigo) => await _session.GetAsync<Tabela_Pessoas>(pes_codigo);

        public async Task Remove(int pes_codigo)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                var item = await _session.GetAsync<Tabela_Pessoas>(pes_codigo);
                await _session.DeleteAsync(item);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await transaction?.RollbackAsync();
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        public async Task Update(Tabela_Pessoas item)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                await _session.UpdateAsync(item);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await transaction?.RollbackAsync();
            }
            finally
            {
                transaction?.Dispose();
            }
        }
    }
}
