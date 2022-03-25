using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isjumping;
    public bool doublejumping;
    public float speed;
    public float jumpforce;
    private Rigidbody2D rig;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
    }


    void move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
        
        if(Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }

        if(Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }

        if(Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("walk", false);
        }

    }

    void jump()
    {
        if(Input.GetButtonDown("Jump")) 
        {
            if(isjumping == false)
            {                    
                rig.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
                doublejumping = true;
                anim.SetBool("jump", true);

            }
            else
            {
                if(doublejumping)
                {
                    rig.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
                    doublejumping = false;  
                }
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision) //detectar que esta tocando em alguma coisa
    {
        if(collision.gameObject.layer == 8)
        {
            isjumping = false;
            anim.SetBool("jump", false);

        }
    }
    void OnCollisionExit2D(Collision2D collision) //para de tocar em algo
    {
        if(collision.gameObject.layer == 8)
        {
            isjumping = true;
        }
    }
}
