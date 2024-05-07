using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class boardUI : MonoBehaviour
{
    GameObject raycastedObj;
    ObjectInteraction referencedScript;
    public GameObject boardScene;
    public UnityEvent onMenuAppear;

    [SerializeField] private int InteractionRange = 2;
    [SerializeField] private LayerMask scenetransitionLayer;

    // Update is called once per frame


    void Start()
    {
        boardScene.SetActive(false);
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, InteractionRange, scenetransitionLayer.value))
        {
            if (hit.collider.CompareTag("board"))
            {
                boardScene.SetActive(true);
                onMenuAppear.Invoke();
                raycastedObj = hit.collider.gameObject;
                referencedScript = raycastedObj.GetComponent<ObjectInteraction>();
            }
        }
        else
        {
            boardScene.SetActive(false);
        }

    }
}
