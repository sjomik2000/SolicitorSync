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
        // GenerateString method is used for custom slug generation to add a random string of specified length to the slug.
        public string GenerateString(int length)
        {
            var charString = new char[length]; //Defining charString length
            var random = new Random(); //Instantiating random object
            for (int i = 0; i < charString.Length; i++)
            {
                charString[i] = chars[random.Next(chars.Length)]; //Creates a random character string using specified characters string chars
            }
            var finalString = new String(charString); //Converts charString to finalString
            return finalString;
        }
        
    }
}
