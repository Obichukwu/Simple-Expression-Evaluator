namespace MathExpress.Tests;

using Xunit;

public class UnitTest1
{
    [Fact]
    public void Evaluate_1_Plus_1_Equals_2()
    {
        var evaluator = new ExpressionEvaluator();
        var (isEvaluationSuccessful, resultOrMessage) = evaluator.Evaluate("1 + 1");

        Assert.True(isEvaluationSuccessful);
        Assert.Equal("2", resultOrMessage);
    }


    [Fact]
    public void Evaluate_10_Minus_1_Equals_9()
    {
        var evaluator = new ExpressionEvaluator();
        var (isEvaluationSuccessful, resultOrMessage) = evaluator.Evaluate("10 - 1");

        Assert.True(isEvaluationSuccessful);
        Assert.Equal("9", resultOrMessage);
    }

    [Fact]
    public void Evaluate_10_Divide_By_2_Equals_5()
    {
        var evaluator = new ExpressionEvaluator();
        var (isEvaluationSuccessful, resultOrMessage) = evaluator.Evaluate("10 / 2");

        Assert.True(isEvaluationSuccessful);
        Assert.Equal("5", resultOrMessage);
    }

    [Fact]
    public void Evaluate_3_Multiply_4_Equals_12()
    {
        var evaluator = new ExpressionEvaluator();
        var (isEvaluationSuccessful, resultOrMessage) = evaluator.Evaluate("3 * 4");

        Assert.True(isEvaluationSuccessful);
        Assert.Equal("12", resultOrMessage);
    }
}