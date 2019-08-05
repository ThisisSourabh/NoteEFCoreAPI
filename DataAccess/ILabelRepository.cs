using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface ILabelRepository
    {
        int CreateLabel(Label labels);
        Label GetLabelsByID(int LabelId);
        List<Label> GetAllLables();

        int UpdateLabel(Label label);
        int RemoveLabel(int LabelId);

    }
}
