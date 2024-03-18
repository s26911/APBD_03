namespace Kontenery_app.Models;

class GKontener : Kontener, IHazardNotifier
{
    public double Cisnienie { get; set; }
    
    public GKontener(int masaKg, int wysokoscCm, int wagaWlasnaKg, int glebokoscCm, string nrSeryjny, int ladownosc, double cisnienie) : base(masaKg, wysokoscCm, wagaWlasnaKg, glebokoscCm, nrSeryjny, ladownosc)
    {
        Cisnienie = cisnienie;
    }

    public override void Oproznij()
    {
        throw new NotImplementedException();
    }

    public override void Zaladuj(double masaDoZaladoawania)
    {
        if (masaDoZaladoawania >= LadownoscKg)
            NiebezpiecznaSytuacja();
        else
            LadownoscKg = masaDoZaladoawania;
    }

    public void NiebezpiecznaSytuacja()
    {
        throw new NotImplementedException();
    }
}