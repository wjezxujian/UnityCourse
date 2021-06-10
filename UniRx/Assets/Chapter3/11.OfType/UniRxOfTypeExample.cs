using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Enemy
{
    public string Name { get; set; }
}

public class Boss : Enemy
{

}

public class Monster : Enemy
{

}


public class UniRxOfTypeExample : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        var subject = new Subject<Enemy>();

        subject.OfType<Enemy, Boss>().Subscribe(enemy =>
        {
            Debug.Log(enemy.Name);
        });

        subject.OnNext(new Boss() { Name = "Ģ����"});
        subject.OnNext(new Boss() { Name = "�Ͳ���" });
        subject.OnNext(new Monster() { Name = "Ģ��" });
        subject.OnNext(new Boss() { Name = "������" });

        subject.OnCompleted();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
