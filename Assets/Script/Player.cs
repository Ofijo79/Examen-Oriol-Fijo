using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent _playerAgent;
    // Start is called before the first frame update
    void Awake()
    {
        _playerAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            SetDestination();
        }
    }

    void SetDestination()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            _playerAgent.destination = hit.point;
        }
    }
}
