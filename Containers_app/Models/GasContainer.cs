using Kontenery_app.Exceptions;

namespace Kontenery_app.Models;

class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; set; }

    public GasContainer(int loadMassKg, int heightCm, int ownWeightKg, int depthCm, int capacityKg,
        double pressure) : base(loadMassKg, heightCm, ownWeightKg, depthCm, capacityKg)
    {
        Pressure = pressure;
    }

    protected override string GenerateSerialNumber()
    {
        return "KON-G-" + SerialNumberIndex++;
    }

    public override void Unload()
    {
        if (LoadMassKg > CapacityKg * 0.05)
            LoadMassKg = CapacityKg * 0.05;
        else
            HazardWarning("Attempt to empty gas container below its 5% capacity!");
    }

    public override void Load(double massToLoad)
    {
        if (massToLoad > CapacityKg)
            throw new OverfillException();

        CapacityKg = massToLoad;
    }

    public void HazardWarning(string info)
    {
        Console.WriteLine("TODO NIEB. SYT." + info);
    }
}