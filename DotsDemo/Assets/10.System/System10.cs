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

        //Ref : 读写
        //in : 只读
        //withAll 查找包含的所有组件
        //withAny 查找包含的任一组件
        //withNo  查找没有包含所有组件
        //上面三个可以同时存在，注意防止冲突
        //WithChangeFilter 监听修改
        //WithSharedComponentFilter 选出来具有特定共享组件的值
        //WithSotreEntityQueryInField 结果筛选存储到EntityQuery
        //WithEntityQueryOptions  查询设置
        // Run 主线程运行 Schedule 开一个线程运行 ScheduleParallel  

        //Native Container
        //NativeArray
        //NativeHaskMap
        //NativeMultiHashMap
        //NativeQueue

        //Allocator Temp 1帧内销毁 JobTemp 4帧内销毁 Persistent 持续存在

        //WithDisposeOnCompletion CompleteDependency 线程阻塞或者线程完成后Dispose
        //WiteReadOnly 变量只读

        //WithStructuralChanges WithoutBurst Run 调价下在Foreach中修改组件

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
