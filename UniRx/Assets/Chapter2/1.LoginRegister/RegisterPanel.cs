using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class RegisterPanel : MonoBehaviour
{
    InputField username;
    InputField password1;
    InputField password2;

    Button registerBtn;
    Button backBtn;

    // Start is called before the first frame update
    void Start()
    {
        username = transform.Find("Username").GetComponent<InputField>();
        password1 = transform.Find("Password1").GetComponent<InputField>();
        password2 = transform.Find("Password2").GetComponent<InputField>();

        registerBtn = transform.Find("Register").GetComponent<Button>();
        backBtn = transform.Find("BackLogin").GetComponent<Button>();

        username.OnEndEditAsObservable().Subscribe(result =>
        {
            password1.Select();
        });

        password1.OnEndEditAsObservable().Subscribe(result =>
        {
            password2.Select();
        });

        password2.OnEndEditAsObservable().Subscribe(result =>
        {
            registerBtn.onClick.Invoke();
        });

        registerBtn.OnClickAsObservable().Subscribe(result =>
        {
            Debug.Log("Register button clicked.");
        });

        backBtn.OnClickAsObservable().Subscribe(result =>
        {
            Debug.Log("BackLogin button clicked.");
            LoginRegisterExample.PanelMgr.loginPanel.gameObject.SetActive(true);
            LoginRegisterExample.PanelMgr.registerPanel.gameObject.SetActive(false);
        });





    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
