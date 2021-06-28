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
    
    
    public class TodoListExampleLoader : TodoListExampleLoaderBase {
        
        protected override IEnumerator LoadScene(TodoListExample scene, Action<float, string> progressDelegate) {
            yield break;
        }
        
        protected override IEnumerator UnloadScene(TodoListExample scene, Action<float, string> progressDelegate) {
            yield break;
        }
    }
}
