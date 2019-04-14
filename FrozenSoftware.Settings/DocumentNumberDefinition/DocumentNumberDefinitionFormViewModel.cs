using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Unity;

namespace FrozenSoftware.Settings
{
    public class DocumentNumberDefinitionFormViewModel : BaseFormViewModel
    {
        public DocumentNumberDefinition Entity { get; set; }

        public override void Initialize(int? entityId, ActionType actionType, List<object> additionalData = null)
        {
            base.Initialize(entityId, actionType, additionalData);

            switch (actionType)
            {
                case ActionType.Add:
                    Entity = new DocumentNumberDefinition();
                    break;
                case ActionType.Edit:
                    var t = ApiClient.ApiDocumentnumberdefinitionsGetAsync(entityId.Value);
                    t.Wait();
                    Entity = t.Result;
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
                        ApiClient.ApiDocumentnumberdefinitionsPostAsync(Entity);
                        break;
                    case ActionType.Edit:
                        ApiClient.ApiDocumentnumberdefinitionsPutAsync(Entity.Id, Entity);
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
    }
}
