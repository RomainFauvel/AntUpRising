using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour{
    public List<GameObject> inventory = new();
    public Text itemCount;

    // Update is called once per frame
    void Update()
    {
        itemCount.text = inventory.Count.ToString();

    }
}
