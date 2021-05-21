using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class LoginRegisterExample : MonoBehaviour
{
    public LoginPanel loginPanel;
    public RegisterPanel registerPanel;

    public static LoginRegisterExample PanelMgr;

    private void Awake()
    {
        PanelMgr = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        loginPanel = transform.Find("LoginPanel").GetComponent<LoginPanel>();
        registerPanel = transform.Find("RegisterPanel").GetComponent<RegisterPanel>();

        loginPanel.gameObject.SetActive(true);
        registerPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
