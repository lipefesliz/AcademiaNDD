using System;
using System.Collections.Generic;
using System.Data;
using DonaLaura.Domain.Features.Products;
using DonaLaura.Domain.Features.Sales;

namespace DonaLaura.Infra.Data.Features.Sales
{
    public class SaleRepository : ISaleRepository
    {
        #region QUERYS

        private const string SqlInsertSale =
            @"INSERT INTO TBSALES
                (CUSTOMER
                 ,PROFIT)
            VALUES
                ({0}CUSTOMER
                 ,{0}PROFIT)";

        private const string SqlUpdateSale =
            @"UPDATE TBSALES
                SET
                    CUSTOMER = {0}CUSTOMER,
                    PROFIT = {0}PROFIT
                WHERE ID = {0}ID";

        private const string SqlDeleteSale =
           @"DELETE FROM TBSALES
                WHERE ID = {0}ID";

        private const string SqlDeleteSaleProducts =
            @"DELETE FROM TBSALEPRODUCTS
                WHERE SALEID = {0}ID";

        private const string SqlSelectAllSales =
           @"SELECT
                ID,
                CUSTOMER,
                PROFIT
            FROM
                TBSALES ORDER BY CUSTOMER";

        private const string SqlSelectSaleById =
           @"SELECT
                ID,
                CUSTOMER,
                PROFIT
            FROM
                TBSALES
            WHERE ID = {0}ID";

        private const string SqlSelectSaleByCustomer =
           @"SELECT
                ID,
                CUSTOMER,
                PROFIT
            FROM
                TBSALES
            WHERE CUSTOMER = {0}CUSTOMER";

        private const string SqlInsertSaleProduct =
            @"INSERT INTO TBSALEPRODUCTS
                (PRODUCTID
                 ,SALEID
                 ,AMOUNT)
            VALUES
                ({0}PRODUCTID
                 ,{0}SALEID
                 ,{0}AMOUNT)";

        private const string SqlUpdateSaleProduct =
            @"UPDATE TBSALEPRODUCTS
                SET
                    PRODUCTID = {0}PRODUCTID,
                    SALEID = {0}SALEID,
                    AMOUNT = {0}AMOUNT
                WHERE ID = {0}ID";

        private const string SqlSelectAllProducts =
            @"SELECT
                TBPRODUCTS.*
            FROM
                TBSALES
                INNER JOIN TBSALEPRODUCTS ON TBSALES.ID = TBSALEPRODUCTS.SALEID
                INNER JOIN TBPRODUCTS ON TBSALEPRODUCTS.PRODUCTID = TBPRODUCTS.ID
                WHERE TBSALES.ID = {0}ID";

        #endregion QUERYS

        public Sale Add(Sale entity)
        {
            entity.Id = Db.Insert(SqlInsertSale, GetParameters(entity));

            for (int i = 0; i < entity.Products.Count; i++)
            {
                Db.Insert(SqlInsertSaleProduct, GetParameters(entity.Products[i].Id, entity.Id, entity.Amount[i]));
            }

            //foreach (var item in entity.Products)
            //{
            //    Db.Insert(SqlInsertSaleProduct, GetParameters(item.Id, entity.Id));
            //}

            return entity;
        }

        public void Delete(long id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            Db.Delete(SqlDeleteSaleProducts, parms);
            Db.Delete(SqlDeleteSale, parms);
        }

        public Sale Get(long id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            return Db.Get(SqlSelectSaleById, Converter, parms);
        }

        public IList<Sale> GetAll()
        {
            return Db.GetAll(SqlSelectAllSales, Converter);
        }

        public Sale GetByCustomer(string customer)
        {
            var parms = new Dictionary<string, object> { { "CUSTOMER", customer } };

            var result = Db.Get(SqlSelectSaleByCustomer, Converter, parms);

            return result;
        }

        public IList<Product> GetProductsFromSale(long id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            return Db.GetAll(SqlSelectAllProducts, ConverterProduct, parms);
        }

        public Sale Update(Sale entity)
        {
            Db.Update(SqlUpdateSale, GetParameters(entity));

            var parms = new Dictionary<string, object> { { "ID", entity.Id } };

            foreach (var item in entity.Products)
            {
                Db.Delete(SqlDeleteSaleProducts, parms);
            }

            for (int i = 0; i < entity.Products.Count; i++)
            {
                Db.Insert(SqlInsertSaleProduct, GetParameters(entity.Products[i].Id, entity.Id, entity.Amount[i]));
            }

            //foreach (var item in entity.Products)
            //{
            //    Db.Insert(SqlInsertSaleProduct, GetParameters(item.Id, entity.Id));
            //}

            return entity;
        }

        private Dictionary<string, object> GetParameters(Sale entity)
        {
            return new Dictionary<string, object>
            {
                { "ID", entity.Id },
                { "CUSTOMER", entity.Customer},
                { "PROFIT", entity.Profit},
            };
        }

        private Dictionary<string, object> GetParameters(int productId, int saleId, int amount)
        {
            return new Dictionary<string, object>
            {
                { "PRODUCTID", productId},
                { "SALEID", saleId},
                { "AMOUNT", amount}
            };
        }

        private static Func<IDataReader, Sale> Converter = reader =>
          new Sale
          {
              Id = Convert.ToInt32(reader["ID"]),
              Customer = Convert.ToString(reader["CUSTOMER"]),
              Profit = Convert.ToDecimal(reader["PROFIT"]),
          };

        private static Func<IDataReader, Product> ConverterProduct = reader =>
          new Product
          {
              Id = Convert.ToInt32(reader["ID"]),
              Name = Convert.ToString(reader["NAME"]),
              CostPrice = Convert.ToDecimal(reader["COSTPRICE"]),
              SalePrice = Convert.ToDecimal(reader["SALEPRICE"]),
              IsAvailable = Convert.ToBoolean(reader["ISAVAILABLE"]),
              Fabrication = Convert.ToDateTime(reader["FABRICATION"]),
              Expiration = Convert.ToDateTime(reader["EXPIRATION"]),
          };
    }
}
