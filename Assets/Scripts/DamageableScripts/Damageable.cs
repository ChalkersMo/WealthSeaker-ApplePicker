using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Damageable : MonoBehaviour
{
    [SerializeField, Range(0.1f, 1000f)] private float maxHealth = 100;
    [SerializeField] private Transform HpSliderParent;
    [SerializeField] private Gradient sliderGradient;
    [SerializeField] private Color sliderTextColor;

    private Image sliderFill;
    private TextMeshProUGUI hpText;
    private float health;

    private void Awake()
    {
        health = maxHealth;
    }

    private void Start()
    {
        AddHealthbarToThisObject();
    }

    private void AddHealthbarToThisObject()
    {
        // Ищем НЕ триггерный BoxCollider
        BoxCollider mainCollider = null;
        foreach (var col in GetComponents<BoxCollider>())
        {
            if (!col.isTrigger)
            {
                mainCollider = col;
                break;
            }
        }

        if (mainCollider == null)
        {
            Debug.LogError("Ошибка: Не найден НЕ триггерный BoxCollider!");
            return;
        }

        
        sliderFill = HpSliderParent.GetChild(0).GetChild(0).GetComponent<Image>();
        sliderFill.DOFillAmount(1, 0);
        sliderFill.DOColor(sliderGradient.Evaluate(1), 1);

        hpText = HpSliderParent.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        hpText.text = $"{health}";

        OnHealthChanged();
    }




    private void OnHealthChanged()
    {
        float fillAmount = health / maxHealth;
        sliderFill.DOColor(sliderGradient.Evaluate(fillAmount), fillAmount);
        sliderFill.DOFillAmount(fillAmount, 1);
        hpText.text = $"{health}";
    }

    public void TakeDamage(float damage)
    {
        health = Mathf.Clamp(health - damage, 0, maxHealth);

        OnHealthChanged();

        if (health == 0)
            Die();
    }

    public void Die()
    {
        HpSliderParent.DOShakeRotation(1.5f, 90, 20, 90);
        HpSliderParent.DOScale(0,2);
        hpText.text = "0";
    }
}