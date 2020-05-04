using System;
using Entitas;

[Serializable]
public enum VarFlag : short
{
    Velocity, // 速度
    AttackSpeed, // 攻击速度
    All,
}

public static class VarFlagExtension
{
    public static short ToIdx(this VarFlag flag)
    {
        return (short) flag;
    }
}

public sealed class StatsComp : IComponent
{
    public float[] Vars;
}
