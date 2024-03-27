// See https://aka.ms/new-console-template for more information
using CommandLine;
using FaceMovie.src.App;
using System.IO.Abstractions;

Console.WriteLine("Hello, World!");

partial class Program
{
    static void Main(string[] args)
    {
        Parser.Default.ParseArguments<CommandLineOptions>(args)
        .WithParsed<CommandLineOptions>(opts =>
        {
            var fileSystem = new FileSystem(); // Use the real file system here
            var imageProcessor = new ImageProcessor(fileSystem);
            imageProcessor.ResizeImages(opts.InputDirectory, opts.OutputDirectory, opts.Size);

            Console.WriteLine("Image processing completed.");
        })
        .WithNotParsed<CommandLineOptions>((errs) =>
        {
            Console.WriteLine("Error parsing command line arguments");
        });
    }
}
