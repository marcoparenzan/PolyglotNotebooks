using Microsoft.DotNet.Interactive;
using Microsoft.DotNet.Interactive.CSharp;
using Microsoft.DotNet.Interactive.Documents;
using Microsoft.DotNet.Interactive.Events;
using System;
using System.IO;

var kernel = new CompositeKernel();

var csharpKernel = new CSharpKernel();
kernel.Add(csharpKernel);

var ki = new KernelInfoCollection();

var path = @"Test01.dib";
var fileInfo = new FileInfo(path);

var document = await InteractiveDocument.LoadAsync(fileInfo, ki);

foreach (var xx in document.Elements)
{
    if (xx.KernelName == csharpKernel.Name)
    {
        var result = await kernel.SubmitCodeAsync(xx.Contents);
        result.KernelEvents.Subscribe(Observe);
    }
}

Console.ReadLine();

void Observe(KernelEvent ev)
{
    switch (ev)
    {
        default:
            Console.WriteLine($"{ev.GetType().Name}: {ev}");
            break;
    }
}
