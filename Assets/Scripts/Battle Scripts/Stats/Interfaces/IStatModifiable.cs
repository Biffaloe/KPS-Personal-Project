public interface IStatModifiable
{
    int StatModifierValue { get; }

    void AddModifier(Stat_Modifier mod);
    void RemoveModifier(Stat_Modifier mod);
    void ClearModifiers();
    void UpdateModifiers();
}
