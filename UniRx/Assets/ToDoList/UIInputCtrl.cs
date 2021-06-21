using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using BindingsRx.Bindings;

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
            mode.Value = Mode.Add;
        });

        btnCancel.OnClickAsObservable().Subscribe(_ =>
        {
            mode.Value = Mode.Add;
        });

        var addStateReactiveProperty = mode.Select(mode => mode == Mode.Add).ToReactiveProperty();
        var editStateReactiveProperty = mode.Select(mode => mode == Mode.Edit).ToReactiveProperty();

        addStateReactiveProperty.Where(isAddState => isAddState).Subscribe(_ => {
            mCachedContent = string.Empty;
            inputContent.text = string.Empty;
            mCachedTodoItem = null;
        }).AddTo(this);

        editStateReactiveProperty.Where(isEditState => isEditState).Subscribe(_ =>
        {
            inputContent.text = mCachedTodoItem.Content.Value;
        }).AddTo(this);

        btnAdd.gameObject.BindActiveTo(addStateReactiveProperty);
        btnUpdate.gameObject.BindActiveTo(editStateReactiveProperty);
        btnCancel.gameObject.BindActiveTo(editStateReactiveProperty);
    }

    string mCachedContent = string.Empty;
    public ToDoItem mCachedTodoItem;

    public void EditModel(ToDoItem item)
    {
        mCachedTodoItem = item;
        mCachedContent = item.Content.Value;
        mode.Value = Mode.Edit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
