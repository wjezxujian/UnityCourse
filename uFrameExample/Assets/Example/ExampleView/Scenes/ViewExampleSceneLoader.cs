namespace Example {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.IOC;
    using uFrame.Kernel;
    using uFrame.MVVM;
    using uFrame.Serialization;
    using UnityEngine;
    
    
    public class ViewExampleSceneLoader : ViewExampleSceneLoaderBase {
        
        protected override IEnumerator LoadScene(ViewExampleScene scene, Action<float, string> progressDelegate) {
            yield break;
        }
        
        protected override IEnumerator UnloadScene(ViewExampleScene scene, Action<float, string> progressDelegate) {
            yield break;
        }
    }
}
