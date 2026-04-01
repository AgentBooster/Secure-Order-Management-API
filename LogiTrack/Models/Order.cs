using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LogiTrack.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        
        [Required]
        public string CustomerName { get; set; } = string.Empty;
        
        public DateTime DatePlaced { get; set; } = DateTime.UtcNow;

        public List<InventoryItem> List { get; set; } = new();

        public void AddItem(InventoryItem item)
        {
            List.Add(item);
        }

        public void RemoveItem(int itemId)
        {
            var item = List.Find(i => i.ItemId == itemId);
            if (item != null)
            {
                List.Remove(item);
            }
        }

        public string GetOrderSummary()
        {
            return $"Pedido #{OrderId} para {CustomerName} | Artículos: {List.Count} | Realizado: {DatePlaced.ToShortDateString()}";
        }
    }
}
