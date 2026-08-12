using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemHoverPreview : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("UI Reference")]
    public Image previewBox;   // Gambar kotak besar di sebelah kanan
    public Sprite itemSprite;  // Gambar alat (Pickaxe/Shovel) slot ini

    // Dipanggil otomatis saat kursor MASUK ke area kotak slot ini
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (previewBox != null && itemSprite != null)
        {
            previewBox.sprite = itemSprite; // Ganti gambar kotak kanan
            previewBox.enabled = true;      // Tampilkan gambarnya
        }
    }

    // Dipanggil otomatis saat kursor KELUAR dari area kotak slot
    public void OnPointerExit(PointerEventData eventData)
    {
        if (previewBox != null)
        {
            // Pilihan 1: Sembunyikan gambar saat kursor keluar
            // previewBox.enabled = false; 

            // Pilihan 2: Atau biarkan tetap menampilkan item terakhir
        }
    }
}