using System;
using Xunit;
using CloudAcademy.Bitcoin;

namespace CloudAcademy.Bitcoin.Tests
{
    public class BitcoinConverterSvcShould
    {
        private ConverterSvc converterSvc;

        public BitcoinConverterSvcShould()
        {
            converterSvc = new ConverterSvc();
        }

        [Fact]
        public async void GetNZDExchangeRate()
        {
            //act
            var exchangeRate = await converterSvc.GetExchangeRate("NZD");

            //assert
            double expected = 100.00;
            Assert.Equal(expected, exchangeRate);
        }

        [Fact]
        public async void GetUSDExchangeRate()
        {
            //act
            var exchangeRate = await converterSvc.GetExchangeRate("USD");

            //assert
            double expected = 200.00;
            Assert.Equal(expected, exchangeRate);
        }

        [Theory]
        [InlineData("NZD",1,100.00)]
        [InlineData("NZD",2,200.00)]
        [InlineData("USD",1,200.00)]
        [InlineData("USD",2,400.00)]
        public async void ConvertBitcoinsToNZD(string currency, int coins, double convertedDollars)
        {
            //act
            var coverterSvc = new ConverterSvc();
            var dollars = await converterSvc.ConvertBitcoins(currency, coins);

            //assert
            var expected = convertedDollars;
            Assert.Equal(expected, dollars);
        }
    }
}
