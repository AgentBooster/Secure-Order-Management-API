using System.ComponentModel.DataAnnotations;

namespace LogiTrack.Models
{
    public class InventoryItem
    {
        [Key]
        public int ItemId { get; set; }
        
        [Required]
        public string Nombre { get; set; } = string.Empty;
        
        public int Cantidad { get; set; }
        
        public string Ubicacion { get; set; } = string.Empty;

        public void DisplayInfo()
        {
            Console.WriteLine($"Artículo: {Nombre} | Cantidad: {Cantidad} | Ubicación: {Ubicacion}");
        }
    }
}
