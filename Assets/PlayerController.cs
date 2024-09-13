using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector3[] points = new Vector3[8];
    [SerializeField] private GameObject pointPrefab;
    [SerializeField] private float speed = 1f;

    private Rigidbody rigidbody;
    private List<GameObject> pointObjects = new List<GameObject>();
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        MakePoints();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rigidbody.velocity = movement * speed;
        MakeDebugLines();
    }

    void MakePoints(){
        foreach (Vector3 point in points){
            pointObjects.Add(Instantiate(pointPrefab, point, Quaternion.identity));
        }
    }

    void MakeDebugLines(){
        foreach (GameObject pointObject in pointObjects){
            float dotProduct = Vector3.Dot(Vector3.forward, GetNormalizedDiff(transform.position, pointObject.transform.position));
            Debug.DrawLine(pointObject.transform.position, transform.position, dotProduct > 0 ? Color.green : Color.red, 0);
        }
    }

    Vector3 GetNormalizedDiff(Vector3 a, Vector3 b){
        Vector3 diff = b - a;
        diff.Normalize();
        return diff;
    }
}
