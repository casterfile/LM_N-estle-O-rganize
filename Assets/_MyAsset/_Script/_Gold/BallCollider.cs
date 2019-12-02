using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(AudioSource))]
public class BallCollider : MonoBehaviour {
	private Transform target;
	private float speed = 80;
	private bool isHit = false, isResetBall = false;
	// Use this for initialization
	public AudioClip Effect1;
	public AudioSource audioData;
    private string TargetName;
    private string isRight;
    private GameObject BallReset;
    private int WhatBall;


    GameObject Canvas, Balls;
	GlobalFunction GFunction;
    Spawner GSpawner;

    void Start () {
//		audioData = GetComponent<AudioSource>();
		Canvas = GameObject.Find("Canvas");
        BallReset = GameObject.Find("BallReset");
        GFunction = Canvas.GetComponent<GlobalFunction>();

        Balls = GameObject.Find("Balls");
        GSpawner = Balls.GetComponent<Spawner>();
    }
	
	// Update is called once per frame
	void Update () {
		if(isHit == true){
            //print(gameObject.name+ " gameObject.name II "+ TargetName + " TargetName");
            if (gameObject.name == "Target1")
            {
                WhatBall = 1;
            }
            else if (gameObject.name == "Target2")
            {
                WhatBall = 2;
            }
            else if (gameObject.name == "Target3")
            {
                WhatBall = 3;
            }

            if (gameObject.name == TargetName)
            {
                //print("Right");
                isRight = "Right";
            }
            else
            {
                //print("Wrong");
                isRight = "Wrong";
            }

            float step = speed * Time.deltaTime;
            
            target = GameObject.Find(TargetName).GetComponent<Transform>();
            if (isResetBall == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            }
            

            
		}

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ButtomGapReset")
        {
            print("Data");
            if (gameObject.name == "Target1")
            {
                WhatBall = 1;
            }
            else if (gameObject.name == "Target2")
            {
                WhatBall = 2;
            }
            else if (gameObject.name == "Target3")
            {
                WhatBall = 3;
            }

            GSpawner.SpawnObject(WhatBall);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter (Collision col)
	{
        if (col.gameObject.name == "ButtomGapReset")
        {
            print("Data");
            if (gameObject.name == "Target1")
            {
                WhatBall = 1;
            }
            else if (gameObject.name == "Target2")
            {
                WhatBall = 2;
            }
            else if (gameObject.name == "Target3")
            {
                WhatBall = 3;
            }

            GSpawner.SpawnObject(WhatBall);
            Destroy(gameObject);
        }

        if (col.gameObject.name == "Entercan1")
		{
            TargetName = "Target1";
            isHit = true;	
			AudioSound ();
			StartCoroutine(NextMove(col.gameObject));
		}

		if(col.gameObject.name == "Target1"){
			if (isHit == true) {

                if (isRight == "Right")
                {

                    GFunction.PlayConfetti1();
                    GetComponent<Rigidbody>().detectCollisions = false;
                    GetComponent<Rigidbody>().isKinematic = false;

                    Destroy(GetComponent<Rigidbody>());
                    GlobalVar.GlobalScore++;
                    GetComponent<Collider>().enabled = false;
                    print("GlobalVar.GlobalScore: " + GlobalVar.GlobalScore);
                    Destroy(gameObject);
                }
                else
                {
                    isHit = false;
                    isResetBall = true;

                    if (isResetBall == true)
                    {
                        GSpawner.SpawnObject(WhatBall);
                        isHit = false;
                        Destroy(gameObject);
                    }
                }
                
			}
		}


        if (col.gameObject.name == "Entercan2")
        {
            TargetName = "Target2";
            isHit = true;
            AudioSound();
            StartCoroutine(NextMove(col.gameObject));
        }

        if (col.gameObject.name == "Target2")
        {
            if (isHit == true)
            {


                if (isRight == "Right")
                {
                    GFunction.PlayConfetti2();
                    GetComponent<Rigidbody>().detectCollisions = false;
                    GetComponent<Rigidbody>().isKinematic = false;

                    Destroy(GetComponent<Rigidbody>());
                    GlobalVar.GlobalScore++;
                    GetComponent<Collider>().enabled = false;
                    print("GlobalVar.GlobalScore: " + GlobalVar.GlobalScore);
                    Destroy(gameObject);
                }
                else
                {
                    isHit = false;
                    isResetBall = true;

                    if (isResetBall == true)
                    {
                        GSpawner.SpawnObject(WhatBall);
                        isHit = false;
                        //StartCoroutine(DelayReset());
                        Destroy(gameObject);
                    }
                }
            }
        }

        if (col.gameObject.name == "Entercan3")
        {
            TargetName = "Target3";
            isHit = true;
            AudioSound();
            StartCoroutine(NextMove(col.gameObject));
        }

        if (col.gameObject.name == "Target3")
        {
            if (isHit == true)
            {


                if (isRight == "Right")
                {
                    GFunction.PlayConfetti3();
                    GetComponent<Rigidbody>().detectCollisions = false;
                    GetComponent<Rigidbody>().isKinematic = false;

                    Destroy(GetComponent<Rigidbody>());
                    GlobalVar.GlobalScore++;
                    GetComponent<Collider>().enabled = false;
                    print("GlobalVar.GlobalScore: " + GlobalVar.GlobalScore);
                    Destroy(gameObject);
                }
                else
                {
                    isHit = false;
                    isResetBall = true;

                    if (isResetBall == true)
                    {
                        GSpawner.SpawnObject(WhatBall);
                        isHit = false;
                        //StartCoroutine(DelayReset());
                        Destroy(gameObject);
                    }
                }
            }
        }
    }

	IEnumerator NextMove(GameObject gm)
	{

		yield return new WaitForSeconds(3);


	}



	private void AudioSound(){
		audioData.PlayOneShot(Effect1, 0.7F);
	}
}
