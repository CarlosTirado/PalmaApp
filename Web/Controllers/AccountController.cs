using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.DatosBasicos.Tercero;
using Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestCore5.Data;
using TestCore5.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly PalmAppContext _dbPalmApp;
        public AccountController(
            ApplicationDbContext db,
            PalmAppContext dbPalmApp)
        {
            _db = db;
            _dbPalmApp = dbPalmApp;
        }

        // GET: api/Account/User/{username}/Roles
        [HttpGet("User/{username}/Roles")]
        public ActionResult<List<RoleViewModel>> GetRole(string username)
        {
            var userRoles = _db.Users
                .Where(t => t.UserName == username)
                .Join(_db.UserRoles,
                    user => user.Id,
                    userRole => userRole.UserId,
                    (user, userRole) => new { user, userRole })
                .Join(_db.Roles,
                    userUserRole => userUserRole.userRole.RoleId,
                    role => role.Id,
                    (userUserRole, role) => new { userUserRole.user, role })
                .Select(t => new RoleViewModel(t.role.Id, t.role.Name, t.role.NormalizedName))
                .ToList();

            return Ok(userRoles);
        }

        [HttpGet("UsersTerceros")]
        public ActionResult<List<TerceroModelView>> GetUsersTerceros()
        {
            var users = _db.Users.ToList();
            var terceros = _dbPalmApp.Terceros.ToList();

            var usersTerceros =  users.Join(terceros,
                    user => user.Email,
                    tercero => tercero.Email,
                    (user, tercero) => tercero)
                .Select(tercero => tercero)
                .ToList();

            return Ok(usersTerceros);
        }
    }

    public class RoleViewModel
    {
        public RoleViewModel(
            string id, 
            string name, 
            string normalizedName)
        {
            Id = id;
            Name = name;
            NormalizedName = normalizedName;
        }
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string NormalizedName { get; private set; }
    }

    public class ApplicationRole : IdentityRole
    {
        public string RolePadre { get; set; }
        public string Description { get; set; }
        public string Application { get; set; }
    }

}
