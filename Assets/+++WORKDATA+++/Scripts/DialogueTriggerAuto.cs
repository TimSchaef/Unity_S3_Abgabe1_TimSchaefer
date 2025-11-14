using UnityEngine;

public class DialogueTriggerAuto : MonoBehaviour
{
    public InkDialogueTwoButtons dialogueManager;
    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D mit: " + other.name);

        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            dialogueManager.StartDialogue();
        }
    }
}


