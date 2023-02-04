using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	[SerializeField]
	public bool toggleValue;

	public bool isAlreadStart = false;

	public Dialogue dialogue;

	private void Update(){
		if(toggleValue && !isAlreadStart){
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
			isAlreadStart = true;
		}
	}
}
