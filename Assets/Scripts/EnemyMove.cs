using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [Header("Move Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEgde;

    [Header("Enemy")]
    [SerializeField] private Transform Enemy;

    [Header("Movement Parameters")]
    [SerializeField] private float enemyspeed;
    private Vector3 initScale;
    private bool movingLeft;

    [SerializeField] private float idleDuration;
    private float idleTimer;



    public Animator anim;

    // Start is called before the first frame update

    private void Awake()
    {
        initScale = Enemy.localScale;
        
    }
    void Start()
    {
        
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        Enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, 
            initScale.y, initScale.z);

        Enemy.position = new Vector3(Enemy.position.x + Time.deltaTime * _direction * enemyspeed,
            Enemy.position.y, Enemy.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (movingLeft)
        {
            anim.SetBool("Moving1", true);
            if(Enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);
            }
            else
            {
                directionChange();
            }
            
        }
        else
        {
            anim.SetBool("Moving1", true);
            if (Enemy.position.x <= rightEgde.position.x)
            {
                MoveInDirection(1);
            }
            else
            {
                directionChange();
            }
        }
        
        
    }

    private void directionChange()
    {
        anim.SetBool("Moving1", false);

        idleTimer += Time.deltaTime;
        if(idleTimer > idleDuration)
        {
            movingLeft = !movingLeft;
        }
        
        
    }

    private void OnDisable()
    {
       // anim.SetBool("Moving1", false); 
    }
}
