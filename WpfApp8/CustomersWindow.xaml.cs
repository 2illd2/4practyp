using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp8.zoomagDataSetTableAdapters;

namespace WpfApp8
{
    public partial class CustomersWindow : Window
    {
        private zoomagDataSet dataset = new zoomagDataSet();
        private CustomersTableAdapter customersAdapter = new CustomersTableAdapter();
        public CustomersWindow()
        {
            InitializeComponent();
            CustomerGrd.ItemsSource = dataset.Customers.DefaultView;
            customersAdapter.Fill(dataset.Customers);
            CustomerGrd.SelectionChanged += CustomerGrd_SelectionChanged;
        }
        private void CustomerGrd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CustomerGrd.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)CustomerGrd.SelectedItem;
                TextBoxCustomerName.Text = selectedRow["Name"].ToString();
                TextBoxCustomerEmail.Text = selectedRow["Email"].ToString();
                TextBoxCustomerPhone.Text = selectedRow["Phone"].ToString();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxCustomerName.Text) || string.IsNullOrWhiteSpace(TextBoxCustomerEmail.Text) ||
                string.IsNullOrWhiteSpace(TextBoxCustomerPhone.Text))
            {
                MessageBox.Show("Please fill in all text fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DataRow newRow = dataset.Customers.NewRow();
            newRow["Name"] = TextBoxCustomerName.Text;
            newRow["Email"] = TextBoxCustomerEmail.Text;
            newRow["Phone"] = TextBoxCustomerPhone.Text;
            dataset.Customers.Rows.Add(newRow);

            customersAdapter.Update(dataset.Customers);
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerGrd.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)CustomerGrd.SelectedItem;
                selectedRow.BeginEdit();
                selectedRow["Name"] = TextBoxCustomerName.Text;
                selectedRow["Email"] = TextBoxCustomerEmail.Text;
                selectedRow["Phone"] = TextBoxCustomerPhone.Text;
                selectedRow.EndEdit();

                customersAdapter.Update(dataset.Customers);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerGrd.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)CustomerGrd.SelectedItem;
                selectedRow.Delete();

                customersAdapter.Update(dataset.Customers);
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
