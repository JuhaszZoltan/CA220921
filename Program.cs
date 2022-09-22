using CA220921;

List<Kuldetes> kuldetesek = new();

using StreamReader sr = new(@"..\..\..\res\kuldetesek.csv");
while (!sr.EndOfStream) kuldetesek.Add(new Kuldetes(sr.ReadLine()));

//3. feladat
Console.WriteLine(
    $"3.feladat:\n\t" +
    $"Összesen {kuldetesek.Count} alkalommal indítottak űrsiklót.");

//4. feladat
//LINQ = Language-Integrated Query
int uo = kuldetesek.Sum(x => x.LegenysegSzama);
Console.WriteLine($"4. feladat:\n\t" +
    $"{uo} utas indult az űrbe összesen.");

//String.Format()
//Console.WriteLine("4. feladat:\n\t" + uo + " utas indult.");
//Console.WriteLine("4. feladat:\n\t{0} utas indult.", uo);
//Console.WriteLine($"4. feladat:\n\t{uo} utas indult.");

//5. feladat
//SELECT COUNT(legenysegSzama)
//FROM kuldetesek
//WHERE utasokSzama < 5;

int km5u = kuldetesek.Count(x => x.LegenysegSzama < 5);
Console.WriteLine($"5. feladat:\n\t" +
    $"Összesen {km5u} alkalommal küldtek kevesebb, mint 5 embert az űrbe.");


//6. feladat:
//SELECT legenyszegSzama
//FROM kuldetesek
//WHERE sikloNeve LIKE 'Cokumbia'
//ORDER BY kilovesNapa DESC
//LIMIT 1

int cuul = kuldetesek
    .Where(x => x.SikloNeve == "Columbia")
    .OrderByDescending(x => x.KilovesDatuma)
    .First()
    .LegenysegSzama;

Console.WriteLine($"6.feladat:\n\t" +
    $"{cuul} asztronauta volt a Columbia fedélzetén annak utolsó útján.");

//7. feladat:
Kuldetes lhk = kuldetesek
    .OrderBy(x => x.KuldetesHossza)
    .Last();
Console.WriteLine($"7. feladat:\n\t" +
    $"A leghosszabb ideig a {lhk.SikloNeve} volt az űrben " +
    $"a {lhk.Kod} küldetés során.\n\t" +
    $"Összesen {lhk.KuldetesHossza} órát volt távol a Földtől.");

//8. feladat:
Console.Write("8. feladat:\n\tÉvszám: ");
int evszam = int.Parse(Console.ReadLine());
int aeksz = kuldetesek.Count(x => x.KilovesDatuma.Year == evszam);
if (aeksz == 0)
    Console.WriteLine("\tEbben az évben nem volt küldetés");
else Console.WriteLine($"\tEbben az évben {aeksz} küldetés volt.");

//9. feladat:
int kulsz = kuldetesek.Count(x => x.LandolasHelye == "Kennedy");
Console.WriteLine($"9. feladat:\n\t" +
    $"A küldetések {kulsz / (float)kuldetesek.Count * 100:0.00}%-a " +
    $"fejeződött be a Kennedy űrközpontban.");

//10. feladat:
//SELECT skiloNeve, [SUM(kuldetesHossza) / 24F]
//FROM kuldetesek
//GROUP BY sikloNeve;

var spkh = kuldetesek.GroupBy(x => x.SikloNeve);
using StreamWriter sw = new(@"..\..\..\res\ursiklok.txt");
foreach (var e in spkh)
    sw.WriteLine($"{e.Key}\t{e.Sum(x => x.KuldetesHossza) / 24f:0.00}");