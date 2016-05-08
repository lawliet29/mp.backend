using Backend.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model
{
    [Table("агроном_ПоляСевооборотов")]
    public class FieldModel
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Number")]
        public int Number { get; set; }
    }
    [Table("агроном_ПоляСевооборотов_Состав")]
    public class FieldFullModel : WorkAreaModel
    {
        [Column("Действует")]
        public bool Active { get; set; }
        [Column("CropRotationId")]
        public int CropRotationId { get; set; }
        [Column("InitialYearOfCycle")]
        public int InitialYear { get; set; }
        [Column("StartYear")]
        public int StartYear { get; set; }
        [Column("ElemAreaID")]
        public ICollection<ElementaryAreaModel> FieldComposition { get; set; }
    }
}
