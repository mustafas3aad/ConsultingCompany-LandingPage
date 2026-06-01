using AutoMapper;
using ConsultingCompany.BLL.Contracts.IEmailService;
using ConsultingCompany.BLL.DTOs.ConsultationRequests;
using ConsultingCompany.BLL.Exceptions;
using ConsultingCompany.BLL.Services;
using ConsultingCompany.DAL.Entities;
using ConsultingCompany.DAL.Enums;
using ConsultingCompany.DAL.Repositories.IRepositories;
using ConsultingCompany.DAL.UnitOfWork;
using ConsultingCompany.Shared.Localization;
using FluentAssertions;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

public class ConsultationServiceTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly Mock<IGenericRepository<Service>> _serviceRepoMock = new();
    private readonly Mock<IGenericRepository<ConsultationRequest>> _consultationRepoMock = new();

    private readonly Mock<IMapper> _mapperMock = new();
    private readonly Mock<IEmailService> _emailMock = new();
    private readonly Mock<ILogger<ConsultationService>> _loggerMock = new();
    private readonly Mock<IStringLocalizer<SharedResource>> _localizerMock = new();

    private ConsultationService CreateService()
    {
        _unitOfWorkMock
            .Setup(x => x.GetRepository<Service>())
            .Returns(_serviceRepoMock.Object);

        _unitOfWorkMock
            .Setup(x => x.GetRepository<ConsultationRequest>())
            .Returns(_consultationRepoMock.Object);

        return new ConsultationService(
            _unitOfWorkMock.Object,
            _mapperMock.Object,
            _loggerMock.Object,
            _emailMock.Object,
            _localizerMock.Object
        );
    }


    [Fact]
    public async Task CreateAsync_Should_Return_Id_When_Valid_Data()
    {
        // Arrange
        var dto = new CreateConsultationRequestDto
        {
            FullName = "Mustafa",
            Email = "test@test.com",
            CompanyName = "ABC",
            ServiceId = 1
        };

        var serviceEntity = new Service
        {
            Id = 1,
            Name = "IT Consulting"
        };

        var consultationEntity = new ConsultationRequest
        {
            Id = 10
        };

        _serviceRepoMock
            .Setup(x => x.GetByIdAsync(1))
            .ReturnsAsync(serviceEntity);

        _mapperMock
            .Setup(x => x.Map<ConsultationRequest>(dto))
            .Returns(consultationEntity);

        _consultationRepoMock
            .Setup(x => x.AddAsync(It.IsAny<ConsultationRequest>()))
            .Returns(Task.CompletedTask);

        _emailMock .Setup(x => x.SendEmailAsync(
         It.IsAny<string>(),
         It.IsAny<string>(),
         It.IsAny<string>()))
        .ReturnsAsync(true);


        var service = CreateService();

        // Act
        var result = await service.CreateAsync(dto);

        // Assert
        result.Should().Be(10);

        _consultationRepoMock.Verify(x => x.AddAsync(It.IsAny<ConsultationRequest>()), Times.Once);
        _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        _emailMock.Verify(x => x.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public async Task CreateAsync_Should_Throw_ServiceNotFoundException()
    {
        // Arrange
        var dto = new CreateConsultationRequestDto
        {
            ServiceId = 99
        };

        _serviceRepoMock
            .Setup(x => x.GetByIdAsync(99))
            .ReturnsAsync((Service)null!);

        var service = CreateService();

        // Act
        Func<Task> act = async () => await service.CreateAsync(dto);

        // Assert
        await act.Should()
            .ThrowAsync<ServiceNotFoundException>();
    }



}
