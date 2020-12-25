using System;
using System.ComponentModel;
using System.Reflection;

namespace Configuration.Helpers
{
    internal static class EnumExtender
    {
        public static string GetDescription(this Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            string description = value.ToString();
            FieldInfo fieldInfo = value.GetType().GetField(description);
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[]) fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                description = attributes[0].Description;
            }
            return description;
        }
    }

    [Flags]
    internal enum StateExpPartEnum
    {
        [Description("В работе")]
        // ReSharper disable once InconsistentNaming
        INWORK,
        [Description("На доработке")] REWORK,
        [Description("Завершен в СП")] CLOSED,
        [Description("На проверке")] UNDERREVIEW,
        [Description("В разнарядке")] INVESTIGATION,
        [Description("Выпущен")] RELEASED,
        [Description("Аннулирован")] CANCELLED,
        [Description("Тех контроль")] REVIEWED,
        [Description("Ожидает утверждения")] PENDING_APPROVAL,
        [Description("Правка")] PURGING,
        [Description("Импорт")] IMPORTING,
    }

    internal enum SharedStatusEnum
    {
        [Description("не определено")] Undefine,
        [Description("отсутствие каталога")] HasntFolder,
        [Description("отказ")] Denied,
        [Description("успех")] Success
    }
}