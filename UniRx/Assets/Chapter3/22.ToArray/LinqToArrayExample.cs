using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class LinqToArrayExample : MonoBehaviour
{
    class Student
    {
        public string name;
        public int age;
    }

    // Start is called before the first frame update
    void Start()
    {
        var students = new Student[] { 
            new Student() {name = "�Դ�", age = 19},
            new Student() {name = "Ǯ��", age = 18},
            new Student() {name = "����", age = 17},
            new Student() {name = "����", age = 16}
        };

        var studentNames = students.Select(student => student.name).ToArray();

        Array.ForEach(studentNames, studentName => Debug.Log(studentName));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
