using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Authoring8 : MonoBehaviour, IConvertGameObjectToEntity
{
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        DynamicBuffer<BufferComponent8> buffer = dstManager.AddBuffer<BufferComponent8>(entity);

        buffer.Add(new BufferComponent8() { data = 1, data2 = 3 });
        buffer.Add(new BufferComponent8() { data = 2, data2 = 2 });
        buffer.Add(new BufferComponent8() { data = 3, data2 = 1 });


    }
}
