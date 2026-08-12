using UnityEngine;
using TMPro;

public class ItemInfoUI : MonoBehaviour
{
    public static ItemInfoUI instance;

    [Header("UI Text References")]
    public TMP_Text nameText;
    public TMP_Text priceText;
    public TMP_Text damageText;

    private void Awake() {
        instance = this;
        gameObject.SetActive(false); // Sembunyikan panel di awal
    }

    // Fungsi untuk memperbarui teks dan menampilkan panel
    public void ShowInfo(ItemData data) {
        if (data == null) return;

        nameText.text = data.itemName;
        priceText.text = "Harga: " + data.price + " Gold";
        damageText.text = "Damage: " + data.damage;

        gameObject.SetActive(true);
    }

    public void HideInfo() {
        gameObject.SetActive(false);
    }
}