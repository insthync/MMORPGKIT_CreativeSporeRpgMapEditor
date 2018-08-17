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

        public override Coroutine PlayActionAnimation(AnimActionType animActionType, int dataId, int index, float playSpeedMultiplier = 1)
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

    [System.Serializable]
    public struct CharacterAnimation2D
    {
        public AnimationClip bottom;
        public AnimationClip top;
        public AnimationClip left;
        public AnimationClip right;
    }

    [System.Serializable]
    public struct WeaponAttack2D
    {
        public WeaponType weaponType;
        public CharacterAnimation2D animation;
    }
    
    [System.Serializable]
    public struct SkillCast2D
    {
        public Skill skill;
        public CharacterAnimation2D animation;
    }
}
