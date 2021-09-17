﻿using System.Xml.Serialization;

namespace Maplecodex2.Data.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Feature { get; set; }
        public string Locale { get; set; }
        public string Icon { get; set; }
        public string Category { get; set; }

        public Item() { } // Datatable

        public Item(int id, string clas, string name, string feature, string locale, string icon, string category)
        {
            Id = id;
            Type = clas;
            Name = name;
            Feature = feature;
            Locale = locale;
            Icon = icon;
            Category = category;
        }
    }
}