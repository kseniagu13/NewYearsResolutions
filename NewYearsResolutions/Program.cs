using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace NewYearsResolutions
{
    class Program
    {
        class Resolution
        {
            public string Description;
           

            public Resolution(string _description)
            {
                Description = _description;  
            }

        }

        static void Main(string[] args)
        {
            string filePath = @"/Users/kseniagustsenko/Desktop/NewYearResolution/NewYearResolution.txt";
            List<string> lines = File.ReadAllLines(filePath).ToList();

            Console.WriteLine("Add your New Years Resolutions: "); //add it in one line separated by comma
            string userInputResolution = Console.ReadLine();
            string[] userInputArray = userInputResolution.Split(',');
            lines.AddRange(userInputArray); // lisatud vastused listi lines
            File.WriteAllLines(filePath, lines); //lisame vastuse faili

            List<Resolution> listOfResolutions = new List<Resolution>(); //list kuhu salvestame uued lubadused

            foreach (string line in lines)
            {
                //Create a resolution object at each line that we read from the file
                Resolution newResolution = new Resolution(line);
                //add the object to the resolutionList
                listOfResolutions.Add(newResolution);
            }
            int i = 1;

            foreach (Resolution resolution in listOfResolutions)
            {
                Console.WriteLine($"Resolution {i} on your New Years Resolution list is: {resolution.Description}");
                i++;
            }

            Console.WriteLine("Please, add a new resolution: "); //ADD
            string userNewResolution = Console.ReadLine();
            Resolution userResolutionAdd = new Resolution(userNewResolution);
            listOfResolutions.Add(userResolutionAdd);
            lines.Add(userNewResolution);
            

            Console.WriteLine("\n Updated NY Resolutions list:");
            int j = 1;
            foreach (Resolution resolution in listOfResolutions)
            {
                Console.WriteLine($"Resolution {j} on your list is: {resolution.Description}");
                j++;
            }

            Console.WriteLine("Please, delete a resolution: "); //DELETE
            string userDeleteResolution = Console.ReadLine();

            for (int z =0; z< listOfResolutions.Count; z++)
            {
                if (listOfResolutions[z].Description == userDeleteResolution)
                {
                    listOfResolutions.Remove(listOfResolutions[z]);
                    lines.Remove(userDeleteResolution);
                }
            }

            Console.WriteLine("\n Updated NY Resolutions list:");
            i = 1;
            foreach (Resolution resolution in listOfResolutions)
            {
                Console.WriteLine($"Resolution {i} on your list is: {resolution.Description}");
                i++;
            }

        }
    }
}
