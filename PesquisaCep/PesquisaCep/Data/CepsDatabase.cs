using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Ceps.Models;

namespace Ceps.Data
{
    public class CepsDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public CepsDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<CepModel>().Wait();
        }

        public Task<List<CepModel>> GetNotesAsync()
        {
            return _database.Table<CepModel>().ToListAsync();
        }

        public Task<CepModel> GetCepAsync(string cep)
        {
            return _database.Table<CepModel>()
                            .Where(i => i.Cep == cep)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveCepAsync(CepModel cep)
        {
            if (cep.Cep != "0")
            {
                return _database.UpdateAsync(cep);
            }
            else
            {
                return _database.InsertAsync(cep);
            }
        }

        public Task<int> DeleteCepAsync(CepModel cep)
        {
            return _database.DeleteAsync(cep);
        }
    }
}
