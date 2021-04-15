using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[DisableAutoCreation]
public class RotationEulerXYZSystem3 : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref RotationEulerXYZ rotationEulerXYZ) =>
        {
            rotationEulerXYZ.Value = new float3(0, 45, 0);
        });
    }
}
