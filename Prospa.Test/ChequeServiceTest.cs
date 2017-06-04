using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prospa.Core;

namespace Prospa.Test
{
    /*
      There are no dependant services/objects so nothing to mock,
      no need for Rhino mocks
     */
    [TestClass]
    public class ChequeServiceTest
    {
        [TestMethod]
        public void Test_cents_are_zero()
        {
            //arrange
            var chequeService = new ChequeService();

            //act
            var result = chequeService.ConvertNumbersToWords(123.00M);

            //assert
            var zeroCents = result.EndsWith("and zero cents");
            Assert.IsTrue(zeroCents);
        }

        [TestMethod]
        public void Test_multiple_of_ten_are_correct()
        {
            //arrange
            var chequeService = new ChequeService();

            //act
            var ten = chequeService.ConvertNumbersToWords(10);
            var fourty = chequeService.ConvertNumbersToWords(40);
            var fifty = chequeService.ConvertNumbersToWords(50);

            //assert
            var tenTest = ten.Contains("Ten Dollars");
            Assert.IsTrue(tenTest);

            var fourtyTest = fourty.Contains("Fourty Dollars");
            Assert.IsTrue(fourtyTest);

            var fiftyTest = fifty.Contains("Fifty Dollars");
            Assert.IsTrue(fiftyTest);
        }

        [TestMethod]
        public void Test_billions()
        {
            //arrange
            var chequeService = new ChequeService();

            //act
            var billion = chequeService.ConvertNumbersToWords(1234567890);
            
            //assert
            var billionTest = billion.Contains("One Billion");
            Assert.IsTrue(billionTest);
        }

        public void Test_multiple_of_billions_correct()
        {
            //arrange
            var chequeService = new ChequeService();

            //act
            var tenbillion = chequeService.ConvertNumbersToWords(10000000000);
            var thirtybillion = chequeService.ConvertNumbersToWords(30000000000);
            var fiftybillion = chequeService.ConvertNumbersToWords(50000000000);
            var eightybillion = chequeService.ConvertNumbersToWords(80000000000);

            //assert
            var tenbillionTest = tenbillion.Contains("Ten Billion");
            var thirtybillionTest = thirtybillion.Contains("Thirty Billion");
            var fiftybillionTest = fiftybillion.Contains("Fifty Billion");
            var eightybillionTest = eightybillion.Contains("Eighty Billion");

            Assert.IsTrue(tenbillionTest);
            Assert.IsTrue(thirtybillionTest);
            Assert.IsTrue(fiftybillionTest);
            Assert.IsTrue(eightybillionTest);
        }


    }
}
