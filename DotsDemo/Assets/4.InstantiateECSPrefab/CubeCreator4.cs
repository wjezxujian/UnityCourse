using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCreator4 : MonoBehaviour
{
    public float interval, sum;
    public GameObject cubePrefab;

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
        
    }
}
