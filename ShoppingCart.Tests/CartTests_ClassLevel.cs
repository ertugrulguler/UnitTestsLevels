using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Tests
{
    [TestClass]
    public class CartTests_ClassLevel
    {

        private static CartItem _cartItem;
        private static CartManager _cartManager;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
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

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _cartManager.Clear();
        }

        [TestMethod]
        public void Sepete_farkli_urunden_1_adet_eklendiginde_toplam_urun_adedi_ve_eleman_sayisi_1_artmalidir()
        {
            //Arrange
            int toplamAdet = _cartManager.TotalQuantity;
            int toplamElemanSayisi = _cartManager.TotalItems;

            _cartItem = new CartItem
            {
                Product = new Product
                {
                    Id = 2,
                    ProductName = "Mouse",
                    UnitPrice = 100
                },
                Quantity = 1
            };

            //Act 
            _cartManager.Add(_cartItem);

            Assert.AreEqual(toplamAdet + 1, _cartManager.TotalQuantity);
            Assert.AreEqual(toplamElemanSayisi + 1, _cartManager.TotalItems);
        }

        [TestMethod]
        public void Sepette_olan_urunden_1_adet_eklendiginde_toplam_urun_adedi_ve_eleman_sayisi_ayni_kalmalidir()
        {

            int toplamAdet = _cartManager.TotalQuantity;
            int toplamElemanSayisi = _cartManager.TotalItems;

            //Act 
            _cartManager.Add(_cartItem);

            Assert.AreEqual(toplamAdet + 1, _cartManager.TotalQuantity);
            Assert.AreEqual(toplamElemanSayisi, _cartManager.TotalItems);
        }
    }
}