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

  expr : expr op=('*'|'/') expr					# mulDivExpr
	  |	expr op=('+'|'-') expr					# addSubExpr
	  | expr op=(LTEQ | GTEQ | LT | GT) expr	# relationalExpr
	  | expr op=(EQ | NEQ) expr					# equalityExpr
	  | atom									# atomExpr
	  | if_stat									# ifExpr
	  | and_stat								# andExpr
	  | or_stat									# orExpr
	  ;
 
  atom : '(' expr ')' expr						# parExpr
	  | (INT | FLOAT)							# numberAtom
	  | (TRUE | FALSE)							# booleanAtom
	  | STRING									# stringAtom
	  ;

 if_stat : IF OPAR condition_block leftstat_block COMMA rightstat_block 
		 ;
				leftstat_block
					: expr
					;
				rightstat_block
					: expr CPAR
					;
 and_stat : AND OPAR condition_block* expr CPAR
		  ;
 or_stat : OR OPAR condition_block* expr CPAR
		 ;

 condition_block
		 : expr COMMA
 		 ;
/*
 * Lexer Rules
 */

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
	| 'no'
	| 'NO'
	| 'N'
	| 'n'
	;

	IF
	: 'if'
	| 'IF'
	;

	OR
	: 'or'
	| 'OR'
	;

	AND
	: 'and'
	| 'AND'
	;

	INT
	: [0-9]+
	;

	FLOAT
	: [0-9]+ '.' [0-9]*
	| '.' [0-9]+
	;

	STRING
	: '"'?[A-Za-z]+'"'?
	;

 OPAR: '(';
 CPAR: ')';
 EQ	 : '=' ;
 NEQ : '!=';
 COMMA:',' ;
 MUL : '*' ;
 DIV : '/' ;
 ADD : '+' ;
 SUB : '-' ;
 LTEQ : '<=' ;
 GTEQ : '>=' ;
 GT : '>' ;
 LT : '<' ;
 NOT : '!';
 WS
	:	(' ' | '\r' | '\n') -> channel(HIDDEN)
	;