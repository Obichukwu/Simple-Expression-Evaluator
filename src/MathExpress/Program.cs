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

        var evaluator = new ExpressionEvaluator();
        var (isEvaluationSuccessful, resultOrMessage) = evaluator.Evaluate(expression);

        if (isEvaluationSuccessful)
            AnsiConsole.MarkupLine($"{expression} = {resultOrMessage}");
        else
            AnsiConsole.MarkupLine(resultOrMessage);
    });
