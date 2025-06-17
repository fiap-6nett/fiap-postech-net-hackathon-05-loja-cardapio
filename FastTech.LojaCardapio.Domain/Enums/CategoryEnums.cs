using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace FastTech.LojaCardapio.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CategoryEnums
    {
        [EnumMember(Value = "Lanche")]
        Lanche,

        [EnumMember(Value = "Acompanhamento")]
        Acompanhamento,

        [EnumMember(Value = "Bebida")]
        Bebida,

        [EnumMember(Value = "Sobremesa")]
        Sobremesa
    }
}
