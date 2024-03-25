namespace Kontenery_app.Models;

class LiquidContainer : Container, IHazardNotifier
{
    private bool IsDangerous { get; set; }

    public LiquidContainer(int loadMassKg, int heightCm, int ownWeightKg, int depthCm,
        int capacityKg, bool isDangerous)
        : base(loadMassKg, heightCm, ownWeightKg, depthCm, capacityKg)
    {
        IsDangerous = isDangerous;
    }

    protected override string GenerateSerialNumber()
    {
        return "KON-L-" + SerialNumberIndex++;
    }

    public override void Unload()
    {
        LoadMassKg = 0;
    }

    public override void Load(double massToLoad)
    {
        if (IsDangerous && massToLoad > 0.5 * CapacityKg)
            HazardWarning("Attempt to fill container with dangerous load type over 50% of its capacity!");
        else if (massToLoad > 0.9 * CapacityKg)
            HazardWarning("Attempt to fill container over 90% of its capacity!");
        else
            LoadMassKg = massToLoad;
    }

    public void HazardWarning(string info)
    {
        Console.WriteLine("TODO NIEB. SYT." + info);
    }
}