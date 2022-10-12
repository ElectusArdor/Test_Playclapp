using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    public float speed, targetPoint;

    void Start()
    {
        rb.velocity = new Vector3(speed, 0, 0);
    }

    private void IsFinish()
    {
        if (transform.localPosition.x >= targetPoint)
            Destroy(rb.gameObject);
    }

    private void Update()
    {
        IsFinish();
    }
}
