﻿namespace DeltaFit.Api.Infrastructure.Authentication
{
    public interface IPermissionService
    {
        Task<HashSet<string>> GetPermissionsAsync(Guid memberId);
    }
}
