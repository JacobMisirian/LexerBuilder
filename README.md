# LexerBuilder
Open Source Easy-To-Use Library for Creating Lexers in C#.

To use, include the LexerBuilder folder in your project, then add a ```using System``` to whatever
classes are going to be using it.

The constructor for LexerBuilder requires no arguments, creating an object works like:

```
LexerBuilder lexer = new LexerBuilder();
```

From here we can set the settings for the Lexer and how it is going to scan our code once we provide it.

The LexerBuilder object contains the following:
```
SetBinding(string letter, TokenType with);
ScanFrom(string from, string to, TokenType tokenType);
IgnoreChar(string character);
IgnoreFrom(string from, string to);
```

SetBinding configures the lexer to scan in a specific letter as a TokenType. TokenType is just an enum
found in Token.cs that can be added to, but already comes with most possible TokenTypes. For instance,
if you did ```lexer.SetBinding("+", TokenType.Addition);
``` it will configure the lexer to scan + as
TokenType.Addition.

ScanFrom configures the lexer to scan in all data between the from and to as a TokenType. Example:
```
lexer.ScanFrom("\"", "\"", TokenType.String);
``` will scan in everything between two double-quotes
as a string.

IgnoreChar configures the lexer to simply skip over all instances of a char in the source code.
Example: ```lexer.IgnoreChar(";");
``` causes the lexer to ignore all semi-colons in the code.

IgnoreFrom configures the lexer to skip over everything between (and including) the to and from
letters. Example: ```lexer.IgnoreFrom("$", "#")
``` will cause the lexer to skip over everything
between $ and #.
