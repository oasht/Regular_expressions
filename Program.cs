using System.Collections;
using static System.Console;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Text.RegularExpressions;


namespace Regular_expressions
{


    class Program
    {
        static void Main(string[] args)
        {

            string fPath = "address.txt";


            /////////////////////////RECORDING////////////////////////////////////
            
            using (FileStream fs = new FileStream(fPath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    string address_pattern = @"^([A-Z]([a-z])*\s)+[0-9]+[A-Z]{0,1}(/[0-9]+){0,1},\s[0-9]+$";
                    WriteLine("Please enter your home address (Exp.: \"Partizana Zheleznyaka 11A, 34\")\n");
                    string address = ReadLine();
                    Regex r_address = new Regex(address_pattern);
                    WriteLine(r_address.IsMatch(address) ? "Correct" : "Incorrect");
                    if (r_address.IsMatch(address))
                    {
                        sw.WriteLine(address);
                        WriteLine("\nInformation recorded");
                    }
                    else { WriteLine("\nInformation was incorrect, try again"); }
                }



            }

            /////////////////////////READING////////////////////////////////////
            
            using (FileStream fs = new FileStream(fPath, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                {

                    WriteLine(sr.ReadToEnd());
                }


                WriteLine("Information was read");
            }
        }
     }
 }
