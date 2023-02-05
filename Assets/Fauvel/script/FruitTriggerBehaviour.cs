using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitTriggerBehaviour : MonoBehaviour
{
    private FruitBehaviour behaviour;
    private CircleCollider2D col2D;


    // Start is called before the first frame update
    void Start()
    {
        col2D = gameObject.GetComponent<CircleCollider2D>();
        behaviour = gameObject.GetComponentInParent<FruitBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && behaviour != null)
        {
            behaviour.isTrigger = true;
        }
    }
}
