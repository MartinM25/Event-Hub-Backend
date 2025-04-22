using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventHub.API.Models
{
    public class Ticket
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid TicketTypeId { get; set; }

        [ForeignKey("TicketTypeId")]
        public required TicketType TicketType { get; set; }

        [Required]
        public Guid AttendeeId { get; set; }

        [ForeignKey("AttendeeId")]
        public required User Attendee { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;

        public bool IsUsed { get; set; } = false;

        public DateTime? UsedAt { get; set; }  // When the ticket was scanned/used

        [Required]
        [MaxLength(500)]  // QR code data or meeting link
        public required string QRCodeData { get; set; }

        // Additional metadata (optional)
        [MaxLength(50)]
        public required string TransactionId { get; set; }  // For payment tracking
    }
}