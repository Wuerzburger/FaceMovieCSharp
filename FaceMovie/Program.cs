// See https://aka.ms/new-console-template for more information
using CommandLine;
using FaceMovie.src.App;

Console.WriteLine("Hello, World!");

partial class Program
{
    static void Main(string[] args)
    {
        Parser.Default.ParseArguments<CommandLineOptions>(args)
               .WithParsed<CommandLineOptions>(opts => RunApplication(opts))
               .WithNotParsed<CommandLineOptions>((errs) => HandleParseError(errs));
    }

    static void RunApplication(CommandLineOptions opts)
    {
        // Application logic goes here
        Console.WriteLine("Application started with the following options:");
        Console.WriteLine($"Input Directory: {opts.InputDirectory}");
        // Print other options similarly
    }

    static void HandleParseError(IEnumerable<Error> errs)
    {
        // Handle errors
        Console.WriteLine("Error parsing command-line arguments");
        // Additional error handling logic as needed
    }
}
