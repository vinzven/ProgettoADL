using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;





namespace ProgettoGUI
{

    /// Applica un fix ricorsivo a tutte le ComboBox presenti nel form.
    /// Chiude automaticamente il menu a tendina quando l'utente inizia a digitare,
    /// migliorando la leggibilità e l'esperienza d'uso.
    public partial class Form1 : Form
    {
        public Form1()


        {
            InitializeComponent();

            AbilitaFixComboBox(this);
        }
        // Cicla attraverso tutti i controlli contenuti nel 'parent'
        private void AbilitaFixComboBox(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                // Se il controllo è una ComboBox, applica la logica di "fix"
                if (c is ComboBox combo)
                {
                    // Gestisce l'evento di pressione tasti
                    combo.KeyDown += (s, e) =>
                    {
                        if (combo.DroppedDown &&
                            (char.IsLetterOrDigit((char)e.KeyCode) || e.KeyCode == Keys.Back))
                        {
                            combo.DroppedDown = false;
                        }
                    };
                }

                // Se il controllo contiene altri controlli (es. un Panel o GroupBox), 
                // richiama se stesso ricorsivamente per non saltare nessuna ComboBox
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

        //inserimento nazione mittente
        private async void comboBoxNazioneMittente_SelectedIndexChangedAsync(object sender, EventArgs e)
        {
            //selezione nazione con controllo se object null
            object selezione = comboBoxNazioneMittente.SelectedItem;

            if (selezione != null)
            {
                //svuotamento città e CAP e disabilitazione bottone finché non carica le città
                comboBoxCittaMittente.Items.Clear();
                comboBoxCittaMittente.Text = "Caricamento in corso";

                comboBoxCAPMittente.Items.Clear();
                comboBoxCAPMittente.Text = "";


                // disabilitiamo il bottone finché non carica le città 
                button1.Enabled = false;

                // Recuperiamo l'ISO dalla stringa selezionata (es: "Italia - IT" -> "IT") per poter fare la chiamata API corretta
                string nazione = selezione.ToString().Split('-')[1].Trim();
                Console.WriteLine(nazione);
                await CaricaTutteLeCittaDellaNazione(nazione, comboBoxCittaMittente);

                //riabilitiamo il bottone solo dopo che le città sono state caricate, così evitiamo che l'utente clicchi prima del tempo
                button1.Enabled = true;

            }

        }


        // Form di caricamento semplice da mostrare durante l'attesa dello script Python
        public class LoadingForm : Form
        {
            public LoadingForm(string messaggioIniziale)
            {
                this.Text = "Caricamento";

                this.ControlBox = false;

                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.StartPosition = FormStartPosition.CenterScreen;
                //this.TopMost = true;
                this.Size = new Size(450, 150);

                Label lblTesto = new Label()
                {
                    Text = messaggioIniziale,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 11, FontStyle.Regular),
                    Padding = new Padding(10)
                };

                this.Controls.Add(lblTesto);
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

        }


        // classi per dialog dei risultati
        public class Spedizione
        {
            public string nome_sito { get; set; }
            public string corriere { get; set; }
            public string prezzo { get; set; }
            public string prezzo_iva { get; set; }
            public string tempo { get; set; }
            public string sito { get; set; }
        }

        public class RisultatoPython
        {
            public List<Spedizione> ordinate_per_prezzo { get; set; }
            public List<Spedizione> ordinate_per_tempo { get; set; }
        }



        public partial class FormSpedizioni : Form
        {
            private List<Process> processiAttivi = new List<Process>();
            public FormSpedizioni(RisultatoPython dati)
            {

                this.Text = "Migliori Tariffe Trovate";
                this.Size = new Size(900, 500);
                this.StartPosition = FormStartPosition.CenterScreen;

                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;

                TabControl tabs = new TabControl { Dock = DockStyle.Fill };

                // Creiamo le due tab
                tabs.TabPages.Add(CreaTab("Economiche", dati.ordinate_per_prezzo));
                tabs.TabPages.Add(CreaTab("Veloci", dati.ordinate_per_tempo));

                this.Controls.Add(tabs);
            }

            private TabPage CreaTab(string titolo, List<Spedizione> lista)
            {
                TabPage pagina = new TabPage(titolo);
                DataGridView grid = new DataGridView
                {
                    Dock = DockStyle.Fill,
                    DataSource = lista,
                    ReadOnly = false,
                    AllowUserToAddRows = false,
                    RowHeadersVisible = false,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                    AllowUserToResizeColumns = false,
                    AllowUserToResizeRows = false
                };

                // USIAMO QUESTO EVENTO: viene lanciato quando i dati sono stati "agganciati"
                grid.DataBindingComplete += (s, e) =>
                {

                    grid.Columns["sito"].Visible = false;
                    grid.Columns["prezzo"].Visible = false;
                };

                // Aggiungiamo la colonna del Bottone (questa non sparisce perché la aggiungiamo a mano)
                DataGridViewButtonColumn colonnaBottone = new DataGridViewButtonColumn
                {
                    Name = "btnVai",
                    HeaderText = "Azione",
                    Text = "Vai al sito",
                    UseColumnTextForButtonValue = true,
                    Width = 100,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                };
                grid.Columns.Add(colonnaBottone);


                grid.CellContentClick += async (sender, e) =>
                {
                    var senderGrid = (DataGridView)sender;
                    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                    {

                        var riga = senderGrid.Rows[e.RowIndex];
                        string url = riga.Cells["sito"].Value?.ToString();
                        string corriere = riga.Cells["corriere"].Value?.ToString();
                        string prezzo_iva = riga.Cells["prezzo_iva"].Value?.ToString();
                        string prezzo = riga.Cells["prezzo"].Value?.ToString();
                        string nome_sito = riga.Cells["nome_sito"].Value?.ToString();

                        if (!string.IsNullOrEmpty(url))
                        {

                            try
                            {
                                Console.WriteLine($"URL: {url} | Corriere: {corriere} | Prezzo: {prezzo}€");

                                await ApriSitoWeb(url, prezzo, corriere);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(
                                    "Errore durante l'apertura del sito.\n\n" + ex.Message,
                                    "Errore",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                            }

                        }
                        else
                        {
                            MessageBox.Show(
                                "URL non valido per questa spedizione.",
                                "Attenzione",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                        }

                    }
                };

                pagina.Controls.Add(grid);
                return pagina;
            }

            private async Task ApriSitoWeb(string url, string prezzo, string corriere)
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string cartellaPython = Path.Combine(baseDir, "Module_Phyton");

                // Interprete Python dentro l'ambiente virtuale
                string percorsoInterprete = Path.Combine(cartellaPython, "env", "Scripts", "python.exe");

                // Percorso dello script Python
                string percorsoScript = Path.Combine(cartellaPython, "Acquisto.py");

                ProcessStartInfo start = new ProcessStartInfo();
                
                    start.FileName = percorsoInterprete;
                    start.Arguments = $"\"{percorsoScript}\" \"{url}\" \"{prezzo}\" \"{corriere}\"";
                    start.UseShellExecute = false;
                    start.RedirectStandardInput = false;
                    start.RedirectStandardOutput = false;
                    start.CreateNoWindow = true;


                if (!File.Exists(percorsoInterprete))
                {
                    MessageBox.Show($@"Errore: Ambiente virtuale non trovato!  assicurati di aver eseguito il file .bat per creare la cartella:
                                {percorsoInterprete}", "Ambiente Mancante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Interrompe l'esecuzione prima del crash
                }

                if (!File.Exists(percorsoScript))
                {
                    MessageBox.Show($"Errore: Lo script Python non è presente in: {percorsoScript}",
                                    "Script Mancante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //LoadingForm f1 = new LoadingForm("Elaborazione in corso attendere...");
                //f1.Show();
                //f1.Refresh();
                Process p = new Process();
                p.StartInfo = start;

                p.Start();

                processiAttivi.Add(p);

                try
                {
                    await p.WaitForExitAsync();
                }
                finally
                {
                    processiAttivi.Remove(p);
                }

            }


            protected override void OnFormClosing(FormClosingEventArgs e)
            {
                foreach (var p in processiAttivi)
                {
                    try
                    {
                        if (!p.HasExited)
                            p.Kill(true); // chiude anche eventuali figli
                    }
                    catch { }
                }

                base.OnFormClosing(e);
            }

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

                    comboBoxCAPDestinatario.Items.Clear();
                    comboBoxCAPDestinatario.Text = "";

                    button1.Enabled = false;

                    string cittaScelta = comboBoxCittaDestinatario.SelectedItem.ToString();
                    string iso = comboBoxNazioneDestinatario.SelectedItem.ToString().Split('-')[1].Trim();

                    await CaricaCAPCitta(iso, cittaScelta, comboBoxCAPDestinatario);

                    button1.Enabled = true;
                }
            }

        }

        private async void comboBoxNazioneDestinatario_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selezione nazione con controllo se object null
            object selezione = comboBoxNazioneDestinatario.SelectedItem;

            if (selezione != null)
            {

                comboBoxCittaDestinatario.Items.Clear();
                comboBoxCittaDestinatario.Text = "Caricamento in corso...";

                comboBoxCAPDestinatario.Items.Clear();
                comboBoxCAPDestinatario.Text = "";

                button1.Enabled = false;

                string nazione = selezione.ToString().Split('-')[1].Trim();
                Console.WriteLine(nazione);
                await CaricaTutteLeCittaDellaNazione(nazione, comboBoxCittaDestinatario);

                button1.Enabled = true;
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

                    comboBoxCAPMittente.Items.Clear();
                    comboBoxCAPMittente.Text = "";

                    button1.Enabled = false;

                    string cittaScelta = comboBoxCittaMittente.SelectedItem.ToString();

                    // Recuperiamo l'ISO dalla prima ComboBox (es: "Italia - IT")
                    string iso = comboBoxNazioneMittente.SelectedItem.ToString().Split('-')[1].Trim();

                    await CaricaCAPCitta(iso, cittaScelta, comboBoxCAPMittente);

                    button1.Enabled = true;
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
            // Controlliamo che tutte le selezioni siano state 

            object? comboBox1Item = comboBoxNazioneMittente.SelectedItem;
            object? comboBox2Item = comboBoxNazioneDestinatario.SelectedItem;

            object? comboBoxCittaMittenteItem = comboBoxCittaMittente.SelectedItem;
            object? comboBoxCittaDestinatarioItem = comboBoxCittaDestinatario.SelectedItem;

            string capMittente = comboBoxCAPMittente.Text;
            string capDestinatario = comboBoxCAPDestinatario.Text;



            string peso = textBox1.Text;
            string lunghezza = textBox2.Text;
            string larghezza = textBox3.Text;
            string altezza = textBox4.Text;

            // Verifica che nessuna delle selezioni sia null e che i campi di testo non siano vuoti o solo spazi
            if (comboBox1Item != null && comboBox2Item != null && comboBoxCittaMittenteItem != null &&
                comboBoxCittaDestinatarioItem != null &&
                !string.IsNullOrWhiteSpace(capMittente) && !string.IsNullOrWhiteSpace(capDestinatario) && !string.IsNullOrWhiteSpace(peso) && !string.IsNullOrWhiteSpace(lunghezza) &&
                !string.IsNullOrWhiteSpace(larghezza) && !string.IsNullOrWhiteSpace(altezza))
            {

                // Estraiamo le stringhe dalle selezioni
                string nazioneMittente = comboBox1Item.ToString();
                string nazioneDestinatario = comboBox2Item.ToString();

                string cittaMittente = comboBoxCittaMittenteItem.ToString();
                string cittaDestinatario = comboBoxCittaDestinatarioItem.ToString();


                float pesoNum;

                int lunghezzaNum, larghezzaNum, altezzaNum;

                // Verifichiamo che peso sia un numero decimale valido e che le dimensioni siano numeri interi validi

                if (float.TryParse(peso, out pesoNum) && int.TryParse(lunghezza, out lunghezzaNum) &&
                    int.TryParse(larghezza, out larghezzaNum) && int.TryParse(altezza, out altezzaNum))
                {

                    // Controlliamo che peso e dimensioni siano positivi

                    if (pesoNum <= 0 || lunghezzaNum <= 0 || larghezzaNum <= 0 || altezzaNum <= 0)
                    {
                        MessageBox.Show("le dimensioni del pacco devono essere positive!",
                                        "errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Interrompe l'esecuzione se i dati non sono validi
                    }


                    int valoreNazioneMittente = comboBoxNazioneMittente.FindStringExact(nazioneMittente);
                    int valoreNazioneDestinatario = comboBoxNazioneDestinatario.FindStringExact(nazioneDestinatario);

                    int valoreCittaMittente = comboBoxCittaMittente.FindStringExact(cittaMittente);
                    int valoreCittaDestinatario = comboBoxCittaDestinatario.FindStringExact(cittaDestinatario);
                    int valoreCapMittente = comboBoxCAPMittente.FindStringExact(capMittente);
                    int valoreCapDestinatario = comboBoxCAPDestinatario.FindStringExact(capDestinatario);


                    // Se tutte le selezioni sono valide (non -1) 
                    if (valoreNazioneMittente != -1 && valoreNazioneDestinatario != -1 && valoreCittaMittente != -1 && valoreCittaDestinatario != -1 && valoreCapMittente != 1 && valoreCapDestinatario != -1)
                    {



                        // stampiamo un riepilogo di tutti i dati inseriti in un MessageBox per conferma prima di lanciare lo script Python, così l'utente può verificare di aver inserito tutto correttamente
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

                        // Se l'utente conferma, procediamo con l'esecuzione dello script Python
                        if (risposta == DialogResult.Yes)
                        {
                            // Controllo ulteriore: se mittente e destinatario sono esattamente uguali, mostriamo un errore.
                            if (cittaMittente == cittaDestinatario && capMittente == capDestinatario && nazioneMittente == nazioneDestinatario)
                            {
                                MessageBox.Show("Il mittente e il destinatario non possono essere uguali!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            // Creiamo un oggetto anonimo con tutti i dati, che poi serializzeremo in JSON per passarlo a Python
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
                            // Serializziamo l'oggetto in una stringa JSON
                            string jsonString = JsonSerializer.Serialize(datiJson);
                            // Percorso base dell'applicazione
                            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                            string cartellaPython = Path.Combine(baseDir, "Module_Phyton");

                            // Interprete Python dentro l'ambiente virtuale
                            string percorsoInterprete = Path.Combine(cartellaPython, "env", "Scripts", "python.exe");

                            // Percorso dello script Python
                            string percorsoScript = Path.Combine(cartellaPython, "Module_Phyton.py");

                            ProcessStartInfo start = new ProcessStartInfo();

                            // usa l'ambiente virtuale per essere sicuri di avere tutte le dipendenze
                            start.FileName = percorsoInterprete;

                            // Passiamo il percorso dello script come argomento
                            start.Arguments = $"\"{percorsoScript}\"";

                            start.UseShellExecute = false;
                            start.RedirectStandardInput = true;
                            start.RedirectStandardOutput = true;
                            start.CreateNoWindow = true;


                            //controllo ambiente virtuale e script Python

                            if (!File.Exists(percorsoInterprete))
                            {
                                MessageBox.Show($@"Errore: Ambiente virtuale non trovato!  assicurati di aver eseguito il file .bat per creare la cartella:
                                {percorsoInterprete}", "Ambiente Mancante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return; // Interrompe l'esecuzione prima del crash
                            }

                            if (!File.Exists(percorsoScript))
                            {
                                MessageBox.Show($"Errore: Lo script Python non è presente in: {percorsoScript}",
                                                "Script Mancante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }


                            // Mostriamo un form di caricamento mentre aspettiamo la risposta dallo script Python
                            LoadingForm f1 = new LoadingForm("Elaborazione in corso attendere...");
                            f1.Show();
                            f1.Refresh();
                            string risultato = "";

                            // Avviamo il processo e comunichiamo con esso tramite StandardInput e StandardOutput

                            using (Process p = Process.Start(start))
                            {
                                //  Scrive l'input (JSON)
                                p.StandardInput.WriteLine(jsonString);
                                p.StandardInput.Close(); // Finito di scrivere

                                // Legge l'output

                                risultato = p.StandardOutput.ReadToEnd();

                                p.WaitForExit(); // Aspetta che finisca

                            }

                            f1.Close();

                            //  GESTISCI IL RISULTATO
                            if (!string.IsNullOrEmpty(risultato))
                            {
                                try
                                {
                                    // Cerchiamo la posizione della prima parentesi graffa
                                    int indiceInizioJson = risultato.IndexOf('{');

                                    // Se troviamo una graffa, proviamo a deserializzare da lì in poi
                                    if (indiceInizioJson != -1)
                                    {
                                        // Prendiamo solo dalla prima graffa in poi
                                        string jsonPuro = risultato.Substring(indiceInizioJson);

                                        // Deserializziamo il JSON puro in un oggetto C#
                                        var opzioni = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                                        RisultatoPython datiFinali = JsonSerializer.Deserialize<RisultatoPython>(jsonPuro, opzioni);

                                        if (datiFinali != null)
                                        {
                                            // Apriamo il form dei risultati passando i dati deserializzati
                                            FormSpedizioni f = new FormSpedizioni(datiFinali);
                                            f.ShowDialog();

                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Errore: Python non ha restituito alcun dato JSON valido.\nOutput ricevuto: " + risultato);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Errore durante l'estrazione dei dati: " + ex.Message);
                                }

                            }

                            else
                            {
                                MessageBox.Show("Il modulo C++ non ha restituito dati!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }



                        }

                    }
                    else
                    {

                        MessageBox.Show("i valori inseriti non sono coretti!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }


                else
                {
                    MessageBox.Show("le dimensioni del pacco sono errate! I valori devono essere interi positivi", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Si prega di compilare tutti i campi", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }


        private void comboBoxCAPMittente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

       
    }

}

