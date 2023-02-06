
public class ExpressionEvaluator{
    public Tuple<bool, string> Evaluate(string expression){
        
        var tokens = expression.Split(' ');
        bool isEvaluationSuccessful = false;
        string evaluationResultOrMessage = "";
        if (tokens.Length < 3)
        {
            isEvaluationSuccessful = false;
            evaluationResultOrMessage="Expression is expected to have 3 parts, operand<space>operator<space>operand>";
        }

        if (!double.TryParse(tokens[0], out double operand1))
        {
            isEvaluationSuccessful = false;
            evaluationResultOrMessage="Operand expects a numerical value";
        }

        if (!double.TryParse(tokens[2], out double operand2))
        {
            isEvaluationSuccessful = false;
            evaluationResultOrMessage="Operand expects a numerical value";
        }

        double result = 0;

        switch (tokens[1])
        {
            case "+":
                result = operand1 + operand2;
                isEvaluationSuccessful = true;
                break;
            case "-":
                result = operand1 - operand2; isEvaluationSuccessful = true;
                break;
            case "/" when operand2 == 0:
                isEvaluationSuccessful = false;
                evaluationResultOrMessage="[red]Cannot divide by 0[/]";
                break;
            case "/" when operand2 > 0:
                result = operand1 / operand2; isEvaluationSuccessful = true;
                break;
            case "*":
                result = operand1 * operand2; isEvaluationSuccessful = true;
                break;
            default:
                isEvaluationSuccessful = false;
                evaluationResultOrMessage="[red]Operation is not suppoprted[/]";
                break;
        }

        if (isEvaluationSuccessful){
            evaluationResultOrMessage=$"{result}";
        }
        
        return Tuple.Create<bool, string>(isEvaluationSuccessful, evaluationResultOrMessage);
    }
}