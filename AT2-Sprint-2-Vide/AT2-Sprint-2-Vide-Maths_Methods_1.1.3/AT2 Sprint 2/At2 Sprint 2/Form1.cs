using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace At2_Sprint_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static int index = 0;
        int[] hoursArray = new int[24];
        bool sorted = false;

        private void random()
        {
            int min = 10;
            int max = 99;

            Random randNum = new Random();
            for (int i = 0; i < hoursArray.Length; i++)
            {
                hoursArray[i] = randNum.Next(min, max);
                index++;
                listBox.Items.Add(hoursArray[i]);
                Console.WriteLine(hoursArray[i]);
            }
        }
        // Method to populate array with random integers for the data stream       

        private void display()
        {
            
            listBox.Items.Clear();
            for (int i = 0; i < index; i++)
            {
                listBox.Items.Add(hoursArray[i]);
            }

            Console.WriteLine("Display Working");
            
        }
        // Method displays the array elements in the listbox 
        // Error handing to check if array is full             

        private void sortBtn_Click(object sender, EventArgs e)
        {
            sort();
            display();
        }
        // Sort button that uses the bubble sort algorithm     

        private void midEBtn_Click(object sender, EventArgs e)
        {
            int middleNo1 = 0;
            int middleNo2 = 0;
            double median;
            int count = hoursArray.Length;
            sort();

            if (count % 2 == 0)
            {
                middleNo1 = hoursArray[(count / 2 - 1)];
                middleNo2 = hoursArray[(count / 2)];
                median = (middleNo1 + middleNo2) / 2;
            }
            else
            {
                median = hoursArray[(count / 2)];
            }
            midExBox.Items.Add($"Mid-Extreme: {median}");
        }

        private void meanBtn_Click(object sender, EventArgs e)
        {           
            double total = 0.0;
            double avg = 0.0;

            try
            {
                for(int i = 0; i < index; i++)
                {
                    total += hoursArray[i];                  
                }
                avg = total / index;
                avg = Math.Round(avg, 2);
                meanBox.Items.Add($"The Average is: {avg}");               
                
            }
            catch (Exception e1)
            {
                MessageBox.Show($"Could not calculate \n Exception: {e1}");              
            }
        }
    

        private void modeBtn_Click(object sender, EventArgs e)
        {
            int element;
            int frequency = 1;
            int mode = 0;
            int counter;
            for (int i = 0; i < hoursArray.Length; i++)
            {
                counter = 0;
                element = hoursArray[i];
                for (int j = 0; j < hoursArray.Length; j++)
                {
                    if (element == hoursArray[j])
                    {
                        counter++;
                    }
                }
                if (counter >= frequency)
                {
                    frequency = counter;
                    mode = element;
                }
            }
            modeBox.Items.Add($"Mode: {mode}");
        }

        private void rangeBtn_Click(object sender, EventArgs e)
        {
            int range;
            int high = getMax();
            int low = getMin();

            try
            {
                range = high - low;

            }
            catch (Exception e2)
            {
                MessageBox.Show($"Please populate array\n Exception: {e2}");
                throw;
            }
            rangeBox.Items.Add($"Range is: {range}");
        }

        private int getMax()
        {
            int max = 0;
            for(int i = 0; i < index; i++)
            {
                if(hoursArray[i] > max)
                {
                    max = hoursArray[i];
                }
            }
            return max;
        }
        private int getMin()
        {
            int min = 0;

            for(int i = 0; i < index; i++)
            {
                if(hoursArray[i] < min)
                {
                    min = hoursArray[i];
                }
               
            }
            return min;
        }
        private void seqBtn_Click(object sender, EventArgs e)
        {        
            try
            {
                int val = int.Parse(textBox.Text);
                if (!String.IsNullOrEmpty(textBox.Text))
                {
                    for (int i = 0; i <= hoursArray.Length; i++)
                    {
                        if (hoursArray[i] == val)
                        {
                            MessageBox.Show($"Value found at index: {i}");
                            break;
                        }
                    }
                }

                else
                {
                    MessageBox.Show("Number not found");
                }
            }
            catch (Exception e3)
            {
                MessageBox.Show($"Please enter integer value \n + Exception: {e3}");
                throw;
            }

            // Sequential search method to return a requested number to the user, algorithm using simple linear rules to run through the hoursarray until value is found
        }

        private void popBtn_Click_1(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            random();
            display();
        }
        // Populate button to add the random integers in the array to the list 

        private void sort()
        {
            for (int i = 0; i < index; i++)
            {
                for (int k = 0; k < index - 1; k++)
                {
                    if (hoursArray[k] > hoursArray[k + 1])
                    {
                        int temp = hoursArray[k];
                        hoursArray[k] = hoursArray[k + 1];
                        hoursArray[k + 1] = temp;
                    }
                }
            }
            sorted = true;         
        }
        // Method to sort items in the listbox (Hoursarray) using bubble sort 
        // Set sorted to true for error handling to ensure list is sorted before binary search 

        private void sortBtn_Click_1(object sender, EventArgs e)
        {
            sort();
            display();

            // Method to sort items in the listbox (Hoursarray) using bubble sort 
            // Set sorted to true for error handling to ensure list is sorted before binary search   
        }

        private void binBtn_Click_1(object sender, EventArgs e)
        {
            int target;
            bool b = int.TryParse(textBox.Text, out target);
            int high = index - 1;
            int low = 0;
            int i = target;

            if (sorted)
            {
                try
                {
                    while (low <= high)
                    {
                        int mid = (high + low) / 2;
                        if (target == hoursArray[mid])
                        {
                            MessageBox.Show("Target found");
                            break;
                        }
                        else if (target > hoursArray[mid])
                        {
                            low = mid + 1;
                        }
                        else
                        {
                            high = mid - 1;
                        }
                        if (b == false)
                        {
                            MessageBox.Show("Please enter an integer");
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Target not found");
                    throw;
                }
            }
            // Binary search method to search for a user inputted value in the listbox (array)
            // Error handling to ensure the list is sorted before binary search
        }

        private void addBtn_Click_1(object sender, EventArgs e)
        {
            int check = 0;
            if (index < hoursArray.Length)
            {
                if (int.TryParse(textBox.Text, out check))
                {
                    hoursArray[index] = check;
                    index++;
                    textBox.Clear();
                }
                else
                {
                    MessageBox.Show("Please enter an integer");
                }
            }
            display();
        }
        // Method that allows user to add elements to the array 
        // Checks to see if there is an integer entered
        // Message box to display error if otherwise

        private void editBtn_Click_1(object sender, EventArgs e)
        {
            int b;
            int a = listBox.SelectedIndex;
            listBox.Items.RemoveAt(a);
            bool c = int.TryParse(textBox.Text, out b);
            if (c == true)
            {
                listBox.Items.Insert(a, b);
            }
            else
            {
                MessageBox.Show("Please enter an integer");
            }
        }
        // Method to allow user to select and edit items in the listbox (array)
        // Error handling to check if input is an integer

        private void delBtn_Click_1(object sender, EventArgs e)
        {
            hoursArray[listBox.SelectedIndex] = hoursArray[index - 1];
            index--;
            display();
        }
        // Method to delete selected item from the listbox (array)  
    }
    
}



