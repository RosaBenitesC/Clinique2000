using Clinique2000_Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace Clinique2000_Web.Controllers
{
    public class UsersController : Controller
    {

        UserManager<User> UserManager;
        
        public UsersController(UserManager<User> userManager)
        {
            UserManager = userManager;
        }


        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Email,Password,PasswordConfirm")] RegisterDTO user)
        {


            if (ModelState.IsValid)
            {
                User utilisateur = new User()
                {
                    UserName = user.Username,
                    Email = user.Email,
                };


                IdentityResult identityResult = await UserManager.CreateAsync(utilisateur, user.Password);




                if (!identityResult.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "La création de l'utilisateur a échoué. Code:" + identityResult.Errors.FirstOrDefault().Code + " Description : " + identityResult.Errors.FirstOrDefault().Description });
                }
                else 
                {
                    //ViewData["userId"] = utilisateur.Id;
                    //ViewData["email"] = utilisateur.Email;
                }
                return RedirectToAction("Create","Patients",utilisateur );
               
                //await _service.CreateAsync(user);
                //return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //// GET: Users/Edit/5
        //public async Task<IActionResult> Edit(int id)
        //{

        //    //return View(await _service.GetForEditAsync(id));
        //}

        [HttpPost]
        public async Task<ActionResult> Register(RegisterDTO register)
        {
            if (register.Password != register.PasswordConfirm)
            { return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Les deux mots de passe spécifiés sont différents." }); }

            User user = new User()
            {
                UserName = register.Username,
                Email = register.Email,

            };


            IdentityResult identityResult = await UserManager.CreateAsync(user, register.Password);

            ViewData["email"] = user.Email;
          

            if (!identityResult.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "La création de l'utilisateur a échoué. Code:" + identityResult.Errors.FirstOrDefault().Code + " Description : " + identityResult.Errors.FirstOrDefault().Description });
            }
            return View(new Patient());
        }




    }
}
