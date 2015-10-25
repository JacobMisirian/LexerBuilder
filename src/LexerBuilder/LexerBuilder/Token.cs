using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerBuilder.LexerBuilder
{
    public enum TokenType
    {
        String,
        Identifier,
        Number,
        Int,
        Double,
        RightParentheses,
        LeftParentheses,
        RightBracket,
        LeftBracket,
        RightBrace,
        LeftBrace,
        Comma,
        Colon,
        SemiColon,
        EndOfLine,
        UnaryOperation,
        BinaryOperation,
        Comparison,
        Operation,
        Dot,
        Lambda,
        Assignment,
        Exception
    }
    public class Token
    {
        public TokenType TokenType { get; private set; }
        public object Value { get; private set; }

        public Token(TokenType tokenType, object value)
        {
            TokenType = tokenType;
            Value = value;
        }
    }
}
