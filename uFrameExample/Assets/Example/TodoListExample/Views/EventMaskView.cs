namespace Example {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.Kernel;
    using uFrame.MVVM;
    using uFrame.MVVM.Services;
    using uFrame.MVVM.Bindings;
    using uFrame.Serialization;
    using UniRx;
    using UnityEngine;
    
    
    public class EventMaskView : EventMaskViewBase {
        
        public override void PageModeChanged(PageMode arg1) {
            this.gameObject.SetActive(arg1 == PageMode.Eidt);
        }
        
        protected override void InitializeViewModel(uFrame.MVVM.ViewModel model) {
            base.InitializeViewModel(model);
            // NOTE: this method is only invoked if the 'Initialize ViewModel' is checked in the inspector.
            // var vm = model as EventMaskViewModel;
            // This method is invoked when applying the data from the inspector to the viewmodel.  Add any view-specific customizations here.
        }
        
        public override void Bind() {
            base.Bind();
            // Use this.EventMask to access the viewmodel.
            // Use this method to subscribe to the view-model.
            // Any designer bindings are created in the base implementation.

            this.gameObject.SetActive(false);
        }
    }
}
