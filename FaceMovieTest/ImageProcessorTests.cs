using ImageMagick;
using Moq;
using System.IO.Abstractions;
using System.IO;
using FaceMovie.src.App;

namespace FaceMovieTest
{
    [TestFixture]
    public class ImageProcessorTests
    {
        [Test]
        public void ResizeImages_ShouldResizeAllJpgImagesInDirectory()
        {
            // Setup mock file system or use a real one in a temporary directory
            // For brevity, this example will not dive into mocking details.

            var fileSystemMock = new Mock<IFileSystem>();

            // Setup your fileSystemMock as necessary...

            var processor = new ImageProcessor(fileSystemMock.Object);
            processor.ResizeImages("mockInputDir", "mockOutputDir", 1024);

            // Verify that images are resized and saved to the output directory
            // This could include checking the output directory for resized images,
            // their dimensions, or other relevant assertions.
        }

        [Test]
        public void ResizeImages_AllJpgImagesResizedAndSaved()
        {
            // Mock the file system
            var fileSystemMock = new Mock<IFileSystem>();
            var directoryMock = new Mock<IDirectory>();
            var fileMock = new Mock<IFile>();
            var inputDirectory = "input";
            var outputDirectory = "output";
            var targetSize = 100; // Target size for testing

            // Setup directory mock to return a list of fake images
            directoryMock.Setup(d => d.EnumerateFiles(inputDirectory, "*.jpg"))
                          .Returns(new List<string> { "image1.jpg", "image2.jpg" });
            // Setup file system mock to use the directory mock
            fileSystemMock.Setup(fs => fs.Directory).Returns(directoryMock.Object);
            fileSystemMock.Setup(fs => fs.File).Returns(fileMock.Object);

            // Mock reading and writing of files
            fileMock.Setup(f => f.OpenRead(It.IsAny<string>())).Returns((string path) =>
            {
                // Return a stream representing a mock image of arbitrary size
                var image = new MagickImage(MagickColors.Red, 200, 200);
                var stream = new MemoryStream();
                image.Write(stream, MagickFormat.Jpg);
                stream.Position = 0;
                return stream;
            });
            fileMock.Setup(f => f.Create(It.IsAny<string>())).Returns((string path) =>
            {
                // Return a memory stream for writing (in reality, this would write to disk)
                return new MemoryStream();
            });

            var processor = new ImageProcessor(fileSystemMock.Object);
            processor.ResizeImages(inputDirectory, outputDirectory, targetSize);

            // Verify that each image file was opened, processed, and saved
            fileMock.Verify(f => f.OpenRead(It.IsAny<string>()), Times.Exactly(2));
            fileMock.Verify(f => f.Create(It.IsAny<string>()), Times.Exactly(2));

            // Additional assertions can be made here, such as verifying the dimensions of the saved images
            // This step requires a more complex setup, including actual image processing and examination
        }
    }
}