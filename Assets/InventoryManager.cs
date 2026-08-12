using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [Header("Data Items")]
    public List<ItemData> itemsToLoad = new List<ItemData>(); // Isi dengan ScriptableObject (PickaxeData, ShovelData, dll)

    [Header("References")]
    public Transform mainInventoryContainer; // Folder MainInventory
    public Transform toolbarContainer;      // Folder Toolbar
    public GameObject inventoryItemPrefab;  // Prefab InventoryItem

    private List<InventorySlot> allSlots = new List<InventorySlot>();

    private void Start() {
        FindAllSlots();
        LoadItemsToUI();
    }

    // Fungsi otomatis mengumpulkan SEMUA slot dari MainInventory & Toolbar
    void FindAllSlots() {
        allSlots.Clear();

        if (toolbarContainer != null) {
            allSlots.AddRange(toolbarContainer.GetComponentsInChildren<InventorySlot>());
        }

        if (mainInventoryContainer != null) {
            allSlots.AddRange(mainInventoryContainer.GetComponentsInChildren<InventorySlot>());
        }
    }

    public void LoadItemsToUI() {
        for (int i = 0; i < itemsToLoad.Count; i++) {
            if (i < allSlots.Count) {
                // Spawn prefab item ke dalam slot
                GameObject newItemObj = Instantiate(inventoryItemPrefab, allSlots[i].transform);
                InventoryItem itemScript = newItemObj.GetComponent<InventoryItem>();

                if (itemScript != null) {
                    itemScript.InitialiseItem(itemsToLoad[i]);
                }
            }
        }
    }
}