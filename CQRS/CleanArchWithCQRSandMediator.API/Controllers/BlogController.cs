using CleanArchWithCQRSandMediator.Application;
using CleanArchWithCQRSandMediator.Application.Blogs.Queries.GetBlogById;
using CleanArchWithCQRSandMediator.Application.Blogs.Queries.GetBlogs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchWithCQRSandMediator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var blog = await Mediator.Send(new GetBlogQuery());
            return Ok(blog);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await Mediator.Send(new GetBlogByIdQuery()
            {
               BlogId=id
            });
            if (blog == null)
            {
                return NotFound("NOTHING WAS FOUND");
            }
            return Ok(blog);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            var blog=await Mediator.Send(command);
            Console.WriteLine($"Created blog with ID: {blog.Id}");

            return CreatedAtAction(nameof(GetById), new { id=blog.Id },blog);

        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBlog(int id, UpdateBlogCommand command)
        {
            if(id!=command.Id)
            {
                return BadRequest("no reccord founr");

            }
            await Mediator.Send(command);
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            await Mediator.Send(new DeleteBlogCommand{Id=id});
            return NoContent();
        }
    }
}