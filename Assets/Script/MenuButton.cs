using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public bool isPlay=true;
    public bool isIntroduction = false;
    public bool isExit = false;
    public Text t;
    Button btn;
    // Start is called before the first frame update
    void Start()
    {
       // btn = this.transform.Find("Panel/Start").GetComponent<Button>();
     //   btn.onClick.Addlistener(JumpToGame);
    }

  //  void JumpToGame()
  //  {
    //    LoadScene.SceneName = "Game";
  //  }
    // Update is called once per frame
    void Update()
    {
        
    }
  public  void OnClick()
    {
        if (isPlay)
        {
            Application.LoadLevel("game");
        }else if (isIntroduction)
        {
            t.SendMessage("ShowOnce", "A:Left,D:Right,W:Jump");
        }else{
            Application.Quit();
        }
    }
}
