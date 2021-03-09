using Styme.Service.Models.InputModels;
using Xunit;

namespace Styme.Service.Tests
{
    public class UpdateRestaurantInputModelTest
    {
        [Fact]
        public void DeveSerInvalidoComIdInvalido()
        {
            var input = new UpdateRestaurantInputModel
            {
                Id = 0,
                Name = "Restaurante",
                Category = "Restaurante",
                Address = "Av. Araxá",
                Location = "Goiânia"
            };

            Assert.False(input.IsValid);
        }

        [Fact]
        public void DeveSerInvalidoComNameVazioOuNulo()
        {
            var input = new UpdateRestaurantInputModel
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
            var input = new UpdateRestaurantInputModel
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
            var input = new UpdateRestaurantInputModel
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
            var input = new UpdateRestaurantInputModel
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
            var input = new UpdateRestaurantInputModel
            {
                Id = 1,
                Name = "Restaurante",
                Category = "Restaurante",
                Address = "Av. Araxá",
                Location = "Goiânia"
            };

            Assert.True(input.IsValid);
        }
    }
}
