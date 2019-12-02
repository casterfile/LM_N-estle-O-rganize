using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GlobalFunction : MonoBehaviour {

	private GameObject WallTobeDelete, Balls,CanObject, CanManager1, CanManager2, CanManager3, Caption1, Confetti1, Confetti2, Confetti3;
	public bool isDeleteTopWall = false, isFallObject = false, isGameEnd = false,isGameLose = false, isPlayOnceOpen = false, isPlayOnceEnd = false, isTimerStart;
	public int countShaking = 0;
	public Animator Anim_Can;
	private  GameObject[] AnimationBalls;
	private Text TimerCounter;
	private float timeLeft = 60;
	// Use this for initialization
	void Start () {
		countShaking = 0;
		isDeleteTopWall = false;

		AnimationBalls = GameObject.FindGameObjectsWithTag ("AnimationBalls");
		WallTobeDelete = GameObject.Find("WallTobeDelete");
		Balls = GameObject.Find("Balls");
		CanObject = GameObject.Find("CanObject");
        CanManager1 = GameObject.Find("CanManager1");
        CanManager2 = GameObject.Find("CanManager2");
        CanManager3 = GameObject.Find("CanManager3");
        //Caption1 = GameObject.Find("Caption1");
		TimerCounter = GameObject.Find("TimerCounter").GetComponent<Text>();
		TimerCounter.text = "";
		Confetti1 = GameObject.Find("CanManager1/CAN/Confetti");
        Confetti2 = GameObject.Find("CanManager2/CAN/Confetti");
        Confetti3 = GameObject.Find("CanManager3/CAN/Confetti");

        Balls.SetActive(false);
        CanManager1.SetActive(false);
        CanManager2.SetActive(false);
        CanManager3.SetActive(false);
        //Caption1.SetActive(false);
		Confetti1.SetActive(false);
        Confetti2.SetActive(false);
        Confetti3.SetActive(false);

        DeleteTopWall();
	}
	
	// Update is called once per frame
	void Update () {
		if(isDeleteTopWall == true && isPlayOnceOpen == false){
			isPlayOnceOpen = true;
            CanManager1.SetActive(true);
            CanManager2.SetActive(true);
            CanManager3.SetActive(true);
            CanObject.SetActive(false);
			CanObject.GetComponent<Collider>().enabled = false;
			CanObject.transform.localPosition = new Vector3(0f, -1.806f, -2.648594f);
			CanObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
			StartCoroutine(PlayAnimationCaption(6.0f));
			StartCoroutine(PlayAnimation(4.0f));
		}

		// if(countShaking >= 200){
		// 	DeleteTopWall();
		// }
		if(isFallObject == true){
			if(GameObject.FindGameObjectsWithTag("fry").Length == 0) {
				if(isPlayOnceEnd == false){
					isPlayOnceEnd = true;
					StartCoroutine(PlayAnimationEnd(2.0f));
				}
		 	}
		}

		if(isTimerStart == true){
			 timeLeft -= Time.deltaTime;
			 int secInt = (int)timeLeft;
			 TimerCounter.text = "Timer: "+secInt;
		     if ( timeLeft < 0 )
		     {
		     	TimerCounter.text = "";
		     	isGameLose = true;
		     	isTimerStart = false;
		        print("End game");
		     }
		}
		
	}


	public void DeleteTopWall(){
		
		isDeleteTopWall = true;
		
	}

	IEnumerator PlayAnimation(float Delay)
    {
        Anim_Can.SetInteger("AnimationNum", 1);
        yield return new WaitForSeconds(Delay);
        
		for(var i = 0 ; i < AnimationBalls.Length ; i ++)
		{
		 	AnimationBalls[i].SetActive(false);
		}

        Balls.SetActive(true);
		
		WallTobeDelete.SetActive(false);
		isFallObject = true;
		

    }

    IEnumerator PlayAnimationEnd(float Delay)
    {
    	isTimerStart = false;
    	TimerCounter.text = "";
		Anim_Can.SetInteger("AnimationNum", 2);
		yield return new WaitForSeconds(1.0f);
		// for(var i = 0 ; i < AnimationBalls.Length ; i ++)
		// {
		//  	AnimationBalls[i].SetActive(true);
		// }

        
        yield return new WaitForSeconds(5.0f);
        isGameEnd = true;
    }

    IEnumerator PlayAnimationCaption(float Delay)
    {
    	
		//Caption1.SetActive(true);
		yield return new WaitForSeconds(Delay);
        //Caption1.SetActive(false);
        isTimerStart = true;
    }

    public void PlayConfetti1(){
    	StartCoroutine(PlayAnimationPlayConfetti1(2.0f));
    }

    IEnumerator PlayAnimationPlayConfetti1(float Delay)
    {
    	
		Confetti1.SetActive(true);
		yield return new WaitForSeconds(Delay);
        Confetti1.SetActive(false);
    }

    public void PlayConfetti2()
    {
        StartCoroutine(PlayAnimationPlayConfetti2(2.0f));
    }

    IEnumerator PlayAnimationPlayConfetti2(float Delay)
    {

        Confetti2.SetActive(true);
        yield return new WaitForSeconds(Delay);
        Confetti2.SetActive(false);
    }

    public void PlayConfetti3()
    {
        StartCoroutine(PlayAnimationPlayConfetti3(2.0f));
    }

    IEnumerator PlayAnimationPlayConfetti3(float Delay)
    {

        Confetti3.SetActive(true);
        yield return new WaitForSeconds(Delay);
        Confetti3.SetActive(false);
    }

}
