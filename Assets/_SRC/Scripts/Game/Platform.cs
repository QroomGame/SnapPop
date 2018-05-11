using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    Transform t;
    Transform ship;
    BoxCollider2D col;
    public enum SIDE { left, right };
    public SIDE pSide;
    bool isvisible = false;
	// Use this for initialization
	void Start () {

        t = transform;
        ship = GameData.instance.shipTr;
        col = GetComponent<BoxCollider2D>();

	}

    public void SetPlatform() {

        Vector3 scale = transform.localScale;
        scale.x *= Random.Range(0.5f, 1.1f);
        if (pSide == SIDE.right) {
            scale.x *= -1;
        }

        transform.localScale = scale;

    }

    private void OnBecameVisible() {
        isvisible = true;
    }

    private void OnBecameInvisible() {
        
        if (isvisible && t.position.y < ship.position.y) {
            GameData.instance.platformManager.AddPlatforms(1);
            Destroy(gameObject);            
        }

    }

    // Update is called once per frame
    void Update () {
        if (t.position.y < ship.position.y) {
            col.isTrigger = false;
        } else {
            col.isTrigger = true;
        }
	}
}
