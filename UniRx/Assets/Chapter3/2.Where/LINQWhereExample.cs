using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;

public class LINQWhereExample : MonoBehaviour
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

        students.Where(student => student.Age > 10)
                .Select(student => student)
                .ToList()
                .ForEach(student =>
                {
                    Debug.Log(student.Name);
                });

        var query = from student in students where student.Age > 10 select student;
        query.ToList()
             .ForEach(student =>
             {
                 Debug.Log(student.Name);
             });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
