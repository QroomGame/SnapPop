using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour {

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;

    Camera camera;
    float yIni;

    void Start() {
        camera = GetComponent<Camera>();
        yIni = camera.WorldToViewportPoint(target.position).y;
       
    }

    // Update is called once per frame
    void Update() {
        if (target) {
            Vector3 tpos = target.position;
            tpos.x = transform.position.x;
            Vector3 point = camera.WorldToViewportPoint(target.position);
            Vector3 delta = tpos - camera.ViewportToWorldPoint(new Vector3(0.5f, yIni, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }

    }
}