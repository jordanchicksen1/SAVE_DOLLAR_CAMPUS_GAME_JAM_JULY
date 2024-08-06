using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DoorRoatorManager : MonoBehaviour
{
    //public GameObject Door;
    public float Timer;

    [SerializeField]
    private float MaxTimeLeft;
    [SerializeField]
    private float MaxTimeRight;
    [SerializeField]
    private float MaxTimeUp;
    [SerializeField]
    private float MaxTimeDown;

    /*public Vector3 upDoorPosition;
    public Vector3 rightDoorPosition;
    public Vector3 downDoorPosition;
    public Vector3 leftDoorPosition;*/

    public GameObject UpPoint;
    public GameObject RightPoint;
    public GameObject LeftPoint;
    public GameObject DownPoint;

    public GameObject UpPoint1;
    public GameObject RightPoint1;
    public GameObject LeftPoint1;
    public GameObject DownPoint1;


    private void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > MaxTimeUp) 
        {
             UpPoint.SetActive(false);
             RightPoint.SetActive(true);
            UpPoint1.SetActive(false);
            RightPoint1.SetActive(true);
        }

        if (Timer > MaxTimeRight) 
        {
             RightPoint.SetActive(false);
             DownPoint.SetActive(true);
            RightPoint1.SetActive(false);
            DownPoint1.SetActive(true);
        }

        if (Timer > MaxTimeDown)
        {
             DownPoint.SetActive(false);
             LeftPoint.SetActive(true);
            DownPoint1.SetActive(false);
            LeftPoint1.SetActive(true);
        }

        if(Timer > MaxTimeLeft) 
        {
            LeftPoint.SetActive(false);
            UpPoint.SetActive(true);
            LeftPoint1.SetActive(false);
            UpPoint1.SetActive(true);
            Timer = 0;
        }
    }

  
}
