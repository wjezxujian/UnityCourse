namespace Example
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UniRx;
    using uFrame.IOC;
    using uFrame.Kernel;
    using uFrame.MVVM;
    using uFrame.Serialization;
    using UnityEngine;



    public class UIPlayerInfoController : UIPlayerInfoControllerBase
    {

        public override void InitializeUIPlayerInfo(UIPlayerInfoViewModel viewModel)
        {
            base.InitializeUIPlayerInfo(viewModel);
            // This is called when a UIPlayerInfoViewModel is created

            Debug.Log("UIPlayerInfoController");

            viewModel.Title = "Hello uFrame!";

            viewModel.Username = "wjezxujian";

            viewModel.TitleProperty.Subscribe(title => Debug.Log(title));

            viewModel.UsernameProperty.ChangedObservable.Subscribe(username => Debug.Log("username@@@:" + username));
        }

        public override void OnButtonClicked(UIPlayerInfoViewModel viewModel)
        {
            base.OnButtonClicked(viewModel);

            Debug.Log("OnButtonClicked");

            Debug.Log("Username is: " + viewModel.Username);
        }

    }
}