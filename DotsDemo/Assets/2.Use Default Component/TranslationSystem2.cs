using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[DisableAutoCreation]
public class TranslationSystem2 : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation translationComponentData1) =>
        {
            translationComponentData1.Value = new float3(1, 1, 1);
        });
    }
}
