using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Header("UI Reference")]
    public Image image;

    [Header("Item Data")]
    public ItemData itemData;

    [HideInInspector] public Transform parentAfterDrag;

    private void Awake() {
        if (image == null) {
            image = GetComponent<Image>();
        }
    }

    private void Start() {
        InitialiseItem(itemData);
    }

    public void InitialiseItem(ItemData newItem) {
        itemData = newItem;
        if (image == null) image = GetComponent<Image>();

        if (itemData != null && image != null) {
            image.sprite = itemData.icon;
        }
    }

    // --- Efek Hover Mouse ---
    public void OnPointerEnter(PointerEventData eventData) {
        if (itemData != null && ItemDetailsUI.instance != null) {
            ItemDetailsUI.instance.ShowDetails(itemData);
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (ItemDetailsUI.instance != null) {
            ItemDetailsUI.instance.HideDetails();
        }
    }

    // --- Drag and Drop Logic ---
    public void OnBeginDrag(PointerEventData eventData) {
        if (ItemDetailsUI.instance != null) {
            ItemDetailsUI.instance.HideDetails();
        }

        if (image != null) image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData) {
        if (Mouse.current != null) {
            transform.position = Mouse.current.position.ReadValue();
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        if (image != null) image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }
}