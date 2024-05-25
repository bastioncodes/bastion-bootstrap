using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Reflex.Attributes;

namespace Bastion.Samples.Weapon
{
    // This is very useful for adding the ability to convert custom complex JSON structures automatically
    // Read and Write is defined here, then the JsonConverter needs to be added to the configuration
    // The config is currently set at the NewtonsoftJsonConverter constructor
    public class WeaponConverter : JsonConverter
    {
        [Inject] private readonly WeaponFactory _factory;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            WeaponData weapon = (WeaponData)value;
            JObject obj = new JObject
            {
                { "name", weapon.Name },
                { "damage", weapon.Damage },
                { "cooldown", weapon.Cooldown },
            };
            obj.WriteTo(writer);
        }


        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            string name = (string)obj["name"];
            int damage = (int)obj["damage"];
            float cooldown = (float)obj["cooldown"];

            return _factory.Create(name, damage, cooldown);
        }


        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(WeaponData);
        }
    }
}