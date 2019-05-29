using RCE.Commons.Abstracts;
using System;
using System.Linq;

namespace RCE.Commons.Extensions
{
    public static class BaseEntityExtension
    {
        public static void InitializeEntity(this BaseEntity baseEntity)
        {
            baseEntity.Id = Guid.NewGuid();
            var field= baseEntity.GetType().GetProperties().FirstOrDefault(m => m.Name == "CreatedDate");
            if (field != null) field.SetValue(baseEntity, DateTime.UtcNow);
        }

        public static void ChangeTo(this BaseEntity baseEntity, BaseEntity entity)
        {
            var baseEntityProperties = baseEntity.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            var entityProperties = entity.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            foreach (var item in baseEntityProperties)
            {
                var value = entityProperties.FirstOrDefault(m => m.Name == item.Name)?.GetValue(entity);
                item.SetValue(baseEntity, value);
            }
        }
    }
}
