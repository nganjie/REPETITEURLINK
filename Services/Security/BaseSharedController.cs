using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REPETITEURLINK.Entities.Extensions;
using REPETITEURLINK.Entities.Data;
using REPETITEURLINK.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace REPETITEURLINK.Services.Security;

public class BaseSharedController: ControllerBase
{
    protected readonly IHttpContextAccessor _accessor;
    protected readonly IRepository _repository;
    
    public  UserInfo? CurrentUser
    {
        get
        {
            return GetUserInfos();
        }
        private set;
    }


    public BaseSharedController(IHttpContextAccessor accessor, IRepository repository)
    {

        _accessor = accessor;
        _repository = repository;
      
       // CurrentUser = GetUserInfos();
    }

    private UserInfo? GetUserInfos()
    {
        //if (User.Identity != null && User.Identity.IsAuthenticated)
        //{
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value ?? string.Empty;
            var firstName = User.FindFirst(ClaimTypes.GivenName)?.Value ?? string.Empty;
            var lastName = User.FindFirst(ClaimTypes.Surname)?.Value ?? string.Empty;
            var roleClaim = User.FindFirst(ClaimTypes.Role)?.Value;
            var parentSubjectTypeClaim = User.FindFirst("parentSubjectType")?.Value ?? nameof(UserSubjectType.None);
            var parentSubjectIdClaim = User.FindFirst("parentSubjectId")?.Value;

        // Parsing sécurisé du userId
        Guid userId = Guid.Empty;
        Guid.TryParse(userIdClaim, out userId);

        // Parsing sécurisé du rôle
        UserRoles role = UserRoles.Student; // valeur par défaut
        if (!string.IsNullOrWhiteSpace(roleClaim))
        {
            Enum.TryParse(roleClaim, ignoreCase: true, out role);
        }

        // Parsing sécurisé de l'organisation
        Guid? parentSubjectId = null;
        if (Guid.TryParse(parentSubjectIdClaim, out var pId))
        {
            parentSubjectId = pId;
        }
        UserSubjectType parentSubjectType = UserSubjectType.None;
        if (!string.IsNullOrWhiteSpace(parentSubjectTypeClaim))
        {
            Enum.TryParse(parentSubjectIdClaim, ignoreCase: true, out parentSubjectType);
        }

        object parentSubject = null;
        if (parentSubjectType == UserSubjectType.None)
        {
            parentSubject= null;

        }
        if(!string.IsNullOrEmpty(parentSubjectIdClaim))
        {
            if (parentSubjectType == UserSubjectType.Parent)
            {
               parentSubject =  _repository.GetAll<Parent>().Where(x => x.Id == parentSubjectId).Select(x=>x.ToDto()).FirstOrDefault();
            }else if(parentSubjectType == UserSubjectType.Student)
            {
                parentSubject = _repository.GetAll<Student>().Where(x => x.Id == Guid.Parse(parentSubjectIdClaim)).Select(x => x.ToDto()).FirstOrDefault();
            }
            else if (parentSubjectType == UserSubjectType.Encadreur)
            {
                parentSubject = _repository.GetAll<Encadreur>().Where(x => x.Id == Guid.Parse(parentSubjectIdClaim)).Select(x => x.ToDto()).FirstOrDefault();
            }
        }


       

            var userInfos = new UserInfo
            {
                Id = userId,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                FullName = $"{firstName} {lastName}".Trim(),
                Role = role,
                ParentSubjectId= parentSubjectId,
                ParentSubjectType =parentSubjectType,
                ParentSubject=parentSubject
            };
            return userInfos;
        //}
       // return null;
    }
}
