using NUnit.Framework;
using ServerApp.Extencions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerApp.Tests.Extencions
{
    class StringExtencionTests
    {

        #region TEST DATA
        [TestCase(" value"       , ExpectedResult = false)]
        [TestCase("  value"      , ExpectedResult = false)]
        [TestCase(" "            , ExpectedResult = false)]
        [TestCase("  "           , ExpectedResult = false)]
        [TestCase(" value value" , ExpectedResult = false)]
        [TestCase("  value value", ExpectedResult = false)]
        [TestCase("value"        , ExpectedResult = true )]
        [TestCase("value "       , ExpectedResult = true )]
        [TestCase(""             , ExpectedResult = true )]
        [TestCase("value value"  , ExpectedResult = true )]
        [TestCase("value value " , ExpectedResult = true )]
        #endregion
        public bool TrimmedLeft(string value)
        {
            return value.TrimedLeft();
        }

        #region TEST DATA
        [TestCase("value "       , ExpectedResult = false)]
        [TestCase("value  "      , ExpectedResult = false)]
        [TestCase(" "            , ExpectedResult = false)]
        [TestCase("  "           , ExpectedResult = false)]
        [TestCase("value value " , ExpectedResult = false)]
        [TestCase("value value  ", ExpectedResult = false)]
        [TestCase("value"        , ExpectedResult = true )]
        [TestCase(" value"       , ExpectedResult = true )]
        [TestCase(""             , ExpectedResult = true )]
        [TestCase("value value"  , ExpectedResult = true )]
        [TestCase(" value value" , ExpectedResult = true )]
        #endregion
        public bool TrimedRight(string value)
        {
            return value.TrimedRight();
        }

        #region TEST DATA
        [TestCase(" value"       , ExpectedResult = false)]
        [TestCase("  value"      , ExpectedResult = false)]        
        [TestCase("value "       , ExpectedResult = false)]
        [TestCase("value  "      , ExpectedResult = false)]
        [TestCase(" "            , ExpectedResult = false)]
        [TestCase("  "           , ExpectedResult = false)]
        [TestCase(" value value" , ExpectedResult = false)]
        [TestCase("  value value", ExpectedResult = false)]
        [TestCase("value value " , ExpectedResult = false)]
        [TestCase("value value  ", ExpectedResult = false)]
        [TestCase("value"        , ExpectedResult = true )]
        [TestCase("value value"  , ExpectedResult = true )]
        [TestCase(""             , ExpectedResult = true )]

        #endregion
        public bool Trimed(string value)
        {
            return value.Trimed();
        }

        #region TEST DATA
        [TestCase("value"        , ExpectedResult = false)]
        [TestCase("value1"       , ExpectedResult = false)]
        [TestCase("1value"       , ExpectedResult = false)]
        [TestCase("value."       , ExpectedResult = false)]
        [TestCase(".value"       , ExpectedResult = false)]
        [TestCase(" value"       , ExpectedResult = false)]
        [TestCase("  value"      , ExpectedResult = false)]
        [TestCase("value "       , ExpectedResult = false)]
        [TestCase("value  "      , ExpectedResult = false)]
        [TestCase("value value"  , ExpectedResult = false)]
        [TestCase("value value1" , ExpectedResult = false)]
        [TestCase("1value value" , ExpectedResult = false)]
        [TestCase("value value." , ExpectedResult = false)]
        [TestCase(".value value" , ExpectedResult = false)]
        [TestCase(" value value" , ExpectedResult = false)]
        [TestCase("  value value", ExpectedResult = false)]
        [TestCase("value value " , ExpectedResult = false)]
        [TestCase("value value  ", ExpectedResult = false)]
        [TestCase("Value"        , ExpectedResult = true )]
        [TestCase("1Value"       , ExpectedResult = false)]
        [TestCase("Value1"       , ExpectedResult = true )]
        [TestCase(".Value"       , ExpectedResult = false)]
        [TestCase("Value."       , ExpectedResult = true )]
        [TestCase("Value "       , ExpectedResult = true )]
        [TestCase("Value  "      , ExpectedResult = true )]
        [TestCase(" Value"       , ExpectedResult = false)]
        [TestCase("  Value"      , ExpectedResult = false)]
        [TestCase("Value value"  , ExpectedResult = true )]
        [TestCase("Value value1" , ExpectedResult = true )]
        [TestCase("1Value value" , ExpectedResult = false)]
        [TestCase("Value value." , ExpectedResult = true )]
        [TestCase(".Value value" , ExpectedResult = false)]
        [TestCase(" Value value" , ExpectedResult = false)]
        [TestCase("  Value value", ExpectedResult = false)]
        [TestCase("Value value " , ExpectedResult = true )]
        [TestCase("Value value  ", ExpectedResult = true )]
        [TestCase(" "            , ExpectedResult = false)]
        [TestCase("  "           , ExpectedResult = false)]
        #endregion
        public bool SentenceCased(string value)
        {
            return value.SentenceCased();
        }

        #region TEST DATA
        [TestCase("          "                , ExpectedResult = true )]
        [TestCase("0123456789"                , ExpectedResult = true )]
        [TestCase("+-/*=%^"                   , ExpectedResult = true )]
        [TestCase("{}[]()<>"                  , ExpectedResult = true )]
        [TestCase(".,"                        , ExpectedResult = true )]
        [TestCase("!?"                        , ExpectedResult = true )]
        [TestCase("@#$&|\\_"                  , ExpectedResult = true )]
        [TestCase("ABCDEFGHIJKLMNOPQRSTUVWXYZ", ExpectedResult = false)]
        [TestCase("abcdefghijklmnopqrstuvwxyz", ExpectedResult = false)]
        #endregion
        public bool HasNoLetters(string value)
        {
            return value.HasNoLetters();
        }

        #region TEST DATA
        // TODO : Add more test cases.
        [TestCase("          "                , ExpectedResult = true )]
        [TestCase("0123456789"                , ExpectedResult = true )]
        [TestCase("+-/*=%^"                   , ExpectedResult = true )]
        [TestCase("{}[]()<>"                  , ExpectedResult = true )]
        [TestCase(".,"                        , ExpectedResult = true )]
        [TestCase("!?"                        , ExpectedResult = true )]
        [TestCase("@#$&|\\_"                  , ExpectedResult = true )]
        [TestCase("ABCDEFGHIJKLMNOPQRSTUVWXYZ", ExpectedResult = true )]
        [TestCase("abcdefghijklmnopqrstuvwxyz", ExpectedResult = true )]
        #endregion
        public bool HasNoMarks(string value)
        {
            return value.HasNoMarks();
        }

        #region TEST DATA
        [TestCase("          "                , ExpectedResult = true )]
        [TestCase("0123456789"                , ExpectedResult = false)]
        [TestCase("+-/*=%^"                   , ExpectedResult = true )]
        [TestCase("{}[]()<>"                  , ExpectedResult = true )]
        [TestCase(".,"                        , ExpectedResult = true )]
        [TestCase("!?"                        , ExpectedResult = true )]
        [TestCase("@#$&|\\_"                  , ExpectedResult = true )]
        [TestCase("ABCDEFGHIJKLMNOPQRSTUVWXYZ", ExpectedResult = true )]
        [TestCase("abcdefghijklmnopqrstuvwxyz", ExpectedResult = true )]
        #endregion
        public bool HasNoNumbers(string value)
        {
            return value.HasNoNumbers();
        }

        #region TEST DATA
        [TestCase("          "                , ExpectedResult = true )]
        [TestCase("0123456789"                , ExpectedResult = true )]
        [TestCase("+-/*=%^"                   , ExpectedResult = true )]
        [TestCase("{}[]()<>"                  , ExpectedResult = true )]
        [TestCase(".,"                        , ExpectedResult = false)]
        [TestCase("!?"                        , ExpectedResult = false)]
        [TestCase("@#$&|\\_"                  , ExpectedResult = true )]
        [TestCase("ABCDEFGHIJKLMNOPQRSTUVWXYZ", ExpectedResult = true )]
        [TestCase("abcdefghijklmnopqrstuvwxyz", ExpectedResult = true )]
        #endregion
        public bool HasNoPuncuation(string value)
        {
            return value.HasNoPunctuation();
        }

        #region TEST DATA
        // TODO : Add more test cases.
        [TestCase("          "                , ExpectedResult = true )]
        [TestCase("0123456789"                , ExpectedResult = true )]
        [TestCase("+-/*=%^"                   , ExpectedResult = true )]
        [TestCase("{}[]()<>"                  , ExpectedResult = true )]
        [TestCase(".,"                        , ExpectedResult = true )]
        [TestCase("!?"                        , ExpectedResult = true )]
        [TestCase("@#$&|\\_"                  , ExpectedResult = true )]
        [TestCase("ABCDEFGHIJKLMNOPQRSTUVWXYZ", ExpectedResult = true )]
        [TestCase("abcdefghijklmnopqrstuvwxyz", ExpectedResult = true )]
        #endregion
        public bool HasNoSymbols(string value)
        {
            return value.HasNoSymbols();
        }

        #region TEST DATA
        [TestCase("          "                , ExpectedResult = false)]
        [TestCase("0123456789"                , ExpectedResult = true )]
        [TestCase("+-/*=%^"                   , ExpectedResult = true )]
        [TestCase("{}[]()<>"                  , ExpectedResult = true )]
        [TestCase(".,"                        , ExpectedResult = true )]
        [TestCase("!?"                        , ExpectedResult = true )]
        [TestCase("@#$&|\\_"                  , ExpectedResult = true )]
        [TestCase("ABCDEFGHIJKLMNOPQRSTUVWXYZ", ExpectedResult = true )]
        [TestCase("abcdefghijklmnopqrstuvwxyz", ExpectedResult = true )]
        #endregion
        public bool HasNoSeparators(string value)
        {
            return value.HasNoSeparators();
        }
    }
}
