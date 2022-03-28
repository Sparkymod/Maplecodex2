using Serilog;
using Maplecodex2.Data.Maple2Custom;
using Maplecodex2.Data.Models;
using Maple2.File.IO;
using Maple2.File.Parser.Tools;

namespace Maplecodex2.Data.Helpers
{
    public class DataHelper
    {
        public Item InitParser()
        {
            Item result = new();

            try
            {
                var reader = new M2dReader(Settings.GetXmlPath());

                // LOCALE: "TW", "TH", "NA", "CN", "JP", "KR"
                // ENV:    "Dev", "Qa", "DevStage", "Stage", "Live"
                Filter.Load(reader, "NA", "Live");

                IEnumerable<Item> parser = new ItemParser(reader).Parse();
                result = parser.Where(item => item.Info.Id == 11020005).Select(x => x).FirstOrDefault();

                reader.Dispose();

                return result;
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.Message);
                throw;
            }

        }
    }
}
