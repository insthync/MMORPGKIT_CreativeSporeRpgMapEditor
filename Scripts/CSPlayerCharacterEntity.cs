using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreativeSpore.RpgMapEditor;

namespace MultiplayerARPG
{
    [RequireComponent(typeof(PhysicCharBehaviour))]
    [RequireComponent(typeof(CharacterModel2D))]
    public partial class CSPlayerCharacterEntity : BasePlayerCharacterEntity
    {
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

        public override float StoppingDistance
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override bool IsMoving()
        {
            throw new System.NotImplementedException();
        }

        public override void KeyMovement(Vector3 direction, bool isJump)
        {
            throw new System.NotImplementedException();
        }

        public override void PointClickMovement(Vector3 position)
        {
            throw new System.NotImplementedException();
        }

        public override void StopMove()
        {
            throw new System.NotImplementedException();
        }
    }
}
