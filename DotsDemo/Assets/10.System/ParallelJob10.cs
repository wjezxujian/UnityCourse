using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Burst;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Collections;
using UnityEngine;

public class ParallelJob10 : MonoBehaviour
{
    public bool useThread;
    public float interval, sum;
    public GameObject cubePrefab;
    private List<GameObject> goList = new List<GameObject>();

    [BurstCompile]
    public struct ParallelJob : IJobParallelFor
    {
        public NativeArray<float3> eulerAngles;
        public float deltaTime;
         
        public void Execute(int index)
        {
            eulerAngles[index] += new float3(0, 30 * deltaTime, 0);

            for (int i = 0; i < 1000; ++i)
            {
                float result = math.exp10(math.sqrt(5 * 6));
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector3 tempVector3 = new Vector3(-interval, 0, 0);

        for (int i = 0; i < sum; ++i)
        {
            for (int j = 0; j < sum; ++j)
            {
                //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                GameObject cube = GameObject.Instantiate(cubePrefab);
                goList.Add(cube);
                cube.transform.position = tempVector3;

                tempVector3.x += interval;
            }

            tempVector3.x = 0;
            tempVector3.y += interval;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (useThread)
        {
            ParallelJob tempParallelJob = new ParallelJob() { deltaTime = Time.deltaTime};
            NativeArray<float3> eulerAngles = new NativeArray<float3>(goList.Count, Allocator.TempJob);
            for (int i = 0; i < goList.Count; ++i)
            {
                eulerAngles[i] = goList[i].transform.eulerAngles;
            }
            tempParallelJob.eulerAngles = eulerAngles;
            JobHandle jobHandle = tempParallelJob.Schedule(goList.Count, 10);
            jobHandle.Complete();
            for (int i = 0; i < goList.Count; ++i)
            {
                goList[i].transform.eulerAngles = eulerAngles[i];
            }

            eulerAngles.Dispose();
        }
        else
        {
            foreach (var item in goList)
            {
                item.transform.eulerAngles += new Vector3(0, 30 * Time.deltaTime, 0);

                for (int i = 0; i < 1000; ++i)
                {
                    float result = math.exp10(math.sqrt(5 * 6));
                }
            }
        }    


        
    }

}
