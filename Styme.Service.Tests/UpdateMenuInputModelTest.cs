using Styme.Service.Models.InputModels;
using Xunit;

namespace Styme.Service.Tests
{
    public class UpdateMenuInputModelTest
    {
        [Fact]
        public void DeveSerInvalidoComIdInvalido()
        {
            var input = new UpdateMenuInputModel
            {
                Description = "Menu 01",
                Price = 10.99m,
                Category = "Categoria 01"
            };

            Assert.False(input.IsValid);
        }

        [Fact]
        public void DeveSerInvalidoComDescriptionVazioOuNulo()
        {
            var input = new UpdateMenuInputModel
            {
                Id = 1,
                Price = 10.99m,
                Category = "Categoria 01"
            };

            Assert.False(input.IsValid);
        }

        [Fact]
        public void DeveSerInvalidoComCategoryVazioOuNulo()
        {
            var input = new UpdateMenuInputModel
            {
                Id = 1,
                Description = "Menu 01",
                Price = 10.99m
            };

            Assert.False(input.IsValid);
        }

        [Fact]
        public void DeveSerInvalidoComPriceZero()
        {
            var input = new UpdateMenuInputModel
            {
                Id = 1,
                Description = "Menu 01",
                Category = "Categoria 01",
                Price = 0m
            };

            Assert.False(input.IsValid);
        }

        [Fact]
        public void DeveSerInvalidoComRestauranteIdInvalido()
        {
            var input = new UpdateMenuInputModel
            {
                Id = 1,
                Description = "Menu 01",
                Category = "Categoria 01",
                Price = 0m
            };

            Assert.False(input.IsValid);
        }

        [Fact]
        public void DeveSerValidoComInformacoesPreenchidas()
        {
            var input = new UpdateMenuInputModel
            {
                Id = 1,
                Description = "Menu 01",
                Category = "Categoria 01",
                Price = 10m
            };

            Assert.True(input.IsValid);
        }
    }
}
