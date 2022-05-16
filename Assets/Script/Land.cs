using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    public float speed = 10F;
    public float startPosZ = -20f;
    public GameObject coin;
    public GameObject wideWall;
    public GameObject wall;
    public GameObject addsec;

   public bool isGameScene =true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0.0F, 0.0F, speed * Time.deltaTime);
        float z = transform.position.z;
        if (z <= -20)
        {
            
            clearObjects();
            setObjects();
            moveToFront();

        }
    }

    void moveToFront()
    {
        transform.position += new Vector3(0, 0, 120.0F);
    }

    void StopMove()
    {
        foreach (Transform child in transform)
        {
            this.speed = 0;
            gameObject.BroadcastMessage("StopMove");
        }
    }
    void clearObjects()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        
    }
    void setObjects()
    {
        float r = Random.Range(0f, 1f);
       if (r <= 0.25)
        {
            for (int i = 1; i < 2; i++)
            {
               bool Twide = Random.Range(0f, 1f) <= 0.01;
                GameObject obj;
               float x;
                if (Twide)
                {
                    obj = Instantiate(wideWall) as GameObject;

                   x = 0;
               }
                else
               {
                   obj = Instantiate(wall) as GameObject;
                    x = Random.Range(-1, 2) * 0.30f;
               }
               obj.transform.SetParent(this.transform);
                obj.transform.localPosition = new Vector3(x, 3f, -3f + i * 6f);
                
            }
        }
        else
        {
            int coinSide = Random.Range(0f, 1f) <= 0.5f ? -1 : 1;
            for (int i = 0; i < 8; i++)
            {
                GameObject obj;
                float r1 = Random.Range(0f, 1f);
                float posX = 0f;
                if (r1 <= 0.05f)
                {

                }
                else if (r1 <= 0.10f)
                {
                    obj = Instantiate(addsec) as GameObject;
                    posX = Random.Range(-1, 2) * 3.5f;
                    obj.transform.localPosition = new Vector3(posX, 0.58f, -4.0f + i);
                    obj.transform.SetParent(this.transform);
                }
                else if (r1 <= 0.15f)
                {

                }
                else
                {
                    obj = Instantiate(coin) as GameObject;
                    int r2 = Random.Range(0, 2) * coinSide;

                    posX = 3.5f * r2;

                    obj.transform.localPosition = new Vector3(posX, 0.58f, -4.0f + i);
                    obj.transform.SetParent(this.transform);
               
                }




            }
        }
    }
}
