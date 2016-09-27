using UnityEngine;
using System.Collections;

public class PlayerControllerTouch : MonoBehaviour {
    private NavMeshAgent agent;

    public Transform goPoint;//El objeto al cual seguiremos

    //variables que se utilizan para el sensor
    private Ray ray;
    private RaycastHit hit;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
	}
	
    void FixedUpdate() {
        //cada que se de click al boton izquierdo
        if (Input.GetMouseButtonDown(0)) {
            //para dibujar el "laser" del raycast
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(ray.origin, ray.direction * 300,
                              Color.blue);

            if (Physics.Raycast(ray, out hit, 300)){ 
                //si llega a tocar el plano
                if (hit.transform.gameObject.tag == "Plane"){
                    //se le da la posicion del toque en el plano
                    goPoint.localPosition = hit.point;

                    agent.destination = goPoint.localPosition;
                }

            }
        }
    }
}
