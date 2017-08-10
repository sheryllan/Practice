grammar calculator;

/*
 * Parser Rules
 */

 block : expr* EOF ;

 /*
  stat : if_stat
	  | and_stat
	  | or_stat
	  | expr
	  ;
 */

  expr : '(' expr ')'							# parExpr
	  |	expr op=('*'|'/') expr					# mulDivExpr
	  |	expr op=('+'|'-') expr					# addSubExpr
	  | expr op=(EQ | NEQ) expr					# equalityExpr
	  | expr op=(LTEQ | GTEQ | LT | GT) expr	# relationalExpr
	  | atom									# atomExpr
	  | if_stat									# ifExpr
	  | and_stat								# andExpr
	  | or_stat									# orExpr
	  | is_error								# isErrorExpr
	  | is_number								# isNumberExpr
	  | is_eqisnan								# iseqisnanExpr
	  | is_not									# isnotExpr
	  | abs_stat								# absExpr
	  | int_stat								# intExpr
	  ;
 
  atom : SUB atom								# unaryMinusExpr 
	  | (INT | FLOAT)							# numberAtom
	  | (TRUE | FALSE)							# booleanAtom
	  | STRING									# stringAtom
	  | DIVZERO									# divZeroAtom
	  ;

 if_stat : IF condition_block leftstat_block COMMA rightstat_block ;
 and_stat : AND condition_block* expr CPAR
		  | AND expr CPAR
		  ;
 or_stat : OR condition_block* rightstat_block  ;
 is_error : ISERROR expr CPAR ;
 is_number : ISNAN expr CPAR ;
 is_eqisnan : ISEQNAN expr CPAR ;
 is_not : NOT expr CPAR ;
 abs_stat : ABS expr CPAR;
 int_stat : INTEXPR expr CPAR;
		
 condition_block
		 : expr COMMA
 		 ;

leftstat_block
		: expr
		;
rightstat_block
		: expr CPAR
		;
/*
 * Lexer Rules
 */
 INT
	: [0-9]+
	;

FLOAT
	: [0-9]+ '.' [0-9]* 'E-'* [0-9]*
	| [0-9]+ '.' [0-9]* 'e-'* [0-9]*
	| [0-9]+ 'E-'+ [0-9]+
	| [0-9]+ 'e-'+ [0-9]+
	| '.' [0-9]+ 'E-'* [0-9]*
	| '.' [0-9]+ 'e-'* [0-9]*
	| [0-9]+ '.' [0-9]* 'E+'* [0-9]*
	| [0-9]+ '.' [0-9]* 'e+'* [0-9]*
	| '.' [0-9]+ 'E+'* [0-9]*
	| '.' [0-9]+ 'e+'* [0-9]*
	| [0-9]+ 'E+'+ [0-9]+
	| [0-9]+ 'e+'+ [0-9]+
	;

STRING
	: '"'* [A-Za-z]+ SENTENCE* '"'*
	;
fragment SENTENCE : ' ' [A-Za-z]+;

NEQ : '!=' 
	| '<>' ;

 TRUE
	: 'TRUE' 
	| 'true'
	| 'T'
	| 't'
	| 'YES'
	| 'yes'
	| 'Y'
	| 'y'
	;

 FALSE
	: 'FALSE'
	| 'false'
	| 'F'
	| 'f'
	| 'NO'
	| 'N'
	| 'n'
	| 'no'
	;

	IF
	: 'if('
	| 'IF('
	| 'If('
	| 'iF('
	| 'IF ('
	| 'if ('
	| 'If ('
	;

	OR
	: 'or('
	| 'OR('
	| 'Or('
	| 'oR('
	| 'or ('
	| 'OR ('
	| 'Or ('
	;

	AND
	: 'and('
	| 'AND('
	| 'And('
	| 'ANd('
	| 'anD('
	| 'and ('
	| 'AND ('
	| 'and ('
	;
	
	ISERROR
	: 'ISERROR('
	| 'iserror('
	| 'Iserror('
	| 'ISERROR ('
	| 'iserror ('
	| 'Iserror ('
	;

	ISNAN
	: 'isnumber('
	| 'ISNUMBER('
	| 'Isnumber('
	| 'isnumber ('
	| 'ISNUMBER ('
	| 'Isnumber ('
	;

	ISEQNAN
	: 'EQISNAN('
	| 'eqisnan('
	| 'Eqisnan('
	;

	NOT
	: 'not('
	| 'NOT('
	| 'Not('
	| 'not ('
	| 'NOT ('
	| 'Not ('
	;

	ABS
	: 'abs('
	| 'ABS('
	| 'Abs('
	| 'abs ('
	| 'ABS ('
	| 'Abs ('
	;

	INTEXPR
	: 'int('
	| 'INT('
	| 'Int('
	| 'int ('
	| 'INT ('
	| 'Int ('
	;



 DIVZERO: 'divide by zero';
 OPAR: '(';
 CPAR: ')';
 CPARGREEDY: ')'+? ;
 EQ	 : '=' ;
 COMMA:',' ;
 MUL : '*' ;
 DIV : '/' ;
 ADD : '+' ;
 SUB : '-' ;
 LTEQ : '<=' ;
 GTEQ : '>=' ;
 GT : '>' ;
 LT : '<' ;
 WS
	:	( ' ' | '\r' | '\n') -> channel(HIDDEN)
	;