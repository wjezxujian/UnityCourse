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


public class ViewBindControllerCmdExample : ViewBase
{
    private Button button;

    private Signal<BtnClickedCommand> onBtnClicked = new Signal<BtnClickedCommand>(new TempViewModel());

    public override Type ViewModelType => throw new NotImplementedException();

    // Start is called before the first frame update
    void Start()
    {
        button = transform.Find("Button").GetComponent<Button>();

        this.BindButtonToCommand(button, onBtnClicked);

        onBtnClicked.Action = command => { Debug.Log("注册成功"); };

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    class TempViewModel : ViewModel
    {

    }

    class BtnClickedCommand : ViewModelCommand
    {

    }
}
