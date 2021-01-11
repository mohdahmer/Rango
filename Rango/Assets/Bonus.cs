using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bonus : MonoBehaviour
{
    ScoreManager scoreManager;
    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>();
    }
    public GameObject gold;
    void OnTriggerEnter2D(Collider2D col)
    {
        scoreManager.IncrementScore();
        Destroy(gold);
    }
}
