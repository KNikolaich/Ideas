using System;
using System.Collections.Generic;

namespace WebCoreApplication.Models
{
    public class PersistentObj
    {
        /// <summary>
        /// Копируем наши данные в некий объект
        /// </summary>
        /// <typeparam name="TPersistentObj"></typeparam>
        /// <param name="resulpObj"></param>
        /// <returns></returns>
        public TPersistentObj CopyTo<TPersistentObj>(TPersistentObj resulpObj) where TPersistentObj : PersistentObj
        {
            var propertys = typeof(TPersistentObj).GetProperties();

            // список полей- исключений
            var exceptionField = new List<string> {"Id"};
            foreach (var property in propertys)
            {
                if (!exceptionField.Contains(property.Name) && property.CanRead && property.CanWrite)
                {
                    property.SetValue(resulpObj, property.GetValue(this), null);
                }
            }
            return resulpObj;
        }

        /// <summary>
        /// Клонируем новый объект
        /// </summary>
        /// <typeparam name="TPersistentObj"></typeparam>
        /// <returns></returns>
        public TPersistentObj Clone<TPersistentObj>() where TPersistentObj : PersistentObj
        {
            var newObject = (TPersistentObj)Activator.CreateInstance(typeof(TPersistentObj));
            return CopyTo(newObject);
        }
    }
}