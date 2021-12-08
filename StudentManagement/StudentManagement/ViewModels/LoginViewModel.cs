﻿using StudentManagement.Commands;
using StudentManagement.Components;
using StudentManagement.Models;
using StudentManagement.Services;
using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Input;

namespace StudentManagement.ViewModels
{
    public class LoginViewModel : BaseViewModel, INotifyDataErrorInfo
    {
        private readonly ErrorBaseViewModel _errorBaseViewModel;

        private string _username;
        private string _password;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;

                // Validation
                _errorBaseViewModel.ClearErrors();
                if (!IsValid(Username))
                {
                    _errorBaseViewModel.AddError(nameof(Username), "Vui lòng nhập tên đăng nhập!");
                }

                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;

                // Validation
                _errorBaseViewModel.ClearErrors();
                if (!IsValid(Password))
                {
                    _errorBaseViewModel.AddError(nameof(Password), "Vui lòng nhập mật khẩu!");
                }

                OnPropertyChanged();
            }
        }

        public bool CanLogin => !HasErrors;
        public bool HasErrors => _errorBaseViewModel.HasErrors;

        public object CurrentView { get => _currentView; set { _currentView = value; OnPropertyChanged(); } }

        private object _currentView;

        public ICommand SwitchView { get; set; }

        public LoginViewModel()
        {
            _errorBaseViewModel = new ErrorBaseViewModel();
            _errorBaseViewModel.ErrorsChanged += ErrorBaseViewModel_ErrorsChanged;

            SwitchView = new RelayCommand<object>((p) => true, (p) => SwitchViewForm());
        }

        private void SwitchViewForm()
        {
            CurrentView = (CurrentView == null) || (CurrentView.GetType() == typeof(LoginForm)) ? new ForgotPassword() : (object)new LoginForm();
        }

        public bool IsExistAccount()
        {
            try
            {
                if (LoginServices.Instance.IsUserAuthentic(Username, Password))
                {
                    LoginServices.Instance.Login(Username);
                    return true;
                }

                _ = MyMessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!\nVui lòng thử lại!", "Đăng nhập thất bại", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return false;
            }
            catch
            {
                _ = MyMessageBox.Show("Xảy ra lỗi kết nối đến cơ sở dữ liệu!\nVui lòng thử lại!", "Đăng nhập thất bại", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return false;
            }
        }

        private bool IsValid(string propertyName)
        {
            return !string.IsNullOrEmpty(propertyName) && !string.IsNullOrWhiteSpace(propertyName);
        }

        private void ErrorBaseViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
            OnPropertyChanged(nameof(CanLogin));
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorBaseViewModel.GetErrors(propertyName);
        }
    }
}
