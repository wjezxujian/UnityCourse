using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQLastExample : MonoBehaviour
{
    class Student
    {
        public string Name;

        public int Age;
    }

    // Start is called before the first frame update
    void Start()
    {
        var students = new List<Student>()
        {
            new Student(){Name = "张三", Age = 18},
            new Student(){Name = "王五", Age = 19},
            new Student(){Name = "李四", Age = 10},
        };

        var lastStudent = students.Last(student => student.Age > 10);
        Debug.Log(lastStudent.Name);

        lastStudent = (from student in students select student).Last(student => student.Age <18);
        Debug.Log(lastStudent.Name);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
