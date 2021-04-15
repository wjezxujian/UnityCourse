using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class PrintAuthoring1 : MonoBehaviour, IConvertGameObjectToEntity
{
    public float printData;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new PrintComponentData1() { printData = printData });
    }

   
}
