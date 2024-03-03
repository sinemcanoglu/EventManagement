namespace EventManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("create")]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventCommand command) => await _mediator.Send(command) ? Ok() : BadRequest();


        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetEvent([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetEventByIdQuery() { EventId = id });
            return result != null ? Ok(result) : NotFound();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteEvent([FromBody] DeleteEventCommand command) => await _mediator.Send(command) ? Ok() : NotFound();

    }
}