using Maple2.File.Parser.Xml.Item;

namespace Maplecodex2.Data.Models
{
    public record struct Item(ItemInfo Info, ItemData Data)
    {
        public static implicit operator (ItemInfo info, ItemData environment)(Item value)
        {
            return (value.Info, value.Data);
        }
    }

    public class ItemInfo
    {
        public int Id;
        public string Name;
        public string MainDescription;
        public string GuideDescription;
        public string ToolDescription;
        public string Type;
        public List<int?> Rarities;
    }
}
