using InsaneSystems.HealthbarsKit.UI;
using TMPro;
using UnityEngine;

namespace InsaneSystems.HealthbarsKit
{
	/// <summary>This component allows to make any game object having health and its own healthbar. Use this in your game or you can make your custom class, using its code as template. </summary>
	public class Damageable : MonoBehaviour
	{
		public event HealthbarsController.HealthChangedAction healthChangedEvent;
		[SerializeField] GameObject Axe;
		[SerializeField] [Range(0.1f, 1000f)] float maxHealth = 100;
		float health;
		ControlerAnimPlayer CAP;

		void Awake()
		{
			health = maxHealth;
			CAP = FindFirstObjectByType<ControlerAnimPlayer>();
		}

		void Start()
		{
			AddHealthbarToThisObject();
		}

		void AddHealthbarToThisObject()
		{
			var healthBar = HealthbarsController.instance.AddHealthbar(gameObject, maxHealth);
			healthChangedEvent += healthBar.OnHealthChanged; // setting up event to connect healthbar with this damageable. Now every time when it will take damage, healthbar will be updated.

			OnHealthChanged();
		}

		void OnHealthChanged()
		{
			if (healthChangedEvent != null)
				healthChangedEvent(health);
		}

		void OnTriggerEnter(Collider other)
        {
			if (other.CompareTag("Player"))
			{
				CAP.ItteractionSign.SetActive(true);
				TextMeshPro text = CAP.ItteractionSign.GetComponentInChildren<TextMeshPro>();
				text.text = "Press 'E' to Attack!";
			}
		}
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (Input.GetKeyDown(KeyCode.E))
					TakeDamage(CAP.playerStrength);			
            }
        }
        private void OnTriggerExit(Collider other)
        {
			if(other.CompareTag("Player"))
				CAP.ItteractionSign.SetActive(false);
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
			GameObject axe = Instantiate(Axe);
			axe.transform.position = transform.parent.position;
			CAP.ItteractionSign.SetActive(false);
			Destroy(transform.parent.gameObject);
		}
	}
}