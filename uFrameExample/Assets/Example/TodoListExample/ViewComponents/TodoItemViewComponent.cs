namespace Example
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.Kernel;
    using uFrame.MVVM;
    using uFrame.MVVM.Bindings;
    using uFrame.Serialization;
    using Example;
    using UnityEngine.UI;
    using UnityEngine;
    using UniRx;
    

    public class TodoItemViewComponent : TodoItemViewComponentBase
    {
        private TodoItemViewModel mTodoItem;

        public void Init(TodoItemViewModel totoItem)
        {
            mTodoItem = totoItem;

            this.GetView<TodoItemView>()
                .ViewModelObject = totoItem; 

            //transform.Find("BtnFinish").GetComponent<Button>().OnClickAsObservable().Subscribe( _ =>
            //{
            //    mTodoItem.Finished = true;
            //    Debug.Log("finished");
            //    (this.View as TodoListView).UpdateView();
            //});

            //UpdateView();

        }

        void UpdateView()
        {
            //transform.Find("Content").GetComponent<Text>().text = mTodoItem.Content;
        }


    }
}
