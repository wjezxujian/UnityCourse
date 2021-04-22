using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine;
using Unity.Jobs;

[DisableAutoCreation]
public class JobComponentSystem10 : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        return Entities.ForEach((Entity pEntity, ref Translation translation) =>
        {
            translation.Value = new float3(12, 12, 12);

        }).Schedule(inputDeps);
    }
}
