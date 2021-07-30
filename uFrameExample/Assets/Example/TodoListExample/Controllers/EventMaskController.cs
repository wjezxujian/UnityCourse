namespace Example {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.IOC;
    using uFrame.Kernel;
    using uFrame.MVVM;
    using uFrame.Serialization;
    using UniRx;
    
    
    public class EventMaskController : EventMaskControllerBase {
        
        public override void InitializeEventMask(EventMaskViewModel viewModel) {
            base.InitializeEventMask(viewModel);
            // This is called when a EventMaskViewModel is created
        }
    }
}
