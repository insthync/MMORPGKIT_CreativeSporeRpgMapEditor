using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreativeSpore.RpgMapEditor;

namespace MultiplayerARPG
{
    [RequireComponent(typeof(PhysicCharBehaviour))]
    public class CSCharacterModel : CharacterModel
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

        public override void UpdateAnimation(bool isDead, Vector3 moveVelocity, float playMoveSpeedMultiplier = 1)
        {
        }

        public override Coroutine PlayActionAnimation(int actionId, AnimActionType animActionType, float playSpeedMultiplier = 1)
        {
            return null;
        }

        public override void PlayHurtAnimation()
        {
        }

        public override void PlayJumpAnimation()
        {
        }
    }
}
