using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
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

        ////²éÑ¯
        //foreach (var item in World.DefaultGameObjectInjectionWorld.Systems)
        //{
        //    Debug.Log(item.ToString());
        //}

        PrintSystem1 printSystem1 =  World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<PrintSystem1>();
        Debug.Log(printSystem1.ToString());

        //´´½¨
        World newWorld = new World("AAA");
        newWorld.AddSystem(printSystem1);

        //É¾³ý
        InitializationSystemGroup systemGroup = World.DefaultGameObjectInjectionWorld.GetExistingSystem<InitializationSystemGroup>();
        systemGroup.RemoveSystemFromUpdateList(printSystem1);
        newWorld.DestroySystem(printSystem1);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
