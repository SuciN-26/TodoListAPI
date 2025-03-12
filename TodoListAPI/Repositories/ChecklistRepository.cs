using Microsoft.EntityFrameworkCore;
using TodoListAPI.Data;
using TodoListAPI.Model;

namespace TodoListAPI.Repositories
{
    public class ChecklistRepository : IChecklistRepository
    {
        private readonly AppDbContext _context;

        public ChecklistRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task AddAsync(Checklist checklist)
        {
            await _context.Checklists.AddAsync(checklist);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Checklist? checklist)
        {
            _context.Checklists.Remove(checklist);
            await _context.SaveChangesAsync();
        }

        public async Task<Checklist> GetChecklist(int id)
        {
            var data = await _context.Checklists.FirstOrDefaultAsync(x => x.Id == id);

            return data;
                 
        }

        public async Task<IEnumerable<Checklist>> GetListChecklist()
        {
            return await _context.Checklists.Include(x => x.User).ThenInclude(x => x.ChecklistItems).ToListAsync();
        }
    }
}
