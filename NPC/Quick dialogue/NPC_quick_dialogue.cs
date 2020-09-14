using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC_quick_dialogue : MonoBehaviour
{

    public TextMeshPro text; 
    [TextArea(1,1)]
    public string dialogueText;
    public float dialogueDisplayTime;

    public Collider2D npcDialogueZone;
    public bool textToggle;

    public float getX;
    public float getY;

    // Start is called before the first frame update
    void Start()
    {
        textToggle = false;
        if (this.GetComponent<Collider2D>())
        {
            npcDialogueZone = this.GetComponent<Collider2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        PositionText();
        if (!textToggle)
        {
            DisableText();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (npcDialogueZone && Input.GetKeyDown(KeyCode.E))
        {
            if (textToggle)
            {
                textToggle = false;
                DisableText();
            }
            else
            {
                textToggle = true;
                EnableText();
            }
        }
    }

    void EnableText()
    {
        if (this.GetComponent<NPC_patern_movement>())
        {
            this.GetComponent<NPC_patern_movement>().stopMovement();
        }
        text.transform.localScale=new Vector3(1, 1, 1);
        text.text = dialogueText;
        StartCoroutine(Wait());
    }

    void DisableText()
    {
        if (this.GetComponent<NPC_patern_movement>())
        {
            this.GetComponent<NPC_patern_movement>().continueMovement();
        }
        text.transform.localScale = new Vector3(0,0,0);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(dialogueDisplayTime);
        textToggle = false;
        if (this.GetComponent<NPC_patern_movement>())
        {
            this.GetComponent<NPC_patern_movement>().continueMovement();
        }
    }

    void PositionText()
    {
        getX = this.gameObject.transform.position.x;
        getY = this.gameObject.transform.position.y + (this.gameObject.GetComponent<SpriteRenderer>().bounds.size.y)/4*3;
        text.transform.position=new Vector3(getX, getY, 0);
    }

}
