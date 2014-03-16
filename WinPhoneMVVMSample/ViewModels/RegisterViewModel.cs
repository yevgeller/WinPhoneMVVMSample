using WinPhoneMVVMSample.Models;
using WinPhoneMVVMSample.ServiceClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WinPhoneMVVMSample.ViewModels
{
    public class RegisterViewModel : ViewModel
    {
        ObservableCollection<Person> people;
        private DelegateCommand _registerCommand;

        public RegisterViewModel()
        {
            people = new ObservableCollection<Person>(); //data store
            people.CollectionChanged += people_CollectionChanged; //update some properties when collection changes
            _registerCommand = new DelegateCommand(this.RegisterCommandAction, CanRegister); //initialize command
            _displayInputWithoutAdditionalPropertyCommand = new DelegateCommand(this.DisplayInputWithoutAdditionalPropertyCommandAction);
        }

        //Registration procedure
        private void RegisterCommandAction(object obj)
        {
            people.Add(new Person
            {
                Name = this.UserName,
                Gender = this.IsALady ? "Lady" : "Gentleman"
            });
            this.UserName = "";
            this.IsALady = false;
            this.IsAGentleman = false;
        }
        //Data consistency conditions that must be satisfied for a successful registration
        private bool CanRegister(object arg)
        {
            return (IsALady || IsAGentleman) && UserName.Length > 0;
        }
        //Update some properties when the data store changes
        void people_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.OnPropertyChanged("People");
            this.OnPropertyChanged("RegisteredCount");
            this.OnPropertyChanged("ProspectiveRegistration");
        }
        //This is how the command exposed to the view
        public ICommand RegisterCommand { get { return _registerCommand; } }
        //Other properties that are exposed by the ViewModel to the View
        private bool _isALady;
        public bool IsALady
        {
            get { return _isALady; }
            set
            {
                if (_isALady == value)
                    return;
                _isALady = value;
                this.OnPropertyChanged("IsALady");
                this.OnPropertyChanged("ProspectiveRegistration");
                _registerCommand.RaiseCanExecuteChanged(); //checking on RegisterCommand to see if it can execute
            }
        }

        private bool _isAGentleman;
        public bool IsAGentleman
        {
            get { return _isAGentleman; }
            set
            {
                if (_isAGentleman == value)
                    return;
                _isAGentleman = value;
                this.OnPropertyChanged("IsAGentleman");
                this.OnPropertyChanged("ProspectiveRegistration");
                _registerCommand.RaiseCanExecuteChanged(); //checking on RegisterCommand to see if it can execute
            }
        }

        private string _userName;
        public string UserName
        {
            get
            {
                if (_userName == null)
                    _userName = "";
                return _userName;
            }
            set
            {
                if (_userName == value)
                    return;
                _userName = value;
                this.OnPropertyChanged("UserName");
                this.OnPropertyChanged("ProspectiveRegistration");
                _registerCommand.RaiseCanExecuteChanged(); //checking on RegisterCommand to see if it can execute
            }
        }

        public string ProspectiveRegistration
        {
            get
            {
                string ret = this.UserName;
                ret += this.UserName.Length > 0 ? ", " : "";

                if (this.IsALady)
                    ret += "Lady";
                if (this.IsAGentleman)
                    ret += "Gentleman";

                return ret;
            }
        }

        public string RegisteredCount { get { return "Registered: " + people.Count(); } }
        public ObservableCollection<Person> People
        {
            get { return people; }
            set
            {
                if (people == value)
                    return;
                people = value;
                this.OnPropertyChanged("People");
            }
        }

        #region Demo how to grab a value from a control's property without an additional command
        //the other line of code pertaining to this technique is instantiating _displayInputWithoutAdditionalPropertyCommand in constructor
        private DelegateCommand _displayInputWithoutAdditionalPropertyCommand;
        public ICommand DisplayInputWithoutAdditionalPropertyCommand { get { return _displayInputWithoutAdditionalPropertyCommand; } }

        private void DisplayInputWithoutAdditionalPropertyCommandAction(object obj)
        {
            //here the app gets the text property from a control via CommandParameter property
            //of a command

            if (obj.ToString().Trim() == string.Empty)
                ShowWhatWasTyped = "type something first";
            else
                ShowWhatWasTyped = "You typed: " + obj.ToString();
        }

        string _typedInput;
        public string TypedInput
        {
            get { return _typedInput; }
            set
            {
                if (_typedInput == value)
                    return;
                _typedInput = value;
                this.OnPropertyChanged("TypedInput");
            }
        }

        string _showWhatWasTyped;
        public string ShowWhatWasTyped
        {
            get { return _showWhatWasTyped; }
            set
            {
                if (_showWhatWasTyped == value)
                    return;
                _showWhatWasTyped = value;
                this.OnPropertyChanged("ShowWhatWasTyped");
            }
        }
        #endregion
    }
}
