using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class ObserverMVCExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var loginView = new View();
        var levelModel = new Model();

        var dispose = levelModel.Delay(TimeSpan.FromSeconds(5f)).Subscribe(loginView);
        levelModel.UpdateLevel(3);
        //dispose.Dispose();
    }
}

public class View : IObserver<int>
{
    public void OnCompleted()
    {
        
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(int value)
    {
        Debug.LogFormat("Show:{0}", value);
    }

     
}


public class Model : IObservable<int>
{
    List<IObserver<int>> mObservers = new List<IObserver<int>>();

    public IDisposable Subscribe(IObserver<int> observer)
    {
        mObservers.Add(observer);
        return Disposable.Create(() => mObservers.Remove(observer));
    }

    public void UpdateLevel(int level)
    {
        mObservers.ForEach(observer => observer.OnNext(level));
    }

}
