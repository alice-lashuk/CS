using System;
using System.Xml.Serialization;

namespace tutorial_2.Models
{
    public class ActiveStudies
    {
        [XmlElement(elementName: "name")]
        public string Name { get; set; }

        [XmlElement(elementName: "numberOfStudents")]
        public Int32 Number { get; set; }

        public void increaseNumber() {
            Number++;
        }
        public override string ToString()
        {
            return Name + " " + " numer: " + Number;
        }
    }
 }
