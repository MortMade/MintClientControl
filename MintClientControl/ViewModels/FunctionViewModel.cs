using MintClientControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MintClientControl.ViewModels
{
    public interface IFunctionViewModel
    {
        //Functions[] Functions { get; set; }
        public List<Functions> FunctionList { get; set; }
        public bool AddDialog { get; set; }
        void SendCommand(string command);
        Task RetrieveFunctionsAsync();
        void DeleteItem(Functions item);
        void OpenDialog();
    }
    public class FunctionViewModel : IFunctionViewModel
    {
        private List<Functions> _functions;
        private IFunctionDataModel _FunctionDataModel;

        public FunctionViewModel(IFunctionDataModel FunctionDataModel)
        {
            _FunctionDataModel = FunctionDataModel;
            AddDialog = false;
        }

        public List<Functions> FunctionList { get => _functions; set => _functions=value; }
        public bool AddDialog { get; set; }


        public async Task RetrieveFunctionsAsync()
        {
            _functions = await _FunctionDataModel.RetrieveFunctionsAsync();
        }

        public void SendCommand(string command)
        {
            Console.WriteLine(command);

        }

        public void DeleteItem(Functions item)
        {
            FunctionList.Remove(item);

        }

        public void OpenDialog()
        {
            if (AddDialog)
            {
                AddDialog = false;
            }
            else
            {
                AddDialog = true;
            }

        }

    }
}
