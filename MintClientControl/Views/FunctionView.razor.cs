using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MintClientControl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MintClientControl.Views
{

    public class FunctionViewBase : ComponentBase
    {
        [Inject]
        public IFunctionViewModel ViewModel { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }
        protected override async Task OnInitializedAsync()
        {
            ViewModel.OnChange += StateHasChanged;

            var authState = await authenticationStateTask;
            var user = authState.User;
            if (user.Identity.IsAuthenticated)
            {
                //ViewModel.UserName = $"{user.Identity.Name}";
                //var claims = user.Identity;
                ViewModel.UserName = user.Claims.FirstOrDefault(c => c.Type == "preferred_username")?.Value;
            }
            else
            {
                ViewModel.UserName = "all";
            }
            await ViewModel.RetrieveFunctionsAsync();
        }
    }
}
