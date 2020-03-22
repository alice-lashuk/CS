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
            University uni = new University()
            {
                CreatedaAt = DateTime.Now.ToString("h:mm:ss tt"),
                Author = "Alice Lashuk"
            };

            var list = parseToList(filePath);
            var listOfSt = (HashSet<Student>)list[0];
            var listOfStudies = new HashSet<ActiveStudies>((List<ActiveStudies>)list[1]);
            uni.studentsSet = listOfSt;
            uni.studies = listOfStudies;

            if (fileFormat.Equals("xml"))
            {
                GenerateXml(destPath, uni);
            }
            else
            {
                GenerateJSON(destPath, uni);
            }
        }

        public static void GenerateXml(string destPath, University uni)
        {
            var writer = new FileStream(@$"{destPath}", FileMode.Create);
            var serializer = new XmlSerializer(typeof(University));
            serializer.Serialize(writer, uni);
        }

        public static void GenerateJSON(string destPath, University uni)
        {
            string jsonString;
            jsonString = JsonSerializer.Serialize(uni);
            File.WriteAllText(@$"{destPath}", jsonString);
        }

        public static List<Object> parseToList(string path)
        {
            using var sw = new StreamWriter(@"log.txt");
            var fi = new FileInfo(path);
            var listOfStudent = new HashSet<Student>(new CustomComparer());
            var listOfStudies = new List<ActiveStudies>();
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
                            Console.WriteLine("test");
                            listOfStudies.Find(x => x.GetName() == activeStudy.GetName()).Number++; 
                            sw.WriteLine($"{activeStudy.GetName()} was not added to the list");
                        } else
                        {
                            listOfStudies.Add(activeStudy);
                        }
                    }
                }
            }
            
            var list = new List<Object>();
            list.Add(listOfStudent);
            list.Add(listOfStudies);
            return list;
        }

        public static void reportError(string msg)
        {
            using var sw = new StreamWriter(@"log.txt");
            sw.WriteLine(msg);
        }
    }
}
