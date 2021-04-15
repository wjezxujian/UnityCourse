using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[UpdateInGroup(typeof(InitializationSystemGroup))]
public class PrintSystem1 : ComponentSystem
{
    protected override void OnUpdate()
    {
        Debug.Log("PrintSystem1");
        Entities.ForEach((ref PrintComponentData1 printComponentData1) =>
        {
            Debug.Log(printComponentData1.printData);
        });
    }
}

[UpdateInGroup(typeof(SimulationSystemGroup))]
public class PrintSystem2 : ComponentSystem
{
    protected override void OnUpdate()
    {
        Debug.Log("PrintSystem2");
        Entities.ForEach((ref PrintComponentData1 printComponentData1) =>
        {
            Debug.Log(printComponentData1.printData);
        });
    }
}

[UpdateInGroup(typeof(PresentationSystemGroup))]
public class PrintSystem3 : ComponentSystem
{
    protected override void OnUpdate()
    {
        Debug.Log("PrintSystem3");
        Entities.ForEach((ref PrintComponentData1 printComponentData1) =>
        {
            Debug.Log(printComponentData1.printData);
        });
    }
}
