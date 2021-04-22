using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine;
using Unity.Collections;
using System;
using System.Threading;

[DisableAutoCreation]
public class System10 : SystemBase
{
    EntityQuery entityQuery;

    protected override void OnCreate()
    {
        Debug.Log("OnCreate");
    }

    protected override void OnStartRunning()
    {
        Debug.Log("OnStartRunning");
    }

    protected override void OnUpdate()
    {
        #region Foreach

        //Ref : ��д
        //in : ֻ��
        //withAll ���Ұ������������
        //withAny ���Ұ�������һ���
        //withNo  ����û�а����������
        //������������ͬʱ���ڣ�ע���ֹ��ͻ
        //WithChangeFilter �����޸�
        //WithSharedComponentFilter ѡ���������ض����������ֵ
        //WithSotreEntityQueryInField ���ɸѡ�洢��EntityQuery
        //WithEntityQueryOptions  ��ѯ����
        // Run ���߳����� Schedule ��һ���߳����� ScheduleParallel  

        //Native Container
        //NativeArray
        //NativeHaskMap
        //NativeMultiHashMap
        //NativeQueue

        //Allocator Temp 1֡������ JobTemp 4֡������ Persistent ��������

        //WithDisposeOnCompletion CompleteDependency �߳����������߳���ɺ�Dispose
        //WiteReadOnly ����ֻ��

        //WithStructuralChanges WithoutBurst Run ��������Foreach���޸����

        NativeArray<int> tempInt = new NativeArray<int>(5, Allocator.TempJob);

        EntityCommandBuffer tempEntityCommandBuffer = new EntityCommandBuffer(Allocator.TempJob);

        Entities.ForEach((Entity pEntity, ref Translation translation) =>
        {
            //Debug.Log(translation.Value);
            tempInt[0] += 5;
            //EntityManager.AddComponentData(pEntity, new PrintComponentData1() { printData = 3 });
            tempEntityCommandBuffer.AddComponent(pEntity, new PrintComponentData1() { printData = 3 });

            translation.Value = new float3(2, 2, 2);
        })
        //.WithAll<PrintComponentData1>()
        //.WithAny<PrintComponentData1, RotationEulerXYZ>()
        //.WithNone<PrintComponentData1, LocalToWorld>()
        //.WithChangeFilter<PrintComponentData1>()
        //.WithSharedComponentFilter(new ShareComponent6() { data = 6 })
        .WithStoreEntityQueryInField(ref entityQuery)
        .WithEntityQueryOptions(EntityQueryOptions.Default)
        .WithName("aaa")
        //.WithDisposeOnCompletion(tempInt)
        //.WithBurst()
        //.ScheduleParallel();
        //.WithStructuralChanges()
        .WithoutBurst()
        .Run();

        tempEntityCommandBuffer.Playback(EntityManager);

        CompleteDependency();
        tempInt.Dispose();
        tempEntityCommandBuffer.Dispose();

        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        //entityQuery = entityManager.CreateEntityQuery(typeof());
        NativeArray<Entity> entities = entityQuery.ToEntityArray(Allocator.TempJob);
        foreach (var entity in entities)
        {
            Debug.Log(EntityManager.GetName(entity));
        }

        entities.Dispose();

        #endregion

        NativeArray<float> floatArray = new NativeArray<float>(1000, Allocator.TempJob);

        Job.WithCode(() =>
        {
            for (int i = 0; i < floatArray.Length; ++i)
            {
                floatArray[i] = 1000;
            }

        }).Schedule();

        CompleteDependency();

        for (int i = 0; i < floatArray.Length; ++i)
        {
            Debug.Log(floatArray[i]);
        }

        floatArray.Dispose();

        Debug.Log("OnUpdate");
    }

    private void SleepTimeout()
    {
        throw new NotImplementedException();
    }

    protected override void OnStopRunning()
    {
        Debug.Log("OnStopRunning");
    }

    protected override void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }
}
