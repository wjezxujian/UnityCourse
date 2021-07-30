namespace Example {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.Kernel;
    using uFrame.MVVM;
    using uFrame.MVVM.Services;
    using uFrame.MVVM.Bindings;
    using uFrame.Serialization;
    using UniRx;
    using UnityEngine;
    
    
    public class TodoEditorView : TodoEditorViewBase {
        
        protected override void InitializeViewModel(uFrame.MVVM.ViewModel model) {
            base.InitializeViewModel(model);
            // NOTE: this method is only invoked if the 'Initialize ViewModel' is checked in the inspector.
            // var vm = model as TodoEditorViewModel;
            // This method is invoked when applying the data from the inspector to the viewmodel.  Add any view-specific customizations here.
        }
        
        public override void Bind() {
            base.Bind();
            // Use this.TodoEditor to access the viewmodel.
            // Use this method to subscribe to the view-model.
            // Any designer bindings are created in the base implementation.

            UpdateState();

            TodoEditor.StateProperty.ChangedObservable.Subscribe(state =>
            {
                UpdateState();
            }).DisposeWith(this);


            _ModifyButton.interactable = false;

            this.BindInputFieldToHandler(_TodoContentInput, inputContent =>
            {
                _ModifyButton.interactable = !string.IsNullOrEmpty(inputContent) && inputContent != TodoEditor.OriginContent;
            });
        }

        private void UpdateState()
        {
            if (TodoEditor.State == TodoEditorState.Creation)
            {
                _AddButton.gameObject.SetActive(true);
                _ModifyButton.gameObject.SetActive(false);
                _CancleButton.gameObject.SetActive(false);
            }
            else
            {
                _AddButton.gameObject.SetActive(false);
                _ModifyButton.gameObject.SetActive(true);
                _CancleButton.gameObject.SetActive(true);
            }
        }
    }
}
