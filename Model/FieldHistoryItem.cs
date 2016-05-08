using Backend.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model
{
    [Table("агроном_ПоляСевооборотов_История")]
    public class FieldHistoryItem
    {
        [Column("FieldID")]
        public int Id { get; set; }
        [Column("Year")]
        public int Year { get; set; }
        [Column("CropID")]
        public int CultureId { get; set; }
    }
}
