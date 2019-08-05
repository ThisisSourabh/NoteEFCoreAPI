using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;

namespace DataAccess
{
    public class LabelRepository : ILabelRepository
    {
        private readonly NoteDbContext context;
        public LabelRepository(NoteDbContext noteDbContext)
        {
            context = noteDbContext;
        }

        public int CreateLabel(Label labels)
        {
            context.Labels.Add(labels);
            return context.SaveChanges();
        }

        public List<Label> GetAllLables()
        {
            return context.Labels.ToList();
            
        }

        public Label GetLabelsByID(int LabelId)
        {
            return context.Labels.Find(LabelId);
            
        }

        public int RemoveLabel(int LabelId)
        {
            return context.SaveChanges();
            
        }

        public int UpdateLabel(Label label)
        {

            context.Entry<Label>(label).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
