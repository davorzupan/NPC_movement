using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_layer_switch : MonoBehaviour
{

    private GameObject player;
    private bool posBehind;
    private bool posFront;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Character");
        if (player.transform.position.y > this.transform.position.y)
        {
            posBehind = true;
            posFront = false;
            this.GetComponent<SpriteRenderer>().sortingLayerName = "NPC_Front";
        }
        if (player.transform.position.y < this.transform.position.y)
        {
            posBehind = false;
            posFront = true;
            this.GetComponent<SpriteRenderer>().sortingLayerName = "NPC_Behind";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > this.transform.position.y && posFront)
        {
            posFront = false;
            posBehind = true;
            this.GetComponent<SpriteRenderer>().sortingLayerName = "NPC_Front";
        }
        else if (player.transform.position.y < this.transform.position.y && posBehind)
        {
            posFront = true;
            posBehind = false;
            this.GetComponent<SpriteRenderer>().sortingLayerName = "NPC_Behind";
        }
    }
}
