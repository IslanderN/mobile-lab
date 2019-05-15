using System.Collections.Generic;
using Xamarin.Forms;
using SQLite;
using Lab3.Entities;
using System.Linq;

namespace Lab3
{
    public class BaseRepository
    {
        SQLiteConnection database;
        public BaseRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
            database.CreateTable<StudentInfoEntity>();
        }
        public IEnumerable<StudentInfoEntity> GetItems()
        {
            return (from i in database.Table<StudentInfoEntity>() select i).ToList();

        }
        public StudentInfoEntity GetItem(int id)
        {
            return database.Get<StudentInfoEntity>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<StudentInfoEntity>(id);
        }
        public int Delete()
        {
            return database.DeleteAll<StudentInfoEntity>();
        }
        public int SaveItem(StudentInfoEntity item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
