using Microsoft.AspNetCore.Html;
using Microsoft.DotNet.Interactive;
using System;

namespace CSVExtension;

public static class Commanding
{
    public static void Display(string text)
    {
        KernelInvocationContext.Current.Display(new HtmlString(text), "text/html");
    }

    public static void ExecuteAsync(string commandName)
    {
        Display($"<div>{commandName ?? "CIAONE"}</div>");
    }
}
