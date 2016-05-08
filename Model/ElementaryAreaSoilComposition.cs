using Backend.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model
{
    [Table("агроном_ЭлементарныеУчастки_СоставПочвы")]
    public class ElementaryAreaSoilComposition
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("Year")]
        public int Year { get; set; }
        [Column("ХимАнализ")]
        public bool ChemicalAnalysis { get; set; }
        [Column("МощПахГор")]
        public int ArableLayerCapasity { get; set; }
        [Column("Фосфор")]
        public int Phosphorus { get; set; }
        [Column("Калий")]
        public int Potassium { get; set; }
        [Column("Кислотность")]
        public int Acidity { get; set; }
        [Column("ДозаИзвести")]
        public int LimeDose { get; set; }
        [Column("Гумус")]
        public int Humus { get; set; }
        [Column("ЕмкКатОбмена")]
        public int CapacityExchange { get; set; }
        [Column("Кальций")]
        public int Calcium { get; set; }
        [Column("Магний")]
        public int Magnesium { get; set; }
        [Column("Сера")]
        public int Sulfur { get; set; }
        [Column("Бор")]
        public int Boron { get; set; }
        [Column("Медь")]
        public int Copper { get; set; }
        [Column("Цинк")]
        public int Zink { get; set; }
        [Column("Марганец")]
        public int Manganese { get; set; }
        [Column("Кобальт")]
        public int Cobalt { get; set; }
        [Column("Цезий")]
        public int Cesium { get; set; }
        [Column("Стронций")]
        public int Strontium { get; set; }
    }
}
