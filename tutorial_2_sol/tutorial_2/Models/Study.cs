using System;
using System.Xml.Serialization;

namespace tutorial_2.Models
{
    public class Study
    {
        [XmlElement(elementName: "name")]
        public string Name { get; set; }

        [XmlElement(elementName: "mode")]
        public string Mode { get; set; }

    }
}
