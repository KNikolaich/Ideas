using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Configuration.Controls;
using Configuration.Controls.Editors;

namespace Configuration.Helpers
{
    /// <summary>
    /// генератор контролов
    /// </summary>
    public class ControlCreator
    {
        internal static ElementBaseControl GetSubElemControl(XElement subXElement, string postName,
            int locationEditorX = 180)
        {
            ElementBaseControl subElemControl;
            var localName = subXElement.Name.LocalName.ToLower();
            var value = subXElement.Value.Trim().ToLower();

            /*if (localName.Contains("smsignediul") || localName.Contains("smsignedcontent")
                || localName.Contains("signactivity") || localName.Contains("signvote"))
            {
                subElemControl = SmSignedGroupControl.GetForParent(subXElement.Parent);
            }
            else*/ 
            if (localName.Contains("stateexppart"))
            {
                subElemControl = new StateExprPartControl();
            }
            else if (localName == "smtypesdocspec")
            {
                subElemControl = new SmTypeDocSpecControl();
            }
            else if (localName == "avproektexport")
            {
                subElemControl = new StringCollectionControl();
            }
            else if (localName == "typeconfigs")
            {
                subElemControl = new TypeConfigCollectionControl() ;
            }
            else if (localName == "containerconfig")
            {
                subElemControl = new ContainerConfigControl();
            }
            else if (localName == "containerconfigs")
            {
                subElemControl = new ContainerConfigsGroupControl();
            }
            else if (localName.Contains("checksumalg"))
            {
                subElemControl = new SmChecksumAlgControl();
            }
            else if (value.Equals("true") || value.Equals("false"))
            {
                subElemControl = new BoolEditControl();
            }
            else
            {
                subElemControl = new ElementBaseControl();
            }
            subElemControl.Name = subXElement.Name + "control" + postName;
            if(subElemControl is StringCollectionControl)
                subElemControl.SetElement(subXElement);
            else
                subElemControl.SetElement(subXElement, locationEditorX);
            return subElemControl;
        }
    }
}