using Microsoft.AspNetCore.Mvc;

using EntityFrameworkDemo.Models;
using EntityFrameworkDemo.Interfaces;


namespace EntityFrameworkDemo.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        readonly IAuthorRepository _authorRepository;
        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        [HttpGet]
        public ActionResult<List<Author>> Get()
        {
        var authors = _authorRepository.GetAuthors();
        return Ok(authors);
    }
    }






