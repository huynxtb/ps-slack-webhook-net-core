using System.ComponentModel;

namespace WebhookSlack;

public static class EnumHelper
{
    public static string ReadDescription<T>(this T enumChild)
    {
        var type = typeof(T);
        var fieldInfo = type.GetField(enumChild?.ToString() ?? string.Empty);
        if (fieldInfo is null) return "";

        var attr = (DescriptionAttribute[])
            fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

        return attr.Length > 0 ? attr[0].Description : "";
    }
}