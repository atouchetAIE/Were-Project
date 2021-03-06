﻿using System;
using System.IO;
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D playRB;
    private Vector2 movement;
    public int speed;
    public GameObject infoHold;
    public Canvas mainCanvas;
    public GameObject[] spawnPoints;

    [HideInInspector] public bool holding = false;

	void Lerp (float a, float b, float c) {//Lerp: moving by position
        gameObject.transform.position = new Vector3(transform.position.x + a, transform.position.y + b, transform.position.z + c);
	}

    void Start()
    {
        playRB = GetComponent<Rigidbody2D>();//Gets Player's RigidBody
        infoHold = GameObject.Find("InformationHolder(Clone)");

        for (int fin = 0; fin < spawnPoints.Length; fin++)
        {
            if (infoHold.GetComponent<InfoHandler>().lastLevel == spawnPoints[fin].name)
            {
                this.gameObject.transform.position = spawnPoints[fin].transform.position;
            }
        }
    }

	void Update () {
        if(!UIRoot.instance.paused)
        {
            float h = Input.GetAxisRaw("Horizontal"); //x Axis control
            float v = Input.GetAxisRaw("Vertical");

            movement = new Vector2(h, v);      
            playRB.AddForce(movement * speed);
        }     
    }
}
