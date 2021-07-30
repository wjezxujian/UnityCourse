namespace Example {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.IOC;
    using uFrame.Kernel;
    using uFrame.MVVM;
    using uFrame.Serialization;
    using UniRx;
    
    
    public class TodoEditorController : TodoEditorControllerBase {
        
        public override void InitializeTodoEditor(TodoEditorViewModel viewModel) {
            base.InitializeTodoEditor(viewModel);
            // This is called when a TodoEditorViewModel is created

            this.OnEvent<ItemClickedChangeComand>().Subscribe(command =>
            {
                viewModel.TodoItem = command.TodoItem;
                viewModel.OriginContent = command.TodoItem.Content;
                viewModel.TodoContent = viewModel.OriginContent;
            }).DisposeWith(viewModel); 
        }
        
        public override void Modify(TodoEditorViewModel viewModel) {
            base.Modify(viewModel);

            viewModel.TodoItem.Content = viewModel.TodoContent;

            viewModel.TodoContent = string.Empty;
            viewModel.State = TodoEditorState.Creation;

            this.Publish(new ModifyCommand());
        }
        
        public override void Cancle(TodoEditorViewModel viewModel) {
            base.Cancle(viewModel);

            viewModel.TodoContent = string.Empty;
            viewModel.State = TodoEditorState.Creation;

            this.Publish(new CancleCommand());
        }
        
        public override void Add(TodoEditorViewModel viewModel) {
            base.Add(viewModel);
        }
    }
}
