using UnityEngine;
using System.Collections;

public class DisableTriggerOnPlayerExit : MonoBehaviour
{

    public void OnTriggerExit (Collider colisor)
    {
        if (colisor.gameObject.CompareTag ("Player"))
        {
            GetComponent<Collider> ().isTrigger = false;
        }
    }
}
