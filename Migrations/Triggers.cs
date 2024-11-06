using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System.Data.Entity.Migrations;

namespace BookStore.Migrations
{
    public partial class Triggers : DbMigration
    {
        public override void Up()
        {
            Sql("CREATE TRIGGER TRG_PreventDropDB ON ALL SERVER " +
                "FOR DROP_DATABASE AS BEGIN " +
                "    RAISERROR('You cannot drop databases on this server.', 16,1)" +
                "    ROLLBACK; " +
                "END");
        }

        public override void Down()
        {
            Sql("DROP TRIGGER TRG_PreventDropDB");
        }
    }
}
