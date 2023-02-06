using Spectre.Console;

// See https://aka.ms/new-console-template for more information
AnsiConsole.Write(
    new FigletText("Maths Expression Eval")
    .LeftJustified()
    .Color(Color.Grey)
);
AnsiConsole.Markup("[underline green]Welcome to[/] [blue]Simple Mathematical Expression Evaluator[/]");


string expression = AnsiConsole.Ask("Enter a simple mathematical expression:", "1 + 1");


AnsiConsole.Status()
    .Start("Processing expression...", ctx =>
    {
        ctx.Spinner(Spinner.Known.Star);

        var tokens = expression.Split(' ');

        if (tokens.Length < 3)
        {
            AnsiConsole.MarkupLine("Expression is expected to have 3 parts, operand<space>operator<space>operand>");
        }

        if (!double.TryParse(tokens[0], out double operand1))
        {
            AnsiConsole.MarkupLine("Operand expects a numerical value");
        }

        if (!double.TryParse(tokens[2], out double operand2))
        {
            AnsiConsole.MarkupLine("Operand expects a numerical value");
        }

        double result = 0;
        bool isEvaluationSuccessful = false;
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
                AnsiConsole.MarkupLine("[red]Cannot divide by 0[/]");
                break;
            case "/" when operand2 > 0:
                result = operand1 / operand2; isEvaluationSuccessful = true;
                break;
            case "*":
                result = operand1 * operand2; isEvaluationSuccessful = true;
                break;
            default:
                isEvaluationSuccessful = false;
                AnsiConsole.MarkupLine("[red]Operation is not suppoprted[/]");
                break;
        }
        if (isEvaluationSuccessful)
          AnsiConsole.MarkupLine($"{expression} = {result}");
    });