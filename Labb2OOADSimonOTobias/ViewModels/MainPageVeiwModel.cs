using System;
using System.Collections.Generic;
using System.Windows.Input;
using Labb2OOADSimonOTobias.Objects;
using Labb2OOADSimonOTobias.ValidationPattern;
using Labb2OOADSimonOTobias.Views;
using Xamarin.Forms;

namespace Labb2OOADSimonOTobias.ViewModels
{
    public class MainPageVeiwModel : BaseViewModel, ICallback
    {
        private bool IsEnabled { get; set; }
        private List<BreachedSites> breachedSites;
        public ICommand Navigate { get; set; }
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
        private string _color = "Black";
        public string MyColor 
        { 
            get { return _color; } 
            set { SetProperty(ref _color, value); }
        }

        public MainPageVeiwModel()
        {
            Navigate = new Command(Nav, () => IsEnabled);
            PwnedButton = new Command(ClickedPwned);
            AddValidations();
        }

        private void ClickedPwned()
        {
            IsEnabled = false;
            CanExecute();
            if (Validate()){
                HttpRequest.Request(InputLabel.Value, this);
            }
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

        public void Callback(int pwned, List<BreachedSites> result)
        {
            switch (pwned)
            {
                case -1:
                    OutputLabel = "Something went wrong";
                    MyColor = "Blue";
                    break;
                case 0:
                    OutputLabel = "Not pwned!";
                    MyColor = "Green";
                    break;
                case 1:
                    OutputLabel = "PWNED!!!";
                    MyColor = "Red";
                    breachedSites = result;
                    break;
                default:
                    break;
            }
            IsEnabled = result == null ? false : true;
            CanExecute();
        }
        private void Nav()
        {
            ListViewPage listViewPage = new ListViewPage();
            listViewPage.BindingContext = new ListViewViewModel(breachedSites);
            Application.Current.MainPage.Navigation.PushAsync(listViewPage);
        }

        private void CanExecute()
        {
            (Navigate as Command).ChangeCanExecute();
        }
    }
}
