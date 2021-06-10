using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;

public class UniRxWhereExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        (from updateEvent in Observable.EveryUpdate() where Input.GetMouseButtonDown(0) select updateEvent).Subscribe(_ => Debug.Log("Mouse down.")).AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
