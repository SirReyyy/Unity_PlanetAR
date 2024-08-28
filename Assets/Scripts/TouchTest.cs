using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : MonoBehaviour
{
    public GameObject infoPop;

    // Update is called once per frame
    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100)) {
                if(hit.transform.tag == "Sun") {
                    Debug.Log("Sun Prefab");
                }

                if(hit.transform.tag == "Info") {
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}
