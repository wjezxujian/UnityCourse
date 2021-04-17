using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine;

public class System10 : SystemBase
{ 
    protected override void OnCreate()
    {
        Debug.Log("OnCreate");
    }

    protected override void OnStartRunning()
    {
        Debug.Log("OnStartRunning");
    }

    protected override void OnUpdate()
    {
        Debug.Log("OnUpdate");
    }

    protected override void OnStopRunning()
    {
        Debug.Log("OnStopRunning");
    }

    protected override void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }
}
