﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToGround : MonoBehaviour {

    public GameObject MaxHeight;
    public GameObject CurrentGround;
    public Vector3 _Position, __Position;
    public float Timer, _Timer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = new Ray(MaxHeight.transform.position, -transform.up);
        RaycastHit raycastHit;
        bool Didraycasthit;
        LayerMask mask = LayerMask.GetMask("Ground");
        Didraycasthit = Physics.Raycast(ray, out raycastHit, 3f, mask);

        if (Didraycasthit)
        {
            Timer += Time.deltaTime;
            _Timer = 0;
            if (raycastHit.transform.gameObject != CurrentGround)
            {
                CurrentGround = raycastHit.transform.gameObject;
                transform.parent = CurrentGround.transform.root;
                //transform.eulerAngles = CurrentGround.transform.root.eulerAngles;
            }
            Vector3 _P = transform.localPosition;
            transform.position  = raycastHit.point;
            _P.y = transform.localPosition.y;
            transform.localPosition = _P;
            //transform.position = raycastHit.point;

            if (Timer > 1.4f)
            {
                __Position = _Position;
                _Position = transform.localPosition;
                Timer = 0;
            }
        }
        else
        {
            _Timer += Time.deltaTime;

            if (_Timer > 0.1f && __Position != new Vector3 (0,0,0))
            {
                _Timer = 0;
                if (Timer > 1)
                    transform.localPosition = __Position;
                else
                    transform.localPosition = _Position;
            }
        }
    }
}