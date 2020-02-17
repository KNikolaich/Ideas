using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebCoreApplication.Infrastructure
{
    public static class RazorExtensions
    {
        /// <summary>
        /// Gets the <see cref="ViewLayoutAttribute"/> from the current calling controller of the <see cref="ViewContext"/>.
        /// </summary>
        public static ViewLayoutAttribute GetLayoutAttribute(this ViewContext viewContext)
        {
            ViewLayoutAttribute layoutAttributeFound = null;

            // Property ControllerTypeInfo can be seen on runtime.
            Type controllerType = (Type)viewContext.ActionDescriptor
                .GetType()
                .GetProperty("ControllerTypeInfo")
                .GetValue(viewContext.ActionDescriptor);

            if (controllerType.IsSubclassOf(typeof(Controller)))
            {
                layoutAttributeFound = Attribute.GetCustomAttribute(controllerType, typeof(ViewLayoutAttribute)) as ViewLayoutAttribute;
            }

            return layoutAttributeFound;
        }
    }
}
