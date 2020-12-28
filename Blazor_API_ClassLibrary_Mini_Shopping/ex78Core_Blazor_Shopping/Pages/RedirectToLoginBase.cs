using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ex78Core_Blazor_Shopping.Pages
{
    public class RedirectToLoginBase : ComponentBase
    {

        [Inject]
        public NavigationManager nav { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> authenticationState { get; set; }


        protected override async Task OnInitializedAsync()
        {
            var state = await authenticationState;

            if (state?.User?.Identity is null || !state.User.Identity.IsAuthenticated)
            {
                var returnUrl = nav.ToBaseRelativePath(nav.Uri);

                if (string.IsNullOrEmpty(returnUrl))
                {
                    nav.NavigateTo("identity/account/login");
                }
                else
                {
                    nav.NavigateTo($"identity/account/login?returnUrl=~/{returnUrl}", true);
                }
            }
        }
    }
}
