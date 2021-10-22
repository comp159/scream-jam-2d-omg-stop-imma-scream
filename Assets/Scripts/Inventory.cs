using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool inventoryEnabled;
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject slot;
    [SerializeField] private GameObject slot2;
    //[SerializeField] private GameObject slot3;
    //[SerializeField] private GameObject slot4;
    //[SerializeField] private GameObject slot5;
    //[SerializeField] private GameObject slot6;
    //[SerializeField] private GameObject slot7;
    //[SerializeField] private GameObject slot8;

    private bool hasKey = false;
    
    // Start is called before the first frame update
    void Start()
    {
        slot.SetActive(false);
        slot2.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        inventorySlots();

        if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
        }

        if (inventoryEnabled == true)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }
    }
    
    void inventorySlots()
    {
        if (itemCollision.item1 == 1)
        {
            slot.SetActive(true);
            hasKey = true;
        }
        
        if (itemCollision.item2 == 1)
        {
            slot2.SetActive(true);
        }
    }

    public bool HasKey()
    {
        return hasKey;
    }
}
