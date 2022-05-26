using WorkScheduler.Data;

namespace WorkScheduler.Controllers;

public interface IDatabaseInteraction
{
    Task<List<WorkDTO>> GetAll();
    Task<WorkDTO?> GetById(int id);
    Task Create(WorkDTO work);
    Task<bool> Update(WorkDTO work);
    Task<bool> Delete(int id);
}