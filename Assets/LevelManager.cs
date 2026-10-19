using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LevelManager : MonoBehaviour
{
    public GameObject CurrentCheckpoint;


    void Start()
    {
        CurrentCheckpoint = null;
    }


    void Update()
    {

    }


    public void RespawnPlayer()
    {

        if (CurrentCheckpoint != null)
        {
            var player = FindObjectOfType<PlayerController>();
            if (player != null)
                player.transform.position = CurrentCheckpoint.transform.position;
        }
    }
}