using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

[Serializable]
public class ToDoItem
{
    public int Id;
    public StringReactiveProperty Content;
    public BoolReactiveProperty Completed;
}

[Serializable]
public class ToDoList
{
    public int TopId = 2;

    public ToDoList()
    {
        TodoItemsCollection = new ReactiveCollection<ToDoItem>();

        TodoItemsCollection.ObserveAdd().Subscribe(item => toDoItems.Add(item.Value));
        TodoItemsCollection.ObserveRemove().Subscribe(item => toDoItems.Remove(item.Value));
        //TodoItemsCollection.ObserveReplace().Subscribe(item => toDoItems.Replace(item.Value));
    }

    public void Add(string content)
    {
        TodoItemsCollection.Add(new ToDoItem()
        {
            Id = TopId++,
            Content = new StringReactiveProperty(content),
            Completed = new BoolReactiveProperty(false)
        });
    }


    [SerializeField]
    private List<ToDoItem> toDoItems = new List<ToDoItem>()
    {
        new ToDoItem()
        {
            Id = 0,
            Content = new StringReactiveProperty("去买胡萝卜"),
            Completed = new BoolReactiveProperty(false)
        },
        new ToDoItem()
        {
            Id = 1,
            Content = new StringReactiveProperty("去Siki下载视频"),
            Completed = new BoolReactiveProperty(false)
        }
    };

    public ReactiveCollection<ToDoItem> TodoItemsCollection;

    public void Save()
    {
        PlayerPrefs.SetString("model", JsonUtility.ToJson(this));
    }

    internal static ToDoList Load()
    {
        var jsonContent = PlayerPrefs.GetString("model", string.Empty);

        ToDoList returnList = null;

        if(string.IsNullOrEmpty(jsonContent))
        {
            returnList = new ToDoList();
        }
        else
        {
            returnList = JsonUtility.FromJson<ToDoList>(jsonContent);
        }

        returnList.toDoItems.ForEach(item =>
        {
            item.Completed.Where(completed => completed).Subscribe(_ => returnList.Save());
            item.Content.Subscribe(_ => returnList.Save());
        });

        returnList.TodoItemsCollection = new ReactiveCollection<ToDoItem>(returnList.toDoItems);
        returnList.TodoItemsCollection.ObserveAdd().Subscribe(item => {
            returnList.toDoItems.Add(item.Value);
            returnList.Save();
            item.Value.Completed.Where(completed => completed).Subscribe(_ => returnList.Save());
            item.Value.Content.Subscribe(_ => returnList.Save());
        });
        returnList.TodoItemsCollection.ObserveRemove().Subscribe(item => {
            returnList.toDoItems.Remove(item.Value);
            returnList.Save();
        });


        return returnList;
        
    }
}
