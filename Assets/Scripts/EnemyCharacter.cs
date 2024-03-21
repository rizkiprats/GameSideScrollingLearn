using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    [Header("Attack Pramaters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float damage;
    [SerializeField] private float range;

    [Header(" Colliders Parameters")]
    [SerializeField] private float distanceCollider;

    [Header("Player Layers")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField]private BoxCollider2D boxCollider;
    


    private Animator anim;

    private Health playerhealth;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (checkPlayer())
        {
            if(cooldownTimer >= attackCooldown)
            {
                //Attack
                cooldownTimer = 0;

                //animasi
                anim.SetTrigger("Enemy Attack");
 
            }
        }
        
    }

    private bool checkPlayer()
    {
        //cek posisi player
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * 
            transform.localScale.x * distanceCollider, new Vector3(boxCollider.bounds.size.x * range, 
            boxCollider.bounds.size.y, boxCollider.bounds.size.z),0, Vector2.left,0, playerLayer);

        if(hit.collider != null)
        {
            playerhealth = hit.transform.GetComponent<Health>();
        }
        return hit.collider != null;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * 
            range * transform.localScale.x * distanceCollider, new Vector3(boxCollider.bounds.size.x * 
            range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (checkPlayer())
        {
            playerhealth.TakeDamage(damage);

        }
    }



}
