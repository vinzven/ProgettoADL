using System.Diagnostics;
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

            AbilitaFixComboBox(this);
        }

        private void AbilitaFixComboBox(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is ComboBox combo)
                {
                    combo.KeyDown += (s, e) =>
                    {
                        if (combo.DroppedDown &&
                            (char.IsLetterOrDigit((char)e.KeyCode) || e.KeyCode == Keys.Back))
                        {
                            combo.DroppedDown = false;
                        }
                    };
                }

                if (c.HasChildren)
                    AbilitaFixComboBox(c);
            }
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

        private async void comboBoxNazioneMittente_SelectedIndexChangedAsync(object sender, EventArgs e)
        {
            //selezione nazione con controllo se object null
            object selezione = comboBoxNazioneMittente.SelectedItem;

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
                    string url = $"http://api.geonames.org/searchJSON?country={codiceISO}&featureClass=P&maxRows={maxRows}&startRow={startRow}&orderby=population&lang=it&username={user}";

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

        private async void comboBoxCittaDestinatario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCittaDestinatario.SelectedItem != null)
            {
                if (comboBoxNazioneDestinatario.SelectedItem != null)
                {
                    string cittaScelta = comboBoxCittaDestinatario.SelectedItem.ToString();
                    string iso = comboBoxNazioneDestinatario.SelectedItem.ToString().Split('-')[1].Trim();

                    await CaricaCAPCitta(iso, cittaScelta, comboBoxCAPDestinatario);
                }
            }

        }

        private async void comboBoxNazioneDestinatario_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selezione nazione con controllo se object null
            object selezione = comboBoxNazioneDestinatario.SelectedItem;

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

        private async void comboBoxCittaMittente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCittaMittente.SelectedItem != null)
            {
                if (comboBoxNazioneMittente.SelectedItem != null)
                {
                    string cittaScelta = comboBoxCittaMittente.SelectedItem.ToString();

                    // Recuperiamo l'ISO dalla prima ComboBox (es: "Italia - IT")
                    string iso = comboBoxNazioneMittente.SelectedItem.ToString().Split('-')[1].Trim();

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

                comboBoxCAP.Items.Clear();

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
            object? comboBox1Item = comboBoxNazioneMittente.SelectedItem;
            object? comboBox2Item = comboBoxNazioneDestinatario.SelectedItem;

            object? comboBoxCittaMittenteItem = comboBoxCittaMittente.SelectedItem;
            object? comboBoxCittaDestinatarioItem = comboBoxCittaDestinatario.SelectedItem;

            string capMittente = comboBoxCAPMittente.Text;
            string capDestinatario = comboBoxCAPDestinatario.Text;


            if (comboBox1Item != null && comboBox2Item != null && comboBoxCittaMittenteItem != null &&
                comboBoxCittaDestinatarioItem != null &&
                !string.IsNullOrWhiteSpace(capMittente) && !string.IsNullOrWhiteSpace(capDestinatario))
            {
                string nazioneMittente = comboBox1Item.ToString();
                string nazioneDestinatario = comboBox2Item.ToString();

                string cittaMittente = comboBoxCittaMittenteItem.ToString();
                string cittaDestinatario = comboBoxCittaDestinatarioItem.ToString();



                string peso = textBox1.Text;
                string lunghezza = textBox2.Text;
                string larghezza = textBox3.Text;
                string altezza = textBox4.Text;



                float pesoNum;

                int lunghezzaNum, larghezzaNum, altezzaNum;

                if (float.TryParse(peso, out pesoNum) && int.TryParse(lunghezza, out lunghezzaNum) &&
                    int.TryParse(larghezza, out larghezzaNum) && int.TryParse(altezza, out altezzaNum))
                {


                    int valoreNazioneMittente = comboBoxNazioneMittente.FindStringExact(nazioneMittente);
                    int valoreNazioneDestinatario = comboBoxNazioneDestinatario.FindStringExact(nazioneDestinatario);

                    int valoreCittaMittente = comboBoxCittaMittente.FindStringExact(cittaMittente);
                    int valoreCittaDestinatario = comboBoxCittaDestinatario.FindStringExact(cittaDestinatario);
                    int valoreCapMittente = comboBoxCAPMittente.FindStringExact(capMittente);
                    int valoreCapDestinatario = comboBoxCAPDestinatario.FindStringExact(capDestinatario);

                    if (valoreNazioneMittente != -1 && valoreNazioneDestinatario != -1 && valoreCittaMittente != -1 && valoreCittaDestinatario != -1 && valoreCapMittente != 1 && valoreCapDestinatario != -1)
                    {


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
                        DialogResult risposta = MessageBox.Show(riepilogo, "Recap", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (risposta == DialogResult.Yes)
                        {
                            var datiJson = new
                            {
                                sender = new { country = nazioneMittente, city = cittaMittente, ZIP = capMittente },
                                receiver = new { country = nazioneDestinatario, city = cittaDestinatario, ZIP = capDestinatario },
                                package = new
                                {
                                    weight = peso,
                                    dimensions = new { l = lunghezza, w = larghezza, h = altezza }
                                }
                            };

                            string jsonString = JsonSerializer.Serialize(datiJson);

                            string cartellaScript = @"C:\Users\antonio\source\repos\ProgettoADL\Module_Phyton";
                            string nomeFile = "Module_Phyton.py";
                            string percorsoCompleto = System.IO.Path.Combine(cartellaScript, nomeFile);

                            ProcessStartInfo start = new ProcessStartInfo();

                            start.FileName = "python";
                            start.Arguments = $"\"{percorsoCompleto}\"";
                            start.UseShellExecute = false;
                            start.RedirectStandardInput = true;
                            start.RedirectStandardOutput = true;
                            start.CreateNoWindow = true;



                            using (Process p = Process.Start(start))
                            {
                                // 1. Scrivi l'input (JSON)
                                p.StandardInput.WriteLine(jsonString);
                                p.StandardInput.Close(); // Finito di scrivere

                                // 2. Leggi l'output
                                string risultato = p.StandardOutput.ReadToEnd();
                                p.WaitForExit(); // Aspetta che finisca

                                MessageBox.Show(risultato);
                            }

                        }

                    }
                    else
                    {

                        MessageBox.Show("the entered values are not correct!", "Fields Error");

                    }

                }


                else
                {
                    MessageBox.Show("The package dimensions must be numeric values!", "Fields Error");
                }
            }
            else
            {
                MessageBox.Show("Please fill all fields!", "Fields Error");


            }
        }






        private void comboBoxCAPMittente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LanciaPythonInModalitaAcquisto("https://www.packlink.it/order/IT/95031/IT/95041/service?origin-city=Adrano&destination-city=Caltagirone&p=2,20,33,22");
        }

        // checkout prova

        private void LanciaPythonInModalitaAcquisto(string url)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();

                // Percorso del tuo interprete Python (o solo "python" se è nelle variabili d'ambiente)
                psi.FileName = "python";

                // Percorso del file .py
                string scriptPath = @"C:\Users\antonio\source\repos\ProgettoADL\Module_Phyton\Module_Phyton.py";

                // COSTRUZIONE COMANDO
                // --url e --corriere sono gli argomenti che abbiamo definito in Python con argparse
                // Usiamo le virgolette (\") per gestire spazi nei nomi o caratteri strani nell'URL
                psi.Arguments = $"\"{scriptPath}\" --url \"{url}\"";

                // IMPOSTAZIONI VISIBILITÀ
                psi.UseShellExecute = false;

                // CreateNoWindow = false -> FONDAMENTALE: Vogliamo vedere la console nera 
                // così se c'è un errore lo leggi. Se vuoi nasconderla metti true, 
                // ma il browser si aprirà comunque perché headless=False in Python.
                psi.CreateNoWindow = false;

                Process.Start(psi);
            }
            catch (Exception ex)
            {
                // Gestisci errore (es. Python non installato)
                System.Windows.Forms.MessageBox.Show("Errore avvio Python: " + ex.Message);
            }
        }




    }

}

