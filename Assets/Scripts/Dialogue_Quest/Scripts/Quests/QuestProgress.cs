using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuestProgress
{
    public string questId;
    public List<string> completedObjectives = new List<string>();
    public bool isCompleted => completedObjectives.Count >= totalObjectives;
    public int totalObjectives;

    public QuestProgress(string questId, int totalObjectives)
    {
        this.questId = questId;
        this.totalObjectives = totalObjectives;
    }

    public void MarkObjectiveComplete(string objectiveId)
    {
        if (!completedObjectives.Contains(objectiveId))
            completedObjectives.Add(objectiveId);
    }
}