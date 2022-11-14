using AutoFixture;
using AutoFixture.AutoMoq;
using DocuManage.Data.Interfaces;
using DocuManage.Data.Models;
using DocuManage.Logic.Services;
using Moq;

namespace DocuManage.Test.Services
{
    public class DocumentServiceTests
    {
        private readonly IFixture _fixture;
        private Mock<IDocumentRepository> _documentRepositoryMock;

        public DocumentServiceTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _documentRepositoryMock = _fixture.Freeze<Mock<IDocumentRepository>>();
        }

        [Fact]
        public async Task GetShouldReturnValidResponse()
        {
            // setup
            _documentRepositoryMock.Setup(s => s.GetDocument(It.IsAny<Guid>()))
                .ReturnsAsync(_fixture.Build<DocumentDto>().Create());

            var service = new DocumentService(_documentRepositoryMock.Object);

            // test
            var response = await service.GetDocument(Guid.NewGuid());

            // assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task GetShouldReturnValidResponse_InvalidRequest()
        {
            // setup
            _documentRepositoryMock.Setup(s => s.GetDocument(It.IsAny<Guid>()))
                .ReturnsAsync(_fixture.Build<DocumentDto>().Create());

            var service = new DocumentService(_documentRepositoryMock.Object);

            // test
            var response = await service.GetDocument(Guid.Empty);

            // assert
            Assert.Null(response);
        }
    }
}