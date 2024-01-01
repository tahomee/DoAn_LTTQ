using DoAn_LTTQ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DoAn_LTTQ.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public bool IsLoaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand MoneyCommand { get; set; }
        public ICommand UserCommand { get; set; }
        public ICommand AccountCommand { get; set; }
        public ICommand InputCommand { get; set; }
        public ICommand OutputCommand { get; set; }
        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                IsLoaded = true;
                if (p == null)
                {
                    return;
                }
                p.Hide();
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
                if (loginWindow.DataContext == null)
                    return;
                var loginWM = loginWindow.DataContext as LoginViewModel;

                if (loginWM.IsLogin)
                {
                    p.Show();
                }

                else
                {
                    p.Close();
                }



            }
        );
          
            UserCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                UserWindow userWindow = new UserWindow();
                userWindow.ShowDialog();

            }
        );
            AccountCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                AccountWindow accountWindow = new AccountWindow();

                accountWindow.ShowDialog();
            }
        );
            InputCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                InputWindow inputWindow = new InputWindow();
                inputWindow.ShowDialog();

            }
        );
            OutputCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                OutputWindow outputWindow = new OutputWindow();
                outputWindow.ShowDialog();

            }
        );
        }

    }
}
