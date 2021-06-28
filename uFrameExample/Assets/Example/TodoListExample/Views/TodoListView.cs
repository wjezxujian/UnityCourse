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
    using UnityEngine.UI;
    using System.Text;

    public class TodoListView : TodoListViewBase
    {

        public override void TodoItemsOnAdd(TodoItem arg1)
        {
            Debug.Log("add: " + arg1);

            UpdateView();
        }

        public override void TodoItemsOnRemove(TodoItem arg1)
        {
            Debug.Log("remove: " + arg1);

            UpdateView();
        }

        public void UpdateView()
        {
            var todoTextBuilder = new StringBuilder();


            var count = this.TodoItemsContentView.transform.childCount;
            for (var i = count; i > 0; --i)
            {
                Destroy(this.TodoItemsContentView.transform.GetChild(i - 1).gameObject);
            }

            foreach (var todoItem in TodoList.TodoItems)
            {
                if (!todoItem.Finished)
                {
                    var obj = Instantiate(this.TodoItemView.gameObject, this.TodoItemsContentView.transform);
                    obj.SetActive(true);
                    obj.GetComponent<TodoItemView>().Init(todoItem);
                }

                //todoTextBuilder.Append(todoItem.Content).Append("\t").AppendLine(todoItem.Finished ? "已完成" : "未完成");
            }

            //transform.Find("Text").GetComponent<Text>().text = todoTextBuilder.ToString();
        }


        protected override void InitializeViewModel(uFrame.MVVM.ViewModel model)
        {
            base.InitializeViewModel(model);
            // NOTE: this method is only invoked if the 'Initialize ViewModel' is checked in the inspector.
            // var vm = model as TodoListElementViewModel;
            // This method is invoked when applying the data from the inspector to the viewmodel.  Add any view-specific customizations here.


        }

        public override void Bind()
        {
            base.Bind();
            // Use this.TodoListElement to access the viewmodel.
            // Use this method to subscribe to the view-model.
            // Any designer bindings are created in the base implementation.

            _OnBtnAddClickedButton.interactable = false;

            this.BindInputFieldToHandler(_TodoContentInput, inputContent =>
            {
                _OnBtnAddClickedButton.interactable = !string.IsNullOrEmpty(inputContent);
            });

            //_TodoContentInput.OnValueChangedAsObservable().Subscribe(inputContent =>
            //{
            //    if (string.IsNullOrEmpty(inputContent))
            //        _OnBtnAddClickedButton.interactable = false;
            //    else
            //        _OnBtnAddClickedButton.interactable = true;
            //});

            //TodoItemView.Instantiate(this).name ="@@@@";
        }
    }
}
