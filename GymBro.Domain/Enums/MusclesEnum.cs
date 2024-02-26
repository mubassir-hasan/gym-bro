using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Domain.Enums
{
    public enum MuscleGroup
    {
        [EnumMember(Value = "Biceps")]
        Biceps,

        [EnumMember(Value = "Long Head Bicep")]
        LongHeadBicep,

        [EnumMember(Value = "Short Head Bicep")]
        ShortHeadBicep,

        [EnumMember(Value = "Traps (mid-back)")]
        TrapsMidBack,

        [EnumMember(Value = "Lower back")]
        LowerBack,

        [EnumMember(Value = "Abdominals")]
        Abdominals,

        [EnumMember(Value = "Lower Abdominals")]
        LowerAbdominals,

        [EnumMember(Value = "Upper Abdominals")]
        UpperAbdominals,

        [EnumMember(Value = "Calves")]
        Calves,

        [EnumMember(Value = "Tibialis")]
        Tibialis,

        [EnumMember(Value = "Soleus")]
        Soleus,

        [EnumMember(Value = "Gastrocnemius")]
        Gastrocnemius,

        [EnumMember(Value = "Forearms")]
        Forearms,

        [EnumMember(Value = "Wrist Extensors")]
        WristExtensors,

        [EnumMember(Value = "Wrist Flexors")]
        WristFlexors,

        [EnumMember(Value = "Glutes")]
        Glutes,

        [EnumMember(Value = "Gluteus Medius")]
        GluteusMedius,

        [EnumMember(Value = "Gluteus Maximus")]
        GluteusMaximus,

        [EnumMember(Value = "Hamstrings")]
        Hamstrings,

        [EnumMember(Value = "Medial Hamstrings")]
        MedialHamstrings,

        [EnumMember(Value = "Lateral Hamstrings")]
        LateralHamstrings,

        [EnumMember(Value = "Lats")]
        Lats,

        [EnumMember(Value = "Shoulders")]
        Shoulders,

        [EnumMember(Value = "Lateral Deltoid")]
        LateralDeltoid,

        [EnumMember(Value = "Anterior Deltoid")]
        AnteriorDeltoid,

        [EnumMember(Value = "Posterior Deltoid")]
        PosteriorDeltoid,

        [EnumMember(Value = "Triceps")]
        Triceps,

        [EnumMember(Value = "Long Head Tricep")]
        LongHeadTricep,

        [EnumMember(Value = "Lateral Head Triceps")]
        LateralHeadTriceps,

        [EnumMember(Value = "Medial Head Triceps")]
        MedialHeadTriceps,

        [EnumMember(Value = "Traps")]
        Traps,

        [EnumMember(Value = "Upper Traps")]
        UpperTraps,

        [EnumMember(Value = "Lower Traps")]
        LowerTraps,

        [EnumMember(Value = "Quads")]
        Quads,

        [EnumMember(Value = "Inner Thigh")]
        InnerThigh,

        [EnumMember(Value = "Inner Quadriceps")]
        InnerQuadriceps,

        [EnumMember(Value = "Outer Quadricep")]
        OuterQuadricep,

        [EnumMember(Value = "Rectus Femoris")]
        RectusFemoris,

        [EnumMember(Value = "Chest")]
        Chest,

        [EnumMember(Value = "Upper Pectoralis")]
        UpperPectoralis,

        [EnumMember(Value = "Mid and Lower Chest")]
        MidAndLowerChest,

        [EnumMember(Value = "Obliques")]
        Obliques,

        [EnumMember(Value = "Hands")]
        Hands,

        [EnumMember(Value = "Feet")]
        Feet,

        [EnumMember(Value = "Front Shoulders")]
        FrontShoulders,

        [EnumMember(Value = "Rear Shoulders")]
        RearShoulders
    }
}
