using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;
using System;

public class PaddleScript : MonoBehaviour {

    private Transform Paddle;
    private Pose _lastPose = Pose.Unknown;
    public GameObject myo = null;
    public float speed;
    public float rightScreenEdge;
    public float leftScreenEdge;
    public GameManager gm;
    public BallScript bs;

    // Use this for initialization
    void Start () {
        Paddle = GameObject.FindGameObjectWithTag("Player").transform;
        Paddle = gameObject.GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {

        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();
        if (gm.gameOver)
        {
            return;
        }
        
        

        if (thalmicMyo.pose != _lastPose)
        {
            float xm = 0;
            float x = 0;

            float horizontal = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right * horizontal * Time.deltaTime * xm);

            xm -= 150 * Time.deltaTime;
            x += 150 * Time.deltaTime;

            _lastPose = thalmicMyo.pose;
            //make the paddlre turn left
            if (Paddle.position.x > leftScreenEdge && thalmicMyo.pose == Pose.WaveIn)
            {
                // Vibrate the Myo armband when a FingersSpread is made.
                thalmicMyo.Vibrate(VibrationType.Short);
                Paddle.Translate(new Vector3(xm, 0, 0), Space.Self);
                ExtendUnlockAndNotifyUserAction(thalmicMyo);
            }
            //make the paddle turn right
            if (transform.position.x < rightScreenEdge && thalmicMyo.pose == Pose.WaveOut)
            {
                // Vibrate the Myo armband when a FingersSpread is made.
                thalmicMyo.Vibrate(VibrationType.Short);
                Paddle.Translate(new Vector3(x, 0, 0), Space.Self);
                ExtendUnlockAndNotifyUserAction(thalmicMyo);
            }
        }
    }
    

    private void OnTriggerEnter2D(Collider2D other)
     {
        if (other.CompareTag("extraLife"))
        {
            gm.UpdateLives(1);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("fasterSpeed"))
        {
            bs.speed = bs.speed + 50;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("lowerSpeed"))
        {
            bs.speed = bs.speed - 50;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("widePaddle"))
        {
            GetComponent<Transform>().localScale = new Vector2(20, 2f);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("thinPaddle"))
        {
            GetComponent<Transform>().localScale = new Vector2(10, 2f);
            Destroy(other.gameObject);
        }


    }

   

    void ExtendUnlockAndNotifyUserAction(ThalmicMyo myo)
    {
        ThalmicHub hub = ThalmicHub.instance;

        if (hub.lockingPolicy == LockingPolicy.Standard)
        {
            myo.Unlock(UnlockType.Timed);
        }

        myo.NotifyUserAction();
    }
}
