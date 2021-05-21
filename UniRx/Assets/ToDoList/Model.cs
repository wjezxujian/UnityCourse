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

    public void Add(string content)
    {
        toDoItems.Add(new ToDoItem()
        {
            Id = TopId++,
            Content = new StringReactiveProperty(content),
            Completed = new BoolReactiveProperty(false)
        });
    }


    [SerializeField]
    public List<ToDoItem> toDoItems = new List<ToDoItem>()
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

    public void Save()
    {
        PlayerPrefs.SetString("model", JsonUtility.ToJson(this));
    }

    internal static ToDoList Load()
    {
        var jsonContent = PlayerPrefs.GetString("model", string.Empty);
        if(string.IsNullOrEmpty(jsonContent))
        {
            return new ToDoList();
        }
        else
        {
            return JsonUtility.FromJson<ToDoList>(jsonContent);
        }
        
    }
}
