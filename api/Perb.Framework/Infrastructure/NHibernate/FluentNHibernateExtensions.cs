using FluentNHibernate.Mapping;
using NHibernate.Type;

namespace Perb.Framework.Infrastructure.NHibernate
{
    public static class FluentNHibernateExtensions
    {
        public static PropertyPart AsClob(this PropertyPart propertyPart)
        {
            return propertyPart.CustomType("StringClob").CustomSqlType("nvarchar(max)");
        }
        
        public static PropertyPart AsEnumString<T>(this PropertyPart propertyPart)
        {
            return propertyPart.CustomType<EnumStringType<T>>();
        }
    }
}