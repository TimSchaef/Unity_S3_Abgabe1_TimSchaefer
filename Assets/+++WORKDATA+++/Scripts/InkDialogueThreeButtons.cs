using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public class InkDialogueThreeButtons : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Image portraitFred;
    public Image portraitAlfred;
    public Image portraitAlfredo;

    public Button nextButton;
    public Button choiceButton1;
    public Button choiceButton2;
    public Button choiceButton3;

    [Header("Ink")]
    public TextAsset inkJSONAsset;

    [Header("Player")]
    public GameObject player;

    private Story story;
    private bool dialogueActive = false;

    public void StartDialogue()
    {
        if (dialogueActive) return;

        story = new Story(inkJSONAsset.text);
        dialogueActive = true;

        gameObject.SetActive(true);
        ContinueStory();
    }

    void ContinueStory()
    {
        ResetButtons();
        HideAllPortraits();

        if (story.canContinue)
        {
            string line = "";

            do
            {
                if (!story.canContinue) break;
                line = story.Continue().Trim();
            }
            while (string.IsNullOrEmpty(line));

            if (!string.IsNullOrEmpty(line))
                ApplySpeaker(line, line);

            // Mehr Text ohne Choices → NEXT BUTTON
            if (story.canContinue && story.currentChoices.Count == 0)
            {
                nextButton.gameObject.SetActive(true);
                nextButton.onClick.AddListener(ContinueStory);
                return;
            }
        }

        // Choices anzeigen
        if (story.currentChoices.Count > 0)
        {
            ShowChoices();
        }
        else if (!story.canContinue)
        {
            EndDialogue();
        }
    }

    void ShowChoices()
    {
        int count = story.currentChoices.Count;

        if (count >= 1)
        {
            choiceButton1.gameObject.SetActive(true);
            choiceButton1.GetComponentInChildren<TextMeshProUGUI>().text = story.currentChoices[0].text;
            choiceButton1.onClick.AddListener(() => SelectChoice(0));
        }

        if (count >= 2)
        {
            choiceButton2.gameObject.SetActive(true);
            choiceButton2.GetComponentInChildren<TextMeshProUGUI>().text = story.currentChoices[1].text;
            choiceButton2.onClick.AddListener(() => SelectChoice(1));
        }

        if (count >= 3)
        {
            choiceButton3.gameObject.SetActive(true);
            choiceButton3.GetComponentInChildren<TextMeshProUGUI>().text = story.currentChoices[2].text;
            choiceButton3.onClick.AddListener(() => SelectChoice(2));
        }
    }

    void ResetButtons()
    {
        nextButton.gameObject.SetActive(false);
        nextButton.onClick.RemoveAllListeners();

        choiceButton1.gameObject.SetActive(false);
        choiceButton2.gameObject.SetActive(false);
        choiceButton3.gameObject.SetActive(false);

        choiceButton1.onClick.RemoveAllListeners();
        choiceButton2.onClick.RemoveAllListeners();
        choiceButton3.onClick.RemoveAllListeners();
    }

    void HideAllPortraits()
    {
        portraitFred.gameObject.SetActive(false);
        portraitAlfred.gameObject.SetActive(false);
        portraitAlfredo.gameObject.SetActive(false);
    }

    void ApplySpeaker(string line, string fallback)
    {
        HideAllPortraits();

        // Spieler töten, wenn Text erscheint
        if (line.Contains("The twins eat you whole"))
        {
            if (player != null)
                Destroy(player);
        }

        int idx = line.IndexOf(':');

        if (idx == -1)
        {
            nameText.text = "";
            dialogueText.text = line;
            return;
        }

        string speaker = line.Substring(0, idx).Trim();
        string content = line.Substring(idx + 1).Trim();

        nameText.text = speaker;
        dialogueText.text = content;

        switch (speaker)
        {
            case "Fred":
            case "Fred (You)":
                portraitFred.gameObject.SetActive(true);
                break;

            case "Alfred":
                portraitAlfred.gameObject.SetActive(true);
                break;

            case "Alfredo":
                portraitAlfredo.gameObject.SetActive(true);
                break;
        }
    }

    void SelectChoice(int index)
    {
        story.ChooseChoiceIndex(index);
        ContinueStory();
    }

    void EndDialogue()
    {
        dialogueActive = false;
        HideAllPortraits();
        gameObject.SetActive(false);
    }
}

