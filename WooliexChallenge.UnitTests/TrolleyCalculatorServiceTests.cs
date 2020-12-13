using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using WooliesxChallenge.Application;
using WooliesxChallenge.Domain;
using WooliesxChallenge.Domain.Models;
using Xunit;

namespace WooliexChallenge.UnitTests
{
    public class TrolleyCalculatorServiceTests
    {
        [Fact]
        public void GivenSingleProductWithSpecialShouldGiveMaxPrice()
        {
            var trolleyCalculator = new TrolleyCalculatorService();
            var result = trolleyCalculator.CalculateTotal(SingleItemWithoutSpecial());
            result.Should().Be(80);
        }

        [Fact]
        public void GivenSingleProductWithSpecialShouldGiveMinPrice()
        {
            var trolleyCalculator = new TrolleyCalculatorService();
            var result = trolleyCalculator.CalculateTotal(SingleItemWithSpecial());
            result.Should().Be(4);
        }

        [Fact]
        public void GivenSingleProductWitDifferentSpecialShouldGiveMinPrice()
        {
            var trolleyCalculator = new TrolleyCalculatorService();
            Action action = () => trolleyCalculator.CalculateTotal(DifferentSpecial());
            action.Should().Throw<ValidationException>();
        }


        [Fact]
        public void GivenTwoProductWitMultipleSpecialShouldGiveMinPrice()
        {
            var trolleyCalculator = new TrolleyCalculatorService();
            var result = trolleyCalculator.CalculateTotal(TwoProductWithMultipleSpecial());
            result.Should().Be(7);
        }

        private static TrolleyRequest SingleItemWithSpecial()
        {
            return new TrolleyRequest
            {
                Products = new List<TrolleyProductModel>
                {
                    new TrolleyProductModel
                    {
                        Name = "Test Product A",
                        Price = 20
                    }
                },
                Specials = new List<TrolleySpecialModel>
                {
                    new TrolleySpecialModel
                    {
                        Quantities = new List<TrolleyQuantityModel>
                        {
                            new TrolleyQuantityModel
                            {
                                Name = "Test Product A",
                                Quantity = 1
                            }
                        },


                        Total = 1
                    }
                },
                Quantities = new List<TrolleyQuantityModel>
                {
                    new TrolleyQuantityModel
                    {
                        Name = "Test Product A",
                        Quantity = 4
                    }
                }
            };
        }


        private static TrolleyRequest DifferentSpecial()
        {
            return new TrolleyRequest
            {
                Products = new List<TrolleyProductModel>
                {
                    new TrolleyProductModel
                    {
                        Name = "Test Product A",
                        Price = 20
                    }
                },
                Specials = new List<TrolleySpecialModel>
                {
                    new TrolleySpecialModel
                    {
                        Quantities = new List<TrolleyQuantityModel>
                        {
                            new TrolleyQuantityModel
                            {
                                Name = "Test Product B",
                                Quantity = 1
                            }
                        },


                        Total = 1
                    }
                },
                Quantities = new List<TrolleyQuantityModel>
                {
                    new TrolleyQuantityModel
                    {
                        Name = "Test Product A",
                        Quantity = 4
                    }
                }
            };
        }

        private static TrolleyRequest SingleItemWithoutSpecial()
        {
            return new TrolleyRequest
            {
                Products = new List<TrolleyProductModel>
                {
                    new TrolleyProductModel
                    {
                        Name = "Test Product A",
                        Price = 20
                    }
                },

                Quantities = new List<TrolleyQuantityModel>
                {
                    new TrolleyQuantityModel
                    {
                        Name = "Test Product A",
                        Quantity = 4
                    }
                }
            };
        }

        private static TrolleyRequest TwoProductWithMultipleSpecial()
        {
            return new TrolleyRequest
            {
                Products = new List<TrolleyProductModel>
                {
                    new TrolleyProductModel
                    {
                        Name = "milk",
                        Price = 2
                    },
                    new TrolleyProductModel
                    {
                        Name = "tea",
                        Price = 2
                    }
                },
                Specials = new List<TrolleySpecialModel>
                {
                    new TrolleySpecialModel
                    {
                        Quantities = new List<TrolleyQuantityModel>
                        {
                            new TrolleyQuantityModel
                            {
                                Name = "milk",
                                Quantity = 1
                            },
                            new TrolleyQuantityModel
                            {
                                Name = "tea",
                                Quantity = 2
                            }
                        },

                        Total = 1
                    },
                    new TrolleySpecialModel
                    {
                        Quantities = new List<TrolleyQuantityModel>
                        {
                            new TrolleyQuantityModel
                            {
                                Name = "milk",
                                Quantity = 1
                            },
                            new TrolleyQuantityModel
                            {
                                Name = "tea",
                                Quantity = 3
                            }
                        },

                        Total = 5
                    }
                },
                Quantities = new List<TrolleyQuantityModel>
                {
                    new TrolleyQuantityModel
                    {
                        Name = "milk",
                        Quantity = 3
                    },
                    new TrolleyQuantityModel
                    {
                        Name = "tea",
                        Quantity = 3
                    }
                }
            };
        }
    }
}
