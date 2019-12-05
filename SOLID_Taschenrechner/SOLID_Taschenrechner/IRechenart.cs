namespace SOLID_Taschenrechner
{
    interface IRechenart
    {
        string[] Operatoren { get;}
        int Berechne(Formel input);
    }

}
