﻿using AgentPortal.ClassApp;
using AgentPortal.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AgentPortal.WindowsApp
{
    /// <summary>
    /// Логика взаимодействия для EditAgentWindow.xaml
    /// </summary>
    public partial class EditAgentWindow : Window
    {
        public int userID {  get; set; }
        public EditAgentWindow(Employee employee)
        {
            InitializeComponent();
            userID = Convert.ToInt32(employee.user_id);
            txbSurname.Text = employee.surname;
            txbName.Text = employee.name;
            txbPatronymic.Text = employee.patronymic;
            txbPhone.Text = employee.phone;
            txbLogin.Text = ClassDB.connection.User.Where(z => z.ID == userID).FirstOrDefault().login;
            txbPassword.Text = ClassDB.connection.User.Where(z => z.ID == userID).FirstOrDefault().password.ToString();
        }

        private void ClEventSave(object sender, RoutedEventArgs e)
        {
            if (txbSurname.Text != "" && txbName.Text != "" && txbPatronymic.Text != "" && txbLogin.Text != "" && txbPassword.Text != "")
            {

                Employee employee = ClassDB.connection.Employee.Where(z => z.ID == userID).FirstOrDefault();
                employee.surname = txbSurname.Text;
                employee.name = txbName.Text;
                employee.patronymic = txbPatronymic.Text;
                employee.phone = txbPhone.Text;
                User _user = ClassDB.connection.User.Where(z => z.ID == employee.user_id).FirstOrDefault();
                _user.login = txbLogin.Text;
                _user.password = txbPassword.Text;
                ClassDB.connection.SaveChanges();
                this.Close();
            }
        }

        private void ClEventGoBack(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
