using Styme.Service.Models.InputModels;
using Xunit;

namespace Styme.Service.Tests
{
    public class NewMenuInputModelTest
    {
        [Fact]
        public void DeveSerInvalidoComDescriptionVazioOuNulo()
        {
            var input = new NewMenuInputModel
            {
                Price = 10.99m,
                Category = "Categoria 01",
                RestaurantId = 1
            };

            Assert.False(input.IsValid);
        }

        [Fact]
        public void DeveSerInvalidoComCategoryVazioOuNulo()
        {
            var input = new NewMenuInputModel
            {
                Description = "Menu 01",
                Price = 10.99m,
                RestaurantId = 1
            };

            Assert.False(input.IsValid);
        }

        [Fact]
        public void DeveSerInvalidoComPriceZero()
        {
            var input = new NewMenuInputModel
            {
                Description = "Menu 01",
                Category = "Categoria 01",
                Price = 0m,
                RestaurantId = 1
            };

            Assert.False(input.IsValid);
        }

        [Fact]
        public void DeveSerInvalidoComRestauranteIdInvalido()
        {
            var input = new NewMenuInputModel
            {
                Description = "Menu 01",
                Category = "Categoria 01",
                Price = 0m,
                RestaurantId = 0
            };

            Assert.False(input.IsValid);
        }

        [Fact]
        public void DeveSerValidoComInformacoesPreenchidas()
        {
            var input = new NewMenuInputModel
            {
                Description = "Menu 01",
                Category = "Categoria 01",
                Price = 10m,
                RestaurantId = 1
            };

            Assert.True(input.IsValid);
        }
    }
}
