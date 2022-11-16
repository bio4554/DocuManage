using AutoFixture;
using AutoFixture.AutoMoq;
using DocuManage.Data.Interfaces;
using DocuManage.Data.Models;
using DocuManage.Logic.Interfaces;
using DocuManage.Logic.Services;
using Moq;

namespace DocuManage.Test.Services
{
    public class DocumentServiceTests
    {
        private readonly IFixture _fixture;
        private Mock<IDocumentRepository> _documentRepositoryMock;
        private Mock<IFileService> _fileServiceMock;

        public DocumentServiceTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _documentRepositoryMock = _fixture.Freeze<Mock<IDocumentRepository>>();
            _fileServiceMock = _fixture.Freeze<Mock<IFileService>>();
        }

        [Fact]
        public async Task GetShouldReturnValidResponse()
        {
            // setup
            _documentRepositoryMock.Setup(s => s.Single<Document>(It.IsAny<Guid>()))
                .Returns(_fixture.Build<Document>().Create());

            var service = new DocumentService(_documentRepositoryMock.Object, _fileServiceMock.Object);

            // test
            var response = await service.GetDocument(Guid.NewGuid());

            // assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task GetShouldReturnValidResponse_InvalidRequest()
        {
            // setup
            _documentRepositoryMock.Setup(s => s.Single<Document>(It.IsAny<Guid>()))
                .Returns(_fixture.Build<Document>().Create());

            var service = new DocumentService(_documentRepositoryMock.Object, _fileServiceMock.Object);

            // test
            var response = await service.GetDocument(Guid.Empty);

            // assert
            Assert.Null(response);
        }
    }
}