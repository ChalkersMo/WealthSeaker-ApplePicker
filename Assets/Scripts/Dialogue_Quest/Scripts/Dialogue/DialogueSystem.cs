using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance;

    public GameObject dialoguePanel;
    public TextMeshProUGUI speakerText;
    public TextMeshProUGUI dialogueText;
    public Transform choicesPanel;
    public GameObject choiceButtonPrefab;

    private DialogueData currentDialogue;
    private int currentNodeIndex;

    private void Awake()
    {
        Instance = this;
        dialoguePanel.SetActive(false);
    }

    public void StartDialogue(DialogueData data)
    {
        currentDialogue = data;
        currentNodeIndex = 0;
        dialoguePanel.SetActive(true);
        ShowCurrentNode();
    }

    private void ShowCurrentNode()
    {
        foreach (Transform child in choicesPanel)
            Destroy(child.gameObject);

        if (currentNodeIndex < 0 || currentNodeIndex >= currentDialogue.nodes.Count)
        {
            EndDialogue();
            return;
        }

        DialogueNode node = currentDialogue.nodes[currentNodeIndex];

        if (node.requiredLevel > GameStateManager.Instance.currentState.playerLevel)
        {
            dialogueText.text = "Вам потрібен рівень " + node.requiredLevel + " для цієї розмови.";
            return;
        }

        speakerText.text = node.speakerName;
        dialogueText.text = node.text;

        foreach (var choice in node.playerChoices)
        {
            GameObject btnObj = Instantiate(choiceButtonPrefab, choicesPanel);
            btnObj.GetComponentInChildren<TextMeshProUGUI>().text = choice.choiceText;

            btnObj.GetComponent<Button>().onClick.AddListener(() =>
            {
                if (choice.startQuest && choice.questToStart != null)
                {
                    QuestManager.Instance.StartQuest(choice.questToStart);
                }
                currentNodeIndex = choice.nextNodeIndex;
                ShowCurrentNode();
            });
        }
    }

    public void EndDialogue()
    {
        currentDialogue = null;
        dialoguePanel.SetActive(false);
    }
}