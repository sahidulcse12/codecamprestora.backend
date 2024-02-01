using CodeCampRestora.Application.Common;
using CodeCampRestora.Application.Extensions;
using FluentValidation;

namespace CodeCampRestora.Application.Features.Auths.Commands.OwnerUpdate;
public class UpdateOwnerValidator : ApplicationValidator<UpdateOwnerCommand>
{
    public UpdateOwnerValidator()
    {
        RuleFor(p => p.FullName).NotEmpty().WithMessage("FullName is required");
        RuleFor(p=>p.NewPassword).Cascade(CascadeMode.Stop).ValidatePassword();
    }
}
