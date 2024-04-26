﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class enterbrainn : MonoBehaviour
{
    GameObject raycastedObj;
    ObjectInteraction referencedScript;
    public GameObject enterScene;
    public UnityEvent onMenuAppear;
    public UnityEvent onMenuDisppear;

    [SerializeField] private int InteractionRange = 1;
    [SerializeField] private LayerMask scenetransitionLayer;

    // Update is called once per frame


    void Start()
    {
        enterScene.SetActive(false);
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, InteractionRange, scenetransitionLayer.value))
        {
            if (hit.collider.CompareTag("enter"))
            {
                enterScene.SetActive(true);
                onMenuAppear.Invoke();
                raycastedObj = hit.collider.gameObject;
                referencedScript = raycastedObj.GetComponent<ObjectInteraction>();
            }
        }
        else
        {
            enterScene.SetActive(false);
        }

    }
}
