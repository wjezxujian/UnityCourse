using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UniRx;

public class AsyncOperationExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Resources.LoadAsync<GameObject>("TestCanvas").AsAsyncOperationObservable().Subscribe(request =>
        //{
        //    Instantiate(request.asset);
        //});

        ScheduledNotifier<float> progressObservable = new ScheduledNotifier<float>();

        SceneManager.LoadSceneAsync(0).AsAsyncOperationObservable(progressObservable).Subscribe(_ =>
        {
            Debug.Log("Load done.");
        });

        progressObservable.Subscribe(progress => Debug.LogFormat("º”‘ÿ¡À£∫{0}%", progress * 100));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
