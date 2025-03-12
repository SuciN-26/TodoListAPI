using System.Net;
using System.Security.Claims;
using TodoListAPI.Data;
using TodoListAPI.DTOs;
using TodoListAPI.Model;
using TodoListAPI.Repositories;

namespace TodoListAPI.Service
{
    public class ChecklistService : IChecklistService
    {
        private readonly IChecklistRepository _checklistRepository;
        private readonly ICurrentUserService _currentUserService;

        public ChecklistService(IChecklistRepository checklistRepository, ICurrentUserService currentUserService)
        {
            _checklistRepository = checklistRepository;
            _currentUserService = currentUserService;
        }

        public async Task<DataResponse<Checklist>> CreateChecklist(CreateChecklistDTO input)
        {
            var checklist = new Checklist()
            {
                Name = input.Name,
                UserId = Guid.Parse(_currentUserService.Id)
            };

            await _checklistRepository.AddAsync(checklist);

            return new DataResponse<Checklist>() { Code = 200, Message ="Data Berhasil disimpan"};
        }

        public async Task<DataResponse<Checklist>> DeleteChecklist(int id)
        {
            var data = await _checklistRepository.GetChecklist(id);

            if(data != null)
            {
                await _checklistRepository.DeleteAsync(data);
                return new DataResponse<Checklist>() { Code = 200, Message = "Data Berhasil dihapus" };
            }

            return new DataResponse<Checklist>()
            {
                Code = 404,
                Message = "Data Berhasil dihapus"
            }; 
        }

        public async Task<DataResponse<IEnumerable<Checklist>>> GetChecklist()
        {
            var data = await _checklistRepository.GetListChecklist();

            return new DataResponse<IEnumerable<Checklist>>
            {
                Code = (int)HttpStatusCode.OK,
                Message = "Data berhasil ditampilkan",
                Data = data
            };
        }



    }
}
