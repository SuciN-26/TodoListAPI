using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListAPI.DTOs;
using TodoListAPI.Service;

namespace TodoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChecklistController : ControllerBase
    {
        private readonly IChecklistService _checklistService;

        public ChecklistController(IChecklistService checklistService)
        {
            _checklistService = checklistService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetListChecklist()
        {
            var data = await _checklistService.GetChecklist();
            return Ok(data);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateChecklistDTO input)
        {
            var data = await _checklistService.GetChecklist();
            return Ok(data);
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(int checklistid)
        {
            var data = await _checklistService.DeleteChecklist(checklistid);

            if(data.Code == 404)
                return NotFound(data);

            return Ok(data);
        }
    }
}
