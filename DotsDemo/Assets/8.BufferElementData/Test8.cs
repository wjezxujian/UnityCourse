using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Collections;
using UnityEngine;

public class Test8 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        //≤È—Ø
        EntityQuery entityQuery = entityManager.CreateEntityQuery(typeof(BufferComponent8));
        NativeArray<Entity> entities = entityQuery.ToEntityArray(Allocator.TempJob);


        foreach (var entity in entities)
        {
            DynamicBuffer<BufferComponent8> dynamicbuffer = entityManager.GetBuffer<BufferComponent8>(entity);

            //…æ≥˝
            dynamicbuffer.RemoveAt(0);

            //≤Â»Î
            dynamicbuffer.Insert(0, new BufferComponent8() { data = 5, data2 = 6 });

            var i = 0;
            foreach (var buffer in dynamicbuffer)
            {
                Debug.Log("EntityIndex: " + entity.Index + ", BufferIndex: " + i + ", data = " + buffer.data + ", data2 = " + buffer.data2);
                ++i;
            }            
        }



        entities.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
