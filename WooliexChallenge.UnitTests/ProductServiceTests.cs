using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Options;
using NSubstitute;
using WooliesxChallenge.Application;
using WooliesxChallenge.Domain;
using WooliesxChallenge.Domain.Enums;
using WooliesxChallenge.Domain.Interfaces;
using Xunit;

namespace WooliexChallenge.UnitTests
{
    public class ProductServiceTests
    {
        private IDevChallengeResourceProxy _proxy;
        private IOptions<UserSetting> _options;
        public ProductServiceTests()
        {
            _proxy = Substitute.For<IDevChallengeResourceProxy>();
            _options = Options.Create(new UserSetting());

        }

        [Fact]
        public async Task GivenEmptyProductShouldReturnSameValue()
        {
            IList<Product> products = new List<Product>();
            _proxy.GetProductAsync(Arg.Any<Guid>()).Returns(Task.FromResult(products));
            var productService = new ProductService(_proxy, _options);
            var result = await productService.GetProductAsync(SortOption.High);
            result.Should().BeEquivalentTo(products);
        }

        [Fact]
        public async Task GivenProductSortWithHighShouldReturnPriceHightoLow()
        {
            IList<Product> products = GetProduct();
            _proxy.GetProductAsync(Arg.Any<Guid>()).Returns(Task.FromResult(products));
            var productService = new ProductService(_proxy, _options);
            var result = await productService.GetProductAsync(SortOption.High);
            result.Should().BeInDescendingOrder(r => r.Price);
        }

        [Fact]
        public async Task GivenProductSortWithLowShouldReturnPriceLowToHigh()
        {
            IList<Product> products = GetProduct();
            _proxy.GetProductAsync(Arg.Any<Guid>()).Returns(Task.FromResult(products));
            var productService = new ProductService(_proxy, _options);
            var result = await productService.GetProductAsync(SortOption.Low);
            result.Should().BeInAscendingOrder(r => r.Price);
        }


        [Fact]
        public async Task GivenProductSortWithAscendingShouldReturnNameAscending()
        {
            IList<Product> products = GetProduct();
            _proxy.GetProductAsync(Arg.Any<Guid>()).Returns(Task.FromResult(products));
            var productService = new ProductService(_proxy, _options);
            var result = await productService.GetProductAsync(SortOption.Ascending);
            result.Should().BeInAscendingOrder(r => r.Name);
        }


        [Fact]
        public async Task GivenProductSortWithDescendingShouldReturnNameDescending()
        {
            IList<Product> products = GetProduct();
            _proxy.GetProductAsync(Arg.Any<Guid>()).Returns(Task.FromResult(products));
            var productService = new ProductService(_proxy, _options);
            var result = await productService.GetProductAsync(SortOption.Descending);
            result.Should().BeInDescendingOrder(r => r.Name);
        }


        [Fact]
        public async Task GivenProductSortWithRecommendedShouldReturnOnSaleCountAndDescending()
        {
            IList<Product> products = GetProduct();
            IList<ShopperHistory> shopperHistories = GetShopperHistory();
            _proxy.GetProductAsync(Arg.Any<Guid>()).Returns(Task.FromResult(products));
            _proxy.GetShopperHistoryAsync(Arg.Any<Guid>()).Returns(Task.FromResult(GetShopperHistory()));

            var productService = new ProductService(_proxy, _options);
            var result = await productService.GetProductAsync(SortOption.Recommended);
            result.Should().BeEquivalentTo(GetRecommendedProduct());
        }

        private IList<ShopperHistory> GetShopperHistory()
        {
            return new List<ShopperHistory>
            {
                new ShopperHistory
                {
                    CustomerId = 123,
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Name = "Test Product A",
                            Price =  99.99M,
                            Quantity = 3
                        },
                        new Product
                        {
                            Name = "Test Product B",
                            Price =  101.99M,
                            Quantity = 1
                        },
                        new Product
                        {
                            Name = "Test Product F",
                            Price = 999999999999M,
                            Quantity = 1
                        }
                    }
                },
                new ShopperHistory
                {
                    CustomerId = 23,
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Name = "Test Product A",
                            Price = 99.99M,
                            Quantity = 2
                        },
                        new Product
                        {
                            Name = "Test Product B",
                            Price =  101.99M,
                            Quantity = 1
                        },
                        new Product()
                        {
                            Name = "Test Product F",
                            Price = 999999999999M,
                            Quantity = 1
                        }
                    }
                },
                new ShopperHistory
                {
                    CustomerId = 23,
                    Products = new List<Product>
                    {
                        new Product()
                        {
                            Name = "Test Product C",
                            Price = 10.99M,
                            Quantity = 2
                        },
                        new Product()
                        {
                            Name = "Test Product F",
                            Price = 999999999999M,
                            Quantity = 2
                        }

                    }
                }
            };
        }

        private IList<Product> GetRecommendedProduct()
        {
            return new List<Product>{
                new Product
                {
                    Name = "Test Product F",
                    Price = 999999999999,
                    Quantity = 4
                },
                new Product
                {
                    Name = "Test Product A",
                    Price = 99.99M,
                    Quantity = 5
                },
                new Product
                {
                    Name = "Test Product B",
                    Price = 101.99M,
                    Quantity = 2
                },
                new Product()
                {
                    Name = "Test Product C",
                    Price = 10.99M,
                    Quantity = 2
                }
            };
        }


        private IList<Product> GetProduct()
        {
            return new List<Product>{
               new Product
               {
                   Name = "Test Product D",
                   Price = 5,
                   Quantity = 0
               },
               new Product
               {
                   Name = "Test Product A",
                   Price = (decimal)99.99,
                   Quantity = 0
               },
               new Product
               {
                   Name = "Test Product C",
                   Price = (decimal)10.99,
                   Quantity = 0
               },

               new Product
               {
                   Name = "Test Product F",
                   Price = 999999999999,
                   Quantity = 0
               },
               new Product
               {
                   Name = "Test Product B",
                   Price = (decimal)101.99,
                   Quantity = 0
               }
            };
        }
    }
}
