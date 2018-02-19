using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinTest2.objects;

namespace XamarinTest2.util
{
    public class SQLiteClient
    {

        readonly SQLiteAsyncConnection database;

        public SQLiteClient(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Post>().Wait();
        }

        public Task<List<Post>> GetItemsAsync()
        {
            return database.Table<Post>().ToListAsync();
        }

        public Task<Post> GetItemAsync(string id)
        {
            return database.Table<Post>().Where(i => i.ID.ToString() == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Post post)
        {
            if (!post.ID.ToString().Equals("0"))
            {
                return database.UpdateAsync(post);
            }
            else
            {
                return database.InsertAsync(post);
            }
        }

        public Task<int> DeleteItemAsync(Post post)
        {
            return database.DeleteAsync(post);
        }
    }
}
