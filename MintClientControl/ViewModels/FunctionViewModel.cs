using MintClientControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MintClientControl.ViewModels
{
    public interface IFunctionViewModel
    {
        Functions[] Functions { get; set; }
        void SendCommand(string command);
        Task RetrieveFunctionsAsync();
    }
    public class FunctionViewModel : IFunctionViewModel
    {
        private Functions[] _functions;
        private IFunctionDataModel _FunctionDataModel;

        public FunctionViewModel(IFunctionDataModel FunctionDataModel)
        {
            _FunctionDataModel = FunctionDataModel;
        }

        public Functions[] Functions { get => _functions; set => _functions=value; }

        public async Task RetrieveFunctionsAsync()
        {
            _functions = await _FunctionDataModel.RetrieveFunctionsAsync();
        }

        public void SendCommand(string command)
        {
            Console.WriteLine(command);

        }

    }
}
