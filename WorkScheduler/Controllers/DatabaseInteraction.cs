using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkScheduler.Data;
using WorkScheduler.Database;

namespace WorkScheduler.Controllers;

internal class DatabaseInteraction : IDatabaseInteraction
{
    private readonly WorkDbContext _context;
    private readonly IMapper _mapper;

    public DatabaseInteraction(WorkDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<WorkDTO>> GetAll()
    {
        return _mapper.Map<List<WorkDTO>>(_context.Works.ToList());
    }

    public async Task<WorkDTO?> GetById(int id)
    {
        return _mapper.Map<WorkDTO>(await _context.FindAsync<Work>(id));
    }
    
    public async Task Create(WorkDTO work)
    {
        var newWork = _mapper.Map<Work>(work);
        await _context.AddAsync(newWork);
        await _context.SaveChangesAsync();
    }
    
    public async Task<bool> Update(WorkDTO work)
    {
        var oldWork = await _context.FindAsync<Work>(work.Id);
        if (oldWork == null) return false;
        oldWork.Assignee = work.Assignee;
        oldWork.Description = work.Description;
        oldWork.Created = work.Created;
        oldWork.DeadLine = work.DeadLine;
        oldWork.Name = work.Name;
        _context.Update(oldWork);
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> Delete(int id)
    {
        var work = await _context.FindAsync<Work>(id);
        if (work is null)
        {
            return false;
        }
        _context.Works.Remove(work);
        await _context.SaveChangesAsync();
        return true;
    }
}