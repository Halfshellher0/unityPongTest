using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    enum Direction {up=1,still=0,down=-1};
    Direction direction;
    float previousPositionY;

    [SerializeField]
    bool isPlayerTwo;
    [SerializeField]
    float speed = 0.15f;       // how far the paddle moves per frame
    [SerializeField]
    float maxPaddleHeight = 3.2f;

    Transform myTransform;    // reference to the object's transform

    // Use this for initialization
    void Start()
    {
        myTransform = transform;
        previousPositionY = myTransform.position.y;
    }

    

    // FixedUpdate is called once per physics tick/frame
    void FixedUpdate()
    {
        // first decide if this is player 1 or player 2 so we know what keys to listen for
        if (isPlayerTwo)
        {
            if (Input.GetKey("o"))
                MoveUp();
            else if (Input.GetKey("l"))
                MoveDown();
        }
        else // if not player 2 it must be player 1
        {
            if (Input.GetKey("q"))
                MoveUp();
            else if (Input.GetKey("a"))
                MoveDown();
        }

        if (previousPositionY > myTransform.position.y)
        {
            direction = Direction.down;
        }
        else if (previousPositionY < myTransform.position.y)
        {
            direction = Direction.up;
        }
        else
        {
            direction = Direction.still;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        float adjust = 5 * (int)direction;
        other.rigidbody.velocity = new Vector2(other.rigidbody.velocity.x, other.rigidbody.velocity.y + adjust);
    }

    void LateUpdate()
    {
        previousPositionY = myTransform.position.y;
    }

    // move the player's paddle up by an amount determined by 'speed'
    void MoveUp()
    {
        if (myTransform.position.y + speed < maxPaddleHeight)
        {
            myTransform.position = new Vector2(myTransform.position.x, myTransform.position.y + speed);
        }
    }

    // move the player's paddle down by an amount determined by 'speed'
    void MoveDown()
    {
        if (myTransform.position.y - speed > 0 - maxPaddleHeight)
        {
            myTransform.position = new Vector2(myTransform.position.x, myTransform.position.y - speed);
        }        
    }
}
