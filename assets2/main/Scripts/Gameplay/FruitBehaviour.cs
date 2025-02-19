using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBehaviour : MonoBehaviour
{

    public bool isTrigger = false;
    private InventoryScript inventoryScript;

    void Start(){
        GameObject logic = GameObject.Find("InventoryLogic");
        inventoryScript = logic.GetComponent<InventoryScript>();
    }


    void Update(){
        if (isTrigger)
        {
            inventoryScript.inventory.Add(gameObject);
            gameObject.SetActive(false);
        }
    }
}
