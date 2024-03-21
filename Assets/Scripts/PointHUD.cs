using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointHUD : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Text PointText;
    private int PointCount;
    void Start()
    {
        PointCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<Point>() != null)
            PointCount = FindObjectOfType<Point>().point;
        PointText.text = PointCount.ToString();
    }
}
