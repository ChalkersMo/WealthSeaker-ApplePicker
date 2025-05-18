using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    private Dictionary<string, QuestProgress> questProgresses = new();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void StartQuest(QuestData quest)
    {
        if (!questProgresses.ContainsKey(quest.questId))
        {
            QuestProgress progress = new QuestProgress(quest.questId, quest.objectiveIds.Count);
            questProgresses.Add(quest.questId, progress);
            Debug.Log("Квест почався: " + quest.questId);
        }
    }

    public void CompleteObjective(string questId, string objectiveId)
    {
        if (questProgresses.TryGetValue(questId, out var progress))
        {
            progress.MarkObjectiveComplete(objectiveId);
            Debug.Log($"Ціль '{objectiveId}' завершена для квесту {questId}");

            if (progress.isCompleted)
            {
                Debug.Log($"Квест '{questId}' завершено!");
            }
        }
    }

    public bool IsQuestCompleted(string questId)
    {
        return questProgresses.TryGetValue(questId, out var progress) && progress.isCompleted;
    }

    public List<QuestProgress> GetAllProgress() => new List<QuestProgress>(questProgresses.Values);
}