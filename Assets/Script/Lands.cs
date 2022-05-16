using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lands : MonoBehaviour
{
    public GameObject land;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StopMove()
    {
        gameObject.BroadcastMessage("StopMove");
    }
}
