using UnityEngine;
using System.Collections;

public class SpawnAnts : MonoBehaviour
{
    public GameObject ants;
    public int numberOfAnts;
    public bool isCalculating;
    public bool isMoving = false;

    private KmeansClustering _kmeans;
    
    private void Start()
    {
        isCalculating = true;
        _kmeans = GetComponent<KmeansClustering>();
        for (var i = 0; i < numberOfAnts; i++)
        {
            Instantiate(ants, new Vector3(Random.Range(-13, 14), 0f, Random.Range(-29, 30)),Quaternion.identity);
        }
        _kmeans.ants = GameObject.FindGameObjectsWithTag("Ant");
    }

    private void Update()
    {
        if (isCalculating)
        {
            _kmeans.FindClosestCentroid();
        }
    }

    public void MoveAnts(){
        StartCoroutine(StartMoving());
    }

    IEnumerator StartMoving() {
        isMoving = true;

        yield return new WaitForSeconds(5);

        isMoving = false;

    }
}
