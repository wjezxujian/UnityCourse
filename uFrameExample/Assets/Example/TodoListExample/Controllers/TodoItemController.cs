namespace Example
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.IOC;
    using uFrame.Kernel;
    using uFrame.MVVM;
    using uFrame.Serialization;
    using UniRx;
    using UnityEngine;

    public class TodoItemController : TodoItemControllerBase
    {

        public override void InitializeTodoItem(TodoItemViewModel viewModel)
        {
            base.InitializeTodoItem(viewModel);
            // This is called when a TodoItemViewModel is created
        }

        public override void BtnFinishClicked(TodoItemViewModel viewModel)
        {
            base.BtnFinishClicked(viewModel);

            //viewModel.Finished = true;
            Debug.Log("finished");
        }

        public override void BtnRestoreClicked(TodoItemViewModel viewModel)
        {
            base.BtnRestoreClicked(viewModel);
        }

        public override void BtnDeleteClicked(TodoItemViewModel viewModel)
        {
            base.BtnDeleteClicked(viewModel);

            Debug.Log("delete:" + viewModel.Content);

            this.Publish(new BtnDeleteClickedCommand() { Sender = viewModel });
        }

        public override void TodoItemClicked(TodoItemViewModel viewModel)
        {
            base.TodoItemClicked(viewModel);

            Debug.Log("TodoItemClicked");
            Debug.Log(viewModel.Content);

            this.Publish(new TodoItemClickedCommand() { Sender = viewModel });
        }
    }
}
