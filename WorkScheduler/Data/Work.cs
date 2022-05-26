namespace WorkScheduler.Data;

public class Work
{
    public DateTime DeadLine { get; set; }
    public string Description { get; set; } = "";
    public string Name { get; set; } = "";
    
    public int Id { get; set; }
    public string? Assignee { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }    
}