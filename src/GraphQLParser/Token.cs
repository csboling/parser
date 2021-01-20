namespace GraphQLParser
{
    /// <summary>
    /// Represents a lexical token within GraphQL document.
    /// </summary>
    public readonly struct Token
    {
        /// <summary>
        /// Initializes a new instance with the specified properties.
        /// </summary>
        public Token(TokenKind kind, ROM value, int start, int end)
        {
            Kind = kind;
            Value = value;
            Start = start;
            End = end;
        }

        /// <summary>
        /// Kind of token. 
        /// </summary>
        public TokenKind Kind { get; }

        /// <summary>
        /// Starting position of the token in the document.
        /// </summary>
        public int Start { get; }

        /// <summary>
        /// Ending position of the token in the document.
        /// </summary>
        public int End { get; }

        /// <summary>
        /// Token value represented as a contiguous region of memory.
        /// </summary>
        public ROM Value { get; }

        internal static string GetTokenKindDescription(TokenKind kind) => kind switch
        {
            TokenKind.EOF => "EOF",
            TokenKind.BANG => "!",
            TokenKind.DOLLAR => "$",
            TokenKind.PAREN_L => "(",
            TokenKind.PAREN_R => ")",
            TokenKind.SPREAD => "...",
            TokenKind.COLON => ":",
            TokenKind.EQUALS => "=",
            TokenKind.AT => "@",
            TokenKind.BRACKET_L => "[",
            TokenKind.BRACKET_R => "]",
            TokenKind.BRACE_L => "{",
            TokenKind.PIPE => "|",
            TokenKind.BRACE_R => "}",
            TokenKind.NAME => "Name",
            TokenKind.INT => "Int",
            TokenKind.FLOAT => "Float",
            TokenKind.STRING => "String",
            TokenKind.COMMENT => "#",
            _ => string.Empty
        };

        private bool HasUniqueValue =>
            Kind == TokenKind.NAME ||
            Kind == TokenKind.INT ||
            Kind == TokenKind.FLOAT ||
            Kind == TokenKind.STRING ||
            Kind == TokenKind.COMMENT ||
            Kind == TokenKind.UNKNOWN;

        /// <inheritdoc/>
        public override string ToString() => HasUniqueValue
            ? $"{GetTokenKindDescription(Kind)} \"{Value}\""
            : GetTokenKindDescription(Kind);
    }
}
