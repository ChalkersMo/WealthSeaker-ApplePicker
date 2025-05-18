using UnityEngine;

public static class QuestObjectiveFactory
{
    public static IQuestObjective CreateObjective(string id)
    {
        switch (id)
        {
            case "kill_enemy":
                return new KillEnemyObjective();
            case "visit_location":
                return new VisitLocationObjective();
            default:
                Debug.LogWarning("Невідома ціль: " + id);
                return null;
        }
    }
}

public interface IQuestObjective
{
    void StartObjective();
    bool IsComplete();
}

public class KillEnemyObjective : IQuestObjective
{
    public void StartObjective() => Debug.Log("Почата ціль: Вбий ворога");
    public bool IsComplete() => false;
}

public class VisitLocationObjective : IQuestObjective
{
    public void StartObjective() => Debug.Log("Почата ціль: Відвідай локацію");
    public bool IsComplete() => false;
}