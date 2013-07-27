namespace TWRDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class widen_tables_update : DbMigration
    {
        public override void Up()
        {
            this.AlterColumn("Reviews", "TwoWordReview", c => c.String(maxLength: 300));
            this.AlterColumn("Subjects", "Name", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {

            this.AlterColumn("Reviews", "TwoWordReview", c => c.String(maxLength: 30));
            this.AlterColumn("Subjects", "Name", c => c.String(maxLength: 30));
        }
    }
}
