using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace tutorial_2.Models
{
    public class ActiveStudies: IEquatable<ActiveStudies>
    {
        [XmlElement(elementName: "name")]
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        [XmlElement(elementName: "numberOfStudents")]
        public Int32 Number { get; set; }

        public bool Equals(ActiveStudies other)
        {
            return (this.Name.Equals(other.Name));
        }

        public void increaseNumber() {
            Number++;
        }

        public override string ToString()
        {
            return Name + " " + " numer: " + Number;
        }

        internal string GetName()
        {
            return _name;
        }
    }
 }
