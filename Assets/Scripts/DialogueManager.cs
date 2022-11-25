using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Animator animator;
    private Queue<string> sentences;
  
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;

        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        IEnumerator TypeSentence(string sentence)
        {
            dialogueText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.05f);
            }
        }

        //public IEnumerator TypeText(TextMeshProUGUI descriptionText, string descriptionToDisplay)
        //{
        //    isTyping = true;
        //    descriptionText.text = "";
        //    foreach (char letter in descriptionToDisplay.ToCharArray())
        //    {
        //        if (!isTyping)
        //        {
        //            descriptionText.text = "";
        //            descriptionText.text = descriptionToDisplay;
        //            break;
        //        }
        //        descriptionText.text += letter;
        //        yield return new WaitForSeconds(0.03f);
        //    }
        //    isTyping = false;
        //}
        void EndDialogue()
        {
            animator.SetBool("IsOpen", false); 
        }

    }
}
