using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticBlockMovement : MonoBehaviour
{
    public Vector3 targetPos1;
    public Vector3 targetPos2;
    public float moveTime;
    float curMoveProportion = 0;
    Vector3 targetPos = Vector3.zero;
    Vector3 prevPos = Vector3.zero;
 // in Start, set up whichever is the first position to be going to
 void Start()
 {
     targetPos = targetPos2;
     transform.position = targetPos1;
     prevPos = transform.position;
 }
 // in Update, move the box around between the two points
 void Update()
 {
     curMoveProportion += (Time.deltaTime / moveTime);
     if(curMoveProportion >= 1)
     {
         if(targetPos == targetPos1)
         {
             targetPos = targetPos2;
         } else {
             targetPos = targetPos1;
         }
         prevPos = transform.position;
         curMoveProportion = 0;
     }
     transform.position = Vector3.Lerp(prevPos, targetPos, curMoveProportion);
 }
}
