using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action<float, float> OnHealthChanged;

    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    private void Update()
    {
        // Pemicu simulasi: Tekan Spasi untuk kurangi darah
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10f);
        }
    }
}