using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Astronomical Processing, 
// Team VIDE 
// Tyler Hill, FLetcher Kent 

namespace At2_Sprint_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Ttip.SetToolTip(this.binBtn, "search the data in the program via binaray search method");
            Ttip.SetToolTip(this.addBtn, "Record a value in the program");
            Ttip.SetToolTip(this.delBtn, "Delete a record from the program");
            Ttip.SetToolTip(this.sortBtn, "Sort values in the program via bubble sort method");
            Ttip.SetToolTip(this.editBtn, "Edit a value in the program");
            Ttip.SetToolTip(this.midEBtn, "Display the Mid Extreme of the data");
            Ttip.SetToolTip(this.meanBtn, "Display the Mean of the data");
            Ttip.SetToolTip(this.modeBtn, "Display the Mode of the data");
            Ttip.SetToolTip(this.rangeBtn, "Display the range of the data");
            Ttip.SetToolTip(this.popBtn, "populate the data in the program with random values");
            Ttip.SetToolTip(this.seqBtn, "search the data in the program via Sequential search method");
        }
        static int index = 0;
        int[] hoursArray = new int[24];
        bool sorted = false;
        ToolTip Ttip = new ToolTip();

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
        // Algorithm to calculate mid-extreme 
        // Count is equal to the length of the array 
        // If the remainder is 0 add the two middle elements and divide by two set that value as median
        // Else divide by 2 and grab the middle element set as median

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
        // Algorithm to return the average from the dataset 
        // Loop through the array for each element in the array. 
        // Adds the current element to the total and Increment the count each time happens.
        // Average is equal to the total divided by the count

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
        // Algorithm to return mode value 
        // temp variable frequency set to 1 
        // Loop through the hoursArray’s lenth and set value of the current element(i) to temp variable “element”.
        // Counter is set back to 0 
        // Another for loop current value set to(j) is created
        // If j equals I then increment the counter by 1. 
        // If the counter is greater the frequency (default 1) frequency is set to counter and the mode equals the element (i). 
        // These steps repeat each other until every part of the array has been checked. 


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
        // Algorithm to return the range value from dataset
        // Set high and low values of the array to low and high variables  
        // Take high- low and set that value to range  
        // Parse the range value to display in the appropriate textbox

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
        // Method to iterate through all the numbers in the array to find and set the max value 

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
        // Method to iterate through all the numbers in the array to find and set the min value 

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
        }
        // Sequential search method to return a requested number to the user, algorithm using simple linear rules to run through the hoursarray until value is found

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
   
        }
        // Method to sort items in the listbox (Hoursarray) using bubble sort 
        // Set sorted to true for error handling to ensure list is sorted before binary search

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
            
        }
        // Binary search method to search for a user inputted value in the listbox (array)
        // Error handling to ensure the list is sorted before binary search

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

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        // Event method that only allows numbers in the textbox

        
        private void listBox_MouseClick(object sender, MouseEventArgs e)
        {
            //StatusMessage.Text = "";
            if (listBox.SelectedIndex != -1)
            {
                string dataItem = listBox.SelectedItem.ToString();
                int dataItemIndex = listBox.FindString(dataItem);
                textBox.Text = hoursArray[dataItemIndex].ToString();
                textBox.Focus();
            }
            else
            {
                MessageBox.Show("ERROR: Please select from the List Box");
            }
        }




    }
    
    
    
    


}



