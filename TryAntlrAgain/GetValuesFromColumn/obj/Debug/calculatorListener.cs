//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.3
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\mh93685.EUR.000\Desktop\ANTLR project\TryAntlrAgain\GetValuesFromColumn\calculator.g4 by ANTLR 4.3

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591

namespace TryAntlrAgain {
using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="calculatorParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.3")]
[System.CLSCompliant(false)]
public interface IcalculatorListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by the <c>booleanAtom</c>
	/// labeled alternative in <see cref="calculatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBooleanAtom([NotNull] calculatorParser.BooleanAtomContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>booleanAtom</c>
	/// labeled alternative in <see cref="calculatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBooleanAtom([NotNull] calculatorParser.BooleanAtomContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>atomExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAtomExpr([NotNull] calculatorParser.AtomExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>atomExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAtomExpr([NotNull] calculatorParser.AtomExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>isErrorExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIsErrorExpr([NotNull] calculatorParser.IsErrorExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>isErrorExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIsErrorExpr([NotNull] calculatorParser.IsErrorExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>divZeroAtom</c>
	/// labeled alternative in <see cref="calculatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDivZeroAtom([NotNull] calculatorParser.DivZeroAtomContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>divZeroAtom</c>
	/// labeled alternative in <see cref="calculatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDivZeroAtom([NotNull] calculatorParser.DivZeroAtomContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="calculatorParser.condition_block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCondition_block([NotNull] calculatorParser.Condition_blockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="calculatorParser.condition_block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCondition_block([NotNull] calculatorParser.Condition_blockContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="calculatorParser.int_stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInt_stat([NotNull] calculatorParser.Int_statContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="calculatorParser.int_stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInt_stat([NotNull] calculatorParser.Int_statContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="calculatorParser.is_not"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIs_not([NotNull] calculatorParser.Is_notContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="calculatorParser.is_not"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIs_not([NotNull] calculatorParser.Is_notContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>parExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParExpr([NotNull] calculatorParser.ParExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>parExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParExpr([NotNull] calculatorParser.ParExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>unaryMinusExpr</c>
	/// labeled alternative in <see cref="calculatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnaryMinusExpr([NotNull] calculatorParser.UnaryMinusExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>unaryMinusExpr</c>
	/// labeled alternative in <see cref="calculatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnaryMinusExpr([NotNull] calculatorParser.UnaryMinusExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>ifExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIfExpr([NotNull] calculatorParser.IfExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>ifExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIfExpr([NotNull] calculatorParser.IfExprContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="calculatorParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBlock([NotNull] calculatorParser.BlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="calculatorParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBlock([NotNull] calculatorParser.BlockContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="calculatorParser.is_error"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIs_error([NotNull] calculatorParser.Is_errorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="calculatorParser.is_error"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIs_error([NotNull] calculatorParser.Is_errorContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="calculatorParser.if_stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIf_stat([NotNull] calculatorParser.If_statContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="calculatorParser.if_stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIf_stat([NotNull] calculatorParser.If_statContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>intExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIntExpr([NotNull] calculatorParser.IntExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>intExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIntExpr([NotNull] calculatorParser.IntExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>addSubExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAddSubExpr([NotNull] calculatorParser.AddSubExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>addSubExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAddSubExpr([NotNull] calculatorParser.AddSubExprContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="calculatorParser.is_eqisnan"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIs_eqisnan([NotNull] calculatorParser.Is_eqisnanContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="calculatorParser.is_eqisnan"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIs_eqisnan([NotNull] calculatorParser.Is_eqisnanContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="calculatorParser.abs_stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAbs_stat([NotNull] calculatorParser.Abs_statContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="calculatorParser.abs_stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAbs_stat([NotNull] calculatorParser.Abs_statContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="calculatorParser.and_stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAnd_stat([NotNull] calculatorParser.And_statContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="calculatorParser.and_stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAnd_stat([NotNull] calculatorParser.And_statContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>orExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOrExpr([NotNull] calculatorParser.OrExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>orExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOrExpr([NotNull] calculatorParser.OrExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>absExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAbsExpr([NotNull] calculatorParser.AbsExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>absExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAbsExpr([NotNull] calculatorParser.AbsExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>isNumberExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIsNumberExpr([NotNull] calculatorParser.IsNumberExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>isNumberExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIsNumberExpr([NotNull] calculatorParser.IsNumberExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>relationalExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRelationalExpr([NotNull] calculatorParser.RelationalExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>relationalExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRelationalExpr([NotNull] calculatorParser.RelationalExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>isnotExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIsnotExpr([NotNull] calculatorParser.IsnotExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>isnotExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIsnotExpr([NotNull] calculatorParser.IsnotExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>numberAtom</c>
	/// labeled alternative in <see cref="calculatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNumberAtom([NotNull] calculatorParser.NumberAtomContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>numberAtom</c>
	/// labeled alternative in <see cref="calculatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNumberAtom([NotNull] calculatorParser.NumberAtomContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="calculatorParser.leftstat_block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLeftstat_block([NotNull] calculatorParser.Leftstat_blockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="calculatorParser.leftstat_block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLeftstat_block([NotNull] calculatorParser.Leftstat_blockContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>stringAtom</c>
	/// labeled alternative in <see cref="calculatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStringAtom([NotNull] calculatorParser.StringAtomContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>stringAtom</c>
	/// labeled alternative in <see cref="calculatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStringAtom([NotNull] calculatorParser.StringAtomContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="calculatorParser.rightstat_block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRightstat_block([NotNull] calculatorParser.Rightstat_blockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="calculatorParser.rightstat_block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRightstat_block([NotNull] calculatorParser.Rightstat_blockContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>iseqisnanExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIseqisnanExpr([NotNull] calculatorParser.IseqisnanExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>iseqisnanExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIseqisnanExpr([NotNull] calculatorParser.IseqisnanExprContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="calculatorParser.or_stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOr_stat([NotNull] calculatorParser.Or_statContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="calculatorParser.or_stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOr_stat([NotNull] calculatorParser.Or_statContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>mulDivExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMulDivExpr([NotNull] calculatorParser.MulDivExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>mulDivExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMulDivExpr([NotNull] calculatorParser.MulDivExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>equalityExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEqualityExpr([NotNull] calculatorParser.EqualityExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>equalityExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEqualityExpr([NotNull] calculatorParser.EqualityExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>andExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAndExpr([NotNull] calculatorParser.AndExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>andExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAndExpr([NotNull] calculatorParser.AndExprContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="calculatorParser.is_number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIs_number([NotNull] calculatorParser.Is_numberContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="calculatorParser.is_number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIs_number([NotNull] calculatorParser.Is_numberContext context);
}
} // namespace TryAntlrAgain
