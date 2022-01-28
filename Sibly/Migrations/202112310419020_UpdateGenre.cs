namespace Sibly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(GenreId,Name) VALUES(1,'Action')");
            Sql("INSERT INTO Genres(GenreId,Name) VALUES(2,'Adventure')");
            Sql("INSERT INTO Genres(GenreId,Name) VALUES(3,'Comedy')");
            Sql("INSERT INTO Genres(GenreId,Name) VALUES(4,'Drama')");
            Sql("INSERT INTO Genres(GenreId,Name) VALUES(5,'Romance')");
            Sql("INSERT INTO Genres(GenreId,Name) VALUES(6,'Horror')");
            Sql("INSERT INTO Genres(GenreId,Name) VALUES(7,'Family')");
        }
        
        public override void Down()
        {
        }
    }
}
