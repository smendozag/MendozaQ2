using System;
//TShirtOrder.cs
//Programmer: Rob Garner (rgarner7@cnm.edu)
//Date: 10 Mar 2020
//Purpose: Model a TShirt order.
namespace TShirtOrders
{
    /// <summary>
    /// TShirtOrder
    /// Provides a model of a shirt order.
    /// </summary>
    public class TShirtOrder
    {                                                                                                                               //IN: printAreaSqIn had to inititalized like the rest of the parameters
        public TShirtOrder(string firstName="",string lastName = "", string address = "", DateTime? orderDate=null,bool isLocalPickup=true, double printAreaInSqIn = 1, int numColors=1,int numShirts=1)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            OrderDate = orderDate;
            IsLocalPickup = isLocalPickup;
            this.printAreaInSqIn = printAreaInSqIn;
            this.numColors = numColors;
            this.numShirts = numShirts;
            Calc();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime? OrderDate { get; set; }
        public bool IsLocalPickup { get; set; }
        private double printAreaInSqIn;
        public double PrintAreaInSqIn
        {
            get { return printAreaInSqIn; }
            set { printAreaInSqIn = value; Calc(); }
        }

        private int numColors;
        public int NumColors
        {
            //change property name to the field name
            get { return numColors; }
            set { numColors = value; Calc(); }
        }

        private int numShirts;
        public int NumShirts
        {
            get { return numShirts; }
            set { numShirts = value; Calc(); }
        }
        //IN change the accessor public by removing the private accessor
        public decimal Price {  get; set; }
        private void Calc()
        {
            //IN needed to convert numShirts to a decimal 
            Price = Convert.ToDecimal(numShirts * (numColors * 2.25 + printAreaInSqIn * .05));
        }
        public override string ToString()
        {
            return FirstName + " "
                + LastName + " "
                + OrderDate.ToString()//Had to remove this from the parenthesis=> "MM/dd/yyyy HH:mm:ss")
                +" Price: "+Price.ToString("c");
        }
    }
}
