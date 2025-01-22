using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;

public class InteractionTablleController : MonoBehaviour
{
    [SerializeField] GameObject interactionTable;
    private TextMeshPro interactionTableText;
    private bool interactionEnabled = false;

    private void Start()
    {
        interactionTableText = interactionTable.GetComponentInChildren<TextMeshPro>();
    }
    public void ShowTip(string textToShow)
    {
        interactionTableText.text = textToShow;
        interactionTable.transform.localScale = Vector3.zero;
        interactionEnabled = true;
        interactionTable.SetActive(true);
        interactionTable.transform.DOScale(1, 1);
    }
    public void CloseTip()
    {
        StartCoroutine(EcloseTip(1));
    }

    private IEnumerator EcloseTip(float TimeToClose)
    {
        interactionEnabled = false;
        interactionTable.transform.DOScale(0, TimeToClose);
        yield return new WaitForSeconds(TimeToClose);
        if(!interactionEnabled)
            interactionTable.SetActive(false);
        StopCoroutine(EcloseTip(TimeToClose));
    }
}
