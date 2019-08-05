using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Label
    {
        public int LabelId { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public virtual Note notes { get; set; }
        public int NoteId { get; set; }

    }
}
