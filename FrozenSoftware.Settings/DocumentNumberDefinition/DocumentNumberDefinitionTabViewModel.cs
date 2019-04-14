using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using Unity;

namespace FrozenSoftware.Settings
{
    public class DocumentNumberDefinitionTabViewModel : BaseTabViewModel
    {
        public DocumentNumberDefinitionTabViewModel(IRegionManager regionManger, IUnityContainer unityContainer)
            : base(regionManger, unityContainer)
        {
            ParentViewName = nameof(SettingsRibbonTabItem);
            HasEditButtons = true;
        }

        public ObservableCollection<DocumentNumberDefinition> DocumentNumberDefinitions { get; set; }

        public async override void InitializeData()
        {
            try
            {
                var docNumbDefinitions = await ApiClient.ApiDocumentnumberdefinitionsGetAsync();
                DocumentNumberDefinitions = new ObservableCollection<DocumentNumberDefinition>(docNumbDefinitions);
            }
            catch (Exception e)
            {
                WindowHandler.WindowHandlerInstance.ShowMessage(e.Message, this.GetType().Name, UnityContainer);
            }
        }

        protected override void OnAddCommand()
        {
            WindowHandler.WindowHandlerInstance.ShowWindow(null, ActionType.Add, typeof(DocumentNumberDefinitionForm), UnityContainer, this.GetType().Name);
        }

        protected override void OnEditCommand()
        {
            DocumentNumberDefinition documentNumberDefinition = DocumentNumberDefinitions[SelectedIndex];
            WindowHandler.WindowHandlerInstance.ShowWindow(documentNumberDefinition.Id, ActionType.Edit, typeof(DocumentNumberDefinitionForm), UnityContainer, this.GetType().Name);
        }

        protected override void OnDeleteCommand()
        {
            DocumentNumberDefinition documentNumberDefinition = DocumentNumberDefinitions[SelectedIndex];
            bool? result = WindowHandler.WindowHandlerInstance.ShowConfirm($"Do you want to delete {documentNumberDefinition.Name}?", this.GetType().Name, UnityContainer, "Document number definition");

            if (result == true)
                ApiClient.ApiDocumentnumberdefinitionsDeleteAsync(documentNumberDefinition.Id);

            InitializeData();
        }
    }
}
