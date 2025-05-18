using UnityEngine;

[System.Serializable]
public class DialogueChoice
{
    public string choiceText;
    public int nextNodeIndex = -1;
    public bool startQuest = false;
    public QuestData questToStart;
}