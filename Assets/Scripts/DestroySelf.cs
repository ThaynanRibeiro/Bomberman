using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour
{
    public float Atraso = 3f;

    void Start ()
    {
        Destroy (gameObject, Atraso);
    }
}
