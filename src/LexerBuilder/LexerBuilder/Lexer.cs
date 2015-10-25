using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerBuilder.LexerBuilder
{
    public class Lexer
    {
        private Dictionary<string, TokenType> bindings = new Dictionary<string, TokenType>();
        private Dictionary<string, Tuple<string, TokenType>> scanFrom = new Dictionary<string, Tuple<string, TokenType>>();
        private string code = "";
        private int position = 0;
        private List<Token> result = new List<Token>();

        private char peekLetter { get { return (char)peekChar(); } }
        private char readLetter { get { return (char)readChar(); } }

        public Lexer(string code)
        {
            this.code = code;
        }

        public List<Token> Scan()
        {
            whiteSpace();

            while (peekChar() != -1)
            {
                if (char.IsLetterOrDigit(peekLetter))
                    result.Add(scanData());
                else if (bindings.ContainsKey(peekLetter.ToString()))
                    result.Add(new Token(bindings[peekLetter.ToString()], readLetter.ToString()));
                else if (scanFrom.ContainsKey(peekLetter.ToString()))
                {
                    Tuple<string, TokenType> entry = scanFrom[peekLetter.ToString()];
                    result.Add(scanDataFrom(peekLetter.ToString(), entry.Item1, entry.Item2));
                }
                else
                    Console.WriteLine("Unknown Token " + readLetter.ToString());
            }

            return result;
        }

        public void SetBinding (string to, TokenType with)
        {
            bindings.Add(to, with);
        }

        public void ScanFrom (string from, string to, TokenType tokenType)
        {
            scanFrom.Add(from, Tuple.Create(to, tokenType));
        }

        private Token scanData()
        {
            string result = "";
            double temp = 0;
            while ((char.IsLetterOrDigit((char)peekChar()) && peekChar() != -1) || ((char)(peekChar()) == '.'))
                result += ((char)readChar()).ToString();
            if (double.TryParse(result, out temp))
                return new Token(TokenType.Number, result);

            return new Token(TokenType.Identifier, result);
        }

        private Token scanDataFrom(string from, string to, TokenType resultType)
        {
            readChar();
            string res = "";
            while (peekLetter.ToString() != to && peekChar() != -1)
                res += readLetter.ToString();

            readChar();

            return new Token(resultType, res);
        }

        private void whiteSpace()
        {
            while (char.IsLetterOrDigit((char)peekChar()))
                readChar();
        }

        private int peekChar(int n = 0)
        {
            if (position + n < code.Length)
                return code[position];
            return -1;
        }

        private int readChar()
        {
            if (position < code.Length)
                return code[position++];
            return -1;
        }
    }
}
