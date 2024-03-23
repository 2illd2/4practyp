using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
using WpfApp8.zoomagDataSetTableAdapters;

namespace WpfApp8
{
    public partial class AnimalsCustomersWindow : Window
    { 
        private zoomagDataSet dataset = new zoomagDataSet();
        private AllDataWithoutIDsTableAdapter AllDataWithoutIDsAdapter = new AllDataWithoutIDsTableAdapter();
        public AnimalsCustomersWindow()
        {
            InitializeComponent();
            AnimalsCustomersGrd.ItemsSource = dataset.AllDataWithoutIDs.DefaultView;
            AllDataWithoutIDsAdapter.Fill(dataset.AllDataWithoutIDs);
            AnimalsCustomersGrd.SelectionChanged += AnimalsCustomersGrd_SelectionChanged;
        }
        private void AnimalsCustomersGrd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AnimalsCustomersGrd.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)AnimalsCustomersGrd.SelectedItem;
                TextBoxName.Text = selectedRow["AnimalName"].ToString(); 
                TextBoxSpecies.Text = selectedRow["AnimalSpecies"].ToString(); 
                TextBoxAge.Text = selectedRow["AnimalAge"].ToString(); 
                TextBoxPrice.Text = selectedRow["AnimalPrice"].ToString(); 
                TextBoxCustomerName.Text = selectedRow["CustomerName"].ToString();
                TextBoxCustomerEmail.Text = selectedRow["CustomerEmail"].ToString();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxCustomerName.Text) ||
                string.IsNullOrWhiteSpace(TextBoxCustomerEmail.Text) ||
                string.IsNullOrWhiteSpace(TextBoxName.Text) ||
                string.IsNullOrWhiteSpace(TextBoxSpecies.Text) ||
                string.IsNullOrWhiteSpace(TextBoxAge.Text) ||
                string.IsNullOrWhiteSpace(TextBoxPrice.Text) ||
                DatePickerOrderDate.SelectedDate == null) 
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DateTime orderDate = DatePickerOrderDate.SelectedDate.Value;

            DataRow newRow = dataset.AllDataWithoutIDs.NewRow();
            newRow["AnimalName"] = TextBoxCustomerName.Text;
            newRow["CustomerEmail"] = TextBoxCustomerEmail.Text;
            newRow["CustomerName"] = TextBoxName.Text;
            newRow["AnimalSpecies"] = TextBoxSpecies.Text;
            newRow["AnimalAge"] = Convert.ToInt32(TextBoxAge.Text);
            newRow["AnimalPrice"] = Convert.ToInt32(TextBoxPrice.Text);
            newRow["CustomerPhone"] = Convert.ToInt32(TextBoxAge.Text);
            newRow["OrderQuantity"] = Convert.ToInt32(TextBoxAge.Text);
            newRow["OrderDate"] = orderDate; 
            dataset.AllDataWithoutIDs.Rows.Add(newRow);
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (AnimalsCustomersGrd.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)AnimalsCustomersGrd.SelectedItem;

                int age;
                if (int.TryParse(TextBoxAge.Text, out age))
                {
                    selectedRow["AnimalAge"] = age;
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите корректный возраст.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                int price;
                if (int.TryParse(TextBoxPrice.Text, out price))
                {
                    selectedRow["AnimalPrice"] = price;
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите корректную цену.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                int selectedIndex = AnimalsCustomersGrd.SelectedIndex;
                try
                {
                    DataRow[] foundRows = dataset.AllDataWithoutIDs.Select($"AnimalName = '{selectedRow["AnimalName"]}' AND AnimalSpecies = '{selectedRow["AnimalSpecies"]}'");
                    if (foundRows.Length > 0)
                    {
                        DataRow originalRow = foundRows[0];
                        originalRow.BeginEdit();
                        originalRow["AnimalAge"] = age;
                        originalRow["AnimalPrice"] = price;
                        originalRow.EndEdit();
                        dataset.AllDataWithoutIDs.Rows[selectedIndex].ItemArray = originalRow.ItemArray;
                        MessageBox.Show("Данные успешно обновлены.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Строка не найдена.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при обновлении данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
            {
                if (AnimalsCustomersGrd.SelectedItem != null)
                {
                    DataRowView selectedRow = (DataRowView)AnimalsCustomersGrd.SelectedItem;
                    selectedRow.Delete();

                }
            }
        private void TextBoxAge_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[0-9]+$"))
            {
                e.Handled = true;
            }
        }
        private void TextBoxName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                int maxLength = 50;

                if (textBox.Text.Length >= maxLength)
                {
                    e.Handled = true;
                    return;
                }

                foreach (char c in e.Text)
                {
                    if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        private void TextBoxPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                int maxLength = 100;
                if (textBox.Text.Length >= maxLength)
                {
                    e.Handled = true;
                }
            }
        }
        private void TextBoxSpecies_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                int maxLength = 100;
                if (textBox.Text.Length >= maxLength)
                {
                    e.Handled = true;
                }
            }
        }
       
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }


    }
}
