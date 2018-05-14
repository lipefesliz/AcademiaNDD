using System;
using System.Collections.Generic;
using System.Data;
using DonaLaura.Domain.Features.Products;

namespace DonaLaura.Infra.Data.Features.Products
{
    public class ProductRepository : IProductRepository
    {
        #region

        private const string sqlInsertProduct =
            @"INSERT INTO TBPRODUCTS
                (NAME,
                 COSTPRICE,
                 SALEPRICE,
                 ISAVAILABLE,
                 FABRICATION,
                 EXPIRATION)
            VALUES
                ({0}NAME,
                 {0}COSTPRICE,
                 {0}SALEPRICE,
                 {0}ISAVAILABLE,
                 {0}FABRICATION,
                 {0}EXPIRATION)";

        private const string sqlDeleteProduct = @"DELETE FROM TBPRODUCTS WHERE ID = {0}ID";

        private const string sqlGetProduct = @"SELECT * FROM TBPRODUCTS WHERE ID = {0}ID";

        private const string sqlGetAllProducts = @"SELECT * FROM TBPRODUCTS";

        string sqlUpdateProduct =
            @"UPDATE TBPRODUCTS
                SET
                    NAME = {0}NAME,
                    COSTPRICE = {0}COSTPRICE,
                    SALEPRICE = {0}SALEPRICE,
                    ISAVAILABLE = {0}ISAVAILABLE,
                    FABRICATION = {0}FABRICATION,
                    EXPIRATION = {0}EXPIRATION
                WHERE ID = {0}ID";

        private const string SqlSelectProductByName = @"SELECT * FROM TBPRODUCTS WHERE NAME = {0}NAME";

        private const string sqlIsTied = @"SELECT * FROM TBSALEPRODUCTS WHERE PRODUCTID = {0}ID";

        #endregion

        public Product Add(Product entity)
        {
            entity.Validate();

            entity.Id = Db.Insert(sqlInsertProduct, GetParameters(entity));

            return entity;
        }

        public void Delete(long id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            Db.Delete(sqlDeleteProduct, parms);
        }

        public Product Get(long id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            return Db.Get(sqlGetProduct, Converter, parms);
        }

        public IList<Product> GetAll()
        {
            return Db.GetAll(sqlGetAllProducts, Converter);
        }

        public Product GetByName(string name)
        {
            var parms = new Dictionary<string, object> { { "NAME", name } };

            var result = Db.Get(SqlSelectProductByName, Converter, parms);

            return result;
        }

        public bool Exist(string name)
        {
            var parms = new Dictionary<string, object> { { "NAME", name } };

            var result = Db.Get(SqlSelectProductByName, Converter, parms);

            return result != null;
        }

        public bool IsTiedTo(long id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            var result = Db.Get(sqlIsTied, ConverterSaleProducts, parms);

            return result != null;
        }

        public Product Update(Product entity)
        {
            entity.Validate();
            
            Db.Update(sqlUpdateProduct, GetParameters(entity));

            return entity;
        }

        private static Func<IDataReader, Product> Converter = reader =>
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

        private static Func<IDataReader, Product> ConverterSaleProducts = reader =>
            new Product
            {
                Id = Convert.ToInt32(reader["ID"])
            };

        private Dictionary<string, object> GetParameters(Product product)
        {
            return new Dictionary<string, object>
            {
                { "ID", product.Id },
                { "NAME", product.Name },
                { "COSTPRICE", product.CostPrice},
                { "SALEPRICE", product.SalePrice},
                { "ISAVAILABLE", product.IsAvailable},
                { "FABRICATION", product.Fabrication},
                { "EXPIRATION", product.Expiration},
            };
        }
    }
}
