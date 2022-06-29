// Jacob Girsky
// 1-1-20
// Sorting Algorithm Visualizer

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AlgoWPF
{

    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        private ArrayInt[] values;
        private int size;
        private readonly Comparer cmp = new();
        public static MainWindow myWindow;
        public bool running;

        public MainWindow()
        {
            InitializeComponent();
            Binding readvals = new();
            readvals.Source = Sort.reads;
            ReadsText.SetBinding(TextBlock.TextProperty, readvals);
            Binding compvals = new();
            compvals.Source = Sort.comparisons;
            CompsText.SetBinding(TextBlock.TextProperty, compvals);
            Binding icmpvals = new();
            icmpvals.Source = Sort.icmps;
            ICmprText.SetBinding(TextBlock.TextProperty, compvals);
            Binding writevals = new();
            writevals.Source = Sort.comparisons;
            WritesText.SetBinding(TextBlock.TextProperty, writevals);
            Setup();
            Draw();
            myWindow = this;
        }

        

        // Sets size to the current size in the textbox
        // Creates a random number generator and populates an array with random numbers
        public void Setup()
        {
            size = (int)ArraySize.Value;
            Random random = new();
            values = new ArrayInt[size];
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
                    Line line = new()
                    {
                        X1 = i,
                        X2 = i,
                        Y1 = canvas.Height,
                        Y2 = canvas.Height - values[i],
                        StrokeThickness = 1,
                        Stroke = Brushes.Black
                    };
                    canvas.Children.Add(line);
                }
            }
        }

        // Draws the line and adds it to the canvas
        private void DrawLine(double gap, double stroke, int i)
        {
            Line line = new()
            {
                X1 = i * gap,
                X2 = i * gap,
                Y1 = canvas.Height,
                Y2 = canvas.Height - values[i],
                StrokeThickness = stroke,
                Stroke = Brushes.Black
            };
            canvas.Children.Add(line);
        }

        // Gets the type of sort and loops through sorting the lines
        private async void Sort_button_Click(object sender, RoutedEventArgs e)
        {
            GetSortSelection();
            

            //running = true;
            while (true)
            {
                await Task.Delay(50);
                canvas.Children.Clear();
                Draw();
            }
            
        }

        // Gets the sort that the user selects 
        private void GetSortSelection()
        {
            sort_button.IsEnabled = false;
            string sort = GetComboBoxItem();

            //_ = DrawCycle();
            switch (sort)
            {
                case SortingConstants.bubbleSort:
                    SortAlgorithms.BubbleSort(values, cmp);
                    break;

                default:
                    break;
            }
            sort_button.IsEnabled = true;
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

        // Clears the canvas and sets back to default
        private void Reset_button_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            size = 500;
            sort_button.IsEnabled = true;
            canvas.Children.Clear();
            Setup();
            Draw();
        }

        private void ArraySize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            (sender as Slider).Value = Math.Round(e.NewValue, 0);
        }
    }
}
