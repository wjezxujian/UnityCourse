using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Authoring6 : MonoBehaviour, IConvertGameObjectToEntity
{
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddSharedComponentData(entity, new ShareComponent6() { data = 6 });
    }

   
}
