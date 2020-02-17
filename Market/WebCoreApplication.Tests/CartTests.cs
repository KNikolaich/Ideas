using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCoreApplication.Models;
using WebCoreApplication.Tests.FakeAndMock;
using Xunit;

namespace WebCoreApplication.Tests
{
    public class CartTests
    {

        [Fact]
        public void Can_Add_New_Lines()
        {
            var repository = new ModelCompleteFakeRepository();
            var target = new Cart();

            short s = 0;
            foreach(var p in repository.Products)
            {
                target.AddItem(p, s++);
            }

            var result = target.Lines.ToList();

            Assert.Equal(s, result.Count); // сколько добавляли, столько и добавили
            Assert.Equal("Kayak", result[0].Product.Name);
            Assert.Equal("Lamp on table", result[result.Count-1].Product.Name);
        }

        [Fact]
        public void Can_Add_Quantity_For_Existing_Lines()
        {
            var repository = new ModelCompleteFakeRepository();
            var target = new Cart();

            short s = 1;
            foreach (var p in repository.Products)
            {
                target.AddItem(p, s++);
            }

            var result = target.Lines.ToList();

            Assert.Equal(s-1, result.Count); // сколько добавляли, столько и добавили
            Assert.Equal(1, result[0].Quantity);
            Assert.Equal(6, result[result.Count - 1].Quantity);
        }
        
        [Fact]
        public void Can_Remove_Line()
        {
            var p1 = new Product(1, "Kayak", 275M, "Cat1");
            var p2 = new Product(2, "Lifejacket", 48.95M, "Cat1");
            var p3 = new Product(3, "Soccer nall", 19.5M, "Cat2");

            var target = new Cart();

            target.AddItem(p1, 1);
            target.AddItem(p2, 3);
            target.AddItem(p3, 5);
            target.AddItem(p2, 1);

            target.RemoveLine(p2);

            var result = target.Lines.ToList();

            Assert.Empty(target.Lines.Where(c=>c.Product == p2)); // сколько добавляли, столько и добавили
            Assert.Equal(2, target.Lines.Count());
        }


        [Fact]
        public void Calculate_Cart_Total()
        {
            var p1 = new Product(1, "Kayak", 275M, "Cat1");
            var p2 = new Product(2, "Lifejacket", 48.95M, "Cat1");
            var p3 = new Product(3, "Soccer nall", 19.5M, "Cat2");

            var target = new Cart();
            target.AddItem(p1, 1);
            target.AddItem(p2, 3);
            target.AddItem(p3, 5);
            target.AddItem(p2, 1);

            decimal result = target.ComputeTotalValue();

            Assert.Equal(568.30M, result);
        }

        [Fact]
        public void Can_Clear_Contant()
        {
            var p1 = new Product(1, "Kayak", 275M, "Cat1");
            var p2 = new Product(2, "Lifejacket", 48.95M, "Cat1");
            var p3 = new Product(3, "Soccer nall", 19.5M, "Cat2");

            var target = new Cart();
            target.AddItem(p1, 1);
            target.AddItem(p2, 3);
            target.AddItem(p3, 5);
            target.AddItem(p2, 1);

            target.Clear();

            Assert.Empty(target.Lines);
        }
    }
}
