﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SCR_FeelingIt : MonoBehaviour {

    [HideInInspector]
    public Transform boredPosition;
    [HideInInspector]
    public Transform dancingPosition;
    [HideInInspector]
    public float myChanceToShine;

    private NavMeshAgent navMesh;
    public Slider danceMeter;

    public Transform squid;

    private void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
       // danceMeter = FindObjectOfType<Slider>();
        transform.LookAt(squid);
    }

    private void Update()
    {
        if (danceMeter.value >= myChanceToShine)
        {
            Vector3 klmaoPosition = squid.position;
            navMesh.SetDestination(dancingPosition.position);

            Vector3 playerPos = klmaoPosition - transform.position;
            Quaternion playerRotation = Quaternion.LookRotation(playerPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, playerRotation, Time.deltaTime * 5);
        }
        else
            navMesh.SetDestination(boredPosition.position);
    }
}
