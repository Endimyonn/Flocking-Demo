using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avoidable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("WALL HIT!!");
        if (other.gameObject.tag == "Crow")
        {
            //Debug.Log("Redirecting crow");
            //other.gameObject.GetComponent<Crow>().avoidThese.Add(this.gameObject);
            other.transform.position = new Vector3(-other.transform.position.x, 3, -other.transform.position.z);
            other.transform.position = Vector3.Lerp(other.transform.position, new Vector3(0, 3, 0), Time.deltaTime);
        }
    }
}
