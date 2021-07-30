namespace Example
{
    using Newtonsoft.Json;
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

    public class TodoListController : TodoListControllerBase
    {
        [Inject]
        public TodoListService TodoListService { get; private set; }


        public override void InitializeTodoList(TodoListViewModel viewModel)
        {
            base.InitializeTodoList(viewModel);
            // This is called when a TodoListElementViewModel is created

            //viewModel.TodoItems.Add(new TodoItem() { Content = "Hello" });

            Debug.Log(TodoListService.TodoItemsViewModels.Count);
            //var output = JsonConvert.SerializeObject(TodoListService.TodoItemsViewModels);
            //Debug.Log(output);

            //var todoItems = new ModelCollection<TodoItemViewModel>();

            //foreach (var todoItem in TodoListService.TodoItems)
            //{
            //    todoItems.Add(new TodoItemViewModel(EventAggregator)
            //    {
            //        Content = todoItem.Content,
            //        Finished = todoItem.Finished
            //    });;
            //}

            viewModel.TodoItems = TodoListService.TodoItemsViewModels;

            this.OnEvent<BtnDeleteClickedCommand>().Subscribe(command =>
            {
                viewModel.TodoItems.Remove(command.Sender as TodoItemViewModel);
                //Debug.Log("TodoListController");
            }).DisposeWith(viewModel);

            this.OnEvent<TodoItemClickedCommand>().Subscribe(command =>
            {
                //viewModel.TodoContent = (command.Sender as TodoItemViewModel).Content;
                viewModel.TodoEditor.State = TodoEditorState.Modify;

                this.Publish(new ItemClickedChangeComand() { TodoItem = (command.Sender as TodoItemViewModel) });

                viewModel.EventMask.PageMode = PageMode.Eidt;

                //Debug.Log("TodoItemClickedCommand: " + viewModel.TodoContent);
            }).DisposeWith(viewModel);

            this.OnEvent<ModifyCommand>().Subscribe(command => {
                viewModel.EventMask.PageMode = PageMode.Normal;
            }).DisposeWith(viewModel);

            this.OnEvent<CancleCommand>().Subscribe(command =>
            {
                viewModel.EventMask.PageMode = PageMode.Normal;
            }).DisposeWith(viewModel);

            //var output = JsonConvert.SerializeObject(viewModel.TodoItems);
            //Debug.Log(output);
        }

        public override void OnBtnAddClicked(TodoListViewModel viewModel)
        {
            base.OnBtnAddClicked(viewModel);

            var todoItemViewModel = this.CreateViewModel<TodoItemViewModel>();
            viewModel.TodoItems.Add(todoItemViewModel);
            todoItemViewModel.Content = viewModel.TodoContent;

            viewModel.TodoContent = string.Empty;

            //viewModel.PageType = 

            Publish(new OnBtnAddClickedCommand());
        }

        public override void BtnShowFinishedListCllicked(TodoListViewModel viewModel)
        {
            base.BtnShowFinishedListCllicked(viewModel);

            viewModel.PageType = PageType.FinishedList;

            this.Publish(new PageTypeChangedCommand() { PageType = viewModel.PageType });
        }

        public override void BtnShowTodoListClicked(TodoListViewModel viewModel)
        {
            base.BtnShowTodoListClicked(viewModel);

            viewModel.PageType = PageType.TodoList;

            this.Publish(new PageTypeChangedCommand() {PageType = viewModel.PageType });
        }

    }
}
