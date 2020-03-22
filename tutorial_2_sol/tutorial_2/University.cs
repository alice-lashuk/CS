using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using tutorial_2.Models;

namespace tutorial_2
{   
    public class University : ISerializable
    {
        [XmlAttribute(attributeName:"createdAt")]
        public string CreatedaAt { get; set; }

        [XmlAttribute(attributeName: "author")]
        public string Author { get; set; }

        [XmlElement(elementName: "Student")]
        public HashSet<Student> studentsSet { get; set; }
        [XmlElement(elementName: "ActiveStudy")]
        public HashSet<ActiveStudies> studies { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("createdAt", CreatedaAt);
            info.AddValue("author", Author);
            info.AddValue("Student", studentsSet);
            info.AddValue("ActiveStudy", studies);
        }
    }
}
