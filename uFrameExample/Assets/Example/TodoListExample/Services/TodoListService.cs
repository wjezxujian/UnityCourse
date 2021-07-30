namespace Example
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UniRx;
    using uFrame.IOC;
    using uFrame.Kernel;
    using uFrame.MVVM;
    using Newtonsoft.Json;
    //using QFramework;

    public class TodoListService : TodoListServiceBase
    {
        //private ModelCollection<TodoItemViewModel> mTodoItems;
        //= new ModelCollection<TodoItem>()
        //{
        //    new TodoItem()
        //    {
        //        Content = "测试内容",
        //        Finished = false,
        //    }
        //};


        public ModelCollection<TodoItemViewModel> TodoItemsViewModels { get; set; }



        public override void Setup()
        {
            base.Setup();
            
            var jsonConetnt = PlayerPrefs.GetString("TODO_LIST_ITEMS");

            Debug.Log("jsonConetnt： " + jsonConetnt);


            TodoItemsViewModels = new ModelCollection<TodoItemViewModel>();
            List<TodoItem> todoItems = String.IsNullOrEmpty(jsonConetnt) 
                ? new List<TodoItem>() 
                : JsonConvert.DeserializeObject<List<TodoItem>>(jsonConetnt);

            todoItems.ForEach(todoItem =>
            {
                var todoItemViewModel = this.CreateViewModel<TodoItemViewModel>();
                todoItemViewModel.Content = todoItem.Content;
                todoItemViewModel.Finished = todoItem.Finished;
                TodoItemsViewModels.Add(todoItemViewModel);
            });
        }

        private void OnApplicationQuit()
        {
            var todoItemList = TodoItemsViewModels.Select(itemViewModel => new TodoItem()
            {
                Content = itemViewModel.Content,
                Finished = itemViewModel.Finished
            }).ToList();

            var output = JsonConvert.SerializeObject(todoItemList);
            PlayerPrefs.SetString("TODO_LIST_ITEMS", output);

            Debug.Log("output： " + output);
        }

        //public override void OnBtnAddClickedHandler(OnBtnAddClickedCommand data)
        //{
        //    base.OnBtnAddClickedHandler(data);

        //    Debug.Log("OnBtnAddClickedHandler Service");
        //}

        //    public override void TodoItemHandler(TodoItemViewModel data)
        //    {
        //        base.TodoItemHandler(data);

        //        Debug.Log("TodoItemhandler: " + data.Content);
        //    }
    }
}
