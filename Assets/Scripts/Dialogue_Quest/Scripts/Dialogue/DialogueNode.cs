using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueNode
{
    public string speakerName;
    [TextArea] public string text;
    public List<DialogueChoice> playerChoices = new List<DialogueChoice>();
    public int requiredLevel = 0;
}