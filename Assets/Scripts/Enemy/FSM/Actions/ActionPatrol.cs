using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPatrol : FSMAction
{
    [Header("Config")]
    [SerializeField] private float speed;
    private WayPoint waypoint;
    private int pointIndex;
    private Vector3 nextPosition;

    private void Awake()
    {
        waypoint = GetComponent<WayPoint>();
    }

    public override void Act()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        transform.position = Vector3.MoveTowards(transform.position, GetCurrentPosition(), speed*Time.deltaTime);
        if(Vector3.Distance(transform.position, GetCurrentPosition()) <= 0.1f){

            UpdateNextPostition();
        }
    }

    private void UpdateNextPostition()
    {
        pointIndex++;
        if(pointIndex > waypoint.Points.Length - 1)
        {
            pointIndex = 0;
        }
    }

    private Vector3 GetCurrentPosition()
    {
        return waypoint.GetPostion(pointIndex);
    }
}
