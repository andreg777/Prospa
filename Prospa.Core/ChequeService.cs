using System;
using System.Collections.Generic;
using Microsoft.SqlServer.Server;
using Prospa.Core.Interface;
using Prospa.Model;

namespace Prospa.Core
{
    public class ChequeService : IChequeService
    {
        readonly Dictionary<int, string> _unitDictionary;
        readonly Dictionary<int, string> _teenDictionary;
        readonly Dictionary<int, string> _decDictionary;

        public ChequeService()
        {
            _unitDictionary = new Dictionary<int, string> { { 1, "One" }, { 2, "Two" }, { 3, "Three" }, { 4, "Four" }, { 5, "Five" }, { 6, "Six" }, { 7, "Seven" }, { 8, "Eight" }, { 9, "Nine" } };
            _teenDictionary = new Dictionary<int, string> { { 10, "Ten" }, { 11, "Eleven" }, { 12, "Twelve" }, { 13, "Thirteen" }, { 14, "Fourteen" }, { 15, "Fifteen" }, { 16, "Sixteen" }, { 17, "Seventeen" }, { 18, "Eighteen" }, { 19, "Nineteen" } };
            _decDictionary = new Dictionary<int, string> { { 20, "Twenty" }, { 30, "Thirty" }, { 40, "Fourty" }, { 50, "Fifty" }, { 60, "Sixty" }, { 70, "Seventy" }, { 80, "Eighty" }, { 90, "Ninety" } };
        }

        public ChequeModel ConvertNumbersToWords(ChequeModel model)
        {
            var words = ConvertNumbersToWords(model.Amount);
            return new ChequeModel() { WordOutput = words };
        }

        public string ConvertNumbersToWords(decimal amount)
        {
            if (amount < 0)
            {
                return "Can't pay negative amount.";
            }
            if (amount == 0)
            {
                return "Zero dollars";
            }
            if (amount > 100000000000)
            {
                return "Hundred billion is max";
            }

            var dollars = ProcessDollarsToWords(amount);
            var cents = ProcessCentsToWords(amount);

            var result = FormatDollarText(dollars, cents);
            return result;
        }

        private string FormatDollarText(string dollars,string cents)
        {
            var result = string.Concat(dollars, " Dollars and ", cents, " cents");
            result = result.Replace("  ", " "); //get rid of redundant spaces
            return result;
        }        

        public string ProcessCentsToWords(decimal amount)
        {
            amount = (amount - Math.Truncate(amount)) * 100;
            var cents = MapWords(Convert.ToInt32(amount));
            return cents;
        }

        public string ProcessDollarsToWords(decimal amount)
        {

            var numericText = "";

            if (amount >= Significance.Billion)
            {
                numericText += ProcessDollarsToWords(amount / Significance.Billion) + " Billion ";
                amount = amount % Significance.Billion;
            }

            if (amount >= Significance.Million)
            {
                numericText += ProcessDollarsToWords(amount / Significance.Million) + " Million ";
                amount = amount % Significance.Million;
            }

            if (amount >= Significance.Thousand)
            {
                numericText += ProcessDollarsToWords(amount / Significance.Thousand) + " Thousand ";
                amount = amount % Significance.Thousand;
            }

            if (amount >= Significance.Hundred)
            {
                numericText += ProcessDollarsToWords(amount / Significance.Hundred) + " Hundred ";
                amount = amount % Significance.Hundred;
            }

            if (amount >= 1)
            {
                numericText += MapWords(Convert.ToInt32(Math.Truncate(amount))) + " ";
            }

            return numericText;
        }

        private string MapWords(int amount)
        {
            var result = "";

            if (amount >= 20)
            {
                result = _decDictionary[amount - amount % 10];

                amount = amount % 10;

                if (amount >= 1)
                {
                    result += " " + _unitDictionary[amount];
                }
            }
            else if (amount >= 10)
            {
                result += _teenDictionary[amount];
            }
            else if (amount >= 1)
            {
                result += _unitDictionary[amount];
            }
            else if (amount == 0)
            {
                result += " zero ";
            }

            return result;
        }

    }
}