using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
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

        ////查询
        //foreach (var item in World.DefaultGameObjectInjectionWorld.Systems)
        //{
        //    Debug.Log(item.ToString());
        //}

        //PrintSystem1 printSystem1 =  World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<PrintSystem1>();
        //Debug.Log(printSystem1.ToString());

        ////创建
        //World newWorld = new World("AAA");
        //newWorld.AddSystem(printSystem1);

        ////删除
        //InitializationSystemGroup systemGroup = World.DefaultGameObjectInjectionWorld.GetExistingSystem<InitializationSystemGroup>();
        //systemGroup.RemoveSystemFromUpdateList(printSystem1);
        //newWorld.DestroySystem(printSystem1);

        #region Entity
        //创建
        //1.GameObject To Entity
        //IConvertGameObjectToEntity 
        //GameObjectCoversionUtility.ConvertGameObjectHierarchy() 
        //SubScene

        //2.从0开始创建Entity
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


        //查找
        NativeArray<Entity> entitis = entityManager.GetAllEntities();
        foreach (var item in entitis)
        {
            Debug.Log(item.Index);
        }

        EntityQuery entityQuery = entityManager.CreateEntityQuery(typeof(PrintComponentData1));

        NativeArray<Entity> entites2 =  entityQuery.ToEntityArray(Allocator.Temp);
        foreach (var item in entites2)
        {
            Debug.Log("查询实体索引：" + item.Index);
        }



        //删除
        //entityManager.DestroyEntity(entity);
        //entityManager.DestroyEntity(entitis);
        #endregion

        #region Component
        //1.组件的创建方式
        Entity entity2 = entityManager.CreateEntity(typeof(RotationEulerXYZ));
        entityManager.AddComponent(entity2, typeof(PrintComponentData1));
        //entityManager.AddComponent<PrintComponentData1>(entites2);
        //entityManager.AddComponent<PrintComponentData1>(entityQuery);
        entityManager.AddComponents(entity2, new ComponentTypes(typeof(PrintComponentData1), typeof(RotationEulerXYZ)));
        entityManager.AddComponentData(entity2, new PrintComponentData1 { printData = 5 });

        //2.组件的查询
        RotationEulerXYZ rotationEulerXYZ = entityManager.GetComponentData<RotationEulerXYZ>(entity2);
        Debug.Log(rotationEulerXYZ);


        //3.组件的修改
        //rotationEulerXYZ.Value = new float3(-1, -1, -1); //错误类型，这是struct类型
        entityManager.SetComponentData<RotationEulerXYZ>(entity2, new RotationEulerXYZ() { Value = new float3(-55, -1, -1) });

        //4.组件的删除
        entityManager.RemoveComponent(entity2, typeof(RotationEulerXYZ));


        #endregion

        nativeArray.Dispose();
        entitis.Dispose();
        entites2.Dispose();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
