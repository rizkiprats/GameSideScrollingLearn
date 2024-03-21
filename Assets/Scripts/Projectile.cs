using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float projectile_lifetime;

    private Health playerhealth;


    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (hit) return;
        
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        projectile_lifetime += Time.deltaTime;

        if (projectile_lifetime > 5)
        {
            //gameObject.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // kalau hit sesuatu
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode"); 

        if(collision.tag == "Enemy")
        {
            collision.GetComponent<Health>().TakeDamage(1);
        }

    }



    public void setDirection(float projectile_direction)
    {
        direction = projectile_direction;
        //untuk menentukan projectile masih ada
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;

        if (Mathf.Sign(localScaleX) != projectile_direction)
        {
           localScaleX = -localScaleX;

        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);



    }

    private void Deactivate()
    {
        gameObject.SetActive(false);

    }

     
     
}
