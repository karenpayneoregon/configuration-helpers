using System;

namespace ConfigurationHelperConventional
{
    public static class PropertyExtension
    {

        public static void SetPropertyValue(this object pObject, string pPropertyName, object value)
        {
            var propertyInfo = pObject.GetType().GetProperty(pPropertyName);
            Type t = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
            object safeValue = (value == null) ? null : Convert.ChangeType(value, t);

            propertyInfo.SetValue(pObject, safeValue, null);
        }
    }

}
