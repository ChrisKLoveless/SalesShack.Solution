using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using SalesShack.Models;

namespace SalesShack.Controllers
{
  public class RoleController : Controller
  {
    private RoleManager<IdentityRole> roleManager;
    private UserManager<User> userManager;
    public RoleController(RoleManager<IdentityRole> roleMgr, UserManager<User> userMrg)
    {
      roleManager = roleMgr;
      userManager = userMrg;
    }

    public async Task<ActionResult> Index()
    {
      Dictionary<string, List<string>> members = new Dictionary<string, List<string>> { };
      foreach (IdentityRole role in roleManager.Roles.ToList())
      {
        string newRoleId = role.Id;
        IList<User> validMembers = await userManager.GetUsersInRoleAsync(role.Name);
        List<string> memberNames = new List<string> { };
        foreach (User memb in validMembers.ToList())
        {
          memberNames.Add(memb.UserName);
        }
        members.Add(newRoleId, memberNames);
      }
      ViewBag.members = members;
      return View(roleManager.Roles);
    }

    private void Errors(IdentityResult result)
    {
      foreach (IdentityError error in result.Errors)
        ModelState.AddModelError("", error.Description);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create([Required] string name)
    {
      if (ModelState.IsValid)
      {
        IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));
        if (result.Succeeded)
          return RedirectToAction("Index");
        else
          Errors(result);
      }
      return View(name);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
      IdentityRole role = await roleManager.FindByIdAsync(id);
      if (role != null)
      {
        IdentityResult result = await roleManager.DeleteAsync(role);
        if (result.Succeeded)
          return RedirectToAction("Index");
        else
          Errors(result);
      }
      else
        ModelState.AddModelError("", "No role found");
      return View("Index", roleManager.Roles);
    }

    public async Task<IActionResult> Update(string id)
    {
      IdentityRole role = await roleManager.FindByIdAsync(id);
      IList<User> members = await userManager.GetUsersInRoleAsync(role.Name);
      List<User> nonMembers = new List<User>();

      foreach (User user in userManager.Users)
      {
        if (!members.Contains(user))
        {
          nonMembers.Add(user);
        }
      }
      return View(new RoleEdit
      {
        Role = role,
        Members = members,
        NonMembers = nonMembers
      });
    }

    [HttpPost]
    public async Task<IActionResult> Update(RoleModification model)
    {
      IdentityResult result;
      if (ModelState.IsValid)
      {
        foreach (string userId in model.AddIds ?? new string[] { })
        {
          User user = await userManager.FindByIdAsync(userId);
          if (user != null)
          {
            result = await userManager.AddToRoleAsync(user, model.RoleName);
            if (!result.Succeeded)
              Errors(result);
          }
        }
        foreach (string userId in model.DeleteIds ?? new string[] { })
        {
          User user = await userManager.FindByIdAsync(userId);
          if (user != null)
          {
            result = await userManager.RemoveFromRoleAsync(user, model.RoleName);
            if (!result.Succeeded)
              Errors(result);
          }
        }
      }

      if (ModelState.IsValid)
        return RedirectToAction(nameof(Index));
      else
        return await Update(model.RoleId);
    }
  }
}