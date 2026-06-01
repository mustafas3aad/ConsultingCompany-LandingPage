using AutoMapper;
using ConsultingCompany.BLL.Contracts.IEmailService;
using ConsultingCompany.BLL.DTOs.NewsletterSubscribers;
using ConsultingCompany.BLL.Exceptions;
using ConsultingCompany.BLL.Services;
using ConsultingCompany.DAL.Entities;
using ConsultingCompany.DAL.Repositories.IRepositories;
using ConsultingCompany.DAL.Specifications.ISpecifications;
using ConsultingCompany.DAL.UnitOfWork;
using ConsultingCompany.Shared.Localization;
using FluentAssertions;
using Microsoft.Extensions.Localization;
using Moq;
using Xunit;

public class NewsletterSubscriberServiceTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly Mock<IGenericRepository<NewsletterSubscriber>> _repoMock = new();

    private readonly Mock<IMapper> _mapperMock = new();
    private readonly Mock<IEmailService> _emailMock = new();
    private readonly Mock<IStringLocalizer<SharedResource>> _localizerMock = new();

    private NewsletterSubscriberService CreateService()
    {
        _unitOfWorkMock
            .Setup(x => x.GetRepository<NewsletterSubscriber>())
            .Returns(_repoMock.Object);

        return new NewsletterSubscriberService(
            _unitOfWorkMock.Object,
            _mapperMock.Object,
            _emailMock.Object,
            _localizerMock.Object
        );
    }

    [Fact]
    public async Task CreateAsync_Should_Return_Id_When_Email_Not_Exists()
    {
        // Arrange
        var dto = new CreateNewsletterSubscriberDto
        {
            Email = "test@test.com"
        };

        var subscriber = new NewsletterSubscriber
        {
            Id = 5,
            Email = dto.Email
        };

        _repoMock
            .Setup(x => x.GetByIdAsync(It.IsAny<ISpecifications<NewsletterSubscriber>>()))
            .ReturnsAsync((NewsletterSubscriber)null!);

        _mapperMock
            .Setup(x => x.Map<NewsletterSubscriber>(dto))
            .Returns(subscriber);

        _emailMock
            .Setup(x => x.SendEmailAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()))
            .ReturnsAsync(true);

        var service = CreateService();

        // Act
        var result = await service.CreateAsync(dto);

        // Assert
        result.Should().Be(5);

        _repoMock.Verify(x => x.AddAsync(It.IsAny<NewsletterSubscriber>()), Times.Once);
        _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);

        _emailMock.Verify(x => x.SendEmailAsync(
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public async Task CreateAsync_Should_Throw_Exception_When_Email_Already_Exists()
    {
        // Arrange
        var dto = new CreateNewsletterSubscriberDto
        {
            Email = "test@test.com"
        };

        var existingSubscriber = new NewsletterSubscriber
        {
            Id = 1,
            Email = dto.Email
        };

        _repoMock
            .Setup(x => x.GetByIdAsync(It.IsAny<ISpecifications<NewsletterSubscriber>>()))
            .ReturnsAsync(existingSubscriber);

        var service = CreateService();

        // Act
        Func<Task> act = async () => await service.CreateAsync(dto);

        // Assert
        await act.Should()
            .ThrowAsync<EmailAlreadySubscribedException>();
    }
}