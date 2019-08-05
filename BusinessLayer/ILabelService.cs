using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public interface ILabelService
    {
        List<Label> GetAllLables();
        Label GetLabelsByID(int LabelId);
        int Createlabel(Label label);

        int UpdateLabel(Label label);
        int RemoveLabel(int LabelId);
    }
}
