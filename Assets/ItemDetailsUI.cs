using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDetailsUI : MonoBehaviour
{
    public static ItemDetailsUI instance;

    [Header("UI Component References")]
    public Image itemIcon;
    public TMP_Text nameText;
    public TMP_Text priceText;
    public TMP_Text damageText;

    private void Awake() {
        instance = this;
        HideDetails(); // Sembunyikan window secara otomatis saat game baru mulai
    }

    // Dipanggil saat kursor menempel pada item
    public void ShowDetails(ItemData data) {
        if (data == null) return;

        if (itemIcon != null) {
            itemIcon.sprite = data.icon;
            itemIcon.enabled = true;
        }

        if (nameText != null) nameText.text = data.itemName;
        if (priceText != null) priceText.text = "Harga: " + data.price;
        if (damageText != null) damageText.text = "Damage: " + data.damage;

        gameObject.SetActive(true); // Munculkan window
    }

    // Dipanggil saat kursor keluar dari item
    public void HideDetails() {
        gameObject.SetActive(false); // Sembunyikan window
    }
}