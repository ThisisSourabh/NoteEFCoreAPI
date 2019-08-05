using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities
{
    public class Note
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NoteId { get; set; } 
        [Required]
        public string Title { get; set; }
        public string Text { get; set; }
        public virtual ICollection<Label> Labels { get; set; }

    }
}
