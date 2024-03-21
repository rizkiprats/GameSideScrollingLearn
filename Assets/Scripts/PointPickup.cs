using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPickup : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private int PointAddedRate;
    private float pointpickuplifetime;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        pointpickuplifetime += Time.deltaTime;
        if (pointpickuplifetime > 5)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Point>().AddPoint(PointAddedRate);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

    }
}
