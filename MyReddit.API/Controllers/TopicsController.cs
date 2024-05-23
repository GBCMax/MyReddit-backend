using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyReddit.API.Contracts.Topics;
using MyReddit.Core.Interfaces.Services;
using MyReddit.Core.Models;

namespace MyReddit.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class TopicsController : ControllerBase
    {
        private readonly ITopicService _topicService;
        public TopicsController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet("GetAllTopics")]
        public async Task<ActionResult<List<TopicsResponse>>> GetTopics()
        {
            var topics = await _topicService.GetAllTopics();

            var response = topics.Select(x => new TopicsResponse(x.Id, x.Name));

            return Ok(response);
        }

        [HttpGet("GetTopicByName")]
        public async Task<ActionResult<TopicsResponse>> GetTopicByName([FromQuery] string name)
        {
            var topic = await _topicService.GetTopicByName(name);

            if(topic == null)
            {
                return BadRequest("Не найдено!");
            }

            var response = topic.Select(x => new TopicsResponse(x.Id, x.Name));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> AddTopic([FromBody] TopicsRequest request)
        {
            var (topic, error) = Topic.Create(
                Guid.NewGuid(),
                request.Name);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var topicId = await _topicService.AddTopic(topic);

            return Ok(topicId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateTopic(Guid id, [FromBody] TopicsRequest request)
        {
            var topicId = await _topicService.UpdateTopic(id, request.Name);

            return Ok(topicId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteTopic(Guid id)
        {
            return Ok(await _topicService.DeleteTopic(id));
        }
    }
}
