using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class TestWorld5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //World world = new World("AAA");

        ////Debug.Log(World.DefaultGameObjectInjectionWorld.Name);

        //foreach (var item in World.All)
        //{
        //    Debug.Log(item.Name);
        //}

        //world.Dispose();

        ////��ѯ
        //foreach (var item in World.DefaultGameObjectInjectionWorld.Systems)
        //{
        //    Debug.Log(item.ToString());
        //}

        //PrintSystem1 printSystem1 =  World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<PrintSystem1>();
        //Debug.Log(printSystem1.ToString());

        ////����
        //World newWorld = new World("AAA");
        //newWorld.AddSystem(printSystem1);

        ////ɾ��
        //InitializationSystemGroup systemGroup = World.DefaultGameObjectInjectionWorld.GetExistingSystem<InitializationSystemGroup>();
        //systemGroup.RemoveSystemFromUpdateList(printSystem1);
        //newWorld.DestroySystem(printSystem1);

        #region Entity
        //����
        //1.GameObject To Entity
        //IConvertGameObjectToEntity 
        //GameObjectCoversionUtility.ConvertGameObjectHierarchy() 
        //SubScene

        //2.��0��ʼ����Entity
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        Entity entity = entityManager.CreateEntity(typeof(PrintComponentData1), typeof(RotationEulerXYZ));
        entityManager.Instantiate(entity);

        EntityArchetype entityArchetype = entityManager.CreateArchetype(typeof(PrintComponentData1), typeof(RotationEulerXYZ));

        //for (int i = 0; i < 100; ++i)
        //{
        //    entityManager.CreateEntity(entityArchetype);
        //}

        NativeArray<Entity> nativeArray = new NativeArray<Entity>(5, Allocator.TempJob);
        entityManager.CreateEntity(entityArchetype, nativeArray);


        //����
        NativeArray<Entity> entitis = entityManager.GetAllEntities();
        foreach (var item in entitis)
        {
            Debug.Log(item.Index);
        }

        EntityQuery entityQuery = entityManager.CreateEntityQuery(typeof(PrintComponentData1));

        NativeArray<Entity> entites2 =  entityQuery.ToEntityArray(Allocator.Temp);
        foreach (var item in entites2)
        {
            Debug.Log("��ѯʵ��������" + item.Index);
        }

       

        //ɾ��
        //entityManager.DestroyEntity(entity);

        entityManager.DestroyEntity(entitis);


        nativeArray.Dispose();
        entitis.Dispose();
        entites2.Dispose();

        #endregion


    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
