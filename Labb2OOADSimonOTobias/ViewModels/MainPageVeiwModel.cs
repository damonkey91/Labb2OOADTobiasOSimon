using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Labb2OOADSimonOTobias.ViewModels
{
    public class MainPageVeiwModel : BaseViewModel
    {

        public ICommand PwnedButton { get; set; }
        private string _inputLabel = "";
        public string InputLabel 
        { 
            get { return _inputLabel; } 
            set { SetProperty(ref _inputLabel, value); } 
        }
        private string _outputLabel = "";
        public string OutputLabel { 
            get { return _outputLabel; } 
            set { SetProperty(ref _outputLabel, value); } 
        }

        public MainPageVeiwModel()
        {
            PwnedButton = new Command(ClickedPwned);
        }

        private void ClickedPwned()
        {
            //Todo: Make text validation
            //Todo: Make Api call
        }
    }
}
