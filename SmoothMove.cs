using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：SmoothMove  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/7/20 9:39:25
// ================================
namespace Assets.JackCheng.Track
{
    public class SmoothMove : MonoBehaviour
    {
        public enum SmoothMoveType { 
            WORLD,
            LOCAL,
        }
        public SmoothMoveType eType;
        public Transform root;
        public Vector3 targetPos;
        public Vector3 currentPos;
        public Vector3 velocity;
        public float smoothTime = 10f;
        public bool bAction;


        public void Launch(Vector3 _targetPos) {
            GetCurrentPos();
            targetPos = _targetPos;

            bAction = true;
        }

        private void GetCurrentPos() {
            switch (eType) {
                case SmoothMoveType.WORLD:
                    currentPos = root.position;
                    break;
                case SmoothMoveType.LOCAL:
                    currentPos = root.localPosition;
                    break;
            }
        }

        public bool bTest = false;
        void Update()
        {
            if (bTest)
            {
                Launch(targetPos);
                bTest = false;
            }

            if (bAction) {
                Process();
            }
        }

        private Vector3 vTemp;
        private void Process() 
        {
            GetCurrentPos();
            vTemp = Vector3.SmoothDamp(currentPos, targetPos, ref velocity, smoothTime);
            if (Mathf.Abs(velocity.magnitude) < 0.1f)
            {
                bAction = false;
                vTemp = targetPos;
            }
            if (eType == SmoothMoveType.WORLD)
            {
                root.position = vTemp;
            }
            else {
                root.localPosition = vTemp;
            }
            
        }
    }
}
