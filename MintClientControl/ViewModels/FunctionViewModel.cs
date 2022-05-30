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
        public string Notification { get; set; }
        public List<Functions> FunctionList { get; set; }
        public Functions AddData { get; set; }
        public bool AddDialog { get; set; }
        public string UserName { get; set; }
        void SendCommand(string command);
        Task RetrieveFunctionsAsync();
        void DeleteItem(Functions item);
        public void AddItem();
        void OpenDialog();
    }
    public class FunctionViewModel : IFunctionViewModel
    {
        private List<Functions> _functions;
        private IFunctionDataModel _FunctionDataModel;
        private Functions _addData;

        public FunctionViewModel(IFunctionDataModel FunctionDataModel)
        {
            _FunctionDataModel = FunctionDataModel;
            AddDialog = false;
            AddData = new Functions();
        }

        public List<Functions> FunctionList { get => _functions; set => _functions=value; }
        public bool AddDialog { get; set; }
        public Functions AddData { get => _addData; set => _addData=value; }
        public string Notification { get; set; }
        public string UserName { get; set; }

        public async Task RetrieveFunctionsAsync()
        {
            _functions = await _FunctionDataModel.RetrieveFunctionsAsync($"https://mintcontrolapi.azurewebsites.net/api/Functions/{UserName}");
        }

        public void SendCommand(string command)
        {
            Console.WriteLine(command);

        }

        public void DeleteItem(Functions item)
        {
            FunctionList.Remove(item);

        }
        public void AddItem()
        {
            if (AddData.Title != null && AddData.Command != null)
            {
                FunctionList.Add(AddData);
                AddData = new Functions();
                Notification = "Function added successfully";
            }
            else
            {
                Notification = "Missing data, please fill out all fields";
            }

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
