using System;
using System.Collections.Generic;
using System.Text;

namespace ExamServiceReference
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.domain.com/test")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.domain.com/test", IsNullable = false)]
    public partial class MedicalService
    {
        public override string ToString()
        {
            return this.ToXmlString();
        }

    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.domain.com/test")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.domain.com/test", IsNullable = false)]
    public partial class MethodResult
    {
        public override string ToString()
        {
            return this.ToXmlString();
        }

    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.domain.com/test")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.domain.com/test", IsNullable = false)]
    public partial class Error
    {
        public override string ToString()
        {
            return this.ToXmlString();
        }

    }
}
