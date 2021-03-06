using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float health;
    public int coin;
    public float[] position;

    public GameData()
    {
        health = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().health;
        coin = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().coinCollected;

        position = new float[3];
        position[0] = GameObject.FindWithTag("Player").transform.position.x;
        position[1] = GameObject.FindWithTag("Player").transform.position.y;
        position[2] = GameObject.FindWithTag("Player").transform.position.z;
    }
}
