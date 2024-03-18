namespace Kontenery_app.Models;

class LKontener : Kontener, IHazardNotifier
{
    private bool NiebezpiecznyLadunek { get; set; }

    public LKontener(int masaKg, int wysokoscCm, int wagaWlasnaKg, int glebokoscCm,
        string nrSeryjny, int ladownosc, bool niebezpiecznyLadunek)
        : base(masaKg, wysokoscCm, wagaWlasnaKg, glebokoscCm, nrSeryjny, ladownosc)
    {
        NiebezpiecznyLadunek = niebezpiecznyLadunek;
    }

    public override void Oproznij()
    {
        throw new NotImplementedException();
    }

    public override void Zaladuj(double masaDoZaladoawania)
    {
        if (NiebezpiecznyLadunek && masaDoZaladoawania >= 0.5 * LadownoscKg)
        
            NiebezpiecznaSytuacja();
        else if (masaDoZaladoawania >= 0.9 * LadownoscKg)
            NiebezpiecznaSytuacja();
        else
            MasaKg = masaDoZaladoawania;
        
        
    }

    public void NiebezpiecznaSytuacja()
    {
        Console.WriteLine("TODO NIEB. SYT.");
    }
}