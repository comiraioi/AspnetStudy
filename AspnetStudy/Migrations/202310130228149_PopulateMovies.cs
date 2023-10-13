namespace AspnetStudy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Title, DateAdded, ReleaseDate, NumberInStock, GenreId) VALUES ('Wall-E', 2018-10-13, 2008-06-27, 5, 2)");
            Sql("INSERT INTO Movies (Title, DateAdded, ReleaseDate, NumberInStock, GenreId) VALUES ('Toy Story', 2015-02-05, 1995-12-23, 3, 4)");
            Sql("INSERT INTO Movies (Title, DateAdded, ReleaseDate, NumberInStock, GenreId) VALUES ('Salt', 2016-05-13, 2010-07-29, 1, 1)");
        }
        
        public override void Down()
        {
        }
    }
}
