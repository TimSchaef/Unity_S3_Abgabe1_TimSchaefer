using UnityEngine;

public class DialogueTriggerAuto : MonoBehaviour
{
    public InkDialogueThreeButtons dialogueManager;
    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            dialogueManager.StartDialogue();
        }
    }
}


