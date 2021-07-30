namespace Example
{
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


    public class TodoItemView : TodoItemViewBase
    {

        protected override void InitializeViewModel(uFrame.MVVM.ViewModel model)
        {
            base.InitializeViewModel(model);
            // NOTE: this method is only invoked if the 'Initialize ViewModel' is checked in the inspector.
            // var vm = model as TodoItemViewModel;
            // This method is invoked when applying the data from the inspector to the viewmodel.  Add any view-specific customizations here.

        }

        public override void Bind()
        {
            base.Bind();
            // Use this.TodoItem to access the viewmodel.
            // Use this method to subscribe to the view-model.
            // Any designer bindings are created in the base implementation.

            this.BindButtonToHandler(_BtnFinishClickedButton, () =>
            {
                TodoItem.Finished = true;
                Destroy(this.gameObject);
            });

            this.BindButtonToHandler(_BtnRestoreClickedButton, () =>
            {
                TodoItem.Finished = false;
                Destroy(this.gameObject);
            });

            this.OnEvent<PageTypeChangedCommand>().Subscribe(command =>
            {
                UpdatePageType(command.PageType);
                Debug.Log("TodoItemController: " + command.PageType);
            }).DisposeWith(this);

            UpdatePageType(PageType.TodoList);
        }

        public override void FinishedChanged(Boolean arg1)
        {
            Debug.Log(arg1);
        }

        public void UpdatePageType(PageType pageType)
        {
            if(pageType == PageType.TodoList)
            {
                _BtnFinishClickedButton.gameObject.SetActive(true);
                _BtnDeleteClickedButton.gameObject.SetActive(false);                
                _BtnRestoreClickedButton.gameObject.SetActive(false);
            }
            else
            {
                _BtnFinishClickedButton.gameObject.SetActive(false);
                _BtnDeleteClickedButton.gameObject.SetActive(true);
                _BtnRestoreClickedButton.gameObject.SetActive(true);
            }

        }
    }
}
