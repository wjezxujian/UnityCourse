using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

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

        btnCompleted.OnClickAsObservable().Subscribe(_ => {
            Model.Completed.Value = true;
        });

        selfBtn.OnClickAsObservable().Subscribe(_ =>
        {
            Debug.Log("btnClicked");
        });
    }

    public void SetModel(ToDoItem model)
    {
        Model = model;

        UpdateView(Model.Content.Value);

        Model.Content.Subscribe(UpdateView).AddTo(this);
    }

    public void UpdateView(string context)
    {
        content.text = context;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
