using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private float healtPickRate;
    private float healthpickuplifetime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthpickuplifetime += Time.deltaTime;
        if(healthpickuplifetime > 5)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") { 

            collision.GetComponent<Health>().addHealth(healtPickRate);
            gameObject.SetActive(false);
            Destroy(gameObject); 


        }
        
    }
}
