using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healtbar : MonoBehaviour
{
    [SerializeField] private Health playerHealt;
    [SerializeField] private Image totalHealthbar;
    [SerializeField] private Image currHealthbar;


    // Start is called before the first frame update
    void Start()
    {
        totalHealthbar.fillAmount = playerHealt.currHealt / 10;  
    }

    // Update is called once per frame
    void Update()
    {
        currHealthbar.fillAmount = playerHealt.currHealt / 10;
        
    }
}
