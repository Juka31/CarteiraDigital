using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using NHibernate;
using CarteiraDigital.Entidades;

namespace CarteiraDigital.Ropositorio
{
    public class UsuariosRepositorio : IRepository<Tabela_Usuario>
    {

        private ISession _session;
        public UsuariosRepositorio(ISession session) => _session = session;
        public async Task Add(Tabela_Usuario item)
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

        public IEnumerable<Tabela_Usuario> FindAll() => _session.Query<Tabela_Usuario>().ToList();

        internal void Add(Microsoft.AspNetCore.Http.IFormCollection collection)
        {
            throw new NotImplementedException();
        }

        public async Task<Tabela_Usuario> FindByID(int id) => await _session.GetAsync<Tabela_Usuario>(id);

        public async Task Remove(int id)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                var item = await _session.GetAsync<Tabela_Usuario>(id);
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

        public async Task Update(Tabela_Usuario item)
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