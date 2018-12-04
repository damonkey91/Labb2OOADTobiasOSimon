using System;
using System.Windows.Input;
using Labb2OOADSimonOTobias.ValidationPattern;
using Xamarin.Forms;

namespace Labb2OOADSimonOTobias.ViewModels
{
    public class MainPageVeiwModel : BaseViewModel
    {

        public ICommand PwnedButton { get; set; }
        private ValidatableObject<string> _inputLabel = new ValidatableObject<string> ();
        public ValidatableObject<string> InputLabel
        { 
            get { return _inputLabel; } 
            set { _inputLabel = value; } 
        }
        private string _outputLabel = "";
        public string OutputLabel { 
            get { return _outputLabel; } 
            set { SetProperty(ref _outputLabel, value); } 
        }

        public MainPageVeiwModel()
        {
            PwnedButton = new Command(ClickedPwned);
            AddValidations();
        }

        private void ClickedPwned()
        {
            Validate();
            //Todo: Make text validation
            //Todo: Make Api call
        }

        private void AddValidations() 
        {
            _inputLabel.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Enter an email!" });
            _inputLabel.Validations.Add(new EmailRule<string> { ValidationMessage = "Email not valid!" });
        }

        private bool Validate()
        {
            return _inputLabel.Validate();
        }
    }
}
