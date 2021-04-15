using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Collections;
using UnityEngine;

public class Test7 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        EntityQuery entityQuery = entityManager.CreateEntityQuery(typeof(StateComponent7));
        entityManager.DestroyEntity(entityQuery);

        NativeArray<Entity> entities = entityQuery.ToEntityArray(Allocator.TempJob);
        
        foreach (var entity in entities)
        {
            entityManager.SetComponentData(entity, new StateComponent7() { data = 10 });
        }

        //³¹µ×É¾³ý×´Ì¬×é¼þ
        //entityManager.RemoveComponent<StateComponent7>(entities[0]);

        entities.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
