using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector3[] points = new Vector3[8];
    [SerializeField] private GameObject pointPrefab;

    private Rigidbody rigidbody;
    private List<GameObject> pointObjects = new List<GameObject>();
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        MakePoints();
    }

    void MakePoints(){
        foreach (Vector3 point in points){
            pointObjects.Add(Instantiate(pointPrefab, point, Quaternion.identity));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
