using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_patern_movement : MonoBehaviour
{
    public Coordinates[] coordinates;

    private GameObject player;
    private float moveSpeed;

    private int arrayPos;
    private bool canMove;

    private bool posBehind;
    private bool posFront;

    private Vector3 currentPosition;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Character");
        moveSpeed = player.GetComponent<Player_movement>().moveSpeed * player.GetComponent<Player_movement>().diagonalMoveModifier;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            currentPosition = this.gameObject.transform.position;
            for (int i = 0; i < coordinates.Length; i++)
            {
                if (coordinates[i].currentTarget == true)
                {
                    targetPosition = coordinates[i].Point.transform.position;
                    arrayPos = i;
                }
            }
            if (Vector3.Distance(currentPosition, targetPosition) == 0)
            {
                if (arrayPos == coordinates.Length - 1)
                {
                    coordinates[arrayPos].currentTarget = false;
                    arrayPos = 0;
                    coordinates[arrayPos].currentTarget = true;
                }
                else
                {
                    coordinates[arrayPos].currentTarget = false;
                    arrayPos += 1;
                    coordinates[arrayPos].currentTarget = true;
                }
            }
            switch (coordinates[arrayPos].Path)
            {
                case movementType.Straight_Line:
                    transform.position = Vector3.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
                    break;
                case movementType.Grid_Horizontal_First:
                    if (currentPosition.x == targetPosition.x)
                    {
                        transform.position = Vector3.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
                    }
                    else
                    {
                        transform.position = Vector3.MoveTowards(currentPosition, new Vector3(targetPosition.x, currentPosition.y, currentPosition.z), moveSpeed * Time.deltaTime);
                    }
                    break;
                case movementType.Grid_Vertical_First:
                    if (currentPosition.y == targetPosition.y)
                    {
                        transform.position = Vector3.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
                    }
                    else
                    {
                        transform.position = Vector3.MoveTowards(currentPosition, new Vector3(currentPosition.x, targetPosition.y, currentPosition.z), moveSpeed * Time.deltaTime);
                    }
                    break;
            }
        }
    }

    public void stopMovement()
    {
        canMove = false;
    }

    public void continueMovement()
    {
        canMove = true;
    }

}
