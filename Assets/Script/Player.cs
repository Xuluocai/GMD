using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float posLeft = -3.5F;
    public float posRight = 3.5F;
    public float rotateSpeed = 10F;
    public float jumpGravity = 500F;
    public float gameTime = 30f;
    public AudioClip getCoin;
    public AudioClip addSec;
    public AudioClip jumpS;
    public Text coinText;
    public Text hpnum;
    public Text textH;
    public Text t1;
    public Text h2;
    
    int coinNum = 0;
    int hp = 5;
    Rigidbody rg;
    MeshRenderer render;
    bool canJump = true;
    float dstmeTime;


    // Start is called before the first frame update
    void Start()
    {
        dstmeTime = gameTime-60;
        t1.text = dstmeTime.ToString();
        StartCoroutine(countDown());
        render = this.transform.GetComponentInChildren<MeshRenderer>();
        rg = this.GetComponent<Rigidbody>();
    }
    IEnumerator countDown()
    {
        while (dstmeTime > 0)
        {
            yield return new WaitForSeconds(1.0f);
            dstmeTime--;
            t1.text = dstmeTime.ToString();
        }
        textH.text = "GameOver";
        Stop();
    }
    void FixedUpdate()
    {
        
        if (Input.GetKeyDown(KeyCode.W) && canJump)
        {
            AudioSource.PlayClipAtPoint(jumpS, this.transform.position);
            rg.velocity = Vector2.up * jumpGravity;
            canJump = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
     //t1.text = ((int)(gameTime - Time.time)).ToString();
 //     if(Time.time>=gameTime)
   //   {
   //       //Stop();
  //        t1.text = "0";
   //   }
  

        transform.Rotate(Vector3.forward * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            moveRight();
        }
    }
    void moveLeft()
    {

        if (transform.position.x > 0)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
        else if (transform.position.x == 0)
        {
            transform.position = new Vector3(posLeft, transform.position.y, transform.position.z);
            canJump = false;
        }
    }

    void moveRight()
    {

        if (transform.position.x < 0)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
        else if (transform.position.x == 0)
        {
            transform.position = new Vector3(posRight, transform.position.y, transform.position.z);
            canJump = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
       switch (col.gameObject.tag)
       {
           case "Land":
              canJump = true;
               break;
            case "Wall":
                hp--;
                Destroy(col.gameObject);
                hpnum.text = "HP:" + ((float)hp / 5 * 100).ToString() + "%";
                if (hp == 0)
                {
                    textH.text = "You Failed";
                 Stop();
                }
                break;
            case"Add5Sec":
                Destroy(col.gameObject);
                AudioSource.PlayClipAtPoint(addSec, this.transform.position);
                h2.text = "Time + 5s !";
                h2.GetComponent<Animation>().Play("H2");
                this.dstmeTime += 5;
                break;
      }
    }
    void OnTriggerEnter(Collider col)
    {
      switch (col.gameObject.tag)
       {
           case "Coin":
               AudioSource.PlayClipAtPoint(getCoin, this.transform.position);
                coinNum++;
               coinText.text = coinNum.ToString();
               Destroy(col.gameObject);
                break;
        }
    }
    void Stop()
    {
        Application.Quit();
    }
}
