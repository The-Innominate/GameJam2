//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class IsometricCharacterRenderer : MonoBehaviour
//{
//    public static readonly string[] staticDirections = { "Static N", "Static NW", "Static W", "Static SW", "Static S", "Static SE", "Static E", "Static NE" };
//    public static readonly string[] runDirections = { "Run N", "Run NW", "Run W", "Run SW", "Run S", "Run SE", "Run E", "Run NE" };

//    Animator animator;
//    int lastDirection;

//    private void Awake()
//    {
//        //Get the animator component
//        animator = GetComponent<Animator>();
//    }

//    public void SetDirection(Vector2 direction)
//    {
//        //Use the Run states by default
//        string[] directionArray = null;

//        //If the direction is close to a cardinal direction
//        if (direction.magnitude < 0.1f)
//        {
//            //If the y value is positive, use the Up animations
//            //Otherwise use the Down animations

//            directionArray = staticDirections;
//        }
//        else
//        {
//            //If the x value is positive, use the Right animations
//            //Otherwise use the Left animations
//            directionArray = runDirections;
//            lastDirection = DirectionToIndex(direction, 8);
//        }

//        animator.Play(directionArray[lastDirection]);
//    }

//    public static int DirectionToIndex(Vector2 dir, int sliceCount)
//    {
//        //Get the normalized direction
//        Vector2 normDir = dir.normalized;
//        //Calculate how many degrees one slice is
//        float step = 360f / sliceCount;
//        float halfStep = step / 2;
//        //Calculate how many degrees the direction is in
//        float angle = Vector2.SignedAngle(Vector2.up, normDir);
//        angle += halfStep;
//        if (angle < 0)
//        {
//            angle += 360;
//        }
//        float stepCount = angle / step;
//        //Calculate which slice this angle is in
//        //int slice = (int)((angle + halfStep) / step);
//        //return slice % sliceCount;
//        return Mathf.FloorToInt(stepCount);
//    }


//}
