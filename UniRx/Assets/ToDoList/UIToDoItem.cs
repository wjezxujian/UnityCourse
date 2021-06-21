using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using BindingsRx.Bindings;
using System;

public class UIToDoItem : MonoBehaviour
{
    Text content;

    Button btnCompleted;

    ToDoItem Model;

    public Button selfBtn;

    private void Awake()
    {
        content = transform.Find("Content").GetComponent<Text>();
        btnCompleted = transform.Find("BtnComplete").GetComponent<Button>();
        selfBtn = GetComponent<Button>();

        //btnCompleted.OnClickAsObservable().Subscribe(_ => {
        //    Model.Completed.Value = true;
        //    Destroy(gameObject);
        //});

        selfBtn.OnClickAsObservable().Subscribe(_ =>
        {
            Debug.Log("btnClicked");
        });

        

    }

    public void SetModel(ToDoItem model)
    {
        Model = model;

        content.BindTextTo(model.Content);

        Model.Completed.BindValueToButtonOnClick(btnCompleted, () =>
        {
            Destroy(gameObject);
            return true;
        });

        //UpdateView(Model.Content.Value);

        //Model.Content.Subscribe(UpdateView).AddTo(this);
    }

    //public void UpdateView(string context)
    //{
    //    content.text = context;
    //}
}
