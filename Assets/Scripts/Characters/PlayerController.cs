using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Needed to move the RigidBody and not use the GameObject transform
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public float speed = 3.0f;
    public bool isBusy;

    public bool canMove = true;


    //For Animations
    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);
    //To check if we need to flip the animation.
    public bool facingLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();        
    }

    /* Update() is called every frame/time the game computes a new image.
    It could be 20 images per second on a slow computer, or 3000 on a very fast one.
    */
    void Update()
    {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        
        // store the input amount in a Vector2 called move. 
        Vector2 move = new Vector2(horizontal, vertical);
        //Check to see whether move.x or move.y isn’t equal to 0. 
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            //If either x or y isn’t equal to 0, then player is moving, set your look direction to your Move Vector and player should look in the direction that she is moving
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        //Set animator properties
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);



    }

    /*
    When using the Physics system we need the computation to be stable and update at regulart intervals.
    Update() is called every time the game computes a new image, the problem is that this is called at an uncertain rate
    Unity has another function called FixedUpdate that needs to be used any time you want to directly influence physics components or objects, such as a Rigidbody.
    However, you shouldn’t read input in the Fixedupdate function. FixedUpdate isn’t continuously running, so there’s a chance a User Input will be missed.
    */
    void FixedUpdate()
    {
        //Move player
        if(canMove){
            Vector2 position = rigidbody2d.position;
            position.x = position.x + speed * horizontal * Time.deltaTime;
            position.y = position.y + speed * vertical  * Time.deltaTime;
            rigidbody2d.MovePosition(position);

            //Check if animation needs to be flipped
            if(horizontal < 0 && !facingLeft){
                Flip();
            } else if(horizontal > 0 && facingLeft){
                Flip();
            }
        }



    }

    /*FLIP PLAYER SPRITE AND ANIMATION WHEN NEEDED*/
    void Flip(){
        facingLeft = !facingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}