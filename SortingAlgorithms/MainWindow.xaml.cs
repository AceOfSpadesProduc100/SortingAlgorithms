// Jacob Girsky
// 1-1-20
// Sorting Algorithm Visualizer

using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SortingAlgorithms
{

    public partial class MainWindow : Window
    {
        private int[] values;
        private int size;

        public MainWindow()
        {
            InitializeComponent();
            Setup();
            Draw();
        }

        // Sets size to the current size in the textbox
        // Creates a random number generator and populates an array with random numbers
        public void Setup()
        {
            size = Convert.ToInt32(num_elements_textBox.Text);
            Random random = new Random();
            values = new int[size];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = random.Next(0, 350);
            }
        }

        // Draws the lines depending on how many elements will change the size and thickness of the line
        public void Draw()
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (size >= 500 && size <= 500)
                {
                    DrawLine(1.4, 1.2, i);
                }
                else if (size <= 400 && size > 300)
                {
                    DrawLine(1.8, 1.7, i);
                }
                else if (size <= 300 && size > 100)
                {
                    DrawLine(2.2, 2, i);
                }
                else if (size <= 100 && size > 90)
                {
                    DrawLine(7, 4, i);
                }
                else if (size <= 90 && size > 25)
                {
                    DrawLine(10, 6, i);
                }
                else if (size <= 25)
                {
                    DrawLine(30, 25, i);

                }
                else
                {
                    Line line = new Line();
                    line.X1 = i;
                    line.X2 = i;
                    line.Y1 = canvas.Height;
                    line.Y2 = canvas.Height - values[i];
                    line.StrokeThickness = 1;
                    line.Stroke = Brushes.Black;
                    canvas.Children.Add(line);
                }
            }
        }

        // Draws the line and adds it to the canvas
        private void DrawLine(double gap, double stroke, int i)
        {
            Line line = new Line();
            line.X1 = i * gap;
            line.X2 = i * gap;
            line.Y1 = canvas.Height;
            line.Y2 = canvas.Height - values[i];
            line.StrokeThickness = stroke;
            line.Stroke = Brushes.Black;
            canvas.Children.Add(line);
        }

        // Gets the type of sort and loops through sorting the lines
        private async void Sort_button_Click(object sender, RoutedEventArgs e)
        {
            GetSortSelection();
            sort_button.IsEnabled = false;

            for (int i = 0; i < values.Length; i++)
            {
                for (int j = 0; j < values.Length; j++)
                {
                    await Task.Delay(50);
                    canvas.Children.Clear();
                    Draw();
                }
            }
        }

        // Gets the sort that the user selects 
        private void GetSortSelection()
        {
            string sort = GetComboBoxItem();
            if (Delay_textBox.Text.Equals(""))
            {
                Delay_textBox.Text = "10";
            }
            int delay = Convert.ToInt32(Delay_textBox.Text);

            switch (sort)
            {
                case SortingConstants.bubbleSort:
                    SortAlgorithms.BubbleSort(values, delay);
                    break;
                case SortingConstants.selectionSort:
                    SortAlgorithms.SelectionSort(values, delay);
                    break;
                case SortingConstants.insertionSort:
                    SortAlgorithms.InsertionSort(values, delay);
                    break;
                case SortingConstants.quickSort:
                    SortAlgorithms.QuickSort(values, 0, values.Length - 1, delay);
                    timeComplexity_label.Content = SortingConstants.bigOlogN;
                    break;
                case SortingConstants.heapSort:
                    SortAlgorithms.HeapSort(values, delay);
                    timeComplexity_label.Content = SortingConstants.bigOlogN;
                    break;

                default:
                    break;
            }
        }

        // Returns the sort that the user selects 
        public string GetComboBoxItem()
        {
            string sort = "";
            if (sort_comboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a sort.");
            }
            else
            {
                ComboBoxItem typeItem = (ComboBoxItem)sort_comboBox.SelectedItem;
                sort = typeItem.Content.ToString();
            }

            return sort;
        }

        // Updates the number of elements on screen whenever user changes the number of elements 
        private void Num_elements_textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = num_elements_textBox.Text;

            if (text.Equals(""))
            {
                num_elements_textBox.Text = "0";
            }
            else if (Convert.ToInt32(text) > 700)
            {
                MessageBox.Show("Must not be greater than 700.");
            }
            else
            {
                canvas.Children.Clear();
                Setup();
                Draw();
            }
        }

        // Clears the canvas and sets back to default
        private void Reset_button_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            size = 500;
            sort_button.IsEnabled = true;
            num_elements_textBox.Text = "500";
            canvas.Children.Clear();
            Setup();
            Draw();
        }

        // Updates time complexity label whenver user selects a different sort
        private void sort_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            timeComplexity_label.Content = SortingConstants.bigOnSquared;
            string sort = GetComboBoxItem();
            switch (sort)
            {
                case SortingConstants.bubbleSort:
                    break;
                case SortingConstants.selectionSort:
                    break;
                case SortingConstants.insertionSort:
                    break;
                case SortingConstants.quickSort:
                    timeComplexity_label.Content = SortingConstants.bigOlogN;
                    break;
                case SortingConstants.heapSort:
                    timeComplexity_label.Content = SortingConstants.bigOlogN;
                    break;
                default:
                    break;
            }
        }
    }
}
