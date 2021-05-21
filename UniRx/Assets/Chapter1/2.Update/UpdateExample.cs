using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UpdateExample : MonoBehaviour
{
    bool mButtonClicked = false;

    enum ButtonState
    {
        None,
        Clicked,
        DoubleClicked,
    }

    string[] mstrButtonState = {"None", "Clicked", "DoubleClicked"};


    ButtonState mButtonState = ButtonState.None;

    // Start is called before the first frame update
    void Start()
    {
        //¼àÌýÊó±ê×ó¼ü
        Observable.EveryUpdate()
                    .Subscribe(_ => {
                        if (Input.GetMouseButtonDown(0))
                        {
                            Debug.Log("Left mouse button clicked");
                            mButtonClicked = true;
                        }
                    }).AddTo(this);

        //½¢Í§Êó±êÓÒ¼ü
        Observable.EveryUpdate()
                    .Subscribe(_ =>
                    {
                        if (Input.GetMouseButtonDown(1))
                        {
                            Debug.Log("Right mouse button clicked");
                            mButtonClicked = false;
                        }
                    }).AddTo(this);

        //¼àÌý×´Ì¬
        if (mButtonClicked && mButtonState == ButtonState.None)
        {
            mButtonState = ButtonState.Clicked;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("Left mouse button clicked");
        //    mButtonClicked = true;
        //}

        //if (Input.GetMouseButtonDown(1))
        //{
        //    Debug.Log("Right mouse button clicked");
        //    mButtonClicked = false;
        //}

        //if(mButtonClicked && mButtonState == ButtonState.None)
        //{
        //    mButtonState = ButtonState.Clicked;
        //}
        //else
        //{
        //    mButtonState = ButtonState.None;
        //}

        //Debug.Log("ButtonState is :" + mstrButtonState[(int)mButtonState]);
    }
}
