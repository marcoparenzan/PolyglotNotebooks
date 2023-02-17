using Microsoft.DotNet.Interactive;
using System;
using System.Threading.Tasks;

namespace DemoConsoleNotebook;

public abstract class Command
{
    public abstract Task Execute();
}

public class WriteLineCommand: Command
{
    static int i;

    object o;

    public WriteLineCommand(object o) => this.o = o;

    public override Task Execute()
    {
        Console.WriteLine($"{i++:0000}: {o}");
        return Task.CompletedTask;
    }
}

public class SubmitCodeCommand : Command
{
    Kernel kernel;
    string code;

    public SubmitCodeCommand(Kernel kernel, string code)
    {
        this.kernel = kernel;
        this.code = code;
    }

    public override async Task Execute()
    {
        await kernel.SubmitCodeAsync(code);
    }
}
