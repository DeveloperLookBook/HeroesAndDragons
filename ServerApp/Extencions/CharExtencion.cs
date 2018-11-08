using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Extencions
{
    public static class CharExtencion
    {
        public static bool IsLatinVowel(this char value)
        {
            char[] vowels  = new[] { 'a', 'e', 'i', 'o', 'u' };
            bool   isVowel = false;
            var    letter  = Char.ToLower(value);

            foreach (var vowel in vowels)
            {
                if (vowel == letter)
                {
                    isVowel = true;
                    break;
                }
            }

            return isVowel;
        }

        public static bool IsLatinConsonant(this char value)
        {
            char[] consonants  = new[] { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z' };
            bool   isConsonant = false;
            var    letter      = Char.ToLower(value);

            foreach (var consonant in consonants)
            {
                if (consonant == letter)
                {
                    isConsonant = true;
                    break;
                }
            }

            return isConsonant;
        }
    }
}
