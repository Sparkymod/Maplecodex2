using Maple2.File.Parser.Xml.Item;
using Maplecodex2.Data.Models;
using Maplecodex2.Data.Services;
using Microsoft.AspNetCore.Components;
using Serilog;
using System.Reflection;

namespace Maplecodex2.Pages.Components
{
    public partial class ItemDetails
    {
        [Parameter]
        public Item CurrentItem { get; set; }
        [Parameter]
        public int Id { get; set; }

        private int? _selectRarity = 1;

        private bool _isLoading;

        public string? GetIcon() => CurrentItem.Data.property.slotIcon.Contains("icon0.png") ? CurrentItem.Data.property.slotIconCustom : CurrentItem.Data.property.slotIcon;

        public string SetRarityCSS(int? rarity)
        {
            return rarity switch
            {
                1 => "common",
                2 => "rare",
                3 => "exceptional",
                4 => "epic",
                5 => "legendary",
                6 => "ascendant",
                _ => ""
            };
        }

        protected override void OnParametersSet()
        {
            CurrentItem = DataHelperService.Instance.ItemList.Find(x => x.Info.Id == (Id != 0 ? Id : 1));
            //Test();
            base.OnParametersSet();
        }

        private void Test()
        {
            foreach (FieldInfo field in typeof(Install).GetFields())
            {
                var data = field.GetValue(CurrentItem.Data.install);
                Log.Logger.Information($"{field.Name} => {data}");
            }
        }
    }
}
