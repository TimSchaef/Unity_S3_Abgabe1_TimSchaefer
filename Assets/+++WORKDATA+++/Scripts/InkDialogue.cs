using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public class InkDialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public Transform choicesParent;
    public Button choiceButtonPrefab;
    public TextAsset inkJSONAsset;

    private Story story;
    private bool dialogueActive = false;

    public void StartDialogue()
    {
        if (dialogueActive) return;

        if (inkJSONAsset == null)
        {
            Debug.LogError("InkDialogue: Kein Ink JSON Asset zugewiesen!");
            return;
        }

        story = new Story(inkJSONAsset.text);
        dialogueActive = true;

        gameObject.SetActive(true); // UI an
        ContinueStory();
    }

    void ClearChoices()
    {
        foreach (Transform child in choicesParent)
            Destroy(child.gameObject);
    }

    void ContinueStory()
    {
        ClearChoices();

        string text = "";
        while (story.canContinue)
        {
            text += story.Continue();
        }

        dialogueText.text = text;
        Debug.Log("InkDialogue: Text = " + text);

        int choiceCount = story.currentChoices.Count;
        Debug.Log("InkDialogue: Anzahl Choices = " + choiceCount);

        if (choiceCount > 0)
        {
            for (int i = 0; i < choiceCount; i++)
            {
                var choice = story.currentChoices[i];
                Debug.Log($"Choice {i}: {choice.text}");

                Button btn = Instantiate(choiceButtonPrefab, choicesParent);
                var btnText = btn.GetComponentInChildren<TextMeshProUGUI>();
                if (btnText != null)
                    btnText.text = choice.text;

                int choiceIndex = i;
                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(() => OnClickChoice(choiceIndex));
            }
        }
        else
        {
            Debug.Log("InkDialogue: Keine Choices mehr -> Ende");
            EndDialogue();
        }
    }

    void OnClickChoice(int choiceIndex)
    {
        Debug.Log("InkDialogue: Choice geklickt: " + choiceIndex);
        story.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }

    void EndDialogue()
    {
        dialogueActive = false;
        gameObject.SetActive(false); // UI aus
    }
}


