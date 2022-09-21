using CA220921;

List<Kuldetes> kuldetesek = new();

using StreamReader sr = new(@"..\..\..\res\kuldetesek.csv");
while (!sr.EndOfStream) kuldetesek.Add(new Kuldetes(sr.ReadLine()));

//3. feladat
Console.WriteLine(
    $"3.feladat:\n\t" +
    $"Összesen {kuldetesek.Count} alkalommal indítottak űrsiklót.");

//4. feladat

