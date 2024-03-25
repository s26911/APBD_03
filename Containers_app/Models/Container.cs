namespace Kontenery_app.Models;

public abstract class Container
{
    public double LoadMassKg { get; set; }
    public double OwnWeightKg { get; set; }
    protected double CapacityKg { get; set; }
    protected int HeightCm { get; set; }
    protected int DepthCm { get; set; }
    public string SerialNumber { get; set; }

    protected Container(double ownWeightKg, double capacityKg, int heightCm, int depthCm)
    {
        OwnWeightKg = ownWeightKg;
        CapacityKg = capacityKg;
        HeightCm = heightCm;
        DepthCm = depthCm;
        LoadMassKg = 0;
        SerialNumber = GenerateSerialNumber();
    }

    protected abstract string GenerateSerialNumber();

    public abstract void Unload();

    public abstract void Load(double massToLoad);
}