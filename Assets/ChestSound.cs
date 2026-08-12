using UnityEngine;

public class ChestSound : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] private AudioClip openChestSFX;

    // Fungsi ini dipanggil SAAT TOMBOL DITEKAN
    public void OpenChestSound()
    {
        if (AudioManager.Instance != null && openChestSFX != null)
        {
            AudioManager.Instance.PlaySFX(openChestSFX);
        }
    }
}