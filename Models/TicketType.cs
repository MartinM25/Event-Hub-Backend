using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventHub.API.Models
{
    public class TicketType
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]  // e.g., "General Admission", "VIP"
        public required string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]  // Proper decimal precision for pricing
        public decimal Price { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int QuantityAvailable { get; set; }

        [Required]
        public Guid EventId { get; set; }

        [ForeignKey("EventId")]
        public required Event Event { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedAt { get; set; }

        // Navigation property
        public required ICollection<Ticket> Tickets { get; set; }
    }
}