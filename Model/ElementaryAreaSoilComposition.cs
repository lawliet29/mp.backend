using Backend.Metadata;
using Newtonsoft.Json;

namespace Backend.Model
{
    [Table("агроном_ЭлементарныеУчастки_СоставПочвы")]
    public class ElementaryAreaSoilComposition
    {
        [Column("ID")]
        [JsonIgnore]
        public int ElementaryAreaId { get; set; }
        [Column("Year")]
        [JsonProperty("Год")]
        [JsonConverter(typeof(MeasureUnitConverter), "г.")] // TODO: куку
        public int Year { get; set; }
        [Column("ХимАнализ")]
        [JsonProperty("Химический анализ")]
        public bool ChemicalAnalysis { get; set; }
        [Column("МощПахГор")]
        [JsonProperty("Мощность пахотного горизонта")]
        public int ArableLayerCapasity { get; set; }
        [Column("Фосфор")]
        [JsonProperty("Фосфор")]
        public int Phosphorus { get; set; }
        [Column("Калий")]
        [JsonProperty("Калий")]
        public int Potassium { get; set; }
        [Column("Кислотность")]
        [JsonProperty("Кислотность")]
        public int Acidity { get; set; }
        [Column("ДозаИзвести")]
        [JsonProperty("Доза извести")]
        public int LimeDose { get; set; }
        [Column("Гумус")]
        [JsonProperty("Гумус")]
        public int Humus { get; set; }
        [Column("ЕмкКатОбмена")]
        [JsonProperty("Емкость каталитического обмена")]
        public int CapacityExchange { get; set; }
        [Column("Кальций")]
        [JsonProperty("Кальций")]
        public int Calcium { get; set; }
        [Column("Магний")]
        [JsonProperty("Магний")]
        public int Magnesium { get; set; }
        [Column("Сера")]
        [JsonProperty("Сера")]
        public int Sulfur { get; set; }
        [Column("Бор")]
        [JsonProperty("Бор")]
        public int Boron { get; set; }
        [Column("Медь")]
        [JsonProperty("Медь")]
        public int Copper { get; set; }
        [Column("Цинк")]
        [JsonProperty("Цинк")]
        public int Zink { get; set; }
        [Column("Марганец")]
        [JsonProperty("Марганец")]
        public int Manganese { get; set; }
        [Column("Кобальт")]
        [JsonProperty("Кобальт")]
        public int Cobalt { get; set; }
        [Column("Цезий")]
        [JsonProperty("Цезий")]
        public int Cesium { get; set; }
        [Column("Стронций")]
        [JsonProperty("Строниций")]
        public int Strontium { get; set; }
    }
}
