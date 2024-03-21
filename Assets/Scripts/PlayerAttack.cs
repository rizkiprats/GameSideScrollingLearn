using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCoolDown;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    //untuk fire fireball
    [SerializeField] private Transform FirePoint;
    [SerializeField] public GameObject[] Fireballs;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.B) && cooldownTimer > attackCoolDown){
            attack();

        }
        cooldownTimer += Time.deltaTime;



    }

    private void attack()
    {
        cooldownTimer = 0;
        anim.SetTrigger("Attack");
        Fireballs[CheckFireball()].transform.position = FirePoint.position;
        Fireballs[CheckFireball()].GetComponent<Projectile>().setDirection(Mathf.Sign(transform.localScale.x));


    }


    private int  CheckFireball()
    {
        for(int i = 0; i < Fireballs.Length; i++)
        {
            if (Fireballs[i].activeInHierarchy)
            {
                return i;

            }

        }
        return 0;

    }

}
