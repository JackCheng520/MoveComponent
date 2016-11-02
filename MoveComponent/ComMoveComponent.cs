using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：ComMoveComponent  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/7/19 14:14:36
// ================================
namespace Assets.JackCheng.MoveComponent
{
    public class ComMoveComponent
    {
        public Transform transCurrent;

        public Vector3 vecTarget;

        public float fSpeed;

        public float fLength;

        public Vector3 vecDir;

        public bool bAction;
        public void MoveTo(Transform _current, Vector3 _target, float _speed) 
        {
            transCurrent = _current;
            vecTarget = _target;
            fSpeed = _speed;

            Vector3 vec = _target - _current.position;
            fLength = vec.magnitude;
            vecDir = vec.normalized;

        }

        private float fTemp = 0;
        private Vector3 vecTemp = Vector3.zero;
        public void Update() 
        {
            if (bAction)
            {
                fTemp = Time.deltaTime * fSpeed;
                fLength -= fTemp;
                if (fLength > 0)
                {
                    transCurrent.position += fTemp * vecDir;
                }
                else
                {
                    fTemp = fLength + fTemp;
                    transCurrent.position += fTemp * vecDir;
                    bAction = false;
                }
            }
        }
    }
}
