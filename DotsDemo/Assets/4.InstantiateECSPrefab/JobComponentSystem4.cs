using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class JobComponentSystem4 : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        JobHandle jobHandle = Entities.ForEach((ref RotationEulerXYZ rotationEulerXYZ) =>
        {
            rotationEulerXYZ.Value = new float3(0, 45, 0);
        }).WithBurst().Schedule(inputDeps);

        return jobHandle;
    }
}
