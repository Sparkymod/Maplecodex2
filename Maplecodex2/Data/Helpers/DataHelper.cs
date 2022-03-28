using Maple2.File.IO;
using Maple2.File.Parser;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Item;
using Maple2.File.Parser.Xml.String;
using Maple2.File.Parser.Xml;
using Serilog;

namespace Maplecodex2.Data.Helpers
{
    public class DataHelper
    {
        public (int id, string name, ItemData data) InitParser()
        {
            (int id, string name, ItemData data) result = new(1, "", new ItemData());
            try
            {
                var reader = new M2dReader(Settings.GetXmlPath());

                // LOCALE: "TW", "TH", "NA", "CN", "JP", "KR"
                // ENV:    "Dev", "Qa", "DevStage", "Stage", "Live"
                Filter.Load(reader, "NA", "Live");
                var parser = new ItemParser(reader);

                foreach ((int id, string name, ItemData data) in parser.Parse())
                {
                    // Extract fields from ItemData that are needed.
                    result = (id,name, data);
                    break;
                }
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
