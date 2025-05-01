namespace EliteHaven.Web.Controllers;

public class AccountController : Controller
{
    #region Helper Fields
    // Inject all the necessary required classes and interface.
    private readonly IUnitOfWork unitOfWork;
    private readonly UserManager<ApplicationUser> userManager;
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly RoleManager<IdentityRole> roleManager;
    #endregion

    public AccountController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        this.unitOfWork = unitOfWork;
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.roleManager = roleManager;
    }

    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
    {
        // If the returnUrl is empty set it to the rool url.
        returnUrl ??= Url.Content("~/");

        LoginViewModel loginViewModel = new()
        {
            RedirectUrl = returnUrl,
        };

        return View(loginViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (ModelState.IsValid)
        {
            var result = await signInManager.PasswordSignInAsync(loginViewModel.Email!, loginViewModel.Password!, loginViewModel.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var user = await userManager.FindByEmailAsync(loginViewModel.Email!);
                if (await userManager.IsInRoleAsync(user!, StaticDetails.RoleAdmin))
                {
                    return RedirectToAction("Index", "Dashboard");
                }

                TempData["success"] = "Login success";

                if (string.IsNullOrEmpty(loginViewModel.RedirectUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return LocalRedirect(loginViewModel.RedirectUrl);
                }
            }
            else
            {
                TempData["error"] = "Invalid login attempt";
            }
        }
        return View(loginViewModel);
    }

    [HttpGet]
    public IActionResult Register(string? returnUrl = null)
    {
        // If the returnUrl is empty set it to the rool url.
        returnUrl ??= Url.Content("~/");
        RegisterViewModel registerViewModel = new()
        {
            RedirectUrl = returnUrl,
        };

        //registerViewModel.RoleList = GetRoles();

        return View(registerViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {
        // If some of the required fields are not populated.
        if (!ModelState.IsValid)
        {
            TempData["error"] = "Please fill all the details";
            //registerViewModel!.RoleList = GetRoles();
            return View(registerViewModel);
        }
        else
        {
            // This is the user we are supporting now and populating manually.
            ApplicationUser applicationUser = new()
            {
                Name = registerViewModel.Name,
                Email = registerViewModel.Email,
                PhoneNumber = registerViewModel.PhoneNumber,
                NormalizedEmail = registerViewModel.Email!.ToUpper(),
                EmailConfirmed = true,
                UserName = registerViewModel.Email, // Make sure the userName is email here...
                CreatedAt = DateTime.Now
            };

            // Create the ApplicationUser.
            IdentityResult result = await userManager.CreateAsync(applicationUser, registerViewModel.Password!);

            //if (result.Succeeded)
            //{
            //    TempData["success"] = "Account created successfully";

            //    // User has been created and make sure to add the role.
            //    if (!string.IsNullOrEmpty(registerViewModel.Role))
            //    {
            //        await userManager.AddToRoleAsync(applicationUser, registerViewModel.Role);
            //    }
            //    else
            //    {
            //        // If the role is not selected Customer is the default role.
            //        await userManager.AddToRoleAsync(applicationUser, StaticDetails.RoleCustomer);
            //    }

            //    // SignIn the user.
            //    await signInManager.SignInAsync(applicationUser, false);

            //    var user = await userManager.FindByEmailAsync(registerViewModel.Email!);
            //    if (await userManager.IsInRoleAsync(user!, StaticDetails.RoleAdmin))
            //    {
            //        return RedirectToAction("Index", "Dashboard");
            //    }

            //    // If there is something in redirect url go there.
            //    if (string.IsNullOrEmpty(registerViewModel.RedirectUrl))
            //    {
            //        return RedirectToAction("Index", "Home");
            //    }
            //    else
            //    {
            //        return LocalRedirect(registerViewModel.RedirectUrl);
            //    }
            //}
            //else
            //{
            //    // Variable to store the error message.
            //    string errorMessage = "";
            //    foreach (var message in result.Errors)
            //    {
            //        errorMessage += $"{message.Description}\n ";
            //    }

            //    // Add the combined error here to the toastr.
            //    TempData["error"] = $"{errorMessage}";

            //    // Populate the roles.
            //    registerViewModel!.RoleList = GetRoles();

            //    return View(registerViewModel);
            //}
            if (result.Succeeded)
            {
                TempData["success"] = "Account created successfully";

                // هنا نضيف الدور الافتراضي مباشرة بدون اختيار
                await userManager.AddToRoleAsync(applicationUser, StaticDetails.RoleCustomer);

                await signInManager.SignInAsync(applicationUser, false);

                if (string.IsNullOrEmpty(registerViewModel.RedirectUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return LocalRedirect(registerViewModel.RedirectUrl);
                }
            }
            else
            {
                string errorMessage = string.Join("\n", result.Errors.Select(e => e.Description));
                TempData["error"] = errorMessage;
                return View(registerViewModel);
            }
        }
    }


    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }

 
    public IActionResult AccessDenied()
    {
        return View();
    }


    private IEnumerable<SelectListItem> GetRoles()
    {
        return roleManager.Roles.Select(x => new SelectListItem
        {
            Text = x.Name,
            Value = x.Name
        });
    }
}
