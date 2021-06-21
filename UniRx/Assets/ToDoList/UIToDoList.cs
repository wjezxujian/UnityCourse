using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System.Linq;
using BindingsRx.Bindings;

public class UIToDoList : MonoBehaviour
{
    UIToDoItem todoItemPrefab;
    UIInputCtrl inputCtrl;
    GameObject eventMaskObj;

    List<UIToDoItem> uiTodoItems = new List<UIToDoItem>();


    [SerializeField]
    ToDoList Model = default;

    [SerializeField]
    Transform Content;

    private void Awake()
    {
        todoItemPrefab = transform.Find("ToDoItemPrefab").GetComponent<UIToDoItem>();
        inputCtrl = transform.Find("InputCtrl").GetComponent<UIInputCtrl>();
        eventMaskObj = transform.Find("EventMask").gameObject;
    }

    // Start is called before the first frame update
    private void Start()
    {
        //eventMaskObj.BindActiveTo(() => inputCtrl.mode.Value != Mode.Add, resultValue => { }, BindingsRx.BindingTypes.OneWay);
        //eventMaskObj.BindActiveTo(inputCtrl.mode.Select(x => x != Mode.Add).ToReactiveProperty());
        eventMaskObj.BindActiveTo(inputCtrl.mode, x => x != Mode.Add);
        

        //inputCtrl.mode.Subscribe(mode =>
        //{
        //    if (mode == Mode.Add)
        //    {
        //        eventMaskObj.SetActive(false);
        //    }
        //    else
        //    {
        //        eventMaskObj.SetActive(true);
        //    }
        //});

        Model = ToDoList.Load();
        inputCtrl.Model = Model;
        Debug.Log(JsonUtility.ToJson(Model));

        Model.TodoItemsCollection.Where(toDoItem => !toDoItem.Completed.Value).ToList().ForEach(todoItem =>
        {
            AddTodoItem(todoItem);
        });

        Model.TodoItemsCollection.ObserveAdd().DelayFrame(1).Subscribe(addEvent =>
        {
            AddTodoItem(addEvent.Value);
        });

        Model.TodoItemsCollection.ObserveRemove().Subscribe(removeEvent =>
        {
            //TODO 改成 在这里销毁GameObject
            Model.Save();
        });
    }

    private void AddTodoItem(ToDoItem todoItem)
    {
        var item = Instantiate(todoItemPrefab);
        item.transform.SetParent(Content);
        item.transform.localScale = Vector3.one;
        item.gameObject.SetActive(true);

        item.SetModel(todoItem);

        item.selfBtn.OnClickAsObservable()
                    .Subscribe(_ =>
                    {
                        //todoItem.Content.Subscribe(_ =>
                        //{
                        //    OnDataChange();
                        //});
                        inputCtrl.EditModel(todoItem);
                    });

        //todoItem.Completed.Where(completed => completed).Subscribe(_ => {
        //    Destroy(item.gameObject);
        //}).AddTo(item);

        //todoItem.Completed.Subscribe(completed =>
        //{
        //    if (completed) OnDataChange();
        //}).AddTo(item);

        //todoItem.Completed.Where(completed => completed).Subscribe(_ => OnDataChange()).AddTo(item);

        uiTodoItems.Add(item);
    }
}
