# GraphQL Dotnet Parser
<img src="https://ci.appveyor.com/api/projects/status/?svg=true"/>

This library contains a lexer and parser classes as well as the complete GraphQL AST model.

## Lexer
Generates token based on input text.
### Usage
```csharp
var lexer = new Lexer();
var token = lexer.Lex(new Source("\"str\""));
```

## Parser
Parses provided GraphQL expression into AST (abstract syntax tree).
### Usage
```csharp
var lexer = new Lexer();
var parser = new Parser(lexer);
var ast = parser.Parse(new Source(@"
{
  field(complex: {
    a: {
        b: [ $var ]
      }
  })
}"));
```
