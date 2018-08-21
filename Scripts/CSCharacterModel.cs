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

        public void Play2DAnim_Animator(AnimationClip clip)
        {
            CacheAnimator.enabled = false;
            CacheAnimatorController[ANIM_STATE_ACTION_CLIP] = clip;
            CacheAnimator.enabled = true;
        }

        public void Play2DAnim_Animation(AnimationClip clip)
        {
            if (CacheAnimation.GetClip(LEGACY_CLIP_ACTION) != null)
                CacheAnimation.RemoveClip(LEGACY_CLIP_ACTION);
            CacheAnimation.AddClip(clip, LEGACY_CLIP_ACTION);
            CacheAnimation.Play(LEGACY_CLIP_ACTION);
        }
        
        public override void UpdateAnimation(bool isDead, Vector3 moveVelocity, float playMoveSpeedMultiplier = 1)
        {
            switch (animatorType)
            {
                case AnimatorType.Animator:
                    UpdateAnimation_Animator(isDead, moveVelocity, playMoveSpeedMultiplier);
                    break;
                case AnimatorType.LegacyAnimtion:
                    UpdateAnimation_LegacyAnimation(isDead, moveVelocity, playMoveSpeedMultiplier);
                    break;
            }
        }

        private void UpdateAnimation_Animator(bool isDead, Vector3 moveVelocity, float playMoveSpeedMultiplier)
        {
        }

        private void UpdateAnimation_LegacyAnimation(bool isDead, Vector3 moveVelocity, float playMoveSpeedMultiplier)
        {
        }

        public override Coroutine PlayActionAnimation(AnimActionType animActionType, int dataId, int index, float playSpeedMultiplier = 1)
        {
            return null;
        }

        public override void PlayHurtAnimation()
        {
            // TODO: 2D may just play blink red color
        }

        public override void PlayJumpAnimation()
        {
            // TODO: 2D may able to jump
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
