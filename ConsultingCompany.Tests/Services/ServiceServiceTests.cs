using AutoMapper;
using ConsultingCompany.BLL.DTOs.Services;
using ConsultingCompany.BLL.Services;
using ConsultingCompany.DAL.Entities;
using ConsultingCompany.DAL.Repositories.IRepositories;
using ConsultingCompany.DAL.Specifications.ISpecifications;
using ConsultingCompany.DAL.UnitOfWork;
using ConsultingCompany.Shared.Pagination;
using ConsultingCompany.Shared.QueryParams.services;
using FluentAssertions;
using Moq;
using Xunit;

public class ServiceServiceTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly Mock<IGenericRepository<Service>> _repoMock = new();
    private readonly Mock<IMapper> _mapperMock = new();

    private ServiceService CreateService()
    {
        _unitOfWorkMock
            .Setup(x => x.GetRepository<Service>())
            .Returns(_repoMock.Object);

        return new ServiceService(
            _unitOfWorkMock.Object,
            _mapperMock.Object
        );
    }

    [Fact]
    public async Task GetAllAsync_Should_Return_Paginated_Result_With_Data()
    {
        // Arrange
        var query = new ServiceQueryParams
        {
            Search = "it",
            PageIndex = 1,
            PageSize = 5
        };

        var services = new List<Service>
        {
            new Service { Id = 1, Name = "IT Consulting", Description = "Desc1" },
            new Service { Id = 2, Name = "IT Support", Description = "Desc2" }
        };

        var serviceDtos = new List<ServiceDto>
        {
            new ServiceDto { Id = 1, Name = "IT Consulting", Description = "Desc1" },
            new ServiceDto { Id = 2, Name = "IT Support", Description = "Desc2" }
        };

        _repoMock
     .Setup(x => x.GetAllAsync(It.IsAny<ISpecifications<Service>>()))
     .ReturnsAsync(services);

        _repoMock
      .Setup(x => x.CountAsync(It.IsAny<ISpecifications<Service>>()))
      .ReturnsAsync(2);

        _mapperMock
            .Setup(x => x.Map<IEnumerable<ServiceDto>>(services))
            .Returns(serviceDtos);

        var service = CreateService();

        // Act
        var result = await service.GetAllAsync(query);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().HaveCount(2);
        result.Count.Should().Be(2);
        result.PageIndex.Should().Be(1);
        result.PageSize.Should().Be(5);
    }
}