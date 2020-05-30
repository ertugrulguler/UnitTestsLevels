using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingCart.Tests
{
    [TestClass]
    public class CartTests_TestingLevel
    {
        private CartManager _cartManager;
        private CartItem _cartItem;
        [TestInitialize]
        public void TestInitialeze()
        {
            _cartManager = new CartManager();
            _cartItem = new CartItem
            {
                Product = new Product
                {
                    Id = 1,
                    ProductName = "Laptop",
                    UnitPrice = 2500
                },
                Quantity = 1
            };

            //Act 
            _cartManager.Add(_cartItem);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _cartManager.Clear();
        }


        [TestMethod]
        public void Sepete_urun_eklenebilmelidir()
        {
            //Arrange 
            int beklenen = 1;
            #region eski

            //var cartManager = new CartManager();
            //var cartItem = new CartItem
            //{
            //    Product = new Product
            //    {
            //        Id=1,
            //        ProductName="Laptop",
            //        UnitPrice=2500
            //    },
            //    Quantity=1
            //};

            ////Act 
            //cartManager.Add(cartItem); 
            #endregion
            var totalCount = _cartManager.TotalItems;
            #region eski
            //cartManager.TotalItems; 
            #endregion

            //Assert
            Assert.AreEqual(beklenen, totalCount);
        }

        [TestMethod]
        public void Sepetten_urun_cikarilabilmelidir()
        {
            //Arrange 

            #region eski

            //var cartManager = new CartManager();
            //var cartItem = new CartItem
            //{
            //    Product = new Product
            //    {
            //        Id = 1,
            //        ProductName = "Laptop",
            //        UnitPrice = 2500
            //    },
            //    Quantity = 1
            //};

            #endregion
            ////Act 
            //cartManager.Add(cartItem);
            var sepettekiElemanSayisi = _cartManager.TotalItems;

            _cartManager.Remove(1);
            var kalanElemanSayisi = _cartManager.TotalItems;


            //Assert
            Assert.AreEqual(sepettekiElemanSayisi-1, kalanElemanSayisi);
        }

        [TestMethod]
        public void Sepet_temizlenebilmelidir()
        {
            //Arrange 
            #region eski

            //var cartManager = new CartManager();
            //var cartItem = new CartItem
            //{
            //    Product = new Product
            //    {
            //        Id = 1,
            //        ProductName = "Laptop",
            //        UnitPrice = 2500
            //    },
            //    Quantity = 1
            //}; 
            #endregion

            ////Act 
            //cartManager.Add(cartItem);

            _cartManager.Clear();

            //Assert
            Assert.AreEqual(0, _cartManager.TotalQuantity);
            Assert.AreEqual(0, _cartManager.TotalItems);
        }




    }
}
