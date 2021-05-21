using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public enum Mode
{
    Add,
    Edit,
}

public class UIInputCtrl : MonoBehaviour
{
    InputField inputContent;
    Button btnAdd;
    Button btnUpdate;
    Button btnCancel;

    public ToDoList Model;

    public ReactiveProperty<Mode> mode = new ReactiveProperty<Mode>(Mode.Add);

    private void Awake()
    {
        inputContent = transform.Find("InputContent").GetComponent<InputField>();
        btnAdd = transform.Find("BtnAdd").GetComponent<Button>();
        btnUpdate = transform.Find("BtnUpdate").GetComponent<Button>();
        btnCancel = transform.Find("BtnCancel").GetComponent<Button>();

        AddModel();
    }

    // Start is called before the first frame update
    void Start()
    {
        inputContent.OnValueChangedAsObservable()
            .Select(content => !string.IsNullOrEmpty(content))
            .SubscribeToInteractable(btnAdd);

        inputContent.OnValueChangedAsObservable()
            .Select(content => content != mCachedContent && !string.IsNullOrEmpty(content))
            .SubscribeToInteractable(btnUpdate);



        btnAdd.OnClickAsObservable().Subscribe(_ =>
        {
            Model.Add(inputContent.text);
            inputContent.text = string.Empty;
        });

        btnUpdate.OnClickAsObservable().Subscribe(_ =>
        {
            mCachedTodoItem.Content.Value = inputContent.text;
            AddModel();
        });

        btnCancel.OnClickAsObservable().Subscribe(_ =>
        {
            AddModel();
        });
    }

    public void AddModel()
    {
        mCachedContent = string.Empty;
        inputContent.text = string.Empty;
        mCachedTodoItem = null;
        btnAdd.gameObject.SetActive(true);
        btnUpdate.gameObject.SetActive(false);
        btnCancel.gameObject.SetActive(false);
        mode.Value = global::Mode.Add;
    }

    string mCachedContent = string.Empty;
    public ToDoItem mCachedTodoItem;

    public void EditModel(ToDoItem item)
    {
        mCachedTodoItem = item;
        mCachedContent = item.Content.Value;
        inputContent.text = item.Content.Value;
        btnAdd.gameObject.SetActive(false);
        btnUpdate.gameObject.SetActive(true);
        btnCancel.gameObject.SetActive(true);
        mode.Value = global::Mode.Edit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
