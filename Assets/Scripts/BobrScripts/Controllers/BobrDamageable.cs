using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BobrDamageable : MonoBehaviour, IDamageable
{
    public float MaxHealth { get { return maxHealth; }}
    [SerializeField] private float maxHealth;
    [SerializeField] private Transform HpSliderParent;
    [SerializeField] private Gradient sliderGradient;
    [SerializeField] private Color sliderTextColor;

    private BobrStateMachine stateMachine;
    private Image sliderFill;
    private TextMeshProUGUI hpText;
    private float health;

    

    private void Awake()
    {
        stateMachine = GetComponent<BobrStateMachine>();
    }

    private void OnEnable()
    {
        health = MaxHealth;
        AddHealthbarToThisObject();
    }

    private void AddHealthbarToThisObject()
    {
        HpSliderParent.DOScale(0, 0);
        HpSliderParent.DOShakeRotation(3f, 0, 20, 0);
        HpSliderParent.DOScale(1, 3);
        sliderFill = HpSliderParent.GetChild(0).GetChild(0).GetComponent<Image>();
        sliderFill.DOFillAmount(1, 0);
        sliderFill.DOColor(sliderGradient.Evaluate(1), 1);

        hpText = HpSliderParent.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        hpText.text = $"{health}";

        OnHealthChanged();
    }


    public void OnHealthChanged()
    {
        float fillAmount = health / MaxHealth;
        sliderFill.DOColor(sliderGradient.Evaluate(fillAmount), fillAmount);
        sliderFill.DOFillAmount(fillAmount, 1);
        hpText.text = $"{health}";
    }

    public void TakeDamage(float damage)
    {
        health = Mathf.Clamp(health - damage, 0, MaxHealth);

        OnHealthChanged();

        if (health == 0)
            Die();
    }

    public void Die()
    {
        HpSliderParent.DOShakeRotation(1.5f, 90, 20, 90);
        HpSliderParent.DOScale(0,2);
        hpText.text = "0";
        stateMachine.SwitchState(stateMachine.BobrDeathState);
    }
}