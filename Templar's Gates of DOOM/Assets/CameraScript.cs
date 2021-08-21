using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;

    Vector2 cameraPosition;

    public GameObject gameManager;

    void Awake() {
        if (GameManager.instance == null)
            Instantiate(gameManager);
    }
    
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }
}
