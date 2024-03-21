using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D body;
    [SerializeField] private float speed;
    private Animator anim;
    private bool grounded;
    public AudioSource PlayerAudio;

    void Start()
    {
        //mengambil reference dari ridigbody dan animator component
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal_input = Input.GetAxis("Horizontal") * speed;
        //body.velocity = new Vector2(horizontal_input, body.velocity.y);
        body.position = new Vector2(body.position.x + horizontal_input * Time.deltaTime, body.position.y);

        if (horizontal_input > 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }
        if (horizontal_input < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }
        //set animator
        anim.SetBool("Run", horizontal_input != 0);
        anim.SetBool("Grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("Jump");
        PlayerAudio.Play();
        grounded = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;  
        }
        
    }


}
