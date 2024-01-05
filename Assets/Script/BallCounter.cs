using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCounter : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            var gameManager = GameManager.Instance;
            gameManager.BallCountAndWrite();
        }
    }
}
