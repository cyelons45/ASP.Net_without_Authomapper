namespace Sibly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes(MembershipTypeId,SignUpFee,DurationInMonths,DiscountRate,Name) VALUES(1,0,0,0,'Pay as you go')");
            Sql("INSERT INTO MembershipTypes(MembershipTypeId,SignUpFee,DurationInMonths,DiscountRate,Name) VALUES(2,30,1,10,'Monthly')");
            Sql("INSERT INTO MembershipTypes(MembershipTypeId,SignUpFee,DurationInMonths,DiscountRate,Name) VALUES(3,90,3,15,'Quarterly')");
            Sql("INSERT INTO MembershipTypes(MembershipTypeId,SignUpFee,DurationInMonths,DiscountRate,Name) VALUES(4,300,12,20,'Annual')");
      
        }
        
        public override void Down()
        {
        }
    }
}
