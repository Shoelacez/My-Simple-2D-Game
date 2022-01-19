using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private Vector3  tempPos;
    [SerializeField] private float minX,maxX;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        tempPos=this.transform.position;
        tempPos.x=player.transform.position.x;

        //Bounding the camera 
        if (tempPos.x<minX)
        {
            tempPos.x=minX;
        }

        if (tempPos.x>maxX)
        {
            tempPos.x=maxX;
        }

        //finally assigning tempPos to camera's position 
        this.transform.position=tempPos;
    }
}
