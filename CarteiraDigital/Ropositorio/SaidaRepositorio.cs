using CarteiraDigital.Entidades;
using Microsoft.AspNetCore.Http;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISession = NHibernate.ISession;

namespace CarteiraDigital.Ropositorio
{
    public class SaidaRepositorio : IRepositoyEntrada<Tabela_Movimento_Saida>
    {
        private ISession _session;
        public SaidaRepositorio(ISession session) => _session = session;
        public async Task Add(Tabela_Movimento_Saida item)
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

        public IEnumerable<Tabela_Movimento_Saida> FindAll() => _session.Query<Tabela_Movimento_Saida>().ToList();

        public async Task<Tabela_Movimento_Saida> FindByID(int id) => await _session.GetAsync<Tabela_Movimento_Saida>(id);

        public async Task Remove(int id)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                var item = await _session.GetAsync<Tabela_Movimento_Saida>(id);
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

        public async Task Update(Tabela_Movimento_Saida item)
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