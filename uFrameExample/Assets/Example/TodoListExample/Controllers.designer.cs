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
    using uFrame.Serialization;
    using UniRx;
    using Example;
    
    
    public class TodoListControllerBase : uFrame.MVVM.Controller {
        
        private uFrame.MVVM.IViewModelManager _TodoListViewModelManager;
        
        [uFrame.IOC.InjectAttribute("TodoList")]
        public uFrame.MVVM.IViewModelManager TodoListViewModelManager {
            get {
                return _TodoListViewModelManager;
            }
            set {
                _TodoListViewModelManager = value;
            }
        }
        
        public IEnumerable<TodoListViewModel> TodoListViewModels {
            get {
                return TodoListViewModelManager.OfType<TodoListViewModel>();
            }
        }
        
        public override void Setup() {
            base.Setup();
            // This is called when the controller is created
        }
        
        public override void Initialize(uFrame.MVVM.ViewModel viewModel) {
            base.Initialize(viewModel);
            // This is called when a viewmodel is created
            this.InitializeTodoList(((TodoListViewModel)(viewModel)));
        }
        
        public virtual TodoListViewModel CreateTodoList() {
            return ((TodoListViewModel)(this.Create(Guid.NewGuid().ToString())));
        }
        
        public override uFrame.MVVM.ViewModel CreateEmpty() {
            return new TodoListViewModel(this.EventAggregator);
        }
        
        public virtual void InitializeTodoList(TodoListViewModel viewModel) {
            // This is called when a TodoListViewModel is created
            viewModel.OnBtnAddClicked.Action = this.OnBtnAddClickedHandler;
            viewModel.BtnShowFinishedListCllicked.Action = this.BtnShowFinishedListCllickedHandler;
            viewModel.BtnShowTodoListClicked.Action = this.BtnShowTodoListClickedHandler;
            TodoListViewModelManager.Add(viewModel);
        }
        
        public override void DisposingViewModel(uFrame.MVVM.ViewModel viewModel) {
            base.DisposingViewModel(viewModel);
            TodoListViewModelManager.Remove(viewModel);
        }
        
        public virtual void OnBtnAddClicked(TodoListViewModel viewModel) {
        }
        
        public virtual void BtnShowFinishedListCllicked(TodoListViewModel viewModel) {
        }
        
        public virtual void BtnShowTodoListClicked(TodoListViewModel viewModel) {
        }
        
        public virtual void OnBtnAddClickedHandler(OnBtnAddClickedCommand command) {
            this.OnBtnAddClicked(command.Sender as TodoListViewModel);
        }
        
        public virtual void BtnShowFinishedListCllickedHandler(BtnShowFinishedListCllickedCommand command) {
            this.BtnShowFinishedListCllicked(command.Sender as TodoListViewModel);
        }
        
        public virtual void BtnShowTodoListClickedHandler(BtnShowTodoListClickedCommand command) {
            this.BtnShowTodoListClicked(command.Sender as TodoListViewModel);
        }
    }
    
    public class TodoItemControllerBase : uFrame.MVVM.Controller {
        
        private uFrame.MVVM.IViewModelManager _TodoItemViewModelManager;
        
        [uFrame.IOC.InjectAttribute("TodoItem")]
        public uFrame.MVVM.IViewModelManager TodoItemViewModelManager {
            get {
                return _TodoItemViewModelManager;
            }
            set {
                _TodoItemViewModelManager = value;
            }
        }
        
        public IEnumerable<TodoItemViewModel> TodoItemViewModels {
            get {
                return TodoItemViewModelManager.OfType<TodoItemViewModel>();
            }
        }
        
        public override void Setup() {
            base.Setup();
            // This is called when the controller is created
        }
        
        public override void Initialize(uFrame.MVVM.ViewModel viewModel) {
            base.Initialize(viewModel);
            // This is called when a viewmodel is created
            this.InitializeTodoItem(((TodoItemViewModel)(viewModel)));
        }
        
        public virtual TodoItemViewModel CreateTodoItem() {
            return ((TodoItemViewModel)(this.Create(Guid.NewGuid().ToString())));
        }
        
        public override uFrame.MVVM.ViewModel CreateEmpty() {
            return new TodoItemViewModel(this.EventAggregator);
        }
        
        public virtual void InitializeTodoItem(TodoItemViewModel viewModel) {
            // This is called when a TodoItemViewModel is created
            viewModel.BtnFinishClicked.Action = this.BtnFinishClickedHandler;
            viewModel.BtnRestoreClicked.Action = this.BtnRestoreClickedHandler;
            viewModel.BtnDeleteClicked.Action = this.BtnDeleteClickedHandler;
            viewModel.TodoItemClicked.Action = this.TodoItemClickedHandler;
            TodoItemViewModelManager.Add(viewModel);
        }
        
        public override void DisposingViewModel(uFrame.MVVM.ViewModel viewModel) {
            base.DisposingViewModel(viewModel);
            TodoItemViewModelManager.Remove(viewModel);
        }
        
        public virtual void BtnFinishClicked(TodoItemViewModel viewModel) {
        }
        
        public virtual void BtnRestoreClicked(TodoItemViewModel viewModel) {
        }
        
        public virtual void BtnDeleteClicked(TodoItemViewModel viewModel) {
        }
        
        public virtual void TodoItemClicked(TodoItemViewModel viewModel) {
        }
        
        public virtual void BtnFinishClickedHandler(BtnFinishClickedCommand command) {
            this.BtnFinishClicked(command.Sender as TodoItemViewModel);
        }
        
        public virtual void BtnRestoreClickedHandler(BtnRestoreClickedCommand command) {
            this.BtnRestoreClicked(command.Sender as TodoItemViewModel);
        }
        
        public virtual void BtnDeleteClickedHandler(BtnDeleteClickedCommand command) {
            this.BtnDeleteClicked(command.Sender as TodoItemViewModel);
        }
        
        public virtual void TodoItemClickedHandler(TodoItemClickedCommand command) {
            this.TodoItemClicked(command.Sender as TodoItemViewModel);
        }
    }
    
    public class TodoEditorControllerBase : uFrame.MVVM.Controller {
        
        private uFrame.MVVM.IViewModelManager _TodoEditorViewModelManager;
        
        [uFrame.IOC.InjectAttribute("TodoEditor")]
        public uFrame.MVVM.IViewModelManager TodoEditorViewModelManager {
            get {
                return _TodoEditorViewModelManager;
            }
            set {
                _TodoEditorViewModelManager = value;
            }
        }
        
        public IEnumerable<TodoEditorViewModel> TodoEditorViewModels {
            get {
                return TodoEditorViewModelManager.OfType<TodoEditorViewModel>();
            }
        }
        
        public override void Setup() {
            base.Setup();
            // This is called when the controller is created
        }
        
        public override void Initialize(uFrame.MVVM.ViewModel viewModel) {
            base.Initialize(viewModel);
            // This is called when a viewmodel is created
            this.InitializeTodoEditor(((TodoEditorViewModel)(viewModel)));
        }
        
        public virtual TodoEditorViewModel CreateTodoEditor() {
            return ((TodoEditorViewModel)(this.Create(Guid.NewGuid().ToString())));
        }
        
        public override uFrame.MVVM.ViewModel CreateEmpty() {
            return new TodoEditorViewModel(this.EventAggregator);
        }
        
        public virtual void InitializeTodoEditor(TodoEditorViewModel viewModel) {
            // This is called when a TodoEditorViewModel is created
            viewModel.Modify.Action = this.ModifyHandler;
            viewModel.Cancle.Action = this.CancleHandler;
            viewModel.Add.Action = this.AddHandler;
            TodoEditorViewModelManager.Add(viewModel);
        }
        
        public override void DisposingViewModel(uFrame.MVVM.ViewModel viewModel) {
            base.DisposingViewModel(viewModel);
            TodoEditorViewModelManager.Remove(viewModel);
        }
        
        public virtual void Modify(TodoEditorViewModel viewModel) {
        }
        
        public virtual void Cancle(TodoEditorViewModel viewModel) {
        }
        
        public virtual void Add(TodoEditorViewModel viewModel) {
        }
        
        public virtual void ModifyHandler(ModifyCommand command) {
            this.Modify(command.Sender as TodoEditorViewModel);
        }
        
        public virtual void CancleHandler(CancleCommand command) {
            this.Cancle(command.Sender as TodoEditorViewModel);
        }
        
        public virtual void AddHandler(AddCommand command) {
            this.Add(command.Sender as TodoEditorViewModel);
        }
    }
    
    public class EventMaskControllerBase : uFrame.MVVM.Controller {
        
        private uFrame.MVVM.IViewModelManager _EventMaskViewModelManager;
        
        [uFrame.IOC.InjectAttribute("EventMask")]
        public uFrame.MVVM.IViewModelManager EventMaskViewModelManager {
            get {
                return _EventMaskViewModelManager;
            }
            set {
                _EventMaskViewModelManager = value;
            }
        }
        
        public IEnumerable<EventMaskViewModel> EventMaskViewModels {
            get {
                return EventMaskViewModelManager.OfType<EventMaskViewModel>();
            }
        }
        
        public override void Setup() {
            base.Setup();
            // This is called when the controller is created
        }
        
        public override void Initialize(uFrame.MVVM.ViewModel viewModel) {
            base.Initialize(viewModel);
            // This is called when a viewmodel is created
            this.InitializeEventMask(((EventMaskViewModel)(viewModel)));
        }
        
        public virtual EventMaskViewModel CreateEventMask() {
            return ((EventMaskViewModel)(this.Create(Guid.NewGuid().ToString())));
        }
        
        public override uFrame.MVVM.ViewModel CreateEmpty() {
            return new EventMaskViewModel(this.EventAggregator);
        }
        
        public virtual void InitializeEventMask(EventMaskViewModel viewModel) {
            // This is called when a EventMaskViewModel is created
            EventMaskViewModelManager.Add(viewModel);
        }
        
        public override void DisposingViewModel(uFrame.MVVM.ViewModel viewModel) {
            base.DisposingViewModel(viewModel);
            EventMaskViewModelManager.Remove(viewModel);
        }
    }
}
