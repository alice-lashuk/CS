using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using tutorial_2;
using tutorial_2.Models;
using System.Text.Json;

namespace tutorial2
{
    public class Program
    {

        public static void Main(string[] args)
        {

            var filePath = @$"{args[0]}";
            var destPath = @$"{args[1]}";
            var fileFormat = args[2];

            if (fileFormat.Equals("xml"))
            {
                generateXml(filePath, destPath);
            }
            else
            {
                generateJSON(filePath, destPath);
            }
        }
        public static void generateXml(string filePath, string destPath)
        {
            XmlRootAttribute rAttr = new XmlRootAttribute("university");

            var writer = new FileStream(@$"{destPath}", FileMode.Create);
            var serializer = new XmlSerializer(typeof(HashSet<Student>), new XmlRootAttribute("university"));
            serializer.Serialize(writer, parseToList(filePath));

        }

        public static void generateJSON(string filePath, string destPath)
        {
            string jsonString;
            jsonString = JsonSerializer.Serialize(parseToList(filePath));
            File.WriteAllText(@"result.json", jsonString);
        }

        public static HashSet<Student> parseToList(string path)
        {
            using var sw = new StreamWriter(@"log.txt");
            var fi = new FileInfo(path);
            var listOfStudent = new HashSet<Student>(new CustomComparer());
            var listOfStudies = new LinkedList<ActiveStudies>();
            Int32 count = 0;
            using (var stream = new StreamReader(fi.OpenRead()))
            {
                string line = null;

                while ((line = stream.ReadLine()) != null)
                {
                    count++;
                    string[] columns = line.Split(',');
                    if (columns.Length < 9)
                    {
                        reportError($"Student with name{columns[0]} is not described properly");
                    }
                    else
                    {
                        var name = columns[0];
                        var study = new Study
                        {
                            Name = columns[2],
                            Mode = columns[3]
                        };
                        var lastName = columns[1];
                        var index = columns[4];
                        var dateOfBirth = columns[5];
                        var email = columns[6];
                        var mothersName = columns[7];
                        var fathersName = columns[8];

                        var st = new Student
                        {
                            FirstName = name,
                            LastName = lastName,
                            Email = email,
                            StudentIndex = index,
                            Studies = study,
                            DateOfBirth = DateTime.Parse(dateOfBirth),
                            MothersName = mothersName,
                            FathersName = fathersName
                        };

                        var activeStudy = new ActiveStudies
                        {
                            Name = columns[2],
                            Number = 1
                        };

                        if (!listOfStudent.Add(st))
                        {

                            sw.WriteLine($"Student {name} was not added to the list");
                        }

                        if (listOfStudies.Contains(activeStudy))
                        {
                            listOfStudies.Find(activeStudy).Value.increaseNumber();
                            sw.WriteLine($"{activeStudy} was not added to the list");
                        }
                    }
                }
            }
            //Console.WriteLine($"count {count}");
            //Console.WriteLine($"numberOfstudents {listOfStudent.Count}");
            //Console.WriteLine(listOfStudies.ToString());
            //var comList = new List<Combined>();
            //var combined = new Combined
            //{
            //    ListfOfStudies = listOfStudies.ToList(),
            //    ListOfStudent = listOfStudent.ToList()
            //};
            //comList.Add(combined);
           
            return listOfStudent;
        }

        public static void reportError(string msg)
        {
            using var sw = new StreamWriter(@"log.txt");
            sw.WriteLine(msg);
        }
    }
}
