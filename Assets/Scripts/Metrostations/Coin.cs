using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy the coin if it moves far enough
        if(transform.position.magnitude > 50){
            Destroy(gameObject);
        } 
    }
    // Move the Coin after winning it onto the scene.   
    public void Won(Vector2 direction, float force){
        //move the coin in a direction with a certain force
        rigidbody2D.AddForce(direction * force);
    }

}
