using SQLite;

namespace Maui_WorkingDemo
{
    public class LocalDbService
    {
        private const string DB_NAMe = "local_contacts_db.db3";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAMe));
            _connection.CreateTableAsync<Contacts>();
        }

        public async Task<List<Contacts>> GetCustomers()
        {
            return await _connection.Table<Contacts>().ToListAsync();
        }

        public async Task<Contacts> GetById(int Id)
        {
            return await _connection.Table<Contacts>().Where(x=>x.Id==Id).FirstOrDefaultAsync();
        }

        public async Task Create (Contacts contact)
        {
            await _connection.InsertAsync(contact);
        }

        public async Task Update(Contacts contact)
        {
            await _connection.UpdateAsync(contact);
        }

        public async Task Delete (Contacts contact)
        {
            await _connection.DeleteAsync(contact);
        }
    }
}
