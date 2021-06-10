using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class LINQGroupByExample : MonoBehaviour
{
    class Student
    {
        public string name;

        public int age;
    }

    // Start is called before the first frame update
    void Start()
    {
        var students = new List<Student> {
            new Student(){name = "����", age = 18},
            new Student(){name = "����", age = 19},
            new Student(){name = "����", age = 18},
            new Student(){name = "�Դ�", age = 19},
            new Student(){name = "Ǯ��", age = 20},
            new Student(){name = "����", age = 20},
            new Student(){name = "֣��", age = 18},
        };

        students.GroupBy(student => student.age).ToList().ForEach(studentGroup =>
        {
            studentGroup.ToList().ForEach(student =>
            {
                Debug.LogFormat("GroupName:{0}, Name:{1}, Age:{1}", studentGroup.Key, student.name, student.age);
            });
        });

        Debug.Log("-----------------�ָ���-------------------");

        var query = from student in students group student  by student.age into studentGroup select studentGroup;
        query.ToList().ForEach(studentGroup =>
        {
            studentGroup.ToList().ForEach(student =>
            {
                Debug.LogFormat("GroupName:{0}, Name:{1}, Age:{1}", studentGroup.Key, student.name, student.age);
            });
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
