using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
	public Text nameText;
	public Text dialogueText;

	private Queue<string> sentences;

	public GameObject DialogBox;

	private GameObject Player;

	private PlayerController playerController;

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.FindWithTag("Player");
		sentences = new Queue<string>();
		playerController = player.GetComponent<PlayerController>();
	}

	public void StartDialogue (Dialogue dialogue)
	{
		print("start dialogue");
		playerController.isFreeze = true;
		DialogBox.SetActive(true);

		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
		playerController.isFreeze = false;
		DialogBox.SetActive(false);
	}

}
