﻿////////////////////////////////////////////////////////////////////////////////
//
// Light Wings GameProject
//
// (C) 2009 Light Wings GameProject.
//
// https://github.com/LightWings-GameProject
//
////////////////////////////////////////////////////////////////////////////////

using System;

namespace Squirrel.ClassificationDefinitions
{
	public class Token
	{
		public enum TokenType
		{
			ILLEGAL,
			EOF,
			COMMENT,

			// Identifiers and basic type literals
			// (these tokens stand for classes of literals)
			IDENT,  // main
			INT,    // 12345
			FLOAT,  // 123.45
			IMAG,   // 123.45i
			CHAR,   // 'a'
			STRING, // "abc"

			// Operators and delimiters
			ADD, // +
			SUB, // -
			MUL, // *
			QUO, // /
			REM, // %

			AND,     // &
			OR,      // |
			XOR,     // ^
			SHL,     // <<
			SHR,     // >>
			AND_NOT, // &^

			ADD_ASSIGN, // +=
			SUB_ASSIGN, // -=
			MUL_ASSIGN, // *=
			QUO_ASSIGN, // /=
			REM_ASSIGN, // %=

			AND_ASSIGN,     // &=
			OR_ASSIGN,     // |=
			XOR_ASSIGN,     // ^=
			SHL_ASSIGN,     // <<=
			SHR_ASSIGN,     // >>=
			AND_NOT_ASSIGN, // &^=

			LAND,  // &&
			LOR,   // ||
			ARROW, // <-
			INC,   // ++
			DEC,   // --

			EQL,    // ==
			LSS,    // <
			GTR,    // >
			ASSIGN, // =
			NOT,    // !

			NEQ,      // !=
			LEQ,      // <=
			GEQ,      // >=
			DEFINE,   // :=
			ELLIPSIS, // ...

			LPAREN, // (
			LBRACK, // [
			LBRACE, // {
			COMMA, // ,
			PERIOD, // .

			RPAREN,    // )
			RBRACK,    // ]
			RBRACE,    // }
			SEMICOLON, // ;
			COLON,     // :

			// Keywords
			BREAK,
			CASE,
			CHAN,
			CONST,
			CONTINUE,

			DEFAULT,
			DEFER,
			ELSE,
			FALLTHROUGH,
			FOR,

			FUNC,
			GO,
			GOTO,
			IF,
			IMPORT,

			INTERFACE,
			MAP,
			PACKAGE,
			RANGE,
			RETURN,

			SELECT,
			STRUCT,
			SWITCH,
			TYPE,
			VAR
		}

		public string Type { get; set; }
		public string Literal { get; set; }
		public int Position { get; set; }

		public Token(string type, string literal, int position)
		{
			Type = type;
			Literal = literal;
			Position = position;
		}

		public TokenType TypeAsToken
		{
			get
			{
				TokenType result;
				Enum.TryParse<TokenType>(Type, true, out result);
				return result;
			}
		}
	}
}