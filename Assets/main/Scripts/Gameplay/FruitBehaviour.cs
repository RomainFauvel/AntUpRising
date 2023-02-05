using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBehaviour : MonoBehaviour
{

    public bool isTrigger = false;
    private InventoryScript inventoryScript;
    // Start is called before the first frame update
    void Start()
    {
        GameObject logic = GameObject.Find("InventoryLogic");
        inventoryScript = logic.GetComponent<InventoryScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrigger)
        {
            inventoryScript.inventory.Add(gameObject);
            gameObject.SetActive(false);
        }
    }
}
