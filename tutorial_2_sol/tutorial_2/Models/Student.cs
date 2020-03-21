using System;
using System.Xml.Serialization;

namespace tutorial_2.Models
{
    public class Student
    {
        [XmlElement(elementName: "fname")]
        public string FirstName { get; set; }

        [XmlElement(elementName: "lname")]
        public string LastName { get; set; }

        [XmlElement(elementName: "birthdate")]
        public DateTime DateOfBirth { get; set; }

        private string _email;

        [XmlElement(elementName: "email")]
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value ?? throw new ArgumentNullException();
            }
        }

        [XmlElement(elementName: "mothersName")]
        public string MothersName { get; set; }

        [XmlElement(elementName: "fathersName")]
        public string FathersName { get; set; }

        [XmlElement(elementName: "studies")]
        public Study Studies { get; set; }

        [XmlAttribute(attributeName: "indexNumber")]
        public string StudentIndex { get; set; }
    }
}
