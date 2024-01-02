using CodeCampRestora.Application.Common.Interfaces.MediatRs;

namespace CodeCampRestora.Application.Features.Images.Commands.CreateImage;

public record CreateImageCommand: ICommand
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string DataAsBase64 { get; set; } =  string.Empty;
    public int SizeInBytes { get; set; }
}