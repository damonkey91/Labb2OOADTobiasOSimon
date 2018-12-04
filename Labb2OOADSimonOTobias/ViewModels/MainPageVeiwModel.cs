using System;
using System.Windows.Input;
using Labb2OOADSimonOTobias.ValidationPattern;
using Xamarin.Forms;

namespace Labb2OOADSimonOTobias.ViewModels
{
    public class MainPageVeiwModel : BaseViewModel
    {

        public ICommand PwnedButton { get; set; }
        private ValidatableObject<string> _inputLabel;
        public ValidatableObject<string> InputLabel
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

        private void AddValidations() 
        {
            _inputLabel.Validations.Add
        }
    }
}
