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
        //entityManager.DestroyEntity(entitis);
        #endregion

        #region Component
        //1.����Ĵ�����ʽ
        Entity entity2 = entityManager.CreateEntity(typeof(RotationEulerXYZ));
        entityManager.AddComponent(entity2, typeof(PrintComponentData1));
        //entityManager.AddComponent<PrintComponentData1>(entites2);
        //entityManager.AddComponent<PrintComponentData1>(entityQuery);
        entityManager.AddComponents(entity2, new ComponentTypes(typeof(PrintComponentData1), typeof(RotationEulerXYZ)));
        entityManager.AddComponentData(entity2, new PrintComponentData1 { printData = 5 });

        //2.����Ĳ�ѯ
        RotationEulerXYZ rotationEulerXYZ = entityManager.GetComponentData<RotationEulerXYZ>(entity2);
        Debug.Log(rotationEulerXYZ);


        //3.������޸�
        //rotationEulerXYZ.Value = new float3(-1, -1, -1); //�������ͣ�����struct����
        entityManager.SetComponentData<RotationEulerXYZ>(entity2, new RotationEulerXYZ() { Value = new float3(-55, -1, -1) });

        //4.�����ɾ��
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
