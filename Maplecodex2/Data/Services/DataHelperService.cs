using Serilog;
using Maplecodex2.Data.Models;
using Maple2.File.IO;
using Maple2.File.Parser.Tools;

namespace Maplecodex2.Data.Services
{
    public class DataHelperService
    {
        private static DataHelperService _instance;
        public List<Item> ItemList { get; set; }

        public static DataHelperService Instance => _instance ??= new DataHelperService();

        public DataHelperService()
        {
            Log.Logger.Warning("Initializing services... Please Wait");
            ItemList = InitParser().ToList();
        }

        public IEnumerable<Item> InitParser()
        {
            try
            {
                var reader = new M2dReader(Settings.GetXmlPath());

                // LOCALE: "TW", "TH", "NA", "CN", "JP", "KR"
                // ENV:    "Dev", "Qa", "DevStage", "Stage", "Live"
                Filter.Load(reader, "NA", "Live");

                IEnumerable<Item> parser = new ItemParser(reader).Parse();

                reader.Dispose();
                return parser;
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.Message);
                return null;
            }
        }
    }
}
