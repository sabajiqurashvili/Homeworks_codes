using Homework20.Controllers;
using Homework20.Domain;
using Homework20.Filters;
using Homework20.interfaces;
using Homework20.Model;
using Homework20.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Homework20.Tests;

public class PersonControlllerTest
{
    private readonly IPerson<Person> _service;
    private readonly PersonController _personController;

    public PersonControlllerTest()
    {
        _service = new PersonServiceFake();
        _personController = new PersonController(_service);
    }

    [Fact]
    public void GetByIdUnknownGuidPassed_returnsNotFoundResult()
    {
        // arange
        int id = 9;
        // arange + act
        var notFoundResult = _personController.GetById(id);
        //assert
        Assert.IsType<NotFoundObjectResult>(notFoundResult);
    }

    [Fact]
    public void GetByIdCorrectIdPassed_returnsOkResult()
    {
        // arange
        int id = 1;
        // arange + act
        var okResult = _personController.GetById(id);
        //assert
        Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
    }

    [Fact]
    public void GetByIdIncorrectIdPassed_returnsBadRequest()
    {
        // arange
        int id = 0;
        // arange + act
        var badRequest = _personController.GetById(id);
        //assert
        Assert.IsType<BadRequestObjectResult>(badRequest);
    }

    [Fact]
    public void UpdateIncorrectIdPassed_returnsBadRequest()
    {
        int id = 0;
        Person person = _service.GetById(1);
        var badRequest = _personController.Update(id,person);
        Assert.IsType<BadRequestObjectResult>(badRequest);
    }
    [Fact]
    public void UpdateNullPersonPassed_returnsBadRequest()
    {
        int id = 1;
        Person person = null;
        var badRequest = _personController.Update(id,person);
        Assert.IsType<BadRequestObjectResult>(badRequest);
    }

    [Fact]
    public void DeleteIncorrectIdPassed_returnsBadRequest()
    {
        int id = 0;
        var badRequest = _personController.Delete(id);
        Assert.IsType<BadRequestObjectResult>(badRequest);
    }
    [Fact]
    public void DeleteIncorrectIdPassed_returnsNotFound()
    {
        int id = 10;
        var badRequest = _personController.Delete(id);
        Assert.IsType<NotFoundObjectResult>(badRequest);
    }

    
}