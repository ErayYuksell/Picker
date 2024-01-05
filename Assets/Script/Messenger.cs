using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Messenger : MonoBehaviour
{
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectorBoundry"))
        {
            var player = other.gameObject.GetComponentInParent<PlayerController>();
            player.BoundryActive();
        }
    }
}
