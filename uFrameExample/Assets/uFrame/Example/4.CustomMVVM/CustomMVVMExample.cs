using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uFrame.MVVM;
using uFrame.MVVM.Bindings;
using System;
using UniRx;

public class CustomMVVMExample : ViewBase
{
    public InputField inputField;
    public Button button;

    public override Type ViewModelType => throw new NotImplementedException();

    // Start is called before the first frame update
    void Start()
    {
        var viewModel = new CustomViewModel();

        viewModel.Controller = new CustomController(viewModel);

        this.BindButtonToCommand(button, viewModel.OnBtnClickedSignal);
        this.BindInputFieldToProperty(inputField, viewModel.content);

        viewModel.content.ChangedObservable.Subscribe(content =>
        {
            Debug.Log(content);
        }).DisposeWith(viewModel);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class CustomViewModel : ViewModel
{
    public CustomController controller;

    public P<string> content = new P<string>();

    public Signal<OnBtnClickedCommand> OnBtnClickedSignal;

    public CustomViewModel()
    {
        OnBtnClickedSignal = new Signal<OnBtnClickedCommand>(this);
    }
}

public class OnBtnClickedCommand : ViewModelCommand
{

}

public class CustomController : Controller
{
    public CustomController(CustomViewModel viewModel)
    {
        viewModel.OnBtnClickedSignal.Action = cmd =>
        {
            Debug.Log("Button is clicked!");

            viewModel.content.Value = "点击事件被使用了";
        };
    }
}
