Random wuerfel = new Random(); //Zufallsgenerator erzeugen
int wurf1, wurf2, wurf3, wurf4, anzahlWuerfe = 0;

do
{
  wurf1 = wuerfel.Next(1, 7); //Erzeugt eine Zufallswert zischen 1 und 6
  wurf2 = wuerfel.Next(1, 7); //Erzeugt eine Zufallswert zischen 1 und 6
  wurf3 = wuerfel.Next(1, 7); //Erzeugt eine Zufallswert zischen 1 und 6
  wurf4 = wuerfel.Next(1, 7); //Erzeugt eine Zufallswert zischen 1 und 6

  anzahlWuerfe++;

  Console.WriteLine("{4,5}. Wurf: {0} {1} {2} {3}", wurf1, wurf2, wurf3, wurf4, anzahlWuerfe);
}
while (wurf1 != 6 || wurf2 != 6 || wurf3 != 6 || wurf4 != 6);

Console.Read();
