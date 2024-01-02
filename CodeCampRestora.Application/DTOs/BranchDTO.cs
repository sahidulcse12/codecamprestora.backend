using CodeCampRestora.Domain.Enums;

namespace CodeCampRestora.Application.DTOs;

public class BranchDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }
    public PriceRange? PriceRange { get; set; }
    public BranchCuisineTypeDTO BranchCuisineTypeDTO { get; set; }
    public BranchAddressDTO BranchAddressDTO { get; set; }

}

public class BranchCuisineTypeDTO
{
    public required string CuisinTag { get; set; }

}

public class BranchOpeningClosingTimeDTO
{
    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly Opening { get; set; }
    public TimeOnly Closing { get; set; }
    public bool IsClosed { get; set; }
}

public class BranchAddressDTO
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public string Division { get; set; }

    public string District { get; set; }
    public string Thana { get; set; }
    public string AreaDetails { get; set; }
}

