using LibraryAPI.Api.DTOs;
using LibraryAPI.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Api.Controllers;

[ApiController]
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
}
