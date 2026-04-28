using LibraryAPI.Api.DTOs;
using LibraryAPI.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Api.Controllers;

[ApiController]
[Route("api/controller")]
public class AuthorController : ControllerBase
{
    private readonly AuthorService _authorService;
    public AuthorController(AuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAuthor([FromBody] AuthorRequest authorDTO)
    {
        var author = await _authorService.CreateAuthor(authorDTO.Name, authorDTO.Biography);
        return CreatedAtAction(nameof(author.AuthorID), new {id = author.AuthorID}, author);
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var authors = _authorService.GetAllAuthors();
        return Ok(authors);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var author = _authorService.GetAuthorById(id);
        return Ok(author);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id,  [FromBody] AuthorRequest authorDTO)
    {
        var updatedAuthor = await _authorService.UpdateAuthor(id, authorDTO.Name, authorDTO.Biography);
        return Ok(updatedAuthor);
    }
}
