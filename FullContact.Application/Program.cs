using FullContact.Contracts;
using Nito.AsyncEx;
using System;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FullContact.Application
{
  class Program
  {
    /// <summary>
    /// The main entry point of this application.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
      try
      {
        Compose();
        AsyncContext.Run(ExecuteAsync);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    /// <summary>
    /// Gets or sets the full contact api implementation.
    /// </summary>
    static IFullContactApi Api { get; set; }

    /// <summary>
    /// Composes this application using MEF composition container.
    /// </summary>
    static void Compose()
    {
      var executionDirectory = new FileInfo(typeof(Program).GetTypeInfo().Assembly.Location).Directory;
      var assemblyFiles = executionDirectory.EnumerateFiles("*.dll");

      var assemblies = assemblyFiles.Select(file => Assembly.LoadFile(file.FullName));
      var configuration = new ContainerConfiguration().WithAssemblies(assemblies);

      var container = configuration.CreateContainer();
      Api = container.GetExport<IFullContactApi>();
    }

    /// <summary>
    /// Asynchronously executes the task of this application.
    /// </summary>
    /// <returns>An awaitable task object.</returns>
    static async Task ExecuteAsync()
    {
      Console.WriteLine("Enter email address:");
      var email = Console.ReadLine();
      var person = await Api.LookupPersonByEmailAsync(email);
      Console.WriteLine($"{Environment.NewLine}{person}");
    }
  }
}
