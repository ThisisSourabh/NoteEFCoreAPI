using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Entities;
using BusinessLayer.Exceptions;

namespace BusinessLayer
{
    public class LabelService : ILabelService
    {
        private readonly ILabelRepository repository;
        public LabelService(ILabelRepository labelrepository)
        {
            repository = labelrepository;
        }

        public int Createlabel(Label label)
        {
            var _labels = repository.GetLabelsByID(label.LabelId);
            if (_labels == null)
            {
                return repository.CreateLabel(label);
            }
            else
                throw new LabelAlreadyExistException(($"Notes with NoteId {label.LabelId}already Exists"));
        }

        public List<Label> GetAllLables()
        {
            return repository.GetAllLables();
            
        }

        public Label GetLabelsByID(int LabelId)
        {
            var _label = repository.GetLabelsByID(LabelId);
            if (_label == null)
            {
                throw new NoteNotFoundException($"Notes with NoteId {LabelId}does not exist");
            }
            else
                return _label;
        }

        public int RemoveLabel(int LabelId)
        {
            var _label = repository.GetLabelsByID(LabelId);
            if (_label == null)
            {
                throw new LabelNotFoundException($"Label with LabelId {LabelId}does not exist");
            }
            else
                return repository.RemoveLabel(LabelId);
        }

        public int UpdateLabel(Label label)
        {
            var _label = repository.GetLabelsByID(label.LabelId);
            if (_label == null)
            {
                throw new LabelNotFoundException($"label with labelId {label.LabelId}does not exist");
            }
            else
            {
                _label.LabelId = label.LabelId;
                _label.Description = label.Description;
                _label.notes = label.notes;
                return repository.UpdateLabel(_label);
            }
        }
    }
}
