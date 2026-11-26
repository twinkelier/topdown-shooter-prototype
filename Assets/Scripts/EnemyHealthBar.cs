using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Transform bar;
    [SerializeField] private Transform target;
    private Camera cam;
    //Vector3 mRotation;

    Quaternion mRotation;

    void Awake()
    {
        //mRotation = transform.eulerAngles;


        //cam = GameObject.FindObjectOfType<Camera>();

        //mRotation = cam.transform.rotation;
    }

    void Update()
    {
        //transform.rotation = mRotation;

        if (Vector2.Distance(transform.position, target.position) >= 0.6f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, 100 * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, target.position) <= 0.6f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -100 * Time.deltaTime);
        }

        //transform.eulerAngles = mRotation;

        //mRotation = cam.transform.rotation.eulerAngles;

    }
    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }
}
