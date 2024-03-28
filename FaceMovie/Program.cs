// See https://aka.ms/new-console-template for more information
using CommandLine;
using FaceMovie.src.App;
using System.IO.Abstractions;

partial class Program
{
    static void Main(string[] args)
    {
        var fileSystem = new FileSystem();

        Parser.Default.ParseArguments<CommandLineOptions>(args)
            .WithParsed<CommandLineOptions>(opts =>
            {
                var imageProcessor = new ImageProcessor(fileSystem);
                imageProcessor.ResizeImages(opts.InputDirectory, opts.OutputDirectory, opts.Size);

                var faceAligner = new FaceAligner(fileSystem);
                faceAligner.AlignFaces(opts.OutputDirectory, opts.AlignmentDirectory, opts.ReferenceImage);

                Console.WriteLine("Face alignment completed.");
            })
            .WithNotParsed<CommandLineOptions>((errs) =>
            {
                Console.WriteLine("Error parsing command line arguments");
            });
    }
}
