using TodoListAPI.Model;

namespace TodoListAPI.Repositories
{
    public interface IChecklistRepository
    {
        Task<IEnumerable<Checklist>> GetListChecklist();
        Task AddAsync(Checklist checklist);
        Task<Checklist> GetChecklist(int id);
        Task DeleteAsync(Checklist? checklist);
    }
}
