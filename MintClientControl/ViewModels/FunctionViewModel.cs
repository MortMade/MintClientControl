using MintClientControl.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
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
        public event Action OnChange;
        void SendCommand(string command);
        Task RetrieveFunctionsAsync();
        void EditItem(Functions item);
        void CreateItem();
        void DeleteItem(Functions item);
        public Task AddItem();
        void OpenDialog();
        
    }
    public class FunctionViewModel : IFunctionViewModel
    {
        private List<Functions> _functions;
        // private IFunctionDataModel _FunctionDataModel;
        private Functions _addData;
        private bool _modalEdit;

        public FunctionViewModel()
        {
           // _FunctionDataModel = FunctionDataModel;
            AddDialog = false;
            AddData = new Functions();
            _modalEdit = false;
        }

        public List<Functions> FunctionList
        { get { return _functions; }
          set { _functions = value;}
        }
        public bool AddDialog { get; set; }
        public Functions AddData { get => _addData; set => _addData=value; }
        public string Notification { get; set; }
        public string UserName { get; set; }

        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();

        public async Task RetrieveFunctionsAsync()
        {
            FunctionList = await PersistenceService<Functions>.GetData($"api/Functions/{UserName}");
        }


        public void SendCommand(string command)
        {
            Console.WriteLine(command);

        }

        public async void DeleteItem(Functions item)
        {
            if (item.UserId == 1)
            {

            }
            else
            { 
                await PersistenceService<Functions>.DeleteData($"api/Functions/{item.FuncId}");
                FunctionList = await PersistenceService<Functions>.GetData($"api/Functions/{UserName}");
                NotifyStateChanged();
            }
        }

        public async Task AddItem()
        {
            if (_modalEdit)
            {
                await PersistenceService<Functions>.UpdateData(AddData, $"api/Functions/{AddData.FuncId}");
                NotifyStateChanged();
            }
            else
            {
                if (AddData.Title != null && AddData.Command != null)
                {
                    AddData.FuncRights = 0;//TODO set up dropdown
                    await PersistenceService<Functions>.PostData(AddData, $"api/Functions/{UserName}");
                    FunctionList = await PersistenceService<Functions>.GetData($"api/Functions/{UserName}");
                    NotifyStateChanged();
                    //AddData.UserId = 4;
                    //FunctionList.Add(AddData);
                    AddData = new Functions();
                    Notification = "Function added successfully";
                }
                else
                {
                    Notification = "Missing data, please fill out all fields";
                }
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

        public void EditItem(Functions item)
        {
            _modalEdit = true;
            AddData = item;
        }

        public void CreateItem()
        {
            _modalEdit = false;
            AddData = new Functions();
        }
    }
}
