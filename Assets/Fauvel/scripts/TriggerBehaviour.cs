using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBehaviour : MonoBehaviour
{

    private EnnemyBehaviour behaviour;

    // Start is called before the first frame update
    void Start()
    {
        behaviour = gameObject.GetComponentInParent<EnnemyBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && behaviour != null)
        {
            behaviour.getTrigger();
        }
    }
}
