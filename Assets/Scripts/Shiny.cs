using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shiny : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Crow")
        {
            other.transform.localScale += new Vector3(1, 1, 1);
            other.GetComponent<Crow>().targetThis = null;
            Debug.Log("Shiny about to destroy");
            Destroy(gameObject);
        }
    }
}
