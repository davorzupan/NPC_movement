using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_random_movement : MonoBehaviour
{

    public Collider2D walkZone;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;

    private Rigidbody2D rigidBody;
    private bool hasWalkZone;

    private GameObject player;
    
    private float moveSpeed;
    private int walkDirection;

    private float walkTime;
    private float walkCounter;

    private float waitTime;
    private float waitCounter;

    private bool isWalking;

    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Character");
        moveSpeed = (player.GetComponent<Player_movement>().moveSpeed* player.GetComponent<Player_movement>().diagonalMoveModifier) /3;

        StartingRandoms();

        if (this.GetComponent<Rigidbody2D>())
        {
            rigidBody = this.GetComponent<Rigidbody2D>();
        }
        if (walkZone)
        {
            minWalkPoint =walkZone.bounds.min;
            maxWalkPoint =walkZone.bounds.max;
            hasWalkZone = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            walkCounter -= Time.deltaTime;
            switch (walkDirection)
            {
                case 0:
                    rigidBody.velocity = new Vector2(0, moveSpeed);
                    if (hasWalkZone && transform.position.y > maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 1:
                    rigidBody.velocity = new Vector2(0, -moveSpeed);
                    if (hasWalkZone && transform.position.y < minWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 2:
                    rigidBody.velocity = new Vector2(moveSpeed, 0);
                    if (hasWalkZone && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 3:
                    rigidBody.velocity = new Vector2(-moveSpeed, 0);
                    if (hasWalkZone && transform.position.x < minWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
            }
            if(walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
            rigidBody.velocity = Vector2.zero;
            if(waitCounter < 0)
            {
                ChooseRandoms();
            }
        }
    }

    public void StartingRandoms()
    {
        waitTime = Random.Range(1.0f, 2.0f);
        walkTime = Random.Range(1.0f, 2.0f);
    }

    public void ChooseRandoms()
    {
        walkDirection = Random.Range(0, 4);
        waitTime = Random.Range(1.0f, 2.0f);
        walkTime = Random.Range(1.0f, 2.0f);
        isWalking = true;
        walkCounter = walkTime;
    }

}