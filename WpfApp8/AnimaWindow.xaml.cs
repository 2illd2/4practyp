using System;
using System.Collections.Generic;
using System.Data;
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
    
    public partial class AnimaWindow : Window
    {
        private zoomagDataSet dataset = new zoomagDataSet();
        private AnimalsTableAdapter animalsAdapter = new AnimalsTableAdapter();
        public AnimaWindow()
        {
            InitializeComponent();
            AnimalGrd.ItemsSource = dataset.Animals.DefaultView;
            animalsAdapter.Fill(dataset.Animals);
            AnimalGrd.SelectionChanged += AnimalGrd_SelectionChanged;
        }

        private void AnimalGrd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AnimalGrd.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)AnimalGrd.SelectedItem;
                TextBoxName.Text = selectedRow["Name"].ToString();
                TextBoxSpecies.Text = selectedRow["Species"].ToString();
                TextBoxAge.Text = selectedRow["Age"].ToString();
                TextBoxPrice.Text = selectedRow["Price"].ToString();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxName.Text) || string.IsNullOrWhiteSpace(TextBoxSpecies.Text) ||
                string.IsNullOrWhiteSpace(TextBoxAge.Text) || string.IsNullOrWhiteSpace(TextBoxPrice.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все текстовые поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DataRow newRow = dataset.Animals.NewRow();
            newRow["Name"] = TextBoxName.Text;
            newRow["Species"] = TextBoxSpecies.Text;
            newRow["Age"] = Convert.ToInt32(TextBoxAge.Text);
            newRow["Price"] = Convert.ToInt32(TextBoxPrice.Text);
            dataset.Animals.Rows.Add(newRow);

            animalsAdapter.Update(dataset.Animals);
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (AnimalGrd.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)AnimalGrd.SelectedItem;
                selectedRow.BeginEdit();
                selectedRow["Name"] = TextBoxName.Text;
                selectedRow["Species"] = TextBoxSpecies.Text;
                selectedRow["Age"] = Convert.ToInt32(TextBoxAge.Text);
                selectedRow["Price"] = Convert.ToInt32(TextBoxPrice.Text);
                selectedRow.EndEdit();

                animalsAdapter.Update(dataset.Animals);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (AnimalGrd.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)AnimalGrd.SelectedItem;
                selectedRow.Delete();

                animalsAdapter.Update(dataset.Animals);
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

        private void TextBoxPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[0-9]+$"))
            {
                e.Handled = true;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

    }
}
    
