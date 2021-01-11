using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public Transform player3;

    void Update()
    {
     transform.position = new Vector3 (player1.position.x+3 , 0, -10);
     //transform.position = new Vector3 (player2.position.x+3 , 0, -10);
     //transform.position = new Vector3 (player3.position.x+3 , 0, -10);
    }
}
