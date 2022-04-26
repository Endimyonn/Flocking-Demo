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

    [Header("Crow parameters")]
    public float crowSeparationDist = 2.1f;
    public float crowShinyRange;

    [Header("Spawning area")]
    public float spawnAreaX;
    public float spawnAreaY;
    public float spawnHeight = 3f;

    private void Awake()
    {
        lastCrows = numCrows;
    }

    private void Start()
    {
        SpawnCrows();
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
        Vector3 crowPosition = new Vector3(Random.Range(-spawnAreaX, spawnAreaX), spawnHeight, Random.Range(-spawnAreaY, spawnAreaY));
        GameObject crow = GameObject.Instantiate(crowPrefab, crowPosition, Quaternion.Euler(crowPrefab.transform.eulerAngles.x, 0, Random.Range(0, 360)));
        crow.GetComponent<Crow>().flocker = this;
        //init crow?
    }
}
