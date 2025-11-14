using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public class InkDialogueTwoButtons : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI dialogueText;
    public Button choiceButton1;
    public Button choiceButton2;

    [Header("Ink JSON")]
    public TextAsset inkJSONAsset;

    private Story story;
    private bool dialogueActive = false;

    public void StartDialogue()
    {
        if (dialogueActive) return;

        if (inkJSONAsset == null)
        {
            Debug.LogError("InkDialogueTwoButtons: Kein Ink JSON Asset zugewiesen!");
            return;
        }

        story = new Story(inkJSONAsset.text);
        dialogueActive = true;

        gameObject.SetActive(true); // UI anzeigen
        ContinueStory();
    }

    void ContinueStory()
    {
        // Erstmal Buttons verstecken & alte Listener löschen
        choiceButton1.gameObject.SetActive(false);
        choiceButton2.gameObject.SetActive(false);
        choiceButton1.onClick.RemoveAllListeners();
        choiceButton2.onClick.RemoveAllListeners();

        // Text aus der Story lesen
        string text = "";
        while (story.canContinue)
        {
            text += story.Continue();
        }
        dialogueText.text = text;

        int choiceCount = story.currentChoices.Count;
        Debug.Log("InkDialogueTwoButtons: Anzahl Choices = " + choiceCount);

        if (choiceCount == 0)
        {
            EndDialogue();
            return;
        }

        // Choice 0 → Button 1
        if (choiceCount >= 1)
        {
            var choice = story.currentChoices[0];
            choiceButton1.gameObject.SetActive(true);
            choiceButton1.GetComponentInChildren<TextMeshProUGUI>().text = choice.text;
            choiceButton1.onClick.AddListener(() =>
            {
                OnClickChoice(0);
            });
        }

        // Choice 1 → Button 2
        if (choiceCount >= 2)
        {
            var choice = story.currentChoices[1];
            choiceButton2.gameObject.SetActive(true);
            choiceButton2.GetComponentInChildren<TextMeshProUGUI>().text = choice.text;
            choiceButton2.onClick.AddListener(() =>
            {
                OnClickChoice(1);
            });
        }
    }

    void OnClickChoice(int index)
    {
        story.ChooseChoiceIndex(index);
        ContinueStory();
    }

    void EndDialogue()
    {
        dialogueActive = false;
        gameObject.SetActive(false); // UI wieder ausblenden
    }
}
