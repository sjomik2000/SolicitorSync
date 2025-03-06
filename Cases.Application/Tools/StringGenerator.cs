using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cases.Application.Tools
{
    public class StringGenerator()
    {
        private readonly string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public string GenerateString(int length)
        {
            var charString = new char[length];
            var random = new Random();
            for (int i = 0; i < charString.Length; i++)
            {
                charString[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(charString);
            return finalString;
        }
        
    }
}
