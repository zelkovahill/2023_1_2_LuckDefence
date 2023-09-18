using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Enemy_Speed = 2;
    public Transform[] wayPoint;

    private int WayPointIndex = 0;

    private void Start()
    {
        transform.position = wayPoint[WayPointIndex].position;
    }

    private void Update()
    {
        Vector3 direction = wayPoint[WayPointIndex].position - transform.position;
        transform.Translate(direction.normalized*Enemy_Speed*Time.deltaTime,Space.World);

        if (Vector3.Distance(transform.position, wayPoint[WayPointIndex].position) < 0.1f)
        {
            WayPointIndex = (WayPointIndex + 1) % wayPoint.Length;
        }
    }
}