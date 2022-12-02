using UnityEngine;

public class SpawnAnts : MonoBehaviour
{
    public GameObject ants;
    public int numberOfAnts;
    public bool isCalculating;
    
    private KmeansClustering _kmeans;
    
    private void Start()
    {
        isCalculating = true;
        _kmeans = GetComponent<KmeansClustering>();
        for (var i = 0; i < numberOfAnts; i++)
        {
            Instantiate(ants, new Vector3(Random.Range(-17, 16), 0f, Random.Range(-32, 33)),Quaternion.identity);
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

}
