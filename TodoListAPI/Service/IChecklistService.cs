using TodoListAPI.Data;
using TodoListAPI.DTOs;
using TodoListAPI.Model;

namespace TodoListAPI.Service
{
    public interface IChecklistService
    {
        Task<DataResponse<IEnumerable<Checklist>>> GetChecklist();

        Task<DataResponse<Checklist>> CreateChecklist(CreateChecklistDTO input);

        Task<DataResponse<Checklist>> DeleteChecklist(int id);
    }
}
