using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Pages.UsuarioActivo
{
    [Authorize]
    public class CuentaModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public CuentaModel(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            Input = new InputModel();
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password Actual")]
            public string PasswordActual { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "El {0} debe ser de minimo {2} y maximo {1} caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Nuevo Password")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmar nuevo password")]
            [Compare("NewPassword", ErrorMessage = "El password y la confirmacion no coinciden.")]
            public string ConfirmPassword { get; set; }
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if(ModelState.IsValid)
            {
                var usuario = await _userManager.GetUserAsync(User);
                if(usuario == null)
                {
                    return RedirectToPage("/Index");
                }
                var resultado = await _userManager.ChangePasswordAsync(usuario, Input.PasswordActual, Input.NewPassword);
                if(!resultado.Succeeded)
                {
                    foreach(var error in resultado.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return Page();
                }
                await _signInManager.RefreshSignInAsync(usuario);
                return RedirectToPage("/UsuarioActivo/ConfirmacionCambioClave");
            }
            return Page();
        }
    }  
}

