using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine;

[DisableAutoCreation]
public class ComponentSystem10 : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity pEntity, ref Translation translation) =>
        {
            translation.Value = new float3(2, 2, 2);
        });
    }
}
