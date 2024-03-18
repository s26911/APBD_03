namespace Kontenery_app.Models;

public abstract class Kontener
{
    protected double MasaKg { get; set; }
    protected double WysokoscCm { get; set; }
    protected double WagaWlasnaKg { get; set; }
    protected double GlebokoscCm { get; set; }
    protected string NrSeryjny { get; set; }
    protected double LadownoscKg { get; set; }

    public Kontener(int masaKg, int wysokoscCm, int wagaWlasnaKg, int glebokoscCm, string nrSeryjny, int ladownosc)
    {
        MasaKg = masaKg;
        WysokoscCm = wysokoscCm;
        WagaWlasnaKg = wagaWlasnaKg;
        GlebokoscCm = glebokoscCm;
        NrSeryjny = nrSeryjny;
        LadownoscKg = ladownosc;
    }

    public abstract void Oproznij();

    public abstract void Zaladuj(double masaDoZaladoawania);
}