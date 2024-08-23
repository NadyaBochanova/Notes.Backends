using Microsoft.AspNetCore.Http;
using Notes.Application.Interfaces;
using System;
using System.Security.Claims;

namespace Notes.WebApi.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public Guid UserId 
        { 
            get 
            {
                var id = _contextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
                return string.IsNullOrEmpty(id?.Value) ? Guid.Empty : Guid.Parse(id.Value);
            } 
        }

        public CurrentUserService(IHttpContextAccessor contextAccessor) => 
            _contextAccessor = contextAccessor;

    }
}
