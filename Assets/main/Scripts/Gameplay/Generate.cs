using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    public GameObject enemies;

    void Start(){
        InvokeRepeating("CreateObstacle", 1f, 1.5f);
    }

    void CreateObstacle()
    {
        Instantiate(enemies);
    }
}


