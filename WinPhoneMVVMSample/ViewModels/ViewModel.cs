using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhoneMVVMSample.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void NavigateSomewhere(object obj)
        {
            //This is an example of navigation command
            //To use it, create a DelegateCommand on your page
            //Assign this method as the Action
            App.RootFrame.Navigate(new Uri("/Your/page.xaml", UriKind.Relative));

            /* for example:
             * 
             * declare:             private DelegateCommand _navigateToYourPageCommand;
             * ctor:                _navigateToYourPageCommand = new DelegateCommand(NavigateSomewhere);
             * propty for binding:  public ICommand GoToYourPageCommang { get { return _navigateToYourPageCommand; } }
             */
        }
    }
}
