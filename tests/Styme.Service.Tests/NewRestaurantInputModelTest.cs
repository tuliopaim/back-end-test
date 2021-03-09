using Styme.Service.Models.InputModels;
using Xunit;

namespace Styme.Service.Tests
{
    public class NewRestaurantInputModelTest
    {
        [Fact]
        public void DeveSerInvalidoComNameVazioOuNulo()
        {
            var input = new NewRestaurantInputModel
            {
                Address = "Av. Araxá",
                Category = "Restaurante",
                Location = "Goiânia"
            };

            Assert.False(input.IsValid);
        }

        [Fact]
        public void DeveSerInvalidoComAddressVazioOuNulo()
        {
            var input = new NewRestaurantInputModel
            {
                Name = "Restaurante",
                Category = "Restaurante",
                Location = "Goiânia"
            };

            Assert.False(input.IsValid);
        }

        [Fact]
        public void DeveSerInvalidoComCategoryVazioOuNulo()
        {
            var input = new NewRestaurantInputModel
            {
                Name = "Restaurante",
                Address = "Av. Araxá",
                Location = "Goiânia"
            };

            Assert.False(input.IsValid);
        }

        [Fact]
        public void DeveSerInvalidoComLocationVazioOuNulo()
        {
            var input = new NewRestaurantInputModel
            {
                Name = "Restaurante",
                Category = "Restaurante",
                Address = "Av. Araxá",
            };

            Assert.False(input.IsValid);
        }

        [Fact]
        public void DeveSerValidoComInformacoesPreenchidas()
        {
            var input = new NewRestaurantInputModel
            {
                Name = "Restaurante",
                Category = "Restaurante",
                Address = "Av. Araxá",
                Location = "Goiânia"
            };

            Assert.True(input.IsValid);
        }
    }
}
