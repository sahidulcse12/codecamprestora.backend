﻿ 
namespace CodeCampRestora.Domain.Entities.Branches;

public class Address  
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public string Division { get; set; }

    public string District { get; set; }
    public string Thana { get; set; }
    public string AreaDetails { get; set; }
    public Branch Branch { get; set; }


}
