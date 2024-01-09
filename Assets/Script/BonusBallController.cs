using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBallController : MonoBehaviour
{
    [SerializeField] string itemType;
    [SerializeField] int itemIndex;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectorBoundry"))
        {
            if (itemType == "BonusBall")
            {
                GameManager.Instance.CollectorPaletsOn();
                gameObject.SetActive(false);
            }
            else if (itemType == "AddBall")
            {
                GameManager.Instance.BonusBallsActive(itemIndex);
                gameObject.SetActive(false);
            }

        }
    }
}
