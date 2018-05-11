using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPiece : MonoBehaviour {

    private BackgroundManager manager;
    public enum PIECE_TYPE { bottom, piece1, piece2 }
    public PIECE_TYPE pType;
    bool isvisible = false;
    bool doAdd = true;
	// Use this for initialization
	void Start () {

        if(transform.parent!=null){
            manager = transform.parent.GetComponent<BackgroundManager>();        
        }
        
    }

    private void OnBecameVisible() {
        
        isvisible = true;
    }

    private void OnBecameInvisible() {
        
        if (isvisible && doAdd && manager!=null) {                        
            manager.OnPieceDisappear(gameObject);
            doAdd = false;
            /*if (pType != PIECE_TYPE.bottom) {
                Debug.Log("DESTROY");
                Destroy(gameObject);
            }*/
        }
        
    }

    void OnApplicationQuit (){

         isvisible = false;
         
     }
}
