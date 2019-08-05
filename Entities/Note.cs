using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Entities
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Text { get; set; }
        [JsonIgnore]
        public virtual ICollection<Label> Labels { get; set; }

    }
}
