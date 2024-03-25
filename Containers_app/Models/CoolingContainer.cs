using Kontenery_app.Exceptions;

namespace Kontenery_app.Models;

public class CoolingContainer : Container
{
    public string? Type { get; set; }
    public double Temperature { get; set; }

    public Dictionary<string, double> ProductsTemperatures = new Dictionary<string, double>()
    {
        { "bananas", 13.3 }, { "chocolate", 18 }, { "fish", 2 },
        { "meat", -15 }, { "ice cream", -18 }, { "frozen pizza", -30 },
        { "cheese", 7.2 }, { "sausages", 5 }, { "butter", 20.5 },
        { "eggs", 19 }
    };


    public CoolingContainer(int loadMassKg, int heightCm, int ownWeightKg, int depthCm,
        int capacityKg, string? type, double temperature) : base(loadMassKg, heightCm, ownWeightKg, depthCm,
        capacityKg)
    {
        Type = type.ToLower();
        Temperature = temperature;
    }

    protected override string GenerateSerialNumber()
    {
        return "KON-C-" + SerialNumberIndex++;
    }

    public override void Unload()
    {
        LoadMassKg = 0;
    }

    public override void Load(double massToLoad)
    {
        if (massToLoad > CapacityKg)
            throw new OverfillException();

        CapacityKg = massToLoad;
    }

    public void LoadWithCheck(double mass, string productType)
    {
        if (productType.ToLower() != Type)
            Console.WriteLine("Incorrect product type! Aborting operation...");
        else if (Temperature < ProductsTemperatures[Type])
            Console.WriteLine("Temperature of the container over required " + ProductsTemperatures[Type]
                                                                            + " for type " + Type);
        else
            Load(mass);
    }
}