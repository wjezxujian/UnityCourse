using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uFrame.Kernel;
using uFrame.MVVM;
using uFrame.MVVM.Services;
using uFrame.MVVM.Bindings;
using uFrame.Serialization;
using System;

public class UIBindPropertyExample : ViewBase
{
    private Button button;
    private Text text;
    private P<string> textContent = new P<string>(string.Empty);

    public override Type ViewModelType => throw new NotImplementedException();

    // Start is called before the first frame update
    void Start()
    {
        button = transform.Find("Button").GetComponent<Button>();
        text = transform.Find("Text").GetComponent<Text>();

        this.BindTextToProperty(text, textContent);

        button.onClick.AddListener(() =>
        {
            textContent.Value = "Hello";
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
