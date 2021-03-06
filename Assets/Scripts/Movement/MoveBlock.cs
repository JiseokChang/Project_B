﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EMoveBlockState
{
    LeftAndRight,
    BottomAndTop,
    Stop
}

public class MoveBlock : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    public EMoveBlockState state = EMoveBlockState.LeftAndRight;
  
    [SerializeField] float SrcCoord = -1.0f;
    [SerializeField] float DstCoord = 1.0f;

    private Vector2 originSrcCoord;
    private Vector2 originDstCoord;
    private bool isDst = false;
    private bool isPause = false;

    void Start()
    {
        originSrcCoord.x = this.transform.position.x + SrcCoord;
        originSrcCoord.y = this.transform.position.y + SrcCoord;
        originDstCoord.x = this.transform.position.x + DstCoord;
        originDstCoord.y = this.transform.position.y + DstCoord;
    }

    void FixedUpdate()
    {
        if(isPause)
        {
            return;
        }

        if(state == EMoveBlockState.LeftAndRight)
        {
            MoveLeftAndRight();
        }
        else if(state == EMoveBlockState.BottomAndTop)
        {
            MoveBottomAndTop();
        }
    }
    
    void MoveLeftAndRight()
    {
        Vector3 moveDirection = Vector3.zero;

        if(isDst)
        {
            moveDirection = Vector3.right;
        }
        else
        {
            moveDirection = Vector3.left;
        }
        
        this.transform.position += moveDirection * moveSpeed * 0.01f;

        if(originSrcCoord.x >= this.transform.position.x)
        {
            isDst = true;
        }
        else if(originDstCoord.x <= this.transform.position.x)
        {
            isDst = false;
        }
    }
    
    void MoveBottomAndTop()
    {
        Vector3 moveDirection = Vector3.zero;

        if (isDst)
        {
            moveDirection = Vector3.up;
        }
        else
        {
            moveDirection = Vector3.down;
        }

        this.transform.position += moveDirection * moveSpeed * 0.01f;

        if (originSrcCoord.y >= this.transform.position.y)
        {
            isDst = true;
        }
        else if (originDstCoord.y <= this.transform.position.y)
        {
            isDst = false;
        }
    }

    public void SetPause(bool pause)
    {
        isPause = pause;
    }
}

