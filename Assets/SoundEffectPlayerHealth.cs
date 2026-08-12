using UnityEngine;

public class SoundEffectPlayerHealth : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip hurtSound;

    private void OnEnable()
    {
        PlayerHealth.OnHealthChanged += PlayHurtSound;
    }

    private void OnDisable()
    {
        PlayerHealth.OnHealthChanged -= PlayHurtSound;
    }

    private void PlayHurtSound(float currentHealth, float maxHealth)
    {
        if (audioSource != null && hurtSound != null)
        {
            audioSource.PlayOneShot(hurtSound);
        }
    }
}