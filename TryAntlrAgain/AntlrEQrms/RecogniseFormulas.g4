grammar RecogniseFormulas;

 /*
  * Parser RuleS?
  */


  @parser::members {
  List<int> col = new List<int>();
  public RecogniseFormulasParser(ITokenStream input, List<int> col)
		: base(input)
	  {
		_interp = new ParserATNSimulator(this, _ATN);
		this.col = col;
	  }
  }

  file : (row NL)+ ; //NL = new line token

  row
  locals [int i=0]
  : (	STUFF
		{
		$i++;
		if ( col.Contains($i) ) Console.Write($STUFF.text);
		}
	)+
	;

	

/*
 * Lexer Rules
 */
	TAB		: '\t' -> skip	; //match but dont pass to the parser
	NL		: '\r'? '\n'	; // match and do pass to the parser
	STUFF	: ~[\t\r\n]+	; //match any chars except for tab and newline, thus can have space in the column


