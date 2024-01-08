using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuCategories.Commands.DeleteMenuCategory;
public record DeleteMenuCategory(Guid Id) : ICommand<IResult>;
