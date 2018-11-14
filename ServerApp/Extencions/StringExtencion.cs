using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServerApp.Extencions
{
    public static class StringExtencion
    {
        public static bool   IsNull              (this string value) => (value is null);
        public static bool   IsNotNull           (this string value) => !value.IsNull();
        public static bool   IsEmpty             (this string value) => (value == String.Empty);
        public static bool   IsNotEmpty          (this string value) => !value.IsNotEmpty();
        public static bool   IsWhiteSpace        (this string value) => (Regex.IsMatch(value, @"\A\s*\z"));
        public static bool   IsNotWhiteSpace     (this string value) => !value.IsWhiteSpace();

        public static bool   HasMaxLength        (this string value, int limit) => (value.Length <= limit);
        public static bool   HasMinLength        (this string value, int limit) => (value.Length >= limit);

        public static bool   IsMatch             (this string value, string pattern, RegexOptions options)
        {
            pattern.IsNull().Then(() => throw new ArgumentNullException(nameof(pattern)));

            var input   = value;
            var regex   = new Regex(pattern, options);
            var isMatch = regex.IsMatch(input);

            return isMatch;
        }
        public static bool   IsMatch             (this string value, string pattern) => IsMatch(value, pattern, RegexOptions.Multiline);

        public static bool   TrimedLeft          (this string value)
        {
            var isTrimmedLeft = false;

            if (value.IsEmpty())
            {
                isTrimmedLeft = true;
            }
            else
            {
                var input = value;
                var patternt = @"\A[\P{Z}].*\z";
                var options = RegexOptions.Multiline;
                var regex = new Regex(patternt, options);

                isTrimmedLeft = regex.IsMatch(input);
            }

            return isTrimmedLeft;
        }                                             
        public static bool   TrimedRight         (this string value)
        {
            var isTrimmedRight = false;

            if (value.IsEmpty())
            {
                isTrimmedRight = true;
            }
            else
            {
                var input    = value;
                var patternt = @"\A.*?[\P{Z}]\z";
                var options  = RegexOptions.Multiline;
                var regex    = new Regex(patternt, options);

                isTrimmedRight = regex.IsMatch(input);
            }

            return isTrimmedRight;
        }
        public static bool   Trimed              (this string value) => (value.TrimedLeft() && value.TrimedRight());
                             
                             
        public static bool   SentenceCased       (this string value) => value.IsMatch(@"\A[\p{Lu}].*\z");
                             
                             
        public static bool   HasNoLetters        (this string value) => !value.IsMatch(@"\p{L}" );
        public static bool   HasNoMarks          (this string value) => !value.IsMatch(@"\p{M}" );
        public static bool   HasNoNumbers        (this string value) => !value.IsMatch(@"\p{N}" );
        public static bool   HasNoPunctuation    (this string value) => !value.IsMatch(@"\p{P}" );
        public static bool   HasNoSymbols        (this string value) => !value.IsMatch(@"\p{S}" );
        public static bool   HasNoSeparators     (this string value) => !value.IsMatch(@"\p{Z}" );
        public static bool   HasNoControls       (this string value) => !value.IsMatch(@"\p{C}" );        
        public static bool   HasNoLatinCharacters(this string value) => value.IsMatch (@"a-zA-Z");     
                             
                             
        public static bool   HasLetters          (this string value) => !HasNoLetters        (value);
        public static bool   HasMarks            (this string value) => !HasNoMarks          (value);
        public static bool   HasNumbers          (this string value) => !HasNoNumbers        (value);
        public static bool   HasPunctuation      (this string value) => !HasNoPunctuation    (value);
        public static bool   HasSymbols          (this string value) => !HasNoSymbols        (value);
        public static bool   HasSeparators       (this string value) => !HasNoSeparators     (value);
        public static bool   HasControls         (this string value) => !HasNoControls       (value);
        public static bool   HasLatinCharacters  (this string value) => !HasNoLatinCharacters(value);

        /// <summary>
        /// Escape string.
        /// </summary>
        /// <remarks>
        /// Escape: \, *, +, ?, |, {, }, [, ], (, ), ^, $,., # and white space.
        /// </remarks>
        /// <param name="value">String that should be checked.</param>
        /// <returns>Escaped string.</returns>
        public static string Escape              (this string value) => Regex.Replace(value, @"[*+?|{}\[\]()^$.#\\]", @"\$&", RegexOptions.Multiline);


        private static Random Random => new Random();

        public static string AppendRandomLatinVowelLetter    (this string value)
        {
            string[] vowels = new[] { "a", "e", "i", "o", "u" };
            int      count  = vowels.Length;

            return $@"{value}{vowels[Random.Next(0, count - 1)]}";
        }

        public static string AppendRandomLatinConsonantLetter(this string value)
        {
            string[] consonants = new[] { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z" };
            int      count      = consonants.Length;

            return $@"{value}{consonants[Random.Next(0, count - 1)]}";
        }

        public static string AppendRandomLatinVowelLetterCombination(this string value)
        {
            string[] vowelCombinations = new[] { "ai", "ay", "ea", "ey", "ee", "ew", "eu", "oo", "oa", "ou", "ie" };
            int      count             = vowelCombinations.Length;
            
            return $@"{value}{vowelCombinations[Random.Next(0, count - 1)]}";
        }

        public static string AppendRandomLatinConsonantLetterCombination(this string value)
        {
            string[] consonantsCombinations = new[] { "ch", "ck", "tch", "bt", "gh", "dg", "th", "sh", "gn", "mb", "mn", "kn", "wh", "ng", "ph", "wr" };
            int      count                  = consonantsCombinations.Length;

            return $@"{value}{consonantsCombinations[Random.Next(0, count - 1)]}";
        }

        public static bool IsLastLetterLatinVowel    (this string value)
        {
            return value.Last().IsLatinVowel();
        }
        public static bool IsLastLetterLatinConsonant(this string value)
        {
            return value.Last().IsLatinConsonant();
        }
    }
}
