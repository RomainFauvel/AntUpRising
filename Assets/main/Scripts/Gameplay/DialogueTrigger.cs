using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {


	private bool isAlreadStart = false;

	public Dialogue dialogue;

	private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !isAlreadStart)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
			isAlreadStart = true;
        }
    }
}
