//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Example {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.IOC;
    using uFrame.Kernel;
    using uFrame.MVVM;
    using uFrame.MVVM.Bindings;
    using uFrame.Serialization;
    using UnityEngine;
    using UniRx;
    using Example;
    
    
    public partial class TodoListViewModelBase : uFrame.MVVM.ViewModel {
        
        private P<String> _TodoContentProperty;
        
        private P<PageType> _PageTypeProperty;
        
        private P<TodoEditorViewModel> _TodoEditorProperty;
        
        private P<EventMaskViewModel> _EventMaskProperty;
        
        private ModelCollection<TodoItemViewModel> _TodoItems;
        
        private Signal<OnBtnAddClickedCommand> _OnBtnAddClicked;
        
        private Signal<BtnShowFinishedListCllickedCommand> _BtnShowFinishedListCllicked;
        
        private Signal<BtnShowTodoListClickedCommand> _BtnShowTodoListClicked;
        
        public TodoListViewModelBase(uFrame.Kernel.IEventAggregator aggregator) : 
                base(aggregator) {
        }
        
        public virtual P<String> TodoContentProperty {
            get {
                return _TodoContentProperty;
            }
            set {
                _TodoContentProperty = value;
            }
        }
        
        public virtual P<PageType> PageTypeProperty {
            get {
                return _PageTypeProperty;
            }
            set {
                _PageTypeProperty = value;
            }
        }
        
        public virtual P<TodoEditorViewModel> TodoEditorProperty {
            get {
                return _TodoEditorProperty;
            }
            set {
                _TodoEditorProperty = value;
            }
        }
        
        public virtual P<EventMaskViewModel> EventMaskProperty {
            get {
                return _EventMaskProperty;
            }
            set {
                _EventMaskProperty = value;
            }
        }
        
        public virtual String TodoContent {
            get {
                return TodoContentProperty.Value;
            }
            set {
                TodoContentProperty.Value = value;
            }
        }
        
        public virtual PageType PageType {
            get {
                return PageTypeProperty.Value;
            }
            set {
                PageTypeProperty.Value = value;
            }
        }
        
        public virtual TodoEditorViewModel TodoEditor {
            get {
                return TodoEditorProperty.Value;
            }
            set {
                TodoEditorProperty.Value = value;
            }
        }
        
        public virtual EventMaskViewModel EventMask {
            get {
                return EventMaskProperty.Value;
            }
            set {
                EventMaskProperty.Value = value;
            }
        }
        
        public virtual ModelCollection<TodoItemViewModel> TodoItems {
            get {
                return _TodoItems;
            }
            set {
                _TodoItems = value;
            }
        }
        
        public virtual Signal<OnBtnAddClickedCommand> OnBtnAddClicked {
            get {
                return _OnBtnAddClicked;
            }
            set {
                _OnBtnAddClicked = value;
            }
        }
        
        public virtual Signal<BtnShowFinishedListCllickedCommand> BtnShowFinishedListCllicked {
            get {
                return _BtnShowFinishedListCllicked;
            }
            set {
                _BtnShowFinishedListCllicked = value;
            }
        }
        
        public virtual Signal<BtnShowTodoListClickedCommand> BtnShowTodoListClicked {
            get {
                return _BtnShowTodoListClicked;
            }
            set {
                _BtnShowTodoListClicked = value;
            }
        }
        
        public override void Bind() {
            base.Bind();
            this.OnBtnAddClicked = new Signal<OnBtnAddClickedCommand>(this);
            this.BtnShowFinishedListCllicked = new Signal<BtnShowFinishedListCllickedCommand>(this);
            this.BtnShowTodoListClicked = new Signal<BtnShowTodoListClickedCommand>(this);
            _TodoContentProperty = new P<String>(this, "TodoContent");
            _PageTypeProperty = new P<PageType>(this, "PageType");
            _TodoEditorProperty = new P<TodoEditorViewModel>(this, "TodoEditor");
            _EventMaskProperty = new P<EventMaskViewModel>(this, "EventMask");
            _TodoItems = new ModelCollection<TodoItemViewModel>(this, "TodoItems");
        }
        
        public virtual void ExecuteOnBtnAddClicked() {
            this.OnBtnAddClicked.OnNext(new OnBtnAddClickedCommand());
        }
        
        public virtual void ExecuteBtnShowFinishedListCllicked() {
            this.BtnShowFinishedListCllicked.OnNext(new BtnShowFinishedListCllickedCommand());
        }
        
        public virtual void ExecuteBtnShowTodoListClicked() {
            this.BtnShowTodoListClicked.OnNext(new BtnShowTodoListClickedCommand());
        }
        
        public override void Read(ISerializerStream stream) {
            base.Read(stream);
            this.TodoContent = stream.DeserializeString("TodoContent");;
            this.PageType = (PageType)stream.DeserializeInt("PageType");;
            		if (stream.DeepSerialize) this.TodoEditor = stream.DeserializeObject<TodoEditorViewModel>("TodoEditor");;
            		if (stream.DeepSerialize) this.EventMask = stream.DeserializeObject<EventMaskViewModel>("EventMask");;
            if (stream.DeepSerialize) {
                this.TodoItems.Clear();
                this.TodoItems.AddRange(stream.DeserializeObjectArray<TodoItemViewModel>("TodoItems"));
            }
        }
        
        public override void Write(ISerializerStream stream) {
            base.Write(stream);
            stream.SerializeString("TodoContent", this.TodoContent);
            stream.SerializeInt("PageType", (int)this.PageType);;
            if (stream.DeepSerialize) stream.SerializeObject("TodoEditor", this.TodoEditor);;
            if (stream.DeepSerialize) stream.SerializeObject("EventMask", this.EventMask);;
            if (stream.DeepSerialize) stream.SerializeArray("TodoItems", this.TodoItems);
        }
        
        protected override void FillCommands(System.Collections.Generic.List<uFrame.MVVM.ViewModelCommandInfo> list) {
            base.FillCommands(list);
            list.Add(new ViewModelCommandInfo("OnBtnAddClicked", OnBtnAddClicked) { ParameterType = typeof(void) });
            list.Add(new ViewModelCommandInfo("BtnShowFinishedListCllicked", BtnShowFinishedListCllicked) { ParameterType = typeof(void) });
            list.Add(new ViewModelCommandInfo("BtnShowTodoListClicked", BtnShowTodoListClicked) { ParameterType = typeof(void) });
        }
        
        protected override void FillProperties(System.Collections.Generic.List<uFrame.MVVM.ViewModelPropertyInfo> list) {
            base.FillProperties(list);
            // PropertiesChildItem
            list.Add(new ViewModelPropertyInfo(_TodoContentProperty, false, false, false, false));
            // PropertiesChildItem
            list.Add(new ViewModelPropertyInfo(_PageTypeProperty, false, false, true, false));
            // PropertiesChildItem
            list.Add(new ViewModelPropertyInfo(_TodoEditorProperty, true, false, false, false));
            // PropertiesChildItem
            list.Add(new ViewModelPropertyInfo(_EventMaskProperty, true, false, false, false));
            list.Add(new ViewModelPropertyInfo(_TodoItems, true, true, false, false));
        }
    }
    
    public partial class TodoListViewModel {
        
        public TodoListViewModel(uFrame.Kernel.IEventAggregator aggregator) : 
                base(aggregator) {
        }
    }
    
    public partial class TodoItemViewModelBase : uFrame.MVVM.ViewModel {
        
        private P<String> _ContentProperty;
        
        private P<Boolean> _FinishedProperty;
        
        private Signal<BtnFinishClickedCommand> _BtnFinishClicked;
        
        private Signal<BtnRestoreClickedCommand> _BtnRestoreClicked;
        
        private Signal<BtnDeleteClickedCommand> _BtnDeleteClicked;
        
        private Signal<TodoItemClickedCommand> _TodoItemClicked;
        
        public TodoItemViewModelBase(uFrame.Kernel.IEventAggregator aggregator) : 
                base(aggregator) {
        }
        
        public virtual P<String> ContentProperty {
            get {
                return _ContentProperty;
            }
            set {
                _ContentProperty = value;
            }
        }
        
        public virtual P<Boolean> FinishedProperty {
            get {
                return _FinishedProperty;
            }
            set {
                _FinishedProperty = value;
            }
        }
        
        public virtual String Content {
            get {
                return ContentProperty.Value;
            }
            set {
                ContentProperty.Value = value;
            }
        }
        
        public virtual Boolean Finished {
            get {
                return FinishedProperty.Value;
            }
            set {
                FinishedProperty.Value = value;
            }
        }
        
        public virtual Signal<BtnFinishClickedCommand> BtnFinishClicked {
            get {
                return _BtnFinishClicked;
            }
            set {
                _BtnFinishClicked = value;
            }
        }
        
        public virtual Signal<BtnRestoreClickedCommand> BtnRestoreClicked {
            get {
                return _BtnRestoreClicked;
            }
            set {
                _BtnRestoreClicked = value;
            }
        }
        
        public virtual Signal<BtnDeleteClickedCommand> BtnDeleteClicked {
            get {
                return _BtnDeleteClicked;
            }
            set {
                _BtnDeleteClicked = value;
            }
        }
        
        public virtual Signal<TodoItemClickedCommand> TodoItemClicked {
            get {
                return _TodoItemClicked;
            }
            set {
                _TodoItemClicked = value;
            }
        }
        
        public override void Bind() {
            base.Bind();
            this.BtnFinishClicked = new Signal<BtnFinishClickedCommand>(this);
            this.BtnRestoreClicked = new Signal<BtnRestoreClickedCommand>(this);
            this.BtnDeleteClicked = new Signal<BtnDeleteClickedCommand>(this);
            this.TodoItemClicked = new Signal<TodoItemClickedCommand>(this);
            _ContentProperty = new P<String>(this, "Content");
            _FinishedProperty = new P<Boolean>(this, "Finished");
        }
        
        public virtual void ExecuteBtnFinishClicked() {
            this.BtnFinishClicked.OnNext(new BtnFinishClickedCommand());
        }
        
        public virtual void ExecuteBtnRestoreClicked() {
            this.BtnRestoreClicked.OnNext(new BtnRestoreClickedCommand());
        }
        
        public virtual void ExecuteBtnDeleteClicked() {
            this.BtnDeleteClicked.OnNext(new BtnDeleteClickedCommand());
        }
        
        public virtual void ExecuteTodoItemClicked() {
            this.TodoItemClicked.OnNext(new TodoItemClickedCommand());
        }
        
        public override void Read(ISerializerStream stream) {
            base.Read(stream);
            this.Finished = stream.DeserializeBool("Finished");;
        }
        
        public override void Write(ISerializerStream stream) {
            base.Write(stream);
            stream.SerializeBool("Finished", this.Finished);
        }
        
        protected override void FillCommands(System.Collections.Generic.List<uFrame.MVVM.ViewModelCommandInfo> list) {
            base.FillCommands(list);
            list.Add(new ViewModelCommandInfo("BtnFinishClicked", BtnFinishClicked) { ParameterType = typeof(void) });
            list.Add(new ViewModelCommandInfo("BtnRestoreClicked", BtnRestoreClicked) { ParameterType = typeof(void) });
            list.Add(new ViewModelCommandInfo("BtnDeleteClicked", BtnDeleteClicked) { ParameterType = typeof(void) });
            list.Add(new ViewModelCommandInfo("TodoItemClicked", TodoItemClicked) { ParameterType = typeof(void) });
        }
        
        protected override void FillProperties(System.Collections.Generic.List<uFrame.MVVM.ViewModelPropertyInfo> list) {
            base.FillProperties(list);
            // PropertiesChildItem
            list.Add(new ViewModelPropertyInfo(_ContentProperty, false, false, false, false));
            // PropertiesChildItem
            list.Add(new ViewModelPropertyInfo(_FinishedProperty, false, false, false, false));
        }
    }
    
    public partial class TodoItemViewModel {
        
        public TodoItemViewModel(uFrame.Kernel.IEventAggregator aggregator) : 
                base(aggregator) {
        }
    }
    
    public partial class TodoEditorViewModelBase : uFrame.MVVM.ViewModel {
        
        private P<String> _TodoContentProperty;
        
        private P<TodoEditorState> _StateProperty;
        
        private P<TodoItemViewModel> _TodoItemProperty;
        
        private P<String> _OriginContentProperty;
        
        private Signal<ModifyCommand> _Modify;
        
        private Signal<CancleCommand> _Cancle;
        
        private Signal<AddCommand> _Add;
        
        public TodoEditorViewModelBase(uFrame.Kernel.IEventAggregator aggregator) : 
                base(aggregator) {
        }
        
        public virtual P<String> TodoContentProperty {
            get {
                return _TodoContentProperty;
            }
            set {
                _TodoContentProperty = value;
            }
        }
        
        public virtual P<TodoEditorState> StateProperty {
            get {
                return _StateProperty;
            }
            set {
                _StateProperty = value;
            }
        }
        
        public virtual P<TodoItemViewModel> TodoItemProperty {
            get {
                return _TodoItemProperty;
            }
            set {
                _TodoItemProperty = value;
            }
        }
        
        public virtual P<String> OriginContentProperty {
            get {
                return _OriginContentProperty;
            }
            set {
                _OriginContentProperty = value;
            }
        }
        
        public virtual String TodoContent {
            get {
                return TodoContentProperty.Value;
            }
            set {
                TodoContentProperty.Value = value;
            }
        }
        
        public virtual TodoEditorState State {
            get {
                return StateProperty.Value;
            }
            set {
                StateProperty.Value = value;
            }
        }
        
        public virtual TodoItemViewModel TodoItem {
            get {
                return TodoItemProperty.Value;
            }
            set {
                TodoItemProperty.Value = value;
            }
        }
        
        public virtual String OriginContent {
            get {
                return OriginContentProperty.Value;
            }
            set {
                OriginContentProperty.Value = value;
            }
        }
        
        public virtual Signal<ModifyCommand> Modify {
            get {
                return _Modify;
            }
            set {
                _Modify = value;
            }
        }
        
        public virtual Signal<CancleCommand> Cancle {
            get {
                return _Cancle;
            }
            set {
                _Cancle = value;
            }
        }
        
        public virtual Signal<AddCommand> Add {
            get {
                return _Add;
            }
            set {
                _Add = value;
            }
        }
        
        public override void Bind() {
            base.Bind();
            this.Modify = new Signal<ModifyCommand>(this);
            this.Cancle = new Signal<CancleCommand>(this);
            this.Add = new Signal<AddCommand>(this);
            _TodoContentProperty = new P<String>(this, "TodoContent");
            _StateProperty = new P<TodoEditorState>(this, "State");
            _TodoItemProperty = new P<TodoItemViewModel>(this, "TodoItem");
            _OriginContentProperty = new P<String>(this, "OriginContent");
        }
        
        public virtual void ExecuteModify() {
            this.Modify.OnNext(new ModifyCommand());
        }
        
        public virtual void ExecuteCancle() {
            this.Cancle.OnNext(new CancleCommand());
        }
        
        public virtual void ExecuteAdd() {
            this.Add.OnNext(new AddCommand());
        }
        
        public override void Read(ISerializerStream stream) {
            base.Read(stream);
            this.State = (TodoEditorState)stream.DeserializeInt("State");;
            		if (stream.DeepSerialize) this.TodoItem = stream.DeserializeObject<TodoItemViewModel>("TodoItem");;
            this.OriginContent = stream.DeserializeString("OriginContent");;
        }
        
        public override void Write(ISerializerStream stream) {
            base.Write(stream);
            stream.SerializeInt("State", (int)this.State);;
            if (stream.DeepSerialize) stream.SerializeObject("TodoItem", this.TodoItem);;
            stream.SerializeString("OriginContent", this.OriginContent);
        }
        
        protected override void FillCommands(System.Collections.Generic.List<uFrame.MVVM.ViewModelCommandInfo> list) {
            base.FillCommands(list);
            list.Add(new ViewModelCommandInfo("Modify", Modify) { ParameterType = typeof(void) });
            list.Add(new ViewModelCommandInfo("Cancle", Cancle) { ParameterType = typeof(void) });
            list.Add(new ViewModelCommandInfo("Add", Add) { ParameterType = typeof(void) });
        }
        
        protected override void FillProperties(System.Collections.Generic.List<uFrame.MVVM.ViewModelPropertyInfo> list) {
            base.FillProperties(list);
            // PropertiesChildItem
            list.Add(new ViewModelPropertyInfo(_TodoContentProperty, false, false, false, false));
            // PropertiesChildItem
            list.Add(new ViewModelPropertyInfo(_StateProperty, false, false, true, false));
            // PropertiesChildItem
            list.Add(new ViewModelPropertyInfo(_TodoItemProperty, true, false, false, false));
            // PropertiesChildItem
            list.Add(new ViewModelPropertyInfo(_OriginContentProperty, false, false, false, false));
        }
    }
    
    public partial class TodoEditorViewModel {
        
        public TodoEditorViewModel(uFrame.Kernel.IEventAggregator aggregator) : 
                base(aggregator) {
        }
    }
    
    public partial class EventMaskViewModelBase : uFrame.MVVM.ViewModel {
        
        private P<PageMode> _PageModeProperty;
        
        public EventMaskViewModelBase(uFrame.Kernel.IEventAggregator aggregator) : 
                base(aggregator) {
        }
        
        public virtual P<PageMode> PageModeProperty {
            get {
                return _PageModeProperty;
            }
            set {
                _PageModeProperty = value;
            }
        }
        
        public virtual PageMode PageMode {
            get {
                return PageModeProperty.Value;
            }
            set {
                PageModeProperty.Value = value;
            }
        }
        
        public override void Bind() {
            base.Bind();
            _PageModeProperty = new P<PageMode>(this, "PageMode");
        }
        
        public override void Read(ISerializerStream stream) {
            base.Read(stream);
            this.PageMode = (PageMode)stream.DeserializeInt("PageMode");;
        }
        
        public override void Write(ISerializerStream stream) {
            base.Write(stream);
            stream.SerializeInt("PageMode", (int)this.PageMode);;
        }
        
        protected override void FillCommands(System.Collections.Generic.List<uFrame.MVVM.ViewModelCommandInfo> list) {
            base.FillCommands(list);
        }
        
        protected override void FillProperties(System.Collections.Generic.List<uFrame.MVVM.ViewModelPropertyInfo> list) {
            base.FillProperties(list);
            // PropertiesChildItem
            list.Add(new ViewModelPropertyInfo(_PageModeProperty, false, false, true, false));
        }
    }
    
    public partial class EventMaskViewModel {
        
        public EventMaskViewModel(uFrame.Kernel.IEventAggregator aggregator) : 
                base(aggregator) {
        }
    }
}