# UI-project2019
 Brick Breaker game with MYO developing using Unity writing in c#.
 
> Module: Gesture Based UI Development / 4th Year  
> Lecturer: Dr Damien Costello     
> Students: Tianle Shu && Laura Obga 

This application is a local implementation of the application using gestures ([MYO](https://www.myo.com/)) to interact with it. User can use keyboard on PC, MYO armband to control this Brick Breaker Game.

## Feature demo (working with myo)
[![Watch the video](https://image.shutterstock.com/image-vector/youtube-web-video-player-play-260nw-634948040.jpg)](https://youtu.be/aJUlIwRjK6g)

## About Brick Breaker Game
Brick Breaker (platformer) is a Breakout clone in which the player must smash a wall of bricks by deflecting a bouncing ball with a paddle. The paddle may move horizontally and is controlled with the BlackBerry's trackwheel, the computer's mouse or the touch of a finger (in the case of touchscreen). When all the bricks have been destroyed, the player advances to a new level. There are 34 levels. There are many versions of brick breaker, some in which you can shoot flaming fireballs or play with more than one ball if the player gets a power up.

## What is myo armband
The Myo armband is a gesture recognition device worn on the forearm and manufactured by Thalmic Labs. The Myo enables the user to control technology wirelessly using various hand motions. It uses a set of electromyographic (EMG) sensors that sense electrical activity in the forearm muscles, combined with a gyroscope, accelerometer and magnetometer to recognize gestures. The Myo can be used to control video games, presentations, music and visual entertainment. It differs from the Leap Motion device as it is worn rather than a 3D array of cameras that sense motion in the environment.

Please click[Myo Armband Connect](https://developer.thalmic.com/downloads) to download Myo Connect and get more details information.

## About Myo Review
*Advantages:* </br>
+ Novel item.
+ Decent motion tracking.
+ Not much else.
</br>

*Disadvantages:* 
+ Uncomfortable for long usage periods.
+ Constant need to re-sync device.
+ Unpredictable behaviour when battery is low.

## Hardware used in creating the application
1.Myo-Armbard

2.Bluetooth connector

3.A windows Laptop.

## Gestures identified as appropriate for this application
The Myo armband recognises 5 pre-set gestures out of the box. They are:
![myo pose](https://github.com/TangqiFeng/K2048-UNITY-MYO/blob/img/myo%20pose.jpg)
Playing the game Brick Breaker: </br>
Pose like Fist: release the ball.</br>
Pose like Wave in(Wave Left): make the paddle turn left.</br>
Pose like Wave out(Wave Right): make the paddle turn right.</br>

## Architecture for the solution
For reference to how to control the main characters of the game, I refer to the official C# game code released by myo.</br>
For example:make game paddle turn to left
```c#
 //make the paddlre turn left
 if (Paddle.position.x > leftScreenEdge && thalmicMyo.pose == Pose.WaveIn)
 {
    // Vibrate the Myo armband when a FingersSpread is made.
    thalmicMyo.Vibrate(VibrationType.Short);
    Paddle.Translate(new Vector3(xm, 0, 0), Space.Self);
    ExtendUnlockAndNotifyUserAction(thalmicMyo);
 }
```
Turn to right:
```c#
//make the paddle turn right
if (transform.position.x < rightScreenEdge && thalmicMyo.pose == Pose.WaveOut)
{
    // Vibrate the Myo armband when a FingersSpread is made.
    thalmicMyo.Vibrate(VibrationType.Short);
    Paddle.Translate(new Vector3(x, 0, 0), Space.Self);
    ExtendUnlockAndNotifyUserAction(thalmicMyo);
}
```
Release the Ball:
```c#
if (thalmicMyo.pose != _lastPose) // let the ball release if gesture is fist
{
    if ((Input.GetButtonDown("Jump")  || thalmicMyo.pose == Pose.Fist) && !inPlay)
    {
      // Vibrate the Myo armband when a FingersSpread is made.
      thalmicMyo.Vibrate(VibrationType.Short);
      inPlay = true;
      rb.AddForce(Vector2.up * speed);
    }
}
```

## Achtecture diagram
![gamedesign](https://github.com/Tianle97/UI-project2019/blob/master/GameDesign.jpeg)

## Conclusion



## Reference
+ Brick Breaker : https://en.wikipedia.org/wiki/Brick_Breaker </br>
+ Get start with Myo-armband : https://support.getmyo.com/hc/en-us/articles/203398347-Getting-started-with-your-Myo-armband </br>
+ Setup Myo package in unity : https://developerblog.myo.com/setting-myo-package-unity/ </br>


