using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	
	public GameObject BackgroundWin,BackgroundLose;
	public string SceneName;
    public static string btnAnimate = "";
    public static float targetTime = 3.0f;
    private GameObject Servay, A11, A22, A33, A44, A55;
    bool isServayEnd = false;
    GameObject Canvas;
	GlobalFunction GFunction;
	// Use this for initialization
	void Start () {
		BackgroundWin.SetActive (false);
		BackgroundLose.SetActive (false);
		Canvas = GameObject.Find("Canvas");

        A11 = GameObject.Find("A11");
        A22 = GameObject.Find("A22");
        A33 = GameObject.Find("A33");
        A44 = GameObject.Find("A44");
        A55 = GameObject.Find("A55");
        Servay = GameObject.Find("Servay");

        A11.SetActive(false);
        A22.SetActive(false);
        A33.SetActive(false);
        A44.SetActive(false);
        A55.SetActive(false);

        Servay.SetActive(false);
        GFunction = Canvas.GetComponent<GlobalFunction>();
	}
	
	// Update is called once per frame
	void Update () {
		if(GlobalVar.GlobalScore >= 5){
			
		}
		// print("count:"+GameObject.FindGameObjectsWithTag("fry").Length);
		if(GFunction.isGameEnd == true){
			if(GameObject.FindGameObjectsWithTag("fry").Length == 0) {
                if(isServayEnd == true)
                {
                    //Servay.SetActive(true);
                    BackgroundWin.SetActive(false);
                }
                else
                {
                    BackgroundWin.SetActive(true);
                    //Servay.SetActive(false);
                }
		 	}
		}

		if(GFunction.isGameLose == true && GFunction.isGameEnd == false){
			BackgroundLose.SetActive (true);
		}

		if (Input.GetKeyDown("r"))
        {
            RestartOnly();
        }

        if (Input.GetKeyDown("w"))
        {
            RestartOnly();
        }

        if (Input.GetKeyDown("e"))
        {
            RestartOnly();
        }

        if (btnAnimate == "A1")
        {
            //print("This is working A1");
            A11.SetActive(true);
            A22.SetActive(false);
            A33.SetActive(false);
            A44.SetActive(false);
            A55.SetActive(false);
            PlayButtonAnimation();
        }
        else if (btnAnimate == "A2")
        {
            //print("This is working A2");
            A11.SetActive(false);
            A22.SetActive(true);
            A33.SetActive(false);
            A44.SetActive(false);
            A55.SetActive(false);
            PlayButtonAnimation();
        }
        else if (btnAnimate == "A3")
        {
            //print("This is working A3");
            A11.SetActive(false);
            A22.SetActive(false);
            A33.SetActive(true);
            A44.SetActive(false);
            A55.SetActive(false);
            PlayButtonAnimation();
        }
        else if (btnAnimate == "A4")
        {
            //print("This is working A4");
            A11.SetActive(false);
            A22.SetActive(false);
            A33.SetActive(false);
            A44.SetActive(true);
            A55.SetActive(false);
            PlayButtonAnimation();
        }
        else if (btnAnimate == "A5")
        {
            //print("This is working A5");
            A11.SetActive(false);
            A22.SetActive(false);
            A33.SetActive(false);
            A44.SetActive(false);
            A55.SetActive(true);
            PlayButtonAnimation();
        }
        else if (btnAnimate == "Next")
        {
            //print("This is working A5");
            A11.SetActive(false);
            A22.SetActive(false);
            A33.SetActive(false);
            A44.SetActive(false);
            A55.SetActive(true);
            Restart();
            RestartOnly();
        }
        else
        {
            A11.SetActive(false);
            A22.SetActive(false);
            A33.SetActive(false);
            A44.SetActive(false);
            A55.SetActive(false);
        }
    }

	public void Restart(){
		
        isServayEnd = true;
    }

    void PlayButtonAnimation()
    {
        targetTime -= Time.deltaTime;
        print("targetTime: "+ targetTime);
        if (targetTime <= 0.0f)
        {
            Application.LoadLevel(SceneName);
        }
    }

    public void RestartOnly()
    {
        Application.LoadLevel(0);
    }
}
