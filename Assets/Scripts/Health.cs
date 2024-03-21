using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealt;
    public float currHealt { get; private set; }

    private Animator anim;
    public GameObject canvasgo;
    // Start is called before the first frame update
    void Awake()
    {
        currHealt = startingHealt;
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void TakeDamage(float _Damage)
    {
        currHealt = Mathf.Clamp(currHealt - _Damage, 0, startingHealt); 

        if(currHealt > 0)
        {
            anim.SetTrigger("Hurt");

        }
        else
        {
            anim.SetTrigger("Die");

            //Player
            if(GetComponent<PlayerMovement>() != null)
            {
                GetComponent<PlayerMovement>().enabled = false;
            }


            //Enemy
            if (GetComponentInParent<EnemyMove>() != null)
            {
                GetComponentInParent<EnemyMove>().enabled = false;
                

            }

            if (GetComponent<EnemyCharacter>() != null)
            {
                GetComponent<EnemyCharacter>().enabled = false;

            }

        }
         
    }

    private void Playerdie()
    {
        
        Time.timeScale = 0;
        canvasgo.SetActive(true);
        
    }

    public void addHealth(float health)
    {
        currHealt = Mathf.Clamp(currHealt + health, 0, startingHealt);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
        Playerdie();  
    }
}
