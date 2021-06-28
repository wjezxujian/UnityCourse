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


    public class TodoListService : TodoListServiceBase
    {
        private ModelCollection<TodoItem> mTodoItems = new ModelCollection<TodoItem>()
        {
            new TodoItem()
            {
                Content = "测试内容",
                Finished = false,
            }
        };


        public ModelCollection<TodoItem> TodoItems
        {
            get { return mTodoItems; }
            set { mTodoItems = value; }
        }
    }
}
