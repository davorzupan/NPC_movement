using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_follow : MonoBehaviour
{

    private GameObject followCharacter;
    public bool returnsToStart;

    private Vector3 targetPosition;
    private Vector3 startPoint;
    private float moveSpeed;
    private bool hold;
    private bool back;
    

    // Start is called before the first frame update
    void Start()
    {
        followCharacter = GameObject.Find("Character");
        startPoint = this.transform.position;
        moveSpeed = (followCharacter.GetComponent<Player_movement>().moveSpeed)/2;
        hold = false;
        back = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, startPoint) < 0.2)
        {
            back = false;
            hold = false;
        }
        if (returnsToStart && back && !hold && this.transform.position!=startPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPoint, moveSpeed * Time.deltaTime);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == followCharacter)
        {
            back = false;
            if (!hold)
            {
                targetPosition = new Vector3(followCharacter.transform.position.x, followCharacter.transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            }
            if (Vector3.Distance(followCharacter.transform.position,this.transform.position)<2.2)
            {
                hold = true;
            }
            else
            {
                hold = false;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == followCharacter)
        {
            back = true;
        }
    }

}
