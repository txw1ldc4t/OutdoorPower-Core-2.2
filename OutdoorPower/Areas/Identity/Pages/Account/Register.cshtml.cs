﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using OutdoorPower.Models;

namespace OutdoorPower.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<DealerEmployeeLoginCredential> _signInManager;
        private readonly UserManager<DealerEmployeeLoginCredential> _userManager;
        private readonly IOutdoorPowerRepository _outdoorPowerRepository;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<DealerEmployeeLoginCredential> userManager,
            SignInManager<DealerEmployeeLoginCredential> signInManager,
            IOutdoorPowerRepository outdoorPowerRepository,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _outdoorPowerRepository = outdoorPowerRepository;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IEnumerable<SelectListItem> States { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(20, MinimumLength = 2)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [StringLength(30, MinimumLength = 2)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [StringLength(150)]
            [Display(Name = "Dealer Name")]
            public string Name { get; set; }

            [Required]
            [StringLength(150)]
            public string Address { get; set; }

            [StringLength(150)]
            [Display(Name = "Address Line 2")]
            public string AddressLine2 { get; set; }

            [Required]
            [StringLength(150)]
            public string City { get; set; }

            [Required]
            [StringLength(2)]
            public string State { get; set; }

            [Required]
            [StringLength(10)]
            public string Zip { get; set; }

            [Required]
            [StringLength(25)]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }

            [StringLength(500)]
            public string Website { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/Manage/");
            if (ModelState.IsValid)
            {
                var user = new DealerEmployeeLoginCredential {
                    UserName = Input.Email,
                    Email = Input.Email
                };

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    Dealer dealer = new Dealer
                    {
                        Name = Input.Name,
                        Address = Input.Address,
                        AddressLine2 = Input.AddressLine2,
                        City = Input.City,
                        State = Input.State,
                        Zip = Input.Zip,
                        PhoneNumber = Input.PhoneNumber,
                        Website = Input.Website
                    };

                    Dealer found = _outdoorPowerRepository.GetDealer(dealer);

                    if(found == null)
                    {
                        _outdoorPowerRepository.AddDealer(dealer);

                        if (!await _outdoorPowerRepository.SaveChangesAsync())
                        {
                            ModelState.AddModelError("Save Failed", "Unable to save the dealer.");
                        }
                        else
                        {
                            found = dealer;
                        }
                    }

                    DealerEmployee dealerEmployee = new DealerEmployee
                    {
                        FirstName = Input.FirstName,
                        LastName = Input.LastName,
                        DealerId = found.Id,
                        DealerEmployeeLoginCredentialsId = new Guid(user.Id)
                    };

                    _outdoorPowerRepository.AddDealerEmployee(dealerEmployee);
                    if (!await _outdoorPowerRepository.SaveChangesAsync())
                    {
                        ModelState.AddModelError("Save Failed", "Unable to save the user information.");
                    }
                    else
                    {
                        IEnumerable<Claim> claims = new List<Claim>(
                            new Claim[]{
                                new Claim("DealerId", found.Id.ToString()),
                                new Claim("EditAccess", "DealerOwner")
                            }
                        );

                        var identityResult = await _userManager.AddClaimsAsync(
                            user,
                            claims
                        );
                    }


                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                } else
                {
                    bool duplicate = false;

                    foreach (var error in result.Errors)
                    {
                        if (error.Code == "DuplicateUserName" || error.Code == "DuplicateEmail")
                        {
                            duplicate = true;
                        }else
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }

                    if (duplicate)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
