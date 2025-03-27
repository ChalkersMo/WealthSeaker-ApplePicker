using UnityEngine;
using System.Collections.Generic;

public class AttacksController : MonoBehaviour
{
    [HideInInspector] public DamageDealer currentDamageDealer;

    [SerializeField] private List<DamageDealerEntry> damageDealersList;
    private readonly Dictionary<string, DamageDealer> damageDealers = new Dictionary<string, DamageDealer>();
 
    private void Awake()
    {
        foreach (var entry in damageDealersList)
        {
            if (entry.value != null && !damageDealers.ContainsKey(entry.key))
                damageDealers.Add(entry.key, entry.value);
        }
        ChangeDamageDealer("Hand");
    }

    public void Attack()
    {
        if (currentDamageDealer != null)
        {
            currentDamageDealer.DealAttack();
        }
    }

    public void ChangeDamageDealer(string name)
    {
        if (damageDealers.ContainsKey(name))
        {
            if (currentDamageDealer != null)
                currentDamageDealer.gameObject.SetActive(false);

            if(currentDamageDealer == damageDealers[name])
            {
                currentDamageDealer.gameObject.SetActive(false);
            }
            currentDamageDealer = damageDealers[name];
            currentDamageDealer.gameObject.SetActive(true);
        }
        else
            Debug.LogWarning($"There is no dealer with {name} name");
    }
}
