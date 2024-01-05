using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBallController : MonoBehaviour
{
    [SerializeField] List<GameObject> ballList = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ballList.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ballList.Remove(other.gameObject);
        }
    }
    public void AddForceBall()
    {
        for (int i = 0; i < ballList.Count; i++)
        {
            var ball = ballList[i].gameObject.GetComponent<Rigidbody>();
            ball.AddForce(new Vector3(0, 0, .6f), ForceMode.Impulse);
        }
    }
}
