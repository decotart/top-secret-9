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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Практическая_работа__9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<MailSends> mainList = new List<MailSends>();

        MailSends m1 = new(),
            m2 = new(),
            m3 = new(),
            m4 = new(),
            m5 = new();

        private void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            mainList.Add(m1);
            mainList.Add(m2);
            mainList.Add(m3);
            mainList.Add(m4);
            mainList.Add(m5);

            dataGrid.ItemsSource = mainList;
        }

        private void dataGrid_CellEditing(object sender, DataGridCellEditEndingEventArgs e)
        {
            int columnIndex = e.Column.DisplayIndex,
                rowIndex = e.Row.GetIndex();

            try
            {
                MailSends temp = mainList[rowIndex];

                switch (columnIndex)
                {
                    case 0:
                        temp.Town = ((TextBox)e.EditingElement).Text;
                        break;
                    case 1:
                        temp.Street = ((TextBox)e.EditingElement).Text;
                        break;
                    case 2:
                        temp.Recipient = ((TextBox)e.EditingElement).Text;
                        break;
                    case 3:
                        temp.House = Convert.ToInt32(((TextBox)e.EditingElement).Text);
                        break;
                    case 4:
                        temp.Apps = Convert.ToInt32(((TextBox)e.EditingElement).Text);
                        break;
                    case 5:
                        temp.Count = Convert.ToInt32(((TextBox)e.EditingElement).Text);
                        break;
                }
                mainList[rowIndex] = temp;
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный ввод");
                ((TextBox)e.EditingElement).Text = "0";
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                ((TextBox)e.EditingElement).Text = "0";
            }
        }

        private void btnResult_Click(object sender, RoutedEventArgs e)
        {
            int result = MailSends.GetResult(mainList, tbTown.Text);

            tbResult.Text = result.ToString();
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Бла-бла-бла");
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
