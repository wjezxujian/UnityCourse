using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;


public class Job10 : MonoBehaviour
{
    [BurstCompile]
    public struct Job1 : IJob
    {
        [ReadOnly]
        public int i, j;
        public float result;


        public void Execute()
        {
            for(int i = 0; i < 5000000; ++i)
            {
                result = math.exp10(math.sqrt(i * j));
            }
            
        }
    }



        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //1.创建一个线程
        //JobTest();

        //2.创建多个线程
        MultiJobTest();

        //3.无线程
        NoThread();
    }

    void JobTest()
    {
        //NativeArray<int> nativeArray = new NativeArray<int>(1, Allocator.TempJob);
        //Job1 tempJob = new Job1() { i = 6, j = 7, result = nativeArray };
        Job1 tempJob = new Job1() { i = 6, j = 7};
        JobHandle jobHandle = tempJob.Schedule();
        jobHandle.Complete();

        Debug.Log(tempJob.result);
        //nativeArray.Dispose();
    }

    void NoThread()
    {
        int a = 6, b = 7;
        float tempStart = Time.realtimeSinceStartup;

        for (int i = 0; i < 50000000; ++i)
        {
            var result = math.exp10(math.sqrt(a * b));
        }

        float tempSumTime = Time.realtimeSinceStartup - tempStart;
        Debug.Log("NoThreadSumTime: " + tempSumTime);
    }

    void MultiJobTest()
    {
        float tempStart = Time.realtimeSinceStartup;

        NativeList<JobHandle> nativeList = new NativeList<JobHandle>(Allocator.TempJob);

        for (int i = 0; i < 10; ++i)
        {
            Job1 tempJob = new Job1() { i = 6, j = 7};
            nativeList.Add(tempJob.Schedule());
        }

        JobHandle.CompleteAll(nativeList);
        nativeList.Dispose();

        float tempSumTime = Time.realtimeSinceStartup - tempStart;
        Debug.Log("ThreadSumTime: " + tempSumTime);
    }
}
