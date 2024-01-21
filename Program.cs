// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Org.BouncyCastle.Security;
//using System;
//using System.Text;


namespace mysqlefcore
{
   class Program
    {
       public static void Main(string[] args)
        {
            bool name=true;
             do{
            
                Console.WriteLine("\t\t\t\t\t Welcome! Here you can see the Teachers Management System.");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine("1. Insert ");
                Console.WriteLine("2. Read ");
                Console.WriteLine("3. Update ");
                Console.WriteLine("4. Remove ");
                Console.WriteLine("5. Exit");
                Console.Write("Enter the number : ");
                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        InsertData();
                        break;
                    case "2":
                        ReadData();
                        break;
                    case "3":
                        UpdateData();
                        break;
                    case "4":
                        RemoveData();
                         break;
                    case "5":
                       // Environment.Exit(0);
                       name=false;
                        break;
                    default:
                        Console.WriteLine("Invalid Number.Please enter the valid number.");
                        break;
                }
            }while(name);
        }

    

        private static void InsertData()
        {
            using (var context = new TeacherContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();
                // Adds some books
                Console.WriteLine("Enter the Teacher ID : ");
                string? TeacherID = Console.ReadLine();
                Console.WriteLine("Enter the Teacher Name : ");
                string? TeacherName = Console.ReadLine();
                Console.WriteLine("Enter the Teacher's Email ID : ");
                string? TeacherEmailID = Console.ReadLine();
                Console.WriteLine("Enter the Teacher's Qualification : ");
                string? TeacherQualification = Console.ReadLine();
                Console.WriteLine("Enter the Teacher's Location : ");
                string? TeacherLocation = Console.ReadLine();

                context.Teacher_Data.Add(new Teacher
                {
                    Teacher_ID = TeacherID,
                    Teacher_Name = TeacherName,
                    Teacher_EmailID = TeacherEmailID,
                    Teacher_Qualification = TeacherQualification,
                    Teacher_Location = TeacherLocation,
                });



                // Saves changes
                context.SaveChanges();
            }
        }


        private static void ReadData()
        {
            // Gets and prints all books in database
            using (var context = new TeacherContext())
            {
                var Mentor = context.Teacher_Data;

                foreach (var Teacher_Details in Mentor)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"Teacher_ID: {Teacher_Details.Teacher_ID}");
                    data.AppendLine($"Teacher_Name: {Teacher_Details.Teacher_Name}");
                    data.AppendLine($"Teacher_EmailID: {Teacher_Details.Teacher_EmailID}");
                    data.AppendLine($"Teacher_Qualification: {Teacher_Details.Teacher_Qualification}");
                    data.AppendLine($"Teacher_Location: {Teacher_Details.Teacher_Location}");
                    Console.WriteLine(data.ToString());
                }
            }
        }
        private static void UpdateData()
        {
            using (var context = new TeacherContext())
            {
                // Display current data
                Console.WriteLine("Current Details : ");
                ReadData();


                // Get ISBN from user for the book to update
                Console.Write("Enter ID of the Teacher details to update: ");
                string? isbnToUpdate = Console.ReadLine();
                // Retrieve the book by ISBN for update
                var TeacherToUpdate = context.Teacher_Data.FirstOrDefault(b => b.Teacher_ID == isbnToUpdate);
                // Display current details
                if (TeacherToUpdate != null)
                {
                    Console.WriteLine("Updating  values into the tables: ");
                    Console.WriteLine("What you want to update");
                    Console.WriteLine("1. Teacher_Name ");
                    Console.WriteLine("2. Teacher_EmailID");
                    Console.WriteLine("3. Teacher_Qualification ");
                    Console.WriteLine("4. Teacher_Location ");
                    string? updatechoice = Console.ReadLine();
                    string? updatedata = null;
                    switch (updatechoice)
                    {
                        case "1":
                            updatedata = "Teacher_Name";
                            Console.WriteLine($"Current Teacher Name: {TeacherToUpdate.Teacher_Name}");
                            Console.Write("Enter new Teacher Name: ");
                            string? newName = Console.ReadLine();
                            TeacherToUpdate.Teacher_Name = newName;
                            break;
                        case "2":
                            updatedata = "Teacher_EmailID";

                            Console.WriteLine($"Current Teacher EmailID: {TeacherToUpdate.Teacher_EmailID}");
                            Console.Write("Enter new Teacher EmailID: ");
                            string? newEmailID = Console.ReadLine();
                            TeacherToUpdate.Teacher_EmailID = newEmailID;
                            break;
                        case "3":
                            updatedata = "Teacher_Qualification ";

                            Console.WriteLine($"Current Teacher Qualification : {TeacherToUpdate.Teacher_Qualification}");
                            Console.Write("Enter new Teacher Qualification  ");
                            string? newQualification = Console.ReadLine();
                            TeacherToUpdate.Teacher_Qualification = newQualification;
                            break;
                        case "4":
                            updatedata = " Teacher_Location ";

                            Console.WriteLine($"Current  Teacher Location : {TeacherToUpdate.Teacher_Location}");
                            Console.Write("Enter new  Teacher Location : ");
                            string? newLocation = Console.ReadLine();
                            TeacherToUpdate.Teacher_Location = newLocation;
                            break;


                            context.SaveChanges();
                    }
                    //  else
                    // {
                    //     Console.WriteLine($" Teacher_ID{isbnToUpdate} not found.");
                    // }
                }
            }
        }
              private static void RemoveData()
            {
                using (var context = new TeacherContext())
                {
                    // Display current data
                    Console.WriteLine("Current details:");
                    ReadData();


                    // Get ISBN from user for the book to remove
                    Console.Write("Enter ID of the Teacher to remove: ");
                    string? isbnToRemove = Console.ReadLine();


                    // Retrieve the book by ISBN for removal
                    var TeacherToRemove = context.Teacher_Data.FirstOrDefault(b => b.Teacher_ID == isbnToRemove);


                    if (TeacherToRemove != null)
                    {
                        // Display details of the book to be removed
                        Console.WriteLine($"Removing Teacher_ID: {TeacherToRemove.Teacher_ID}, Teacher_Name: {TeacherToRemove.Teacher_Name}");


                        // Remove the book
                        context.Teacher_Data.Remove(TeacherToRemove);


                        // Save changes
                        context.SaveChanges();


                        Console.WriteLine("Removal successful!");
                    }
                    else
                    {
                        Console.WriteLine($"Teacher_ID{isbnToRemove} not found.");
                    }
                }
            }
        }
    }


