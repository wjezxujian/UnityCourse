using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class ESCPrefabCreator4 : MonoBehaviour
{
    public GameObject cube;

    public float interval, sum;

    private void Start()
    {
        GameObjectConversionSettings settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
        Entity entityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(cube, settings);

        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        Translation translation = new Translation();
        for (int i = 0; i < sum; ++i)
        {
            for (int j = 0; j < sum; ++j)
            {
                Entity cubeEntity = entityManager.Instantiate(entityPrefab);
                //Translation translation = entityManager.GetComponentData<Translation>(entityPrefab);
                //translation.Value.x += 1;
                entityManager.SetComponentData(cubeEntity, translation);
                translation.Value.x += interval;
            }

            translation.Value.x = 0;
            translation.Value.y += interval;
        }
    }
}
