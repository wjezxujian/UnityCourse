using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Collections;
using UnityEngine;

public class Test6 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        //Ìí¼Ó
        //entityManager.AddSharedComponentData();

        //ÐÞ¸Ä
        NativeArray<Entity> entites = entityManager.GetAllEntities();
        //foreach (var item in entites)
        //{
        //    Debug.Log(item.Index);
        //}
        entityManager.SetSharedComponentData(entites[0], new ShareComponent6 { data = 10 });

        //²éÑ¯
        ShareComponent6 shareComponent6 = entityManager.GetSharedComponentData<ShareComponent6>(entites[0]);
        Debug.Log("data: " + shareComponent6.data);
        ShareComponent6 shareComponent6_1 = entityManager.GetSharedComponentData<ShareComponent6>(entites[1]);
        Debug.Log(shareComponent6.Equals(shareComponent6_1));

        //É¾³ý
        entityManager.RemoveComponent<ShareComponent6>(entites[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
