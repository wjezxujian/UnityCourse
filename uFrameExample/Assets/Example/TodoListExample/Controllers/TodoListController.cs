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

    public class TodoListController : TodoListControllerBase
    {
        [Inject]
        public TodoListService TodoListService { get; set; }


        public override void InitializeTodoList(TodoListViewModel viewModel)
        {
            base.InitializeTodoList(viewModel);
            // This is called when a TodoListElementViewModel is created

            //viewModel.TodoItems.Add(new TodoItem() { Content = "Hello" });

            Debug.Log(TodoListService.TodoItems.Count);

            viewModel.TodoItems = TodoListService.TodoItems;

            Debug.Log(JsonUtility.ToJson(TodoListService.TodoItems));

            var todoItems = JsonUtility.FromJson<ModelCollection<TodoItem>>(JsonUtility.ToJson(TodoListService.TodoItems));
            Debug.Log("Json Count:"  + todoItems.Count);
        }

        public override void OnBtnAddClicked(TodoListViewModel viewModel)
        {
            base.OnBtnAddClicked(viewModel);

            viewModel.TodoItems.Add(new TodoItem() { Content = viewModel.TodoContent });

            viewModel.TodoContent = string.Empty;
        }
   
    }
}
