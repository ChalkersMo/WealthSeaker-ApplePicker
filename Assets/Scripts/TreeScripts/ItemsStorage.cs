using DG.Tweening;
using TMPro;
using UnityEngine;

public class ItemsStorage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ApplesText;
    [SerializeField] private TextMeshProUGUI LogsText;
    private int ApplesCount;
    private int LogsCount;

    public void AddApples(int applesCount)
    {
        ApplesCount += applesCount;
        ApplesText.transform.DOShakeRotation(1);
        ApplesText.transform.DOShakeScale(1);
        ApplesText.text = ApplesCount.ToString();
    }

    public void Addlogs(int logsCount)
    {
        LogsCount += logsCount;
        LogsText.transform.DOShakeRotation(1);
        LogsText.transform.DOShakeScale(1);
        LogsText.text = logsCount.ToString();
    }
}
