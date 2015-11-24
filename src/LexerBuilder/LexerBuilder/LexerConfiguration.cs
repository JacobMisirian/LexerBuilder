using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexerBuilder.LexerBuilder
{
    public class LexerConfiguration
    {
        public Dictionary<string, TokenType> BindingsDictionary = new Dictionary<string, TokenType>();
        public Dictionary<string, Tuple<string, TokenType>> ScanFromDictionary = new Dictionary<string, Tuple<string, TokenType>>();
        public List<string> IgnoreCharDictionary = new List<string>();
        public Dictionary<string, string> IgnoreFromDictionary = new Dictionary<string, string>();

        public LexerConfiguration()
        {
        }

        public void GroupBind(string letters, TokenType with)
        {
            foreach (char l in letters)
                BindingsDictionary.Add(l.ToString(), with);
        }

        public void ScanFrom(string from, string to, TokenType tokenType)
        {
            ScanFromDictionary.Add(from, Tuple.Create(to, tokenType));
        }

        public void IgnoreChar(string character)
        {
            IgnoreCharDictionary.Add(character);
        }

        public void IgnoreFrom(string from, string to)
        {
            IgnoreFromDictionary.Add(from, to);
        }
    }
}
