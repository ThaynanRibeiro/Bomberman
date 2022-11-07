using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public class Bomb : MonoBehaviour
{
    public AudioClip explosionSound;
    public GameObject explosionPrefab;
    public LayerMask levelMask;

    private bool explodiu = false;

    void Start()
    {
        Invoke("Explode", 3f);
    }

    void Explode()
    {
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        StartCoroutine(CriarExplosoes(Vector3.forward));
        StartCoroutine(CriarExplosoes(Vector3.right));
        StartCoroutine(CriarExplosoes(Vector3.back));
        StartCoroutine(CriarExplosoes(Vector3.left));

        GetComponent<MeshRenderer>().enabled = false; 
        explodiu = true;
        transform.Find("Collider").gameObject.SetActive(false); 
        Destroy(gameObject, .3f);
    }

    public void OnTriggerEnter(Collider colisor)
    {
        if (!explodiu && colisor.CompareTag("Explosion"))
        {
            CancelInvoke("Explode");
            Explode();
        }
    }

    private IEnumerator CriarExplosoes(Vector3 direcao)
    {
        for (int i = 1; i < 3; i++)
        {
            RaycastHit hit;

            Physics.Raycast(transform.position + new Vector3(0, .5f, 0), direcao, out hit, i, levelMask);

            if (!hit.collider)
            {
                Instantiate(explosionPrefab, transform.position + (i * direcao), explosionPrefab.transform.rotation);
            }
            else
            {
                if (hit.collider.CompareTag("BlockDestrutive"))
                    Destroy(hit.collider.gameObject);
                break;

            }

            yield return new WaitForSeconds(.05f); 
        }

    }
}
