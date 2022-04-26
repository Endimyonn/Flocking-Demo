using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Crow : MonoBehaviour
{
    public Flocker flocker;

    public List<GameObject> avoidThese;
    public GameObject targetThis;

    public void CheckAround()
    {
        GameObject[] others = GameObject.FindGameObjectsWithTag("Crow");
        avoidThese.Clear();

        foreach (GameObject other in others)
        {
            if (other == this.gameObject)
            {
                continue;
            }

            if (Vector3.Distance(transform.position, other.transform.position) < flocker.crowSeparationDist)
            {
                avoidThese.Add(other);
            }
            else
            {
                avoidThese.Remove(other);
            }
        }

        if (targetThis != null)
        {
            if (Vector3.Distance(transform.position, targetThis.transform.position) > flocker.crowShinyRange)
            {
                targetThis = null;
            }
        }
    }

    public Vector3 GetAvoidanceDirection()
    {
        if (avoidThese.Count > 0)
        {
            List<Vector3> directions = new List<Vector3>();
            Vector3 finalDirection = Vector3.zero;

            foreach (GameObject avoidThis in avoidThese)
            {
                directions.Add(avoidThis.transform.position - transform.position);
            }

            foreach (Vector3 direction in directions)
            {
                finalDirection += direction;
            }

            finalDirection /= directions.Count;

            return -finalDirection.normalized * flocker.crowSeparationStrength;
        }

        return Vector3.zero;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + GetAvoidanceDirection());
    }
}
