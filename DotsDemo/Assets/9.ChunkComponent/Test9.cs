using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Test9 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        EntityArchetype entityArchetype = entityManager.CreateArchetype(ComponentType.ChunkComponent(typeof(ChunkComponent9)));
        Entity entity = entityManager.CreateEntity(entityArchetype);
        entityManager.CreateEntity(entityArchetype);

        entityManager.SetChunkComponentData(entityManager.GetChunk(entity), new ChunkComponent9() { data = 6 });

        //entityManager.GetChunkComponentData<ChunkComponent9>(entity);
        //entityManager.GetChunkComponentData<ChunkComponent9>(entityManager.GetChunk(entity));
        //entityManager.RemoveChunkComponentData<ChunkComponent9>(entityQuery);
        //entityManager.RemoveChunkComponent<ChunkComponent9>(entity);
        //entityManager.HasChunkComponent<ChunkComponent9>(entity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
