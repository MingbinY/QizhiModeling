using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRot : MonoBehaviour
{
    public float speed;
    public float time;
    [SerializeField]
    float timer;
    public GameObject nextCam;

    private void OnEnable()
    {
        timer = time;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
        timer -= Time.deltaTime;
        if (timer <= 0 && nextCam)
        {
            nextCam.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
