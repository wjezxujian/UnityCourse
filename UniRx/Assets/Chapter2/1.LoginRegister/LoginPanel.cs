using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class LoginPanel : MonoBehaviour
{
    Button loginBtn;
    Button registerBtn;

    InputField username;
    InputField password;

    // Start is called before the first frame update
    void Start()
    {
        loginBtn = transform.Find("Login").GetComponent<Button>();
        registerBtn = transform.Find("Register").GetComponent<Button>();

        username = transform.Find("Username").GetComponent<InputField>();
        password = transform.Find("Password").GetComponent<InputField>();

        loginBtn.OnClickAsObservable().Subscribe(_ =>
        {
            Debug.Log("Login button clicked.");
        });

        username.OnEndEditAsObservable().Subscribe(result => {
            password.Select();
            Debug.Log("username: " + result);
        });
        password.OnEndEditAsObservable().Subscribe(result => { 
            Debug.Log("password: " + result);
            loginBtn.onClick.Invoke();
        });

        registerBtn.OnClickAsObservable().Subscribe(_ =>
        {
            Debug.Log("Register button clicked.");
            LoginRegisterExample.PanelMgr.registerPanel.gameObject.SetActive(true);
            LoginRegisterExample.PanelMgr.loginPanel.gameObject.SetActive(false);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
