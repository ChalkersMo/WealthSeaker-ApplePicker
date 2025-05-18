using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Quests/QuestData")]
public class QuestData : ScriptableObject
{
    public string questId;
    public string description;
    public List<string> objectiveIds;
}