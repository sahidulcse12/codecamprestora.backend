using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Domain.Identity;
using CodeCampRestora.Infrastructure.Identity.Interfaces;
using CodeCampRestora.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace CodeCampRestora.Infrastructure.Identity.Adapters;

[ScopedLifetime]
public class ApplicationRoleManagerAdapter : IApplicationRoleManagerAdapter
{
    private readonly IApplicationRoleManager _applicationRoleManager;

    public ApplicationRoleManagerAdapter(IApplicationRoleManager applicationRoleManager)
    {
        _applicationRoleManager = applicationRoleManager;
    }

    public async Task<ApplicationRole?> FindByNameAsync(string roleName)
    {
        return await _applicationRoleManager.FindByNameAsync(roleName);
    }
}