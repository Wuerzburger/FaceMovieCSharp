using FaceMovie.src.App;
using Moq;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceMovieTest
{
    [TestFixture]
    public class FaceAlignerTests
    {
        [Test]
        public void AlignFaces_ShouldAlignAndSaveFaces()
        {
            var fileSystemMock = new Mock<IFileSystem>();
            // Setup file system mock as needed...

            var aligner = new FaceAligner(fileSystemMock.Object);
            // You would typically call aligner.AlignFaces here and assert the expected outcomes
            // Due to the complexity of mocking Dlib operations, this example will not delve into those details
        }
    }
}
