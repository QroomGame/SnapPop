using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour {
    public Transform leftWall;
    public Transform rightWall;
    public Platform platform;
    public GameObject currentPlatform = null;
    Transform t;
    public Vector2 minMaxDistance;
    
    // Use this for initialization
    void Start () {
        t = transform;
        GameData.instance.platformManager = this;
        InitPlatforms();

    }

    public void InitPlatforms() {
        RemoveAllPlatforms();
        currentPlatform = null;
        AddPlatforms();
        AddPlatforms();
        AddPlatforms();
    }

    public void AddPlatforms(int limit = 3) {

        for(var i=0; i < limit; i++) {
            GameObject plat = Instantiate(platform.gameObject) as GameObject;
            
            Platform pClass = plat.GetComponent<Platform>();
            Vector3 pos;
            if (currentPlatform == null) {
                pos = platform.transform.position;
                if (Random.Range(0, 1000) > 500) {
                    pClass.pSide = Platform.SIDE.left;
                } else {
                    pClass.pSide = Platform.SIDE.right;
                }
            } else {
                pos = currentPlatform.transform.position;
                pos.y += Random.Range(minMaxDistance.x, minMaxDistance.y);
                if (currentPlatform.GetComponent<Platform>().pSide== Platform.SIDE.right) {
                    pClass.pSide = Platform.SIDE.left;
                } else {
                    pClass.pSide = Platform.SIDE.right;
                }
            }
            pClass.SetPlatform();
            plat.transform.parent = t;
            SpriteRenderer brick = leftWall.Find("brick").GetComponent<SpriteRenderer>();
            //Debug.Log(((brick.size.x * brick.transform.localScale.x)) / 2);
            float wi = ((plat.GetComponent<SpriteRenderer>().size.x * Mathf.Abs(plat.transform.localScale.x))  + brick.size.x) / 2;
            //Debug.Log(wi);
            if (pClass.pSide == Platform.SIDE.left) {
                pos.x = leftWall.position.x + wi;
            } else {
                pos.x = rightWall.position.x - wi;
            }

            plat.SetActive(true);
            plat.transform.position = pos;

            currentPlatform = plat;

        }
    }

    void RemoveAllPlatforms() {
        for(var i = 0; i < t.childCount; i++) {
            GameObject pl = t.GetChild(i).gameObject;
            if(pl!= platform.gameObject) {
                Destroy(pl);
            }
        }
    }

	
}
