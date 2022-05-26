using AutoMapper;

namespace WorkScheduler.Data;

public class WorkProfile : Profile
{
    public WorkProfile()
    {
        CreateMap<Work, WorkDTO>();
        CreateMap<WorkDTO, Work>();
    }
}