using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Transactions;
using HomeTask.Core;
using TransactionScope = System.Activities.Statements.TransactionScope;

namespace HomeTask.DataAccessLayer
{
    public class DropCreateDatabaseTables : IDatabaseInitializer<HomeTaskContext>
    {
        public void InitializeDatabase(HomeTaskContext context)
        {          
            if (context.Database.Exists())
            {
                var isDatabaseMatch = context.Database.CompatibleWithModel(false);
                if (!isDatabaseMatch)
                {
                    context.Database.Delete();
                    context.Database.Create();
                }
            }
            else
            {
                context.Database.Create();
            }

        }
    }
}
