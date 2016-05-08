using Backend.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model
{
    [Table("агроном_ИсторияПолей_ОргУдобрения")]
    public class OrganicFertilizerModel
    {
        [Column("ElemAreaID")]
        public int ElemAreaId { get; set; }
        [Column("FertilizerCode")]
        public int FertilizerId { get; set; }
        [RelationColumn(
            ReferenceId = "FertilizerCode",
            FromTable = "_ОрганическиеУдобрения",
            PurposeId = "ID",
            FromColumn = "Name"
        )]
        public string Fertilizer { get; set; }
    }
    [Table("агроном_ИсторияПолей_ОргУдобрения")]
    public class OrganicFertilizerFullModel : OrganicFertilizerModel
    {
        [Column("FertilizationDate")]
        public int FertilizationDate { get; set; }
        [Column("FertilizerWeight")]
        public int FertilizerWeight { get; set; }
        [Column("S")]
        public int S { get; set; }
        [Column("N")]
        public int N { get; set; }
        [Column("P2O5")]
        public int P2O5 { get; set; }
        [Column("K2O")]
        public int K2O { get; set; }
        [Column("Price")]
        public int Price { get; set; }

    }
}
