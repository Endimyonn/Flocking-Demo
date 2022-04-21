using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocker : MonoBehaviour
{
    [Header("General")]
    public int numCrows = 25;
    private int lastCrows;
    public GameObject crowPrefab;
    [HideInInspector] public List<Crow> crows;

    [Header("Flock parameters")]
    public float flockCohesionLimit = 13f;
    public float crowSeparationDist = 2.1f;
    public float crowFOV = 270f;

    [Header("Spawning area")]
    public float spawnAreaX;
    public float spawnAreaY;
    public float spawnHeight = 3f;

    private void Awake()
    {
        lastCrows = numCrows;
    }


    public void SpawnCrows()
    {
        for (int i = 0; i < numCrows; i++)
        {
            SpawnCrow();
        }
    }

    public void SpawnCrow()
    {
        Vector3 crowPosition = new Vector3(Random.Range(-spawnAreaX, spawnAreaX), 0, Random.Range(-spawnAreaY, spawnAreaY));
        GameObject crow = GameObject.Instantiate(crowPrefab, crowPosition, Quaternion.Euler(crowPrefab.transform.eulerAngles.x, 0, Random.Range(0, 360));
        crow.GetComponent<Crow>().flocker = this;
        //init crow?
    }
}
