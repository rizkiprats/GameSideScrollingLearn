using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Point : MonoBehaviour
{
    // Start is called before the first frame update
    public int point { get; private set; }

   
    void Start()
    {
        point = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void AddPoint(int pointadded)
    {
        point = point + pointadded;
    }
}
