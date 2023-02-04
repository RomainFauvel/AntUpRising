using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBehaviour : MonoBehaviour
{

    private EnemiesControler behaviour;
    public CircleCollider2D col2D;
    public float aggroRadius=3;
    public float unAggroRadius=4;
    

    // Start is called before the first frame update
    void Start()
    {
        behaviour = gameObject.GetComponentInParent<EnemiesControler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (behaviour.isTrigger)
        {
            col2D.radius = unAggroRadius;
        }
        else {
            col2D.radius = aggroRadius;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && behaviour != null)
        {
            behaviour.isTrigger=true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && behaviour != null)
        {
            behaviour.isTrigger=false;
        }
    }

}
