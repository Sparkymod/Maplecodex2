using Maplecodex2.Database.Core;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maplecodex2.Data.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Feature { get; set; }
        public string? Locale { get; set; }
        public string? Icon { get; set; }
        public string? Slot { get; set; }

        public Item() { }

        public Item(int id, string type, string name, string feature, string locale, string icon, string slot)
        {
            Id = id;
            Type = type;
            Name = name;
            Feature = feature;
            Locale = locale;
            Icon = icon;
            Slot = slot;
        }

        public static void Build(EntityTypeBuilder<Item> entity) // EF Core builder
        {
            entity.HasKey(item => item.Id);

            entity.Property(item => item.Id).IsRequired();
            entity.Property(item => item.Name).HasMaxLength(255);
            entity.Property(item => item.Type).HasMaxLength(255);
            entity.Property(item => item.Feature).HasMaxLength(255);
            entity.Property(item => item.Locale).HasMaxLength(255);
            entity.Property(item => item.Icon).HasMaxLength(255);
            entity.Property(item => item.Slot).HasMaxLength(255);
        }

        public override string ToString() => $"Id: {Id}, Name: {Name}, Class: {Type}, Slot: {Slot}, Feature: {Feature}"
            + $", Locale: {Locale}, IconPath: {Icon}";
    }
}
