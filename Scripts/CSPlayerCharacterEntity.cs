using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreativeSpore.RpgMapEditor;
using UnityEngine.Profiling;
using LiteNetLibManager;

namespace MultiplayerARPG
{
    [RequireComponent(typeof(PhysicCharBehaviour))]
    [RequireComponent(typeof(CharacterModel2D))]
    public partial class CSPlayerCharacterEntity : PlayerCharacterEntity2D
    {

        public override float StoppingDistance
        {
            get { return stoppingDistance; }
        }

        private PhysicCharBehaviour cachePhysicCharBehaviour;
        public PhysicCharBehaviour CachePhysicCharBehaviour
        {
            get
            {
                if (cachePhysicCharBehaviour == null)
                    cachePhysicCharBehaviour = GetComponent<PhysicCharBehaviour>();
                return cachePhysicCharBehaviour;
            }
        }

        private Vector2 tempMoveDirection;

        protected override void EntityFixedUpdate()
        {
            base.EntityFixedUpdate();
            Profiler.BeginSample("PlayerCharacterEntity2D - FixedUpdate");
            if (!IsServer && !IsOwnerClient)
                return;

            if (currentDestination.HasValue)
            {
                var currentPosition = new Vector2(CacheTransform.position.x, CacheTransform.position.y);
                tempMoveDirection = (currentDestination.Value - currentPosition).normalized;
                if (Vector3.Distance(currentDestination.Value, currentPosition) < StoppingDistance)
                    StopMove();
            }

            if (!IsDead())
            {
                var moveDirectionMagnitude = tempMoveDirection.magnitude;
                if (!IsPlayingActionAnimation() && moveDirectionMagnitude != 0)
                {
                    if (moveDirectionMagnitude > 1)
                        tempMoveDirection = tempMoveDirection.normalized;
                    UpdateCurrentDirection(tempMoveDirection);
                    CachePhysicCharBehaviour.Dir = tempMoveDirection;
                    CachePhysicCharBehaviour.MaxSpeed = CacheMoveSpeed;
                }

                BaseGameEntity tempEntity;
                if (moveDirectionMagnitude == 0 && TryGetTargetEntity(out tempEntity))
                {
                    var targetDirection = (tempEntity.CacheTransform.position - CacheTransform.position).normalized;
                    if (targetDirection.magnitude != 0f)
                        UpdateCurrentDirection(targetDirection);
                }
            }
            Profiler.EndSample();
        }
        
        public override void StopMove()
        {
            currentDestination = null;
            tempMoveDirection = Vector3.zero;
            CachePhysicCharBehaviour.Dir = Vector2.zero;
            if (IsOwnerClient && !IsServer)
                CallNetFunction("StopMove", FunctionReceivers.Server);
        }
    }
}
