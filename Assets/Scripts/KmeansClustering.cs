using UnityEngine;

public class KmeansClustering : MonoBehaviour
{
    #region Variables
    public GameObject[] ants;
    public GameObject[] colorAnts;
    public GameObject[] centroids;
    public Material[] newMaterialRef;
    
    private float _closest = 100f;
    private SpawnAnts _spawnAnts;
    private string[] _colorTag ={"Red_Ant","Green_Ant","Blue_Ant","Purple_Ant"};
    private Vector3 _center;
    private Vector3 _newCenter;
    private float _count;
#endregion

    private void Start()
    {
        _spawnAnts = GetComponent<SpawnAnts>();
    }

    //Make closest data to cluster color
    public void FindClosestCentroid()
    {
        Debug.Log("In Finding Closest Centroid");
        foreach (var ant in ants) 
        {
            for (var j = 0; j < centroids.Length; j++) 
            {
                if (Vector3.Distance(ant.transform.position, centroids[j].transform.position) < _closest)
                {
                    Debug.Log("Setting color");
                    _closest = Vector3.Distance(ant.transform.position, centroids[j].transform.position);
                    ant.GetComponentInChildren<Renderer>().material = newMaterialRef[j];
                    ant.tag = _colorTag[j];
                }
            }
            _closest = 100f;
        }
    }

    public void SetNewCentroid()
    {
        _spawnAnts.isCalculating = false;
        for (var i = 0; i < 4; i++)
        {
            colorAnts = GameObject.FindGameObjectsWithTag(_colorTag[i]);   
            FindNewCentroids(colorAnts,i);
        }
        _spawnAnts.isCalculating = true;
    }
    
    //add this function for every ant of the SAME COLOR
    private void FindNewCentroids(GameObject[] colorAnt, int x)
    {
        _center = Vector3.zero;
        _count = 0;
        foreach (var ant in colorAnt)
        {
            _center += ant.transform.position;
            _count++;
        }
        _newCenter = _center / _count;
        centroids[x].transform.position = new Vector3(_newCenter.x,0.9f,_newCenter.z);
    }
}