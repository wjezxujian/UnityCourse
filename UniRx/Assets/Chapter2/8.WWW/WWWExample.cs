using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.Networking;
using System;
using System.Threading;
using UnityEngine.UI;
using UniRx.Operators;

public class WWWExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //ObservableWWW.Get("http://www.baidu.com/")
        //    .Subscribe(responseText =>
        //    {
        //        Debug.Log("123");
        //    }, e => { Debug.LogError(e); });


        ObservableWWWW.Get("http://www.baidu.com/").Subscribe(responseText =>
        {
            Debug.Log(responseText);
        }, e => { Debug.LogError(e); });
    }

}


namespace UniRx
{
    class FromCoroutineObservable<T> : OperatorObservableBase<T>
    {
        readonly Func<IObserver<T>, CancellationToken, IEnumerator> coroutine;

        public FromCoroutineObservable(Func<IObserver<T>, CancellationToken, IEnumerator> coroutine)
            : base(false)
        {
            this.coroutine = coroutine;
        }

        protected override IDisposable SubscribeCore(IObserver<T> observer, IDisposable cancel)
        {
            var fromCoroutineObserver = new FromCoroutine(observer, cancel);

#if (NETFX_CORE || NET_4_6 || NET_STANDARD_2_0 || UNITY_WSA_10_0)
            var moreCancel = new CancellationDisposable();
            var token = moreCancel.Token;
#else
            var moreCancel = new BooleanDisposable();
            var token = new CancellationToken(moreCancel);
#endif

            MainThreadDispatcher.SendStartCoroutine(coroutine(fromCoroutineObserver, token));

            return moreCancel;
        }

        class FromCoroutine : OperatorObserverBase<T, T>
        {
            public FromCoroutine(IObserver<T> observer, IDisposable cancel) : base(observer, cancel)
            {
            }

            public override void OnNext(T value)
            {
                try
                {
                    base.observer.OnNext(value);
                }
                catch
                {
                    Dispose();
                    throw;
                }
            }

            public override void OnError(Exception error)
            {
                try { observer.OnError(error); }
                finally { Dispose(); }
            }

            public override void OnCompleted()
            {
                try { observer.OnCompleted(); }
                finally { Dispose(); }
            }
        }
    }
    public static partial class ObservableWWWW
    {
        public static IObservable<string> Get(string url)
        {
            IEnumerator GetRequest(string url, IObserver<string> observer, CancellationToken cancel)
            {
                using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
                {
                    yield return webRequest.SendWebRequest();

                    switch (webRequest.result)
                    {
                        case UnityWebRequest.Result.ConnectionError:
                        case UnityWebRequest.Result.DataProcessingError:
                            observer.OnError(new Exception("Error: " + webRequest.error));
                            break;
                        case UnityWebRequest.Result.ProtocolError:
                            observer.OnError(new Exception("HTTP Error: " + webRequest.error));
                            break;
                        case UnityWebRequest.Result.Success:
                            observer.OnNext(webRequest.downloadHandler.text);
                            observer.OnCompleted();
                            break;
                    }

                }
            }

            return new FromCoroutineObservable<string>((observer, cancellation) => { return GetRequest(url, observer, cancellation); });
            //return Observable.FromCoroutine<string>((observer, cancellation) => GetRequest(url, observer, cancellation));
        }
    }
}

