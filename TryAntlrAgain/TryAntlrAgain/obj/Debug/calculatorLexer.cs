//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.3
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\mh93685.EUR.000\Desktop\ANTLR project\TryAntlrAgain\TryAntlrAgain\calculator.g4 by ANTLR 4.3

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591

namespace TryAntlrAgain {
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.3")]
[System.CLSCompliant(false)]
public partial class calculatorLexer : Lexer {
	public const int
		TRUE=1, FALSE=2, IF=3, OR=4, AND=5, INT=6, FLOAT=7, STRING=8, OPAR=9, 
		CPAR=10, EQ=11, NEQ=12, COMMA=13, MUL=14, DIV=15, ADD=16, SUB=17, LTEQ=18, 
		GTEQ=19, GT=20, LT=21, NOT=22, WS=23;
	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] tokenNames = {
		"'\\u0000'", "'\\u0001'", "'\\u0002'", "'\\u0003'", "'\\u0004'", "'\\u0005'", 
		"'\\u0006'", "'\\u0007'", "'\b'", "'\t'", "'\n'", "'\\u000B'", "'\f'", 
		"'\r'", "'\\u000E'", "'\\u000F'", "'\\u0010'", "'\\u0011'", "'\\u0012'", 
		"'\\u0013'", "'\\u0014'", "'\\u0015'", "'\\u0016'", "'\\u0017'"
	};
	public static readonly string[] ruleNames = {
		"TRUE", "FALSE", "IF", "OR", "AND", "INT", "FLOAT", "STRING", "OPAR", 
		"CPAR", "EQ", "NEQ", "COMMA", "MUL", "DIV", "ADD", "SUB", "LTEQ", "GTEQ", 
		"GT", "LT", "NOT", "WS"
	};


	public calculatorLexer(ICharStream input)
		: base(input)
	{
		_interp = new LexerATNSimulator(this,_ATN);
	}

	public override string GrammarFileName { get { return "calculator.g4"; } }

	public override string[] TokenNames { get { return tokenNames; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public static readonly string _serializedATN =
		"\x3\xAF6F\x8320\x479D\xB75C\x4880\x1605\x191C\xAB37\x2\x19\xB0\b\x1\x4"+
		"\x2\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t\a\x4\b\t\b"+
		"\x4\t\t\t\x4\n\t\n\x4\v\t\v\x4\f\t\f\x4\r\t\r\x4\xE\t\xE\x4\xF\t\xF\x4"+
		"\x10\t\x10\x4\x11\t\x11\x4\x12\t\x12\x4\x13\t\x13\x4\x14\t\x14\x4\x15"+
		"\t\x15\x4\x16\t\x16\x4\x17\t\x17\x4\x18\t\x18\x3\x2\x3\x2\x3\x2\x3\x2"+
		"\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x3"+
		"\x2\x5\x2\x42\n\x2\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3"+
		"\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x5\x3T\n\x3\x3\x4\x3\x4"+
		"\x3\x4\x3\x4\x5\x4Z\n\x4\x3\x5\x3\x5\x3\x5\x3\x5\x5\x5`\n\x5\x3\x6\x3"+
		"\x6\x3\x6\x3\x6\x3\x6\x3\x6\x5\x6h\n\x6\x3\a\x6\ak\n\a\r\a\xE\al\x3\b"+
		"\x6\bp\n\b\r\b\xE\bq\x3\b\x3\b\a\bv\n\b\f\b\xE\by\v\b\x3\b\x3\b\x6\b}"+
		"\n\b\r\b\xE\b~\x5\b\x81\n\b\x3\t\x5\t\x84\n\t\x3\t\x6\t\x87\n\t\r\t\xE"+
		"\t\x88\x3\t\x5\t\x8C\n\t\x3\n\x3\n\x3\v\x3\v\x3\f\x3\f\x3\r\x3\r\x3\r"+
		"\x3\xE\x3\xE\x3\xF\x3\xF\x3\x10\x3\x10\x3\x11\x3\x11\x3\x12\x3\x12\x3"+
		"\x13\x3\x13\x3\x13\x3\x14\x3\x14\x3\x14\x3\x15\x3\x15\x3\x16\x3\x16\x3"+
		"\x17\x3\x17\x3\x18\x3\x18\x3\x18\x3\x18\x2\x2\x2\x19\x3\x2\x3\x5\x2\x4"+
		"\a\x2\x5\t\x2\x6\v\x2\a\r\x2\b\xF\x2\t\x11\x2\n\x13\x2\v\x15\x2\f\x17"+
		"\x2\r\x19\x2\xE\x1B\x2\xF\x1D\x2\x10\x1F\x2\x11!\x2\x12#\x2\x13%\x2\x14"+
		"\'\x2\x15)\x2\x16+\x2\x17-\x2\x18/\x2\x19\x3\x2\t\x4\x2VVvv\x4\x2[[{{"+
		"\x4\x2HHhh\x4\x2PPpp\x3\x2\x32;\x4\x2\x43\\\x63|\x5\x2\f\f\xF\xF\"\"\xC4"+
		"\x2\x3\x3\x2\x2\x2\x2\x5\x3\x2\x2\x2\x2\a\x3\x2\x2\x2\x2\t\x3\x2\x2\x2"+
		"\x2\v\x3\x2\x2\x2\x2\r\x3\x2\x2\x2\x2\xF\x3\x2\x2\x2\x2\x11\x3\x2\x2\x2"+
		"\x2\x13\x3\x2\x2\x2\x2\x15\x3\x2\x2\x2\x2\x17\x3\x2\x2\x2\x2\x19\x3\x2"+
		"\x2\x2\x2\x1B\x3\x2\x2\x2\x2\x1D\x3\x2\x2\x2\x2\x1F\x3\x2\x2\x2\x2!\x3"+
		"\x2\x2\x2\x2#\x3\x2\x2\x2\x2%\x3\x2\x2\x2\x2\'\x3\x2\x2\x2\x2)\x3\x2\x2"+
		"\x2\x2+\x3\x2\x2\x2\x2-\x3\x2\x2\x2\x2/\x3\x2\x2\x2\x3\x41\x3\x2\x2\x2"+
		"\x5S\x3\x2\x2\x2\aY\x3\x2\x2\x2\t_\x3\x2\x2\x2\vg\x3\x2\x2\x2\rj\x3\x2"+
		"\x2\x2\xF\x80\x3\x2\x2\x2\x11\x83\x3\x2\x2\x2\x13\x8D\x3\x2\x2\x2\x15"+
		"\x8F\x3\x2\x2\x2\x17\x91\x3\x2\x2\x2\x19\x93\x3\x2\x2\x2\x1B\x96\x3\x2"+
		"\x2\x2\x1D\x98\x3\x2\x2\x2\x1F\x9A\x3\x2\x2\x2!\x9C\x3\x2\x2\x2#\x9E\x3"+
		"\x2\x2\x2%\xA0\x3\x2\x2\x2\'\xA3\x3\x2\x2\x2)\xA6\x3\x2\x2\x2+\xA8\x3"+
		"\x2\x2\x2-\xAA\x3\x2\x2\x2/\xAC\x3\x2\x2\x2\x31\x32\aV\x2\x2\x32\x33\a"+
		"T\x2\x2\x33\x34\aW\x2\x2\x34\x42\aG\x2\x2\x35\x36\av\x2\x2\x36\x37\at"+
		"\x2\x2\x37\x38\aw\x2\x2\x38\x42\ag\x2\x2\x39\x42\t\x2\x2\x2:;\a[\x2\x2"+
		";<\aG\x2\x2<\x42\aU\x2\x2=>\a{\x2\x2>?\ag\x2\x2?\x42\au\x2\x2@\x42\t\x3"+
		"\x2\x2\x41\x31\x3\x2\x2\x2\x41\x35\x3\x2\x2\x2\x41\x39\x3\x2\x2\x2\x41"+
		":\x3\x2\x2\x2\x41=\x3\x2\x2\x2\x41@\x3\x2\x2\x2\x42\x4\x3\x2\x2\x2\x43"+
		"\x44\aH\x2\x2\x44\x45\a\x43\x2\x2\x45\x46\aN\x2\x2\x46G\aU\x2\x2GT\aG"+
		"\x2\x2HI\ah\x2\x2IJ\a\x63\x2\x2JK\an\x2\x2KL\au\x2\x2LT\ag\x2\x2MT\t\x4"+
		"\x2\x2NO\ap\x2\x2OT\aq\x2\x2PQ\aP\x2\x2QT\aQ\x2\x2RT\t\x5\x2\x2S\x43\x3"+
		"\x2\x2\x2SH\x3\x2\x2\x2SM\x3\x2\x2\x2SN\x3\x2\x2\x2SP\x3\x2\x2\x2SR\x3"+
		"\x2\x2\x2T\x6\x3\x2\x2\x2UV\ak\x2\x2VZ\ah\x2\x2WX\aK\x2\x2XZ\aH\x2\x2"+
		"YU\x3\x2\x2\x2YW\x3\x2\x2\x2Z\b\x3\x2\x2\x2[\\\aq\x2\x2\\`\at\x2\x2]^"+
		"\aQ\x2\x2^`\aT\x2\x2_[\x3\x2\x2\x2_]\x3\x2\x2\x2`\n\x3\x2\x2\x2\x61\x62"+
		"\a\x63\x2\x2\x62\x63\ap\x2\x2\x63h\a\x66\x2\x2\x64\x65\a\x43\x2\x2\x65"+
		"\x66\aP\x2\x2\x66h\a\x46\x2\x2g\x61\x3\x2\x2\x2g\x64\x3\x2\x2\x2h\f\x3"+
		"\x2\x2\x2ik\t\x6\x2\x2ji\x3\x2\x2\x2kl\x3\x2\x2\x2lj\x3\x2\x2\x2lm\x3"+
		"\x2\x2\x2m\xE\x3\x2\x2\x2np\t\x6\x2\x2on\x3\x2\x2\x2pq\x3\x2\x2\x2qo\x3"+
		"\x2\x2\x2qr\x3\x2\x2\x2rs\x3\x2\x2\x2sw\a\x30\x2\x2tv\t\x6\x2\x2ut\x3"+
		"\x2\x2\x2vy\x3\x2\x2\x2wu\x3\x2\x2\x2wx\x3\x2\x2\x2x\x81\x3\x2\x2\x2y"+
		"w\x3\x2\x2\x2z|\a\x30\x2\x2{}\t\x6\x2\x2|{\x3\x2\x2\x2}~\x3\x2\x2\x2~"+
		"|\x3\x2\x2\x2~\x7F\x3\x2\x2\x2\x7F\x81\x3\x2\x2\x2\x80o\x3\x2\x2\x2\x80"+
		"z\x3\x2\x2\x2\x81\x10\x3\x2\x2\x2\x82\x84\a$\x2\x2\x83\x82\x3\x2\x2\x2"+
		"\x83\x84\x3\x2\x2\x2\x84\x86\x3\x2\x2\x2\x85\x87\t\a\x2\x2\x86\x85\x3"+
		"\x2\x2\x2\x87\x88\x3\x2\x2\x2\x88\x86\x3\x2\x2\x2\x88\x89\x3\x2\x2\x2"+
		"\x89\x8B\x3\x2\x2\x2\x8A\x8C\a$\x2\x2\x8B\x8A\x3\x2\x2\x2\x8B\x8C\x3\x2"+
		"\x2\x2\x8C\x12\x3\x2\x2\x2\x8D\x8E\a*\x2\x2\x8E\x14\x3\x2\x2\x2\x8F\x90"+
		"\a+\x2\x2\x90\x16\x3\x2\x2\x2\x91\x92\a?\x2\x2\x92\x18\x3\x2\x2\x2\x93"+
		"\x94\a#\x2\x2\x94\x95\a?\x2\x2\x95\x1A\x3\x2\x2\x2\x96\x97\a.\x2\x2\x97"+
		"\x1C\x3\x2\x2\x2\x98\x99\a,\x2\x2\x99\x1E\x3\x2\x2\x2\x9A\x9B\a\x31\x2"+
		"\x2\x9B \x3\x2\x2\x2\x9C\x9D\a-\x2\x2\x9D\"\x3\x2\x2\x2\x9E\x9F\a/\x2"+
		"\x2\x9F$\x3\x2\x2\x2\xA0\xA1\a>\x2\x2\xA1\xA2\a?\x2\x2\xA2&\x3\x2\x2\x2"+
		"\xA3\xA4\a@\x2\x2\xA4\xA5\a?\x2\x2\xA5(\x3\x2\x2\x2\xA6\xA7\a@\x2\x2\xA7"+
		"*\x3\x2\x2\x2\xA8\xA9\a>\x2\x2\xA9,\x3\x2\x2\x2\xAA\xAB\a#\x2\x2\xAB."+
		"\x3\x2\x2\x2\xAC\xAD\t\b\x2\x2\xAD\xAE\x3\x2\x2\x2\xAE\xAF\b\x18\x2\x2"+
		"\xAF\x30\x3\x2\x2\x2\x10\x2\x41SY_glqw~\x80\x83\x88\x8B\x3\x2\x3\x2";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
} // namespace TryAntlrAgain
