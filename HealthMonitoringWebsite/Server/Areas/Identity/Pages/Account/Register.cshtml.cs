// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using HealthMonitoringWebsite.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using HealthMonitoringWebsite.Server.Data;
using HealthMonitoringWebsite.Shared.Domain;
using HealthMonitoringWebsite.Client.Static;
using HealthMonitoringWebsite.Client.Pages;
using System.Drawing.Text;

namespace HealthMonitoringWebsite.Server.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
		private readonly ApplicationDbContext _context;
		//private readonly PasswordHasher<Patient> _passwordHasher = new PasswordHasher<Patient>();
		//private readonly PasswordHasher<Staff> _passwordHasher1 = new PasswordHasher<Staff>();

		public RegisterModel(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context)
			//PasswordHasher<Patient> passwordHasher,
		   //PasswordHasher<Staff> passwordHasher1
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _context = context;
   //         _passwordHasher = passwordHasher;
			//_passwordHasher1 = passwordHasher1;


		}

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		[BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);

                //Set user first and last name
                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName;

                var result = await _userManager.CreateAsync(user, Input.Password);

                //int staffId = 0;
                //int patId = 0;

                if (result.Succeeded)
                {
					//Set user role to user
					_logger.LogInformation("User created a new account with password.");

					if (Input.Email.EndsWith("@staff.vitalmed.com", StringComparison.OrdinalIgnoreCase))
					{
						if (!await _roleManager.RoleExistsAsync("Staff"))
						{
							await _roleManager.CreateAsync(new IdentityRole("Staff"));

						}

						await _userManager.AddToRoleAsync(user, "Staff");
						//var sta = CreateStaff();
						//sta.Email = Input.Email;
      //                  //sta.Password = _passwordHasher1.HashPassword(sta, Input.Password);
      //                  sta.Password = Input.Password;
      //                  _context.Staffs.Add(sta);
						//await _context.SaveChangesAsync();
						//staffId = sta.StaffID;

					}
					else if (Input.Email.EndsWith("@admin.vitalmed.com", StringComparison.OrdinalIgnoreCase))
					{
						if (!await _roleManager.RoleExistsAsync("Admin"))
						{
							await _roleManager.CreateAsync(new IdentityRole("Admin"));
						}
						await _userManager.AddToRoleAsync(user, "Admin");
						//var sta = CreateStaff();
						//sta.Email = Input.Email;
						////sta.Password = _passwordHasher1.HashPassword(sta, Input.Password);
						//sta.Password = Input.Password;
						//_context.Staffs.Add(sta);
						//await _context.SaveChangesAsync();
						////staffId = sta.StaffID;
					}
					else
					{
						// Default role logic here, if necessary
						if (!await _roleManager.RoleExistsAsync("User"))
						{
							await _roleManager.CreateAsync(new IdentityRole("User"));
						}
						//await _userManager.AddToRoleAsync(user, "User");

						//var pat = CreatePatient();
						//pat.Email = Input.Email;
						////pat.Password = _passwordHasher.HashPassword(pat, Input.Password);
      //                  pat.Password = Input.Password;
						//_context.Patients.Add(pat);
						//await _context.SaveChangesAsync();
						////patId = pat.PatientID;
					}


                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {

                        await _signInManager.SignInAsync(user, isPersistent: false);
                        // Redirect user based on role

                        //string redirectUrl = Input.Email.EndsWith("@staff.vitalmed.com", StringComparison.OrdinalIgnoreCase)
                        //	 ? $"~/staffs/edit/{staffId}"
                        //	 : Input.Email.EndsWith("@admin.vitalmed.com", StringComparison.OrdinalIgnoreCase)
                        //	   ? returnUrl // Use a specific URL for admin if needed
                        //	   : $"~/patients/edit/{patId}";
                        //return LocalRedirect(redirectUrl);

                        if (Input.Email.EndsWith("@staff.vitalmed.com", StringComparison.OrdinalIgnoreCase))
                        {

                            return LocalRedirect($"~/staffs/register"); // Adjust to the actual staff dashboard link
                        }
                        else if (Input.Email.EndsWith("@admin.vitalmed.com", StringComparison.OrdinalIgnoreCase))
                        {
                            return LocalRedirect("~/staffs/register"); // Adjust to the actual admin dashboard link
                        }
                        else
                        {
                            return LocalRedirect($"~/patients/register");
                        }
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

   //     private Patient CreatePatient()
   //     {
   //         Patient patient = new Patient();
			//patient.PatientID = patient.Id;
			//patient.PatientName = "";
			//patient.PatientDateOfBirth = DateTime.Now;
   //         patient.PatientGender = "";
   //         patient.PatientNRIC = "";
   //         patient.PatientFamilyHistory = "";
   //         patient.PatientAllergies = "";
   //         patient.PatientBloodType = "";
   //         patient.PatientAddress = "";
   //         patient.PatientContactNumber = "";
   //         patient.PatientEmergencyContact = "";
			//return patient;
   //     }

   //     private Staff CreateStaff()
   //     {
   //         Staff staff = new Staff();
   //         staff.StaffID = staff.Id;
   //         staff.StaffName = "";
   //         staff.StaffContactNumber = "";
   //         staff.StaffRole = "";
   //         staff.StaffSpecialization = "";
   //         return staff;

   //     }
		private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
    }
}
