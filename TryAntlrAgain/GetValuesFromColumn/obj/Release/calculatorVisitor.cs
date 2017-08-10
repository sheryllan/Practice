//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.3
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\PAA\ANTLR project\TryAntlrAgain\GetValuesFromColumn\calculator.g4 by ANTLR 4.3

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591

namespace TryAntlrAgain {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="calculatorParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.3")]
[System.CLSCompliant(false)]
public interface IcalculatorVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by the <c>booleanAtom</c>
	/// labeled alternative in <see cref="calculatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBooleanAtom([NotNull] calculatorParser.BooleanAtomContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>atomExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAtomExpr([NotNull] calculatorParser.AtomExprContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>isErrorExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIsErrorExpr([NotNull] calculatorParser.IsErrorExprContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>divZeroAtom</c>
	/// labeled alternative in <see cref="calculatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDivZeroAtom([NotNull] calculatorParser.DivZeroAtomContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="calculatorParser.condition_block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCondition_block([NotNull] calculatorParser.Condition_blockContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="calculatorParser.int_stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInt_stat([NotNull] calculatorParser.Int_statContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="calculatorParser.is_not"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIs_not([NotNull] calculatorParser.Is_notContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>parExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParExpr([NotNull] calculatorParser.ParExprContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>unaryMinusExpr</c>
	/// labeled alternative in <see cref="calculatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnaryMinusExpr([NotNull] calculatorParser.UnaryMinusExprContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>ifExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfExpr([NotNull] calculatorParser.IfExprContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="calculatorParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBlock([NotNull] calculatorParser.BlockContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="calculatorParser.is_error"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIs_error([NotNull] calculatorParser.Is_errorContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="calculatorParser.if_stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIf_stat([NotNull] calculatorParser.If_statContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>intExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIntExpr([NotNull] calculatorParser.IntExprContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>addSubExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAddSubExpr([NotNull] calculatorParser.AddSubExprContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="calculatorParser.is_eqisnan"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIs_eqisnan([NotNull] calculatorParser.Is_eqisnanContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="calculatorParser.abs_stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAbs_stat([NotNull] calculatorParser.Abs_statContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="calculatorParser.and_stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAnd_stat([NotNull] calculatorParser.And_statContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>orExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOrExpr([NotNull] calculatorParser.OrExprContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>absExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAbsExpr([NotNull] calculatorParser.AbsExprContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>isNumberExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIsNumberExpr([NotNull] calculatorParser.IsNumberExprContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>relationalExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRelationalExpr([NotNull] calculatorParser.RelationalExprContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>isnotExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIsnotExpr([NotNull] calculatorParser.IsnotExprContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>numberAtom</c>
	/// labeled alternative in <see cref="calculatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumberAtom([NotNull] calculatorParser.NumberAtomContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="calculatorParser.leftstat_block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLeftstat_block([NotNull] calculatorParser.Leftstat_blockContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>stringAtom</c>
	/// labeled alternative in <see cref="calculatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStringAtom([NotNull] calculatorParser.StringAtomContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="calculatorParser.rightstat_block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRightstat_block([NotNull] calculatorParser.Rightstat_blockContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>iseqisnanExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIseqisnanExpr([NotNull] calculatorParser.IseqisnanExprContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="calculatorParser.or_stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOr_stat([NotNull] calculatorParser.Or_statContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>mulDivExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMulDivExpr([NotNull] calculatorParser.MulDivExprContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>equalityExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEqualityExpr([NotNull] calculatorParser.EqualityExprContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>andExpr</c>
	/// labeled alternative in <see cref="calculatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAndExpr([NotNull] calculatorParser.AndExprContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="calculatorParser.is_number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIs_number([NotNull] calculatorParser.Is_numberContext context);
}
} // namespace TryAntlrAgain
