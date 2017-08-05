public class UnemploymentData
{
    public readonly string Name;
    public readonly int UnemployedPopulation;
    public readonly int CivilianLabourForce;
    public readonly float UnemploymentRate;
    public readonly int UnemploymentDecile;

    public UnemploymentData(string state, int unemployedPopulation, int civilianLabourForce, float unemploymentRate, int unemploymentDecile)
    {
        Name = state;
        UnemployedPopulation = unemployedPopulation;
        CivilianLabourForce = civilianLabourForce;
        UnemploymentRate = unemploymentRate;
        UnemploymentDecile = unemploymentDecile;
    }
}
