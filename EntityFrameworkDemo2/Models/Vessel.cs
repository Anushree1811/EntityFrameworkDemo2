using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkDemo.Models;

public class Vessel
{
    [Key]
    public Guid Id { get; set; } =Guid.NewGuid();

    public string Name { get; set; }

    public string Description { get; set; }
}

public class VesselDto
{
    
  

    public string Name { get; set; }

    public string Description { get; set; }
}

