using DonaLaura.Infra;

namespace DonaLaura.Common.Tests.Base
{
    public static class BaseSqlTest
    {
        private const string RECREATE_PRODUCT_TABLE = @"TRUNCATE TABLE [dbo].[TBProducts]";
        private const string INSERT_PRODUCT =
            @"INSERT INTO TBPRODUCTS
                (NAME,
                 COSTPRICE,
                 SALEPRICE,
                 ISAVAILABLE,
                 FABRICATION,
                 EXPIRATION)
            VALUES
                ('Sabonete',
                 2,
                 4,
                 1,
                 GETDATE(),
                 GETDATE()+GETDATE())";

        public static void SeedDatabase()
        {
            Db.Update(RECREATE_PRODUCT_TABLE);
            Db.Update(INSERT_PRODUCT);
        }
    }
}
