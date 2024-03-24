namespace Movie_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConstrintsToCustomerName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String());
        }
    }
}
