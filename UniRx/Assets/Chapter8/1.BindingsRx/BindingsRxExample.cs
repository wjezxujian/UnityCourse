using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using BindingsRx.Bindings;
using BindingsRx.Filters;
using System;

public class BindingsRxExample : MonoBehaviour
{
    InputField mInputField;
    Text mText;


    // Start is called before the first frame update
    void Start()
    {
        var stringReactiveProperty = new StringReactiveProperty();

        mInputField = transform.Find("InputField").GetComponent<InputField>();
        mText = transform.Find("Text").GetComponent<Text>();

        //mInputField.BindTextTo(stringReactiveProperty);
        //mText.BindTextTo(stringReactiveProperty);

        //var inputFieldReactiveProperty = new StringReactiveProperty();
        //var textReactiveProperty = new StringReactiveProperty();

        //mInputField.BindTextTo(inputFieldReactiveProperty);
        //mText.BindTextTo(textReactiveProperty);

        //GenericBindings.Bind(inputFieldReactiveProperty, textReactiveProperty);

        //GenericBindings.Bind(() => mInputField.text, x => mInputField.text = x, () => mText.text, inputValue => mText.text = inputValue, BindingsRx.BindingTypes.Default)
        //    .AddTo(mInputField);

        //mInputField.BindTextTo(() => mText.text, value => mText.text = value, filters: new SampleFilter<string>(TimeSpan.FromSeconds(5.0f)));

        //mInputField.OnValueChangedAsObservable().SubscribeToText(mText);

        mInputField.Bind(mText);

        mInputField.OnValueChangedAsObservable().ToReactiveProperty().Subscribe(value => Debug.Log(value));
        //mInputField.BindTextTo(mText);

    }

    
}

public static class BindingsRx2
{
    public static void Bind(this InputField inputField, Text text, BindingsRx.BindingTypes bindingTypes = BindingsRx.BindingTypes.OneWay)
    {
        if(bindingTypes == BindingsRx.BindingTypes.OneWay){
            //inputField.OnValueChangedAsObservable().SubscribeToText(text).AddTo(inputField);
            Bind(inputField.OnValueChangedAsObservable(), text).AddTo(inputField);
        }
    }

    public static IDisposable Bind(IObservable<string> eventObservable, Text text)
    {
        return eventObservable.SubscribeToText(text);
        
    }
}
