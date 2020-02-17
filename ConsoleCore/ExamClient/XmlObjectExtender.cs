using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ExamServiceReference
{
    public static class XmlObjectExtender
    {
        public static string ToXmlString(this object Object)
        {
            XmlSerializer xsSubmit = new XmlSerializer(Object.GetType());
            
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, Object);
                    xml = sww.ToString(); // Your XML
                }
            }
            
            return xml;//.Replace("><", @"><");
        }
    }
}
