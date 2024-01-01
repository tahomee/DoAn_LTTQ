﻿using DoAn_LTTQ.Model;
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
    internal class LoginViewModel : BaseViewModel
    {
       
        public ICommand LoginCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        public ICommand PasswordChangedCommand { get; set; }

        public bool IsLogin { get; set; }
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        public LoginViewModel()
        {
            IsLogin = false;


            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {login(p);});
            CloseCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });

            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                Password = p.Password; 
            });
            void login(Window p)
            {
                if (p == null)
                    return;
                var accCount = DataProvider.Ins.DB.ACCOUNTs.Where(x => x.ACCOUNT_USERNAME == UserName && x.ACCOUNT_PASSWORD == Password).Count();
                if (accCount > 0)
                {
                    IsLogin = true;

                    p.Close();
                }
                else
                {
                    IsLogin = false;
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                }
            }

        }
    }
}

