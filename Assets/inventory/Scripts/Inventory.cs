using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Inventory : MonoBehaviour
{
    public static Inventory Singleton;
    public static InventoryItem carriedItem;
    public int k;
    public GameObject kafa;
    public GameObject g�vde;
    public GameObject ayak;
    public GameObject pantalon;
    public GameObject kilic;
    public int armorHead;
    public int armorChest;
    public int armorLegs;
    public int armorfeet;
    public int totalarmor;
    public TextMeshProUGUI armortext;
    public TextMeshProUGUI swordpower;
    [SerializeField] InventorySlot[] inventorySlots;
    [SerializeField] InventorySlot[] hotbarSlots;

    // 0=Head, 1=Chest, 2=Legs, 3=Feet
    [SerializeField] InventorySlot[] equipmentSlots;

    [SerializeField] Transform draggablesTransform;
    [SerializeField] InventoryItem itemPrefab;

    [Header("Item List")]
    [SerializeField] Item[] items;

    [Header("Debug")]
    [SerializeField] Button giveItemBtn;
    void Awake()
    {
        
        Singleton = this;
        giveItemBtn.onClick.AddListener( delegate { SpawnInventoryItem(); } );
    }
    private void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            SpawnInventoryItem();
        }
        

    }
    void Update()
    {
        if(carriedItem == null) return;

        carriedItem.transform.position = Input.mousePosition;
       
       
    }

    public void SetCarriedItem(InventoryItem item)
    {
        if(carriedItem != null)
        {
            if(item.activeSlot.myTag != SlotTag.None && item.activeSlot.myTag != carriedItem.myItem.itemTag) return;
            item.activeSlot.SetItem(carriedItem);
        }

        if(item.activeSlot.myTag != SlotTag.None)
        { EquipEquipment(item.activeSlot.myTag, null); }

        carriedItem = item;
        carriedItem.canvasGroup.blocksRaycasts = false;
        item.transform.SetParent(draggablesTransform);
    }

    public void EquipEquipment(SlotTag tag, InventoryItem item = null)
    {
        switch (tag)
        {
            case SlotTag.Head:
                if(item == null)
                {
                    // Destroy item.equipmentPrefab on the Player Object;
                    Debug.Log("Unequipped helmet on " + tag);
                }
                else
                {
                    // Instantiate item.equipmentPrefab on the Player Object;
                    Debug.Log("Equipped " + item.myItem.name + " on " + tag);
                    kafa.SetActive(true);
                    armorHead = 20;
                    totalarmor += armorHead;
                    armortext.text = "Defence: " + totalarmor;
                }
                break;
            case SlotTag.Chest:
                if (item == null)
                {
                    // Destroy item.equipmentPrefab on the Player Object;
                    Debug.Log("Unequipped helmet on " + tag);
                }
                else
                {
                    // Instantiate item.equipmentPrefab on the Player Object;
                    Debug.Log("Equipped " + item.myItem.name + " on " + tag);
                    g�vde.SetActive(true);
                    armorChest = 30;
                    totalarmor += armorChest;
                    armortext.text = "Defence: " + totalarmor;
                }
                break;
            case SlotTag.Legs:
                if (item == null)
                {
                    // Destroy item.equipmentPrefab on the Player Object;
                    Debug.Log("Unequipped helmet on " + tag);
                }
                else
                {
                    // Instantiate item.equipmentPrefab on the Player Object;
                    Debug.Log("Equipped " + item.myItem.name + " on " + tag);
                    pantalon.SetActive(true);
                    armorLegs = 10;
                    totalarmor += armorLegs;
                    armortext.text = "Defence: " + totalarmor;
                }
                break;
            case SlotTag.Feet:
                if (item == null)
                {
                    // Destroy item.equipmentPrefab on the Player Object;
                    Debug.Log("Unequipped helmet on " + tag);
                }
                else
                {
                    // Instantiate item.equipmentPrefab on the Player Object;
                    Debug.Log("Equipped " + item.myItem.name + " on " + tag);
                    ayak.SetActive(true);
                    armorfeet = 5;
                    totalarmor += armorfeet;
                    armortext.text = "Defence: " + totalarmor;
                }
                break;
            case SlotTag.Sword:
                if (item == null)
                {
                    // Destroy item.equipmentPrefab on the Player Object;
                    Debug.Log("Unequipped helmet on " + tag);
                }
                else
                {
                    // Instantiate item.equipmentPrefab on the Player Object;
                    Debug.Log("Equipped " + item.myItem.name + " on " + tag);
                    kilic.SetActive(true);
                    swordpower.text = "Bow: " + 50;
                }
                break;
        }
    }

    public void SpawnInventoryItem(Item item = null)
    {
        Item _item = item;
        if(_item == null)
        { _item = PickRandomItem(); }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            // Check if the slot is empty
            if(inventorySlots[i].myItem == null)
            {
                Instantiate(itemPrefab, inventorySlots[i].transform).Initialize(_item, inventorySlots[i]);
                break;
            }
        }
    }

    Item PickRandomItem()
    {

        k++;

        //int random = Random.Range(0, items.Length);
        return items[k];
    }
}
