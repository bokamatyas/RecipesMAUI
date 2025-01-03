using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public class RecipeDataBase
    {
        static SQLiteAsyncConnection? Database;

        async static Task Init()
        {
            try
            {
                if (Database is not null)
                    return;
                Database = new SQLiteAsyncConnection(DataBaseConstants.DatabasePath, DataBaseConstants.Flags);
                var result = await Database.CreateTableAsync<RecipeDataModel>();
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine(ex);
#endif
                return;
            }
        }

    }
}
