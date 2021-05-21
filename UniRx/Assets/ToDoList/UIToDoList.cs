using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System.Linq;

public class UIToDoList : MonoBehaviour
{
    UIToDoItem todoItemPrefab;
    UIInputCtrl inputCtrl;
    GameObject eventMaskObj;


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
        inputCtrl.mode.Subscribe(mode =>
        {
            if (mode == Mode.Add)
            {
                eventMaskObj.SetActive(false);
            }
            else
            {
                eventMaskObj.SetActive(true);
            }
        });

        Model = ToDoList.Load();
        inputCtrl.Model = Model;
        Debug.Log(JsonUtility.ToJson(Model));

        var todoItems = Model.toDoItems;

        Model.toDoItems.ObserveEveryValueChanged((items) => items.Count).Subscribe(_ => { 
            OnDataChange(); 
        });
        OnDataChange();
    }

    private void OnDataChange()
    {
        for(int i = 0; i < Content.childCount; ++i)
        {
           Destroy(Content.GetChild(i).gameObject);
        }


        Model.toDoItems.Where(toDoItem => !toDoItem.Completed.Value).ToList().ForEach(todoItem =>
        {
            todoItem.Completed.Subscribe(completed =>
            {
                if (completed) OnDataChange();
            });
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
        });

        Model.Save();
    }
}
