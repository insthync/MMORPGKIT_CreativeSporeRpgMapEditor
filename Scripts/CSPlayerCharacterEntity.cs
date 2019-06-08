using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreativeSpore.RpgMapEditor;
using UnityEngine.Profiling;
using LiteNetLibManager;

namespace MultiplayerARPG
{
    [System.Obsolete("This is deprecated, but still keep it for backward compatibilities. Use `PlayerCharacterEntity` instead")]
    /// <summary>
    /// This is deprecated, but still keep it for backward compatibilities.
    /// Use `PlayerCharacterEntity` instead
    /// </summary>
    public partial class CSPlayerCharacterEntity : BasePlayerCharacterEntity
    {
        public override void InitialRequiredComponents()
        {
            CharacterMovement = GetComponent<BaseCharacterMovement>();
            if (CharacterMovement == null)
                CharacterMovement = gameObject.AddComponent<CSPhysicCharacterMovement>();
        }
    }
}
