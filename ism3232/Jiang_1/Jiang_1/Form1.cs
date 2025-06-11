//Programmer: WenBo Jiang
//Project: Jiang_1
//Due Date: 2/9/24
//Description: Individual Assignment #1

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jiang_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Calculate everything and display the results in the proper labels
        private void totalButton_Click(object sender, EventArgs e)
        {
            // use the 'try' command to prevent the system from crash due to error and display an error message
            try
            {

                //Declare the constant TAX_RATE
                const decimal TAX_RATE = 0.07m;

                //Declare int variables that will be used in the calculations 
                int roomNumber, numberOfNights;

                //Prevent "use of unassigned local variable" by declare and assign them as 0 (Program 3-14)
                decimal miniBar = 0m, telephone = 0m, miscellaneous = 0m;

                //Declare decimal variables, should use decimal since it is for price
                decimal chargeRate, roomCharge, additionalCharge, subtotal, taxCharge, totalCharge;

                //Use .Parse to convert text box strings into the appropriate numbers values
                roomNumber = int.Parse(roomNumberMaskedTextBox.Text);
                numberOfNights = int.Parse(numberOfNightTextBox.Text);
                chargeRate = decimal.Parse(chargeRateTextBox.Text);

                //Using 'If' command to repalace the 0's (line 30) with the typed string (based off 'Program3-14') 
                //If it is null, the 0's from line 30 will be used instead
                if(miniBarChargeTextBox.Text != "")
                {
                    miniBar = decimal.Parse(miniBarChargeTextBox.Text); //.Parse to convert string into number values
                }

                if(telephoneChargeTextBox.Text != "")
                {
                    telephone = decimal.Parse(telephoneChargeTextBox.Text); //.Parse to convert string into number values
                }

                if(miscellaneousChargesTextBox.Text != "")
                {
                    miscellaneous = decimal.Parse(miscellaneousChargesTextBox.Text); //.Parse to convert string into number values
                }

                //Calculations and use '.ToString' to display the results in the labels.  
                roomCharge = numberOfNights * chargeRate;
                roomChargeLabel.Text = roomCharge.ToString("c"); // "c" for currency

                additionalCharge = miniBar + telephone  + miscellaneous;
                additionalChargeLabel.Text = additionalCharge.ToString("c");

                subtotal = roomCharge + additionalCharge;
                subtotalLabel.Text = subtotal.ToString("c");

                taxCharge = subtotal * TAX_RATE;
                taxChargeLabel.Text = taxCharge.ToString("c");

                totalCharge = roomCharge + additionalCharge + subtotal + taxCharge;
                totalChargesLabel.Text = totalCharge.ToString("c");

                //Put the focus on the clear Button after calculation
                clearButton.Focus();
            }

            //Display error message if wrong/invalid data are typed via 'catch'
            catch
            {      
                MessageBox.Show("Oh no! Invalid data has been entered!");

                //Put the focus on clear button after calculation
                clearButton.Focus(); 
            }

        }

        //clear everything when the 'Clear' button is pushed
        private void clearButton_Click(object sender, EventArgs e)
        {         
            checkoutDateMaskedTextBox.Text = "";
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            roomNumberMaskedTextBox.Text = "";
            numberOfNightTextBox.Text = "";
            chargeRateTextBox.Text = "";
            miniBarChargeTextBox.Text = "";
            telephoneChargeTextBox.Text = "";
            miscellaneousChargesTextBox.Text = "";
            roomChargeLabel.Text = "";
            additionalChargeLabel.Text = "";
            subtotalLabel.Text = "";
            taxChargeLabel.Text = "";
            totalChargesLabel.Text = "";

            checkoutDateMaskedTextBox.Focus(); // put the focus on the first user input(checkout date) after everything has been cleared
        }

        //Display basic instuctions after the help buttons is clicked
        //Used '\n' as linebreaks 
        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "This program is a guest check-out billing program.\n\n" 
                + " To use this program:\n\n"
                + "1. Type the guest's check out date.\n"
                + "2. Enter the guest's name in the Guest Information section.\n"
                + "3. Enter guest's room number, number of nights, and rate of charge in the Room Information section.\n"
                + "4. Type any addtional charges into the Addtional Charge section\n\n"
                + "Use to Total button to compute the billing infomation, also the focus will be the Clear button afterwards\n\n"
                + "Use the Clear button to clear everything, also the focus will be on the Check out textbox afterwards\n\n"
                + "Use the exit button to exit the program."
                );
        }

        //Close the program
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
