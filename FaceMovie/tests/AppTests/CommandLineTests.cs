using CommandLine;
using FaceMovie.src.App;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceMovie.tests.AppTests
{
    [TestFixture]
    public class CommandLineTests
    {
        [Test]
        public void TestCommandLineParsing_ValidArgs()
        {
            var args = new string[] { "-i", "inputDir", "-o", "outputDir", "-r", "reference.jpg" };
            var result = Parser.Default.ParseArguments<CommandLineOptions>(args);
            Assert.That(result.Tag, Is.EqualTo(ParserResultType.Parsed));           
        }

        [Test]
        public void TestCommandLineParsing_InvalidArgs()
        {
            var args = new string[] { "-i", "inputDir" }; // Missing required options
            var result = Parser.Default.ParseArguments<CommandLineOptions>(args);
            Assert.That(result.Tag, Is.EqualTo(ParserResultType.NotParsed));
        }
    }
}
