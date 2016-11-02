using Assets.JackCheng.Probe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：Mover  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/7/19 19:30:43
// ================================
namespace Assets.JackCheng.Track
{
    public class MOVER 
    {
        public float fSpeed = 20;
        public bool bAction = false;

        public Transform tRoot;
        private Vector3 FROM;
        private Vector3 TO;
        private float fLength;
        private Vector3 DIR;
        private float fDelta;

        //public Probe EvnSystem = new Probe();

        public MOVER(Transform t)
        {
            tRoot = t;
        }
        public void Check(Vector3 pos) 
        { 
            FROM = tRoot.transform.position;
            TO = pos;
            Vector3 vecTemp = TO - FROM;
            fLength = vecTemp.magnitude;
            DIR = vecTemp.normalized;

            bAction = true;
        }

        public void MoveTo(Vector3 pos) {
            Check(pos);
        }

        public void Update() 
        {
            if (bAction) 
            {
                Process();        
            }
        }

        private void Process() 
        {
            fDelta = Time.deltaTime * fSpeed;
            fLength -= fDelta;

            if (fLength <= 0) 
            {
                fDelta = fLength + fDelta;
                fLength = 0;
                //EvnSystem.Go();
                bAction = false;
            }

            tRoot.transform.position += fDelta * DIR;
        }
    }
}
