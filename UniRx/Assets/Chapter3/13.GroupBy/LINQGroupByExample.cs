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
            new Student(){name = "张三", age = 18},
            new Student(){name = "李四", age = 19},
            new Student(){name = "王五", age = 18},
            new Student(){name = "赵大", age = 19},
            new Student(){name = "钱二", age = 20},
            new Student(){name = "吴六", age = 20},
            new Student(){name = "郑七", age = 18},
        };

        students.GroupBy(student => student.age).ToList().ForEach(studentGroup =>
        {
            studentGroup.ToList().ForEach(student =>
            {
                Debug.LogFormat("GroupName:{0}, Name:{1}, Age:{1}", studentGroup.Key, student.name, student.age);
            });
        });

        Debug.Log("-----------------分割线-------------------");

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
