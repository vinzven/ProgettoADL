using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProgettoGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async void comboBox1_SelectedIndexChangedAsync(object sender, EventArgs e)
        {
            //selezione nazione con controllo se object null
            object selezione = comboBox1.SelectedItem;

            if (selezione != null)
            {
                string nazione = selezione.ToString().Split('-')[1].Trim();
                Console.WriteLine(nazione);
                await CaricaTutteLeCittaDellaNazione(nazione, comboBoxCittaMittente);

            }

        }

        //chiamata API codice postale
        public class GeonamesSearchResponse
        {
            [JsonPropertyName("totalResultsCount")]
            public int TotaleRisultati { get; set; } // <--- Fondamentale per il ciclo

            [JsonPropertyName("geonames")]
            public List<CityEntry> Cities { get; set; }
        }

        public class CityEntry
        {
            // Questo "mappa" la proprietà JSON 'name' sulla variabile C# 'Nome'
            [JsonPropertyName("name")]
            public string Nome { get; set; }

            // 'adminName1' in GeoNames di solito è la Regione (es. Lazio)
            [JsonPropertyName("adminName1")]
            public string Regione { get; set; }

            // 'population' è il numero di abitanti
            [JsonPropertyName("population")]
            public int Popolazione { get; set; }
        }

        private async Task CaricaTutteLeCittaDellaNazione(string codiceISO, ComboBox comboBoxSelected)
        {
            string user = "assasinghira01";
            int startRow = 0;
            int maxRows = 1000;
            int totaleScaricato = 0;

            // 1. Creiamo una lista temporanea per accumulare i nomi
            List<string> tutteLeCitta = new List<string>();

            using HttpClient client = new HttpClient();

            try
            {
                while (true)
                {
                    string url = $"http://api.geonames.org/searchJSON?country={codiceISO}&featureClass=P&maxRows={maxRows}&startRow={startRow}&orderby=population&username={user}";

                    string json = await client.GetStringAsync(url);
                    var risultato = JsonSerializer.Deserialize<GeonamesSearchResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    if (risultato?.Cities == null || risultato.Cities.Count == 0) break;

                    // 2. Aggiungiamo le città alla lista temporanea invece che alla ComboBox
                    foreach (var city in risultato.Cities)
                    {
                        tutteLeCitta.Add($"{city.Nome}");
                    }

                    totaleScaricato += risultato.Cities.Count;
                    if (totaleScaricato >= risultato.TotaleRisultati) break;

                    startRow += maxRows;
                }

                // 3. ORDINE ALFABETICO: Ordiniamo la lista completa
                tutteLeCitta.Sort();

                // 4. Carichiamo la ComboBox in un colpo solo
                comboBoxSelected.Items.Clear();
                comboBoxSelected.BeginUpdate();
                comboBoxSelected.Items.AddRange(tutteLeCitta.ToArray());
                comboBoxSelected.EndUpdate();

                comboBoxSelected.Text = "Select a city...";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore durante il caricamento: " + ex.Message);
            }
        }


        private void label7_Click(object sender, EventArgs e)
        {

        }

        private async void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCittaDestinatario.SelectedItem != null)
            {
                string cittaScelta = comboBoxCittaDestinatario.SelectedItem.ToString();

                // Recuperiamo l'ISO dalla prima ComboBox (es: "Italia - IT")
                if (comboBox2.SelectedItem.ToString() != "")
                {
                    string iso = comboBox2.SelectedItem.ToString().Split('-')[1].Trim();

                    await CaricaCAPCitta(iso, cittaScelta, comboBoxCAPDestinatario);
                }
            }

        }

        private async void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selezione nazione con controllo se object null
            object selezione = comboBox2.SelectedItem;

            if (selezione != null)
            {
                string nazione = selezione.ToString().Split('-')[1].Trim();
                Console.WriteLine(nazione);
                await CaricaTutteLeCittaDellaNazione(nazione, comboBoxCittaDestinatario);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private async void comboBoxCitta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCittaMittente.SelectedItem != null)
            {
                if (comboBox1.SelectedItem != null)
                {
                    string cittaScelta = comboBoxCittaMittente.SelectedItem.ToString();

                    // Recuperiamo l'ISO dalla prima ComboBox (es: "Italia - IT")
                    string iso = comboBox1.SelectedItem.ToString().Split('-')[1].Trim();

                    await CaricaCAPCitta(iso, cittaScelta, comboBoxCAPMittente);
                }
            }
        }


        //API per il CAP
        private async Task CaricaCAPCitta(string codiceISO, string cittaConRegione, ComboBox comboBoxCAP)
        {
            string user = "assasinghira01";

            // 1. Pulizia: "Roma (Lazio)" diventa "Roma"
            string nomeCittaPuro = cittaConRegione.Split('(')[0].Trim();

            // 2. URL specifico per i CAP di quella città
            string url = $"http://api.geonames.org/postalCodeSearchJSON?placename={Uri.EscapeDataString(nomeCittaPuro)}&country={codiceISO}&maxRows=20&username={user}";

            using HttpClient client = new HttpClient();
            try
            {
                string json = await client.GetStringAsync(url);
                var risultato = JsonSerializer.Deserialize<PostalCodeResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                comboBoxCAPMittente.Items.Clear();

                if (risultato?.PostalCodes != null && risultato.PostalCodes.Count > 0)
                {
                    foreach (var item in risultato.PostalCodes)
                    {
                        // Evitiamo duplicati se l'API manda lo stesso CAP più volte
                        if (!comboBoxCAP.Items.Contains(item.CAP))
                        {
                            comboBoxCAP.Items.Add(item.CAP);
                        }
                    }
                    comboBoxCAP.SelectedIndex = 0;
                }
                else
                {
                    comboBoxCAP.Text = "Nessun CAP trovato.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore durante il recupero del CAP: " + ex.Message);
            }
        }
        public class PostalCodeResponse
        {
            [JsonPropertyName("postalCodes")]
            public List<PostalCodeItem> PostalCodes { get; set; }
        }

        public class PostalCodeItem
        {
            [JsonPropertyName("postalCode")]
            public string CAP { get; set; }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //da aggiungere controllo se null per campi
            string nazioneMittente = comboBox1.SelectedItem.ToString();
            string nazioneDestinatario = comboBox2.SelectedItem.ToString();

            string cittaMittente = comboBoxCittaMittente.SelectedItem.ToString();
            string cittaDestinatario = comboBoxCittaDestinatario.SelectedItem.ToString();

            string capMittente = comboBoxCAPMittente.Text;
            string capDestinatario = comboBoxCAPDestinatario.Text;

            string peso = textBox1.Text;
            string lunghezza = textBox2.Text;
            string larghezza = textBox3.Text;
            string altezza = textBox4.Text;

            Console.WriteLine();

            // Supponiamo che queste variabili contengano i tuoi dati
            string riepilogo = $@"
--------------------------------------------------
          Are you sure?
--------------------------------------------------
SENDER:
  Country:      {nazioneMittente.ToUpper()}
  City:        {cittaMittente}
  ZIP CODE:          {capMittente}

RECEIVER:
  Country:      {nazioneDestinatario.ToUpper()}
  City:        {cittaDestinatario}
  ZIP CODE:          {capDestinatario}

Package info:
  Weight:         {peso} kg
  Size:   {lunghezza}x{larghezza}x{altezza} cm
--------------------------------------------------
";

            // Stampa nell'output di debug o in una finestra
            Console.WriteLine(riepilogo);
            MessageBox.Show(riepilogo);
        }

        private void comboBoxCAPMittente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}

