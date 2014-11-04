using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Using statement for static classes
using System.Console;

namespace CSharp6NewFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Hello world!");

            WriteLine();

            var blankPerson = new Person();

            WriteLine(blankPerson.FirstName);
            WriteLine(blankPerson.LastName);
            WriteLine(blankPerson.BirthDate);

            WriteLine(blankPerson.OtherInformation);

            WriteLine();

            //Dictionary initializers
            var madlangPeople = new Dictionary<string, Person>
            {
                ["Jon"] = new Person("Jon", "Limjap", new DateTime(1990, 11, 23)),
                ["Toto"] = new Person("Toto", "Gamboa", new DateTime(1996, 7, 11)),
                ["Teril"] = new Person("Teril", "Bilog", new DateTime(1998, 7, 10))
            };

            WriteLine(madlangPeople["Jon"].FirstName);
            WriteLine(madlangPeople["Toto"].LastName);
            WriteLine(madlangPeople["Teril"].BirthDate);

            WriteLine();

            WriteLine(madlangPeople["Jon"].FirstName + "'s age is " + madlangPeople["Jon"].Age);

            var sept11 = new DateTime(2001, 9, 11);

            WriteLine(madlangPeople["Jon"].FirstName + "'s age on " + sept11 + " is " + madlangPeople["Jon"].AgeFrom(sept11));

            WriteLine();

            FilteredExceptions("Filter me!");
            FilteredExceptions("blahblahblah");

            WriteLine();

            var jon1 = new Person();
            var jon2 = new Person() { Address = new Address { AddressLine1 = "6750 Ayala Ave" } };

            //Null operator propagation
            WriteLine(jon1?.Address?.AddressLine1 ?? "No address");
            WriteLine(jon2?.Address?.AddressLine1 ?? "No address too");
            WriteLine(jon2?.Address?.AddressLine2 ?? "No address either");

            WriteLine();

            //nameof operator
            WriteLine(nameof(FilteredExceptions));

            ReadKey();
        }

        //Filtered exceptions
        public static void FilteredExceptions(string message)
        {
            try
            {
                throw new Exception(message);
            }
            catch (Exception ex) if (ex.Message == "Filter me!")
            {
                WriteLine("Filtered!");
            }
            catch
            {
                WriteLine("Not filtered");
            }
        }

        //Await inside catch and finally
        public async Task SomeAsyncMethod()
        {
            try
            {
                await OperationThatMayThrowAsync();
            }
            catch (Exception ex)
            {
                await LogAsync(ex);
            }
            finally
            {
                await Cleanup();
            }
        }

        private async Task Cleanup() => WriteLine("Cleanup...");

        private async Task LogAsync(Exception ex) => WriteLine("Exception: " + ex.Message);

        private async Task OperationThatMayThrowAsync()
        {
            throw new Exception("I can't do async!");
        }
    }
}

