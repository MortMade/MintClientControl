using Microsoft.AspNetCore.Components;
using MintClientControl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MintClientControl.Views
{

    public partial class FunctionView
    {
        [Inject]
        public IFunctionViewModel ViewModel { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await ViewModel.RetrieveFunctionsAsync();
        }
    }
}
