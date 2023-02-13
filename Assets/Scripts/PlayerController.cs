using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D theRB;
    public float jumpForce;
    private bool isGrounded;
    public Transform groundPoint;
    private float laserLength = 0.1f;
    public LayerMask groundLayer;
    private Animator anim;
    private SpriteRenderer thesr;
    public LayerMask enemieLayer;
    public Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        thesr = GetComponent<SpriteRenderer>();
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);
        isGrounded = Physics2D.Raycast(groundPoint.position, Vector2.down, laserLength, groundLayer);
        if(Input.GetButtonDown("Jump"))
        {
            if (isGrounded) 
                
            {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                AudioManager.reference.PlaySound(13);
            }
        }

        if(theRB.velocity.x <0)
        {
            thesr.flipX = true; 
        }

        else if(theRB.velocity.x >0)
        {
            thesr.flipX = false;
        }

        //Matar enemigos
        if (Physics2D.Raycast(groundPoint.position, Vector2.down, laserLength, enemieLayer))
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
            AudioManager.reference.PlaySound(7);
            GameManager.reference.puntuacion += 500;
            GameManager.reference.puntuaciontext.text = "Puntuación: " + GameManager.reference.puntuacion.ToString();
            Goomba.reference.DefeatEnemie();
            
        }

        //animations
        anim.SetFloat("moveSpeed", Mathf.Abs (theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);


    }

    public void ResetMario()
    {
        GameManager.reference.puntuacion = 0;
        GameManager.reference.puntuaciontext.text = "Puntuación: " + GameManager.reference.puntuacion.ToString();
        transform.position = initialPosition;
    }
}    
