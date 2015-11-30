using Infrastructor.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructor.MigrationInitialize
{
    public class MigrateDbInitializer : MigrateDatabaseToLatestVersion<UnitOfWork,Configuration>
    {
    }
}
