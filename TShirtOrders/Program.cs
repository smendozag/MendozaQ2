using System;
using System.Collections.Generic;

//Program.cs
//Programmer: Rob Garner (rgarner7@cnm.edu)
//Date: 10 Mar 2020
//Purpose: Process a series of tshirt orders. 

    //TODO:  Good job.  score 95/100
namespace TShirtOrders
{
    class Program
    {
        private const string COMPANYNAME = "Super Shirt Ordermatic 3000";
        private const string COMPANYSLOGAN = "The best shirt ordering system in the multiverse!";

        static void Main(string[] args)
        {
            Header();
            char option;
            List<TShirtOrder> orders = new List<TShirtOrder>();
            do
            {
                DisplayShirtOrders(orders);
                option = GetStringFromUser("(A)dd shirt (R)emove shirt (T)otal (E)xit: ").Trim().ToUpper()[0];
                switch(option)
                {
                    case 'A':
                        AddShirtOrder(orders);
                        break;
                    case 'R':
                        RemoveShirtOrder(orders);
                        break;
                    case 'T':
                        DisplayTotal(orders);
                        break;

                }                
            } while (option!='E');
            Console.WriteLine("Thank you for using "+ COMPANYNAME);
        }
        private static void DisplayTotal(List<TShirtOrder> orders)
        {
            decimal total = 0;

            foreach (TShirtOrder order in orders)
            {
                total += order.Price;
            }
            Console.WriteLine("Total price of order is: " + total);
        }

        private static void RemoveShirtOrder(List<TShirtOrder> orders)
        {
            int index = GetIntFromUser("Enter index of shirt order to remove: ");
            if (GetBoolFromUser("Are you sure you want to delete this order"))
            {
 //TODO:  Need to subtract 1 for zero-indexing  -5   
                //In Changed the Remove to ReoveAt to specify what index selection you want to remove.
                orders.RemoveAt(index);
            }
        }
        private static void AddShirtOrder(List<TShirtOrder> orders)
        {
            TShirtOrder order = new TShirtOrder();
            order.FirstName = GetStringFromUser("Please enter your first name: ");
            order.LastName = GetStringFromUser("Please enter your last name: ");
            order.IsLocalPickup = GetBoolFromUser("Local pickup");
            if (!order.IsLocalPickup)
            {
                order.Address = GetStringFromUser("Address: ");
            }
            order.OrderDate = DateTime.Now;
            order.PrintAreaInSqIn = GetDoubleFromUser("Please enter are of your design in square inches: ");
            order.NumColors = GetIntFromUser("Please enter number of colors: ");
            order.NumShirts = GetIntFromUser("Please enter the number of shirts: ");
            Console.WriteLine(order.ToString());
            orders.Add(order);
        }
        private static void DisplayShirtOrders(List<TShirtOrder> orders)
        {
            Console.WriteLine();
            Console.WriteLine("Current shirts orders:");
            if (orders.Count > 0)
            {
                //IN: Took the paraemthesis of so visual studio will not read iCount as a method
                for (int i = 0; i < orders.Count; ++i)
                {
                    Console.WriteLine((i + 1) + ": " + orders[i]);
                }
            }
            else
            {
                Console.WriteLine("No shirts in order.");
            }
            Console.WriteLine();
        }
        private static void Header()
        {
            Console.WriteLine("Welcome to "+ COMPANYNAME+"!");
            Console.WriteLine(COMPANYSLOGAN);
            Console.WriteLine();
        }
        private static bool GetBoolFromUser(string prompt)
        {
            Console.Write(prompt + " (y/n)? ");
            return Console.ReadLine().ToLower()[0] == 'y';
        }
        private static int GetIntFromUser(string prompt)
        {
            Console.Write(prompt);
            return int.Parse(Console.ReadLine());
        }
        private static double GetDoubleFromUser(string prompt)
        {
            Console.Write(prompt);
            return int.Parse(Console.ReadLine());
        }

        private static string GetStringFromUser(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
