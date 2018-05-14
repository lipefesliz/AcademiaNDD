using DonaLaura.Infra;

namespace DonaLaura.Common.Tests.Base
{
    public static class BaseSqlTest
    {
        /* TBProducts */
        private const string RECREATE_PRODUCT_TABLE = @"DELETE FROM [dbo].[TBProducts]";

        private const string RESET_PRODUCT_IDENTITY = @"DBCC CHECKIDENT('TBProducts', RESEED, 0)";

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

        /* TBSales */
        private const string RECREATE_SALE_TABLE = @"DELETE FROM [dbo].[TBSales]";

        private const string RESET_SALE_IDENTITY = @"DBCC CHECKIDENT('TBSales', RESEED, 0)";

        private const string INSERT_SALE =
            @"INSERT INTO TBSALES
                (CUSTOMER,
                 PROFIT)
            VALUES
                ('Juca',
                 1000)";

        /* TBSaleProducts */
        private const string RECREATE_SALE_PRODUCTS_TABLE = @"TRUNCATE TABLE [dbo].[TBSaleProducts]";

        private const string INSERT_SALE_PRODUCTS =
            @"INSERT INTO TBSALEPRODUCTS
                (PRODUCTID,
                 SALEID,
                 AMOUNT)
            VALUES
                (1,
                 1,
                 10)";

        public static void SeedDatabase()
        {
            Db.Update(RECREATE_PRODUCT_TABLE);
            Db.Update(RESET_PRODUCT_IDENTITY);
            Db.Update(INSERT_PRODUCT);

            //Db.Update(RECREATE_SALE_TABLE);
            //Db.Update(RESET_SALE_IDENTITY);
            //Db.Update(INSERT_SALE);

            //Db.Update(RECREATE_SALE_PRODUCTS_TABLE);
            //Db.Update(INSERT_SALE_PRODUCTS);
        }
    }
}
