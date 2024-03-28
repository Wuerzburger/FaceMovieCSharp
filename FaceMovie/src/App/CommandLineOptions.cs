using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceMovie.src.App
{
    public class CommandLineOptions
    {
        [Option('i', "input", Required = true, HelpText = "Input directory containing images.")]
        public string InputDirectory { get; set; }

        [Option('o', "output", Required = true, HelpText = "Output directory for resized images.")]
        public string OutputDirectory { get; set; }

        [Option('s', "size", Required = false, HelpText = "Target size for resizing images. Format: widthxheight")]
        public int Size { get; set; }

        [Option('r', "reference", Required = true, HelpText = "Reference image for alignment.")]
        public string ReferenceImage { get; set; }

        [Option('f', "fps", Required = false, HelpText = "Frames per second for the output video.")]
        public int? Fps { get; set; }

        [Option('n', "outputName", Required = false, HelpText = "Name of the output video file.")]
        public string OutputName { get; set; }

        // Added AlignmentDirectory option
        [Option('a', "alignment-directory", Required = true, HelpText = "Directory to save aligned images.")]
        public string AlignmentDirectory { get; set; }
    }
}
