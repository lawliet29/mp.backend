using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Backend.Model;
using Newtonsoft.Json;

namespace Backend.Services
{
    public class AggregateElementaryAreaModel
    {
        [JsonProperty("Общая информация")]
        public ElementaryAreaFullModel CommonInfo { get; set; }

        [JsonProperty("Состав почвы")]
        public IDictionary<int, ElementaryAreaSoilComposition> SoilComposition { get; set; } = new Dictionary<int, ElementaryAreaSoilComposition>();

        [JsonProperty("История посевов")]
        public IDictionary<int, ElementaryAreaHistoryIItem> History { get; set; } = new Dictionary<int, ElementaryAreaHistoryIItem>();

        [JsonProperty("Расчет посевов")]
        public IDictionary<int, PaymentCropFullModel> CropRecount { get; set; } = new Dictionary<int, PaymentCropFullModel>();

        [JsonProperty("Минеральные удобрения")]
        public MineralFertilizerFullModel MineralFertilizer { get; set; }

        [JsonProperty("Органические удобрения")]
        public OrganicFertilizerFullModel OrganicFertilizer { get; set; }
    }

    public interface IElementaryAreaService
    {
        ICollection<ElementaryAreaFullModel> List();
        ICollection<ElementaryAreaHistoryIItem> GetHistoryById(int id);
        ICollection<ElementaryAreaSoilComposition> GetElAreaSoilCompositionById(int id);
        ICollection<PaymentCropFullModel> GetCropRecountById(int id);

        IDictionary<int, AggregateElementaryAreaModel> LoadEverything();
    }

    public class ElementaryAreaService : IElementaryAreaService, IDisposable
    {
        private readonly IEntityLoader<ElementaryAreaFullModel> _elementaryAreaLoader;
        private readonly IEntityLoader<ElementaryAreaHistoryIItem> _historyItemLoader;
        private readonly IEntityLoader<ElementaryAreaSoilComposition> _soilCompositionLoader;
        private readonly IEntityLoader<PaymentCropFullModel> _recountLoader;
        private readonly IEntityLoader<MineralFertilizerFullModel> _mineralFertilizerLoader;
        private readonly IEntityLoader<OrganicFertilizerFullModel> _organicFertilizerLoader;
        private readonly IDbConnection _connection;

        public ElementaryAreaService(
            IDbConnectionService connectionService, 
            IEntityLoader<ElementaryAreaFullModel> elementaryAreaLoader, 
            IEntityLoader<ElementaryAreaHistoryIItem> historyItemLoader,
            IEntityLoader<ElementaryAreaSoilComposition> soilCompositionLoader,
            IEntityLoader<PaymentCropFullModel> recountLoader,
            IEntityLoader<MineralFertilizerFullModel> mineralFertilizerLoader,
            IEntityLoader<OrganicFertilizerFullModel> organicFertilizerLoader)
        {
            _connection = connectionService.Connect();
            _elementaryAreaLoader = elementaryAreaLoader;
            _historyItemLoader = historyItemLoader;
            _soilCompositionLoader = soilCompositionLoader;
            _recountLoader = recountLoader;
            _mineralFertilizerLoader = mineralFertilizerLoader;
            _organicFertilizerLoader = organicFertilizerLoader;
        }

        public ICollection<ElementaryAreaFullModel> List()
        {
            return _elementaryAreaLoader.LoadList(_connection).ToList();
        }

        public ICollection<ElementaryAreaHistoryIItem> GetHistoryById(int id)
        {
            return _historyItemLoader.LoadList(_connection).Where(i => i.ElementaryAreaId == id).ToList();
        }

        public ICollection<ElementaryAreaSoilComposition> GetElAreaSoilCompositionById(int id)
        {
            return _soilCompositionLoader.LoadList(_connection).Where(c => c.ElementaryAreaId == id).ToList();
        }

        public ICollection<PaymentCropFullModel> GetCropRecountById(int id)
        {
            return _recountLoader.LoadList(_connection).Where(i => i.Id == id).ToList();
        }

        public IDictionary<int, AggregateElementaryAreaModel> LoadEverything()
        {
            return List()
                .ToDictionary(
                l => l.Id,
                l => new AggregateElementaryAreaModel
                {
                    CommonInfo = l,
                    SoilComposition = GetElAreaSoilCompositionById(l.Id).ToDictionary(c => c.Year, c => c),
                    History = GetHistoryById(l.Id).ToDictionary(h => h.Year, h => h),
                    CropRecount = GetCropRecountById(l.Id).ToDictionary(r => r.Year, r => r),
                    MineralFertilizer = _mineralFertilizerLoader.LoadList(_connection).FirstOrDefault(f => f.ElemAreaId == l.Id),
                    OrganicFertilizer = _organicFertilizerLoader.LoadList(_connection).FirstOrDefault(f => f.ElemAreaId == l.Id)
                });
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
