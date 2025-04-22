using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventHub.API.Models
{
    public enum EventType { InPerson, Online }

    public class Event
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public required string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public required string Description { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }

        [Required]
        public DateTime EndDateTime { get; set; }

        [Required]
        public EventType Type { get; set; }

        [MaxLength(200)]
        public required string Location { get; set; } // For in-person events

        [MaxLength(500)]
        public required string OnlineMeetingLink { get; set; } // For online events

        [Required]
        public Guid OrganizerId { get; set; }

        [ForeignKey("OrganizerId")]
        public required User Organizer { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedAt { get; set; }

        public required ICollection<TicketType> TicketTypes { get; set; }
    }
}