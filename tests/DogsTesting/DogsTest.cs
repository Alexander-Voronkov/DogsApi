using System.Collections.Generic;
using Xunit;
using Moq;
using Application.Common.Interfaces;
using Application.Handlers.Dogs.Commands.CreateDog;
using Domain.Entities;
using Application.Handlers.Dogs.Queries.GetDogs;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Application.Handlers.Dogs.Queries;
using FluentValidation;
using Application.Common.Behaviours;
namespace DogsTesting;

public class DogsTest
{
    public DogsTest()
    {
    }

    [Fact]
    public async Task ValidationFailsInMediatrPipeline()
    {
        // Arrange

        var query = new DogsQuery()
        {
            PageSize = -1,
            PageNumber = -1,
            SortAttribute = "dsad",
            Order = "safa",
            Limit = -1
        };

        var validators = new List<IValidator<DogsQuery>> { new DogsQueryValidator() };

        var pipeline = new ValidationBehaviour<DogsQuery, object>(validators);

        // Act & Assert

        await Assert.ThrowsAsync<FluentValidation.ValidationException>(() => pipeline.Handle(query, null, CancellationToken.None));
    }
}