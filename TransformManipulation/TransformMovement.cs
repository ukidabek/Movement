using UnityEngine;

using System;

namespace BaseGameLogic.Movement.TransformManupulation
{
    [Serializable]
    public class TransformMovement : TransformManipulator
    {
        public TransformMovement () {}

        public TransformMovement (Transform transform, float locomotionSpeed)
        {
            _transform = transform;
            speed = locomotionSpeed;
        }

        public Vector3 CalculatMove(Vector3 input, float deltaTime)
        {
            Vector3 forward = _transform.forward;
            forward *= input.z;
            Vector3 right = _transform.right;
            right *= input.x;

            return ((forward + right) * speed) * deltaTime;
        }

        public void Move(Vector3 input, float deltaTime)
        {
            _transform.position += CalculatMove(input, deltaTime);
        }

        public Vector3 CalculateMoveTowards(Vector3 position, float deltaTime)
        {
            return Vector3.MoveTowards(_transform.position, position, speed * deltaTime);
        }

        public void MoveTowards(Vector3 position, float deltaTime)
        {
            _transform.position = CalculateMoveTowards(position, deltaTime);
        }
    }
}