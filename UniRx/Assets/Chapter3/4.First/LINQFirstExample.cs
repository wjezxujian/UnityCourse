using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQFirstExample : MonoBehaviour
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

        var student = students.First();
        Debug.Log(student.Name);

        student = students.Where(student => student.Age >= 19).First();
        Debug.Log(student.Name);

        student = (from studentX in students select studentX).First(studentX => studentX.Age <= 10);
        Debug.Log(student.Name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
