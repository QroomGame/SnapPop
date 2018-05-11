using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {

    public GameObject piece1;
    public GameObject piece2;
    public GameObject back;
    string currentPiece = "piece2";
    Transform t;
    float lastPos;
    


    // Use this for initialization
    void Start () {
        piece1 = Instantiate(piece1) as GameObject;
        piece2 = Instantiate(piece2) as GameObject;
        piece1.SetActive(false);
        piece2.SetActive(false);
        t = transform;
        lastPos = 0;


    }
	
	/*// Update is called once per frame
	void Update () {
		
	}*/

    public void OnPieceDisappear(GameObject piece) {

        if(piece==piece1 || piece == piece2 || gameObject==null || piece == null || piece1 == null || piece2 == null) {
           
            return;
        }

  
        GameObject npiece;
        Transform last;
        Vector3 pos;
        
        last = t.GetChild(t.childCount - 1);
        pos = last.transform.localPosition;
        pos.y += last.GetComponent<SpriteRenderer>().size.y * last.localScale.y;


        if (currentPiece == "piece1") {
            npiece = Instantiate(piece2) as GameObject;
            currentPiece = "piece2";
        } else {
            npiece = Instantiate(piece1) as GameObject;
            currentPiece = "piece1";
        }

        //in case of premature deactivation
        npiece.transform.parent = t;
        npiece.SetActive(true);

        npiece.transform.localPosition = pos;
       

    }
}
