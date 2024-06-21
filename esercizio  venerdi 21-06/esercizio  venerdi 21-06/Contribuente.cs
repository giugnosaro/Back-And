using System;
using System.Text;

namespace esercizio_venerdi_21_06
{
    public class Contribuente
    {
        // Proprietà della classe
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string DataDiNascita { get; set; }
        public string CodiceFiscale { get; private set; }
        public Sesso Genere { get; set; }
        public string ComuneDiResidenza { get; set; }
        public string ProvinciaResidenza { get; set; }
        public int RedditoAnnuale { get; set; }

        // Enum Sesso
        public enum Sesso
        {
            Uomo,
            Donna
        }

        // Costruttore
        public Contribuente(string nome, string cognome, string dataDiNascita, Sesso genere, string comuneDiResidenza, string provinciaResidenza, int redditoAnnuale)
        {
            Nome = nome;
            Cognome = cognome;
            DataDiNascita = dataDiNascita;
            Genere = genere;
            ComuneDiResidenza = comuneDiResidenza;
            ProvinciaResidenza = provinciaResidenza;
            RedditoAnnuale = redditoAnnuale;
            CodiceFiscale = CalcolaCodiceFiscale();
        }

        // Metodo per calcolare il codice fiscale
        private string CalcolaCodiceFiscale()
        {
            StringBuilder codiceFiscale = new StringBuilder();

            // Cognome (prime tre consonanti)
            string codiceCognome = GeneraCodiceConsonanti(Cognome);
            Console.WriteLine($"Codice Cognome: {codiceCognome}");
            codiceFiscale.Append(codiceCognome);

            // Nome (prime tre consonanti)
            string codiceNome = GeneraCodiceConsonanti(Nome);
            Console.WriteLine($"Codice Nome: {codiceNome}");
            codiceFiscale.Append(codiceNome);

            // Data di nascita
            string giorno = DataDiNascita.Substring(0, 2);
            Console.WriteLine($"Giorno: {giorno}");
            codiceFiscale.Append(giorno);

            string mese = DataDiNascita.Substring(3, 2);
            Console.WriteLine($"Mese: {mese}");
            codiceFiscale.Append(MeseLettera(mese));

            string anno = DataDiNascita.Substring(8, 2);
            Console.WriteLine($"Anno: {anno}");
            codiceFiscale.Append(anno);

            // Sesso
            codiceFiscale.Append(Genere == Sesso.Uomo ? "M" : "F");

            // Comune di residenza (semplificato)
            string comune = ComuneDiResidenza.Length > 3 ? ComuneDiResidenza.Substring(0, 3).ToUpper() : ComuneDiResidenza.ToUpper();
            Console.WriteLine($"Comune: {comune}");
            codiceFiscale.Append(comune);

            // Calcolo del carattere di controllo
            char carattereControllo = CalcolaCarattereControllo(codiceFiscale.ToString());
            Console.WriteLine($"Carattere di controllo: {carattereControllo}");
            codiceFiscale.Append(carattereControllo);

            // Assicura che il codice fiscale sia esattamente di 16 caratteri
            if (codiceFiscale.Length != 16)
            {
                throw new InvalidOperationException("Errore nella generazione del codice fiscale.");
            }

            return codiceFiscale.ToString();
        }


        // Metodo per calcolare il carattere di controllo del codice fiscale
        private char CalcolaCarattereControllo(string codiceFiscaleParziale)
        {
            int valoreParziale = 0;

            // Calcola il valore parziale sommando i valori numerici associati ai caratteri del codice fiscale parziale
            for (int i = 0; i < codiceFiscaleParziale.Length; i++)
            {
                char carattere = codiceFiscaleParziale[i];

                if (char.IsDigit(carattere))
                {
                    valoreParziale += int.Parse(carattere.ToString());
                }
                else if (char.IsLetter(carattere))
                {
                    // Mappa le lettere ai loro valori secondo la tabella del codice fiscale
                    int valoreLettera = ((int)carattere) - 65 + 10; // 65 è il codice ASCII per 'A'
                    valoreParziale += valoreLettera;
                }
                else
                {
                    // Gestione errore, se il codice fiscale contiene caratteri non previsti
                    throw new InvalidOperationException("Il codice fiscale contiene caratteri non validi.");
                }
            }

            // Calcola il carattere di controllo come il resto della divisione del valore parziale per 26
            int resto = valoreParziale % 26;
            char carattereControllo = (char)(resto + 65); // Converti il resto in carattere

            return carattereControllo;
        }


        // Metodo ausiliario per generare le prime tre consonanti di una stringa
        private string GeneraCodiceConsonanti(string testo)
        {
            StringBuilder codice = new StringBuilder();
            int conteggioConsonanti = 0;

            foreach (char c in testo.ToUpper())
            {
                if ("BCDFGHJKLMNPQRSTVWXYZ".Contains(c))
                {
                    codice.Append(c);
                    conteggioConsonanti++;
                }

                if (conteggioConsonanti >= 3)
                {
                    break;
                }
            }

            // Aggiungi 'X' se non ci sono abbastanza consonanti
            while (codice.Length < 3)
            {
                codice.Append("X");
            }

            return codice.ToString();
        }


        // Metodo ausiliario per ottenere il mese in lettera
        private string MeseLettera(string meseNumero)
        {
            switch (meseNumero)
            {
                case "01": return "A";
                case "02": return "B";
                case "03": return "C";
                case "04": return "D";
                case "05": return "E";
                case "06": return "H";
                case "07": return "L";
                case "08": return "M";
                case "09": return "P";
                case "10": return "R";
                case "11": return "S";
                case "12": return "T";
                default: throw new ArgumentException("Mese non valido");
            }
        }

        // Metodo per calcolare l'imposta
        public double CalcolaImposta()
        {
            double imposta = 0;
            if (RedditoAnnuale <= 15000)
            {
                imposta = RedditoAnnuale * 0.23;
            }
            else if (RedditoAnnuale <= 28000)
            {
                imposta = 15000 * 0.23 + (RedditoAnnuale - 15000) * 0.27;
            }
            else if (RedditoAnnuale <= 55000)
            {
                imposta = 15000 * 0.23 + 13000 * 0.27 + (RedditoAnnuale - 28000) * 0.38;
            }
            else if (RedditoAnnuale <= 75000)
            {
                imposta = 15000 * 0.23 + 13000 * 0.27 + 27000 * 0.38 + (RedditoAnnuale - 55000) * 0.41;
            }
            else
            {
                imposta = 15000 * 0.23 + 13000 * 0.27 + 27000 * 0.38 + 20000 * 0.41 + (RedditoAnnuale - 75000) * 0.43;
            }

            return imposta;
        }
        // Metodo per mostrare il riepilogo delle informazioni
        public string MostraRiepilogo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nome: {Nome}");
            sb.AppendLine($"Cognome: {Cognome}");
            sb.AppendLine($"Data di Nascita: {DataDiNascita}");
            sb.AppendLine($"Codice Fiscale: {CodiceFiscale}");
            sb.AppendLine($"Sesso: {Genere}");
            sb.AppendLine($"Comune di Residenza: {ComuneDiResidenza}");
            sb.AppendLine($"Provincia di Residenza: {ProvinciaResidenza}");
            sb.AppendLine($"Reddito Annuale: {RedditoAnnuale}");
            sb.AppendLine($"Imposta da Pagare: {CalcolaImposta()}");

            return sb.ToString();
        }
    }
}
