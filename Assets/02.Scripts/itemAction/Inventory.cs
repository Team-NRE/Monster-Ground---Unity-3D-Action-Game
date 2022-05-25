using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items;
    public static bool inventoryActivated = true;
    public GameObject invenUI;

    [SerializeField]
    private Transform slotParent;

    [SerializeField]
    private Slot[] slots = new Slot[9];

    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }

    void Awake()
    {
        FreshSlot();
    }
    private void Update()
    {
        TryOpenInventory();
    }

    public void FreshSlot()
    {
        int i = 0;
        for(;i<items.Count && i < slots.Length; i++)
        {
            slots[i].item = items[i];
        }
        for (; i < slots.Length; i++)
        {
            slots[i].item = null;
        }
    }
    public void AddItem(Item _item)
    {
        if (items.Count < slots.Length)
        {
            items.Add(_item);
            FreshSlot();
        }
        else
        {
            Debug.Log("Slots all full");
        }
    }
    public void TryOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryActivated = !inventoryActivated;
            if (inventoryActivated)
                OpenInventory();

            else
                CloseInventory();
        }
    }
    private void OpenInventory()
    {
        invenUI.gameObject.SetActive(true);
    }

    private void CloseInventory()
    {
        invenUI.gameObject.SetActive(false);
    }

}
