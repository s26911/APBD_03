namespace Kontenery_app.Models;

public abstract class Container
{
    protected double LoadMassKg { get; set; }
    protected double OwnWeightKg { get; set; }
    protected double HeightCm { get; set; }
    protected double DepthCm { get; set; }
    protected string SerialNumber { get; set; }
    protected double CapacityKg { get; set; }
    protected static int SerialNumberIndex { get; set; } = 1;

    protected Container(int loadMassKg, int heightCm, int ownWeightKg, int depthCm, int capacityKg)
    {
        LoadMassKg = loadMassKg;
        HeightCm = heightCm;
        OwnWeightKg = ownWeightKg;
        DepthCm = depthCm;
        SerialNumber = GenerateSerialNumber();
        CapacityKg = capacityKg;
    }

    protected abstract string GenerateSerialNumber();

    public abstract void Unload();

    public abstract void Load(double massToLoad);
}