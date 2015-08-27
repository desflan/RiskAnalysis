namespace RiskAnalysis.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(),
                        AverageBet = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SettledBet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Win = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        ParticipantId = c.Int(nullable: false),
                        Stake = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.UnsettledBet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ToWin = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        ParticipantId = c.Int(nullable: false),
                        Stake = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UnsettledBet", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.SettledBet", "CustomerId", "dbo.Customer");
            DropIndex("dbo.UnsettledBet", new[] { "CustomerId" });
            DropIndex("dbo.SettledBet", new[] { "CustomerId" });
            DropTable("dbo.UnsettledBet");
            DropTable("dbo.SettledBet");
            DropTable("dbo.Customer");
        }
    }
}
