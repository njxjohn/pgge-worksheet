using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{

    public Transform mPlayer;

    TPCBase mThirdPersonCamera;

    public abstract class TPCBase
    {
        protected Transform mCameraTransform;
        protected Transform mPlayerTransform;

        public Transform CameraTransform
        {
            get
            {
                return mCameraTransform;
            }
        }
        public Transform PlayerTransform
        {
            get
            {
                return mPlayerTransform;
            }
        }

        public TPCBase(Transform cameraTransform, Transform playerTransform)
        {
            mCameraTransform = cameraTransform;
            mPlayerTransform = playerTransform;
        }

        public abstract void Update();
    }

    public class TPCTrack : TPCBase
    {
        public TPCTrack(Transform cameraTransform, Transform playerTransform)
            : base(cameraTransform, playerTransform)
        {
        }

        public override void Update()
        {
            Vector3 targetPos = mPlayerTransform.position;
            mCameraTransform.LookAt(targetPos);
        }
    }

    void Start()
    {
        mThirdPersonCamera = new TPCTrack(transform, mPlayer);
    }

    void LateUpdate()
    {
        mThirdPersonCamera.Update();
    }



}


