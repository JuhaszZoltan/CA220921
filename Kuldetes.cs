namespace CA220921
{
    internal class Kuldetes
    {
        //prop + tab + tab
        public string Kod { get; set; }
        public DateOnly KilovesDatuma { get; set; }
        public string SikloNeve { get; set; }
        private int KuldetesNap { get; set; }
        private int KuldetesOra { get; set; }
        public int KuldetesHossza => KuldetesNap * 24 + KuldetesOra;
        public string LandolasHelye { get; set; }
        public int LegenysegSzama { get; set; }

        //ctor + tab + tab
        public Kuldetes(string fileEgySora)
        {
            string[] v = fileEgySora.Split(';');

            Kod = v[0];
            KilovesDatuma = DateOnly.Parse(v[1]);
            SikloNeve = v[2];
            KuldetesNap = int.Parse(v[3]);
            KuldetesOra = int.Parse(v[4]);
            LandolasHelye = v[5];
            LegenysegSzama = int.Parse(v[6]);
        }
    }
}
