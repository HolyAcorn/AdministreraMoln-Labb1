namespace CvWebApi.Models;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
    
    public short StartYear { get; set; }
    public short EndYear { get; set; }
    public bool Completed { get; set; }
    
}