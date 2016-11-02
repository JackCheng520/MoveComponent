using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：TrackTest  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/7/19 14:56:29
// ================================
namespace Assets.JackCheng.Track
{
    [ExecuteInEditMode]
    public class TrackMovement : MonoBehaviour
    {
        public enum eTYPE { 
            LOCAL,
            WORLD,
        }
        public eTYPE eType = eTYPE.LOCAL;

        public Vector3 UpAix = new Vector3(0, 1, 0);

        public float fx;
        public AnimationCurve curveX;

        public float fy;
        public AnimationCurve curveY;

        public float fz;
        public AnimationCurve curveZ;

        public bool bAction = false;

        public bool bLookAt = false;

        public float fDelay = 0.5f;

        public float timeScale = 1.0f;

        public float shakeScale = 1.0f;

        private Transform targetTransform;

        private Vector3 localStartPos;

        private Vector3 worldStartPos;

        private Vector3 up;

        private Vector3 right;

        private Vector3 forward;

        private float fTime = 0;

        

        Assets.JackCheng.Probe.J_Echo EvnSystem = new Probe.J_Echo();

        public void Launch() 
        {
            CheckPos();
            CheckDir();

            fTime = 0;
            
            bAction = true;
            //EvnSystem.Add(StartAction, fDelay);
        }

        public void Launch(Vector3 _targetPos) {
            CheckPos();
            CheckDir();
            CheckTarget(_targetPos);
        }

        private void CheckPos() 
        {
            localStartPos = transform.localPosition;
            worldStartPos = transform.position;
        }

        private void CheckDir() {
            right = transform.right;
            up = transform.up;
            forward = transform.forward;
        }

        private void CheckTarget(Vector3 pos)
        {
            fz = Vector3.Distance(pos, transform.position);
        }

        private Vector3 CheckX() 
        {
            float fTemp = curveX.Evaluate(fTime);
            return fTemp * right * fx * shakeScale;
        }

        private Vector3 CheckY() {
            float fTemp = curveY.Evaluate(fTime);
            return fTemp * up * fy * shakeScale;
        }

        private Vector3 CheckZ() 
        {
            float fTemp = curveZ.Evaluate(fTime);
            return fTemp * forward * fz;
        }

        private void CheckTime() 
        {
            Vector3 offset = CheckX() + CheckY() + CheckZ();

            if (bLookAt) {
                transform.LookAt(offset + worldStartPos, UpAix);
            }

            if (eType == eTYPE.LOCAL)
            {
                transform.localPosition = localStartPos + offset;

            }
            else {
                transform.position = worldStartPos + offset;
            }
        }
        private void StartAction() {
            bAction = true;
        }

        private void Process() 
        {
            fTime += Time.deltaTime * timeScale;

            if (fTime >= 1) 
            {
                fTime = 1;
                CheckTime();
                bAction = false;
                ActionOver();
                return;
            }
            CheckTime();
        }

        private void ActionOver() { 
        
        }

        public bool bTest = false;
        void Update() 
        {
            if (bTest) 
            {
                Launch();
                bTest = false;
            }

            if (bAction) 
            {
                Process();
            }
        }


    }
}
