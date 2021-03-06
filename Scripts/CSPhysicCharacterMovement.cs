﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreativeSpore.RpgMapEditor;
using LiteNetLibManager;

namespace MultiplayerARPG
{
    [RequireComponent(typeof(PhysicCharBehaviour))]
    public class CSPhysicCharacterMovement : RigidBodyEntityMovement2D
    {
        public PhysicCharBehaviour CachePhysicCharBehaviour { get; private set; }

        private Vector2 tempMoveDirection;

        public override void EntityAwake()
        {
            base.EntityAwake();
            CachePhysicCharBehaviour = GetComponent<PhysicCharBehaviour>();
        }

        public override void EntityFixedUpdate()
        {
            if (CacheEntity.MovementSecure == MovementSecure.ServerAuthoritative && !IsServer)
                return;

            if (CacheEntity.MovementSecure == MovementSecure.NotSecure && !IsOwnerClient)
                return;

            if (currentDestination.HasValue)
            {
                Vector2 currentPosition = new Vector2(CacheTransform.position.x, CacheTransform.position.y);
                tempMoveDirection = (currentDestination.Value - currentPosition).normalized;
                if (Vector3.Distance(currentDestination.Value, currentPosition) < StoppingDistance)
                    StopMove();
            }

            if (CacheEntity.CanMove())
            {
                float moveDirectionMagnitude = tempMoveDirection.magnitude;
                if (moveDirectionMagnitude != 0)
                {
                    if (moveDirectionMagnitude > 1)
                        tempMoveDirection = tempMoveDirection.normalized;
                    CacheEntity.SetDirection2D(tempMoveDirection);
                    CachePhysicCharBehaviour.Dir = tempMoveDirection;
                    CachePhysicCharBehaviour.MaxSpeed = CacheEntity.GetMoveSpeed();
                }
            }
        }

        public new void StopMove()
        {
            currentDestination = null;
            tempMoveDirection = Vector3.zero;
            CachePhysicCharBehaviour.Dir = Vector2.zero;
            if (IsOwnerClient && !IsServer)
                CacheEntity.CallNetFunction(StopMove, FunctionReceivers.Server);
        }
    }
}
