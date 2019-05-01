using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using System;
using System.Collections.Generic;

namespace FrozenSoftware.Settings
{
    public class DocumentNumberDefinitionFormViewModel : BaseFormViewModel
    {
        public DocumentNumberDefinitionFormViewModel()
        {
        }

        public DocumentNumberDefinition Entity { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool HasDate { get; set; }

        public string DateFormat { get; set; }

        public string TextConstant { get; set; }

        public int NumbersCount { get; set; }

        public int NumbersPosition { get; set; }

        public int? TextConstantPostion { get; set; }

        public int? DatePosition { get; set; }

        public string NumberPreview { get; set; }

        protected override void Initialize(int? entityId, ActionType actionType, List<object> additionalData = null)
        {
            base.Initialize(entityId, actionType, additionalData);

            switch (actionType)
            {
                case ActionType.Add:
                    Entity = new DocumentNumberDefinition();
                    break;
                case ActionType.Edit:
                    var task = ApiClient.GetDocumentNumberDefinitionAsync(entityId.Value);
                    task.Wait();
                    Entity = task.Result;
                    break;
            }
        }

        protected override void OnConfirmCommand()
        {
            try
            {
                switch (ActionType)
                {
                    case ActionType.Add:
                        ApiClient.AddDocumentNumberDefinitionAsync(Entity).Wait();
                        break;
                    case ActionType.Edit:
                        ApiClient.UpdateDocumentNumberDefinitionsAsync(Entity.Id, Entity).Wait();
                        break;
                }

                DialogResult = true;

                if (Close != null)
                    Close.Invoke();
            }
            catch (Exception e)
            {
                WindowHandler.WindowHandlerInstance.ShowMessage(e.Message, this.GetType().Name, UnityContainer);
            }
        }

        private void SetData()
        {
            Name = Entity.Name;
            StartDate = Entity.StartDate;
            EndDate = Entity.EndDate;
            HasDate = Entity.HasDate;
            DateFormat = Entity.DateFormat;
            NumbersCount = Entity.NumbersCount;
            TextConstant = Entity.TextConstant;
            NumbersPosition = Entity.NumberPosition;
            TextConstantPostion = Entity.TextConstantPosition;
            DatePosition = Entity.DatePosition;
        }
    }
}

