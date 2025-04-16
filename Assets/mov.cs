using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov : MonoBehaviour
{
    private int currentLane = 1;
    public float laneDistance = 2f;
    public float moveSpeed = 5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane > 0)
            currentLane--;
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane < 2)
            currentLane++;

        Vector3 targetPos = transform.position;
        targetPos.x = (currentLane - 1) * laneDistance;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
}
