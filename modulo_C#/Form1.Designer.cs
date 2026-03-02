namespace ProgettoGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            button2 = new Button();
            button1 = new Button();
            panel4 = new Panel();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label4 = new Label();
            panel3 = new Panel();
            comboBoxCAPDestinatario = new ComboBox();
            label14 = new Label();
            comboBoxCittaDestinatario = new ComboBox();
            label8 = new Label();
            label6 = new Label();
            comboBoxNazioneDestinatario = new ComboBox();
            label3 = new Label();
            panel2 = new Panel();
            comboBoxCAPMittente = new ComboBox();
            label13 = new Label();
            comboBoxCittaMittente = new ComboBox();
            label7 = new Label();
            label5 = new Label();
            comboBoxNazioneMittente = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(975, 492);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // button2
            // 
            button2.Location = new Point(718, 327);
            button2.Name = "button2";
            button2.Size = new Size(133, 65);
            button2.TabIndex = 4;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(192, 255, 192);
            button1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(403, 330);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(172, 62);
            button1.TabIndex = 3;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ButtonFace;
            panel4.BackgroundImageLayout = ImageLayout.None;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(label12);
            panel4.Controls.Add(label11);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(textBox4);
            panel4.Controls.Add(textBox3);
            panel4.Controls.Add(textBox2);
            panel4.Controls.Add(textBox1);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(657, 79);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(292, 187);
            panel4.TabIndex = 2;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label12.Location = new Point(3, 152);
            label12.Name = "label12";
            label12.Size = new Size(93, 20);
            label12.TabIndex = 10;
            label12.Text = "Height (cm):";
            label12.Click += label12_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label11.Location = new Point(3, 114);
            label11.Name = "label11";
            label11.Size = new Size(89, 20);
            label11.TabIndex = 9;
            label11.Text = "Width (cm):";
            label11.Click += label11_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label10.Location = new Point(3, 74);
            label10.Name = "label10";
            label10.Size = new Size(94, 20);
            label10.TabIndex = 8;
            label10.Text = "Length (cm):";
            label10.Click += label10_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label9.Location = new Point(3, 39);
            label9.Name = "label9";
            label9.Size = new Size(94, 20);
            label9.TabIndex = 7;
            label9.Text = "Weight (kg):";
            label9.Click += label9_Click;
            // 
            // textBox4
            // 
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.Location = new Point(117, 151);
            textBox4.Margin = new Padding(3, 2, 3, 2);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(122, 23);
            textBox4.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Location = new Point(117, 116);
            textBox3.Margin = new Padding(3, 2, 3, 2);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(122, 23);
            textBox3.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Location = new Point(117, 75);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(122, 23);
            textBox2.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(117, 40);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(122, 23);
            textBox1.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Symbol", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(60, -1);
            label4.Name = "label4";
            label4.Size = new Size(154, 20);
            label4.TabIndex = 0;
            label4.Text = "Package dimension";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ButtonFace;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(comboBoxCAPDestinatario);
            panel3.Controls.Add(label14);
            panel3.Controls.Add(comboBoxCittaDestinatario);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(comboBoxNazioneDestinatario);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(339, 79);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(292, 187);
            panel3.TabIndex = 2;
            panel3.Paint += panel3_Paint;
            // 
            // comboBoxCAPDestinatario
            // 
            comboBoxCAPDestinatario.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxCAPDestinatario.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxCAPDestinatario.FormattingEnabled = true;
            comboBoxCAPDestinatario.Location = new Point(102, 112);
            comboBoxCAPDestinatario.Margin = new Padding(3, 2, 3, 2);
            comboBoxCAPDestinatario.Name = "comboBoxCAPDestinatario";
            comboBoxCAPDestinatario.Size = new Size(186, 23);
            comboBoxCAPDestinatario.TabIndex = 8;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label14.Location = new Point(3, 114);
            label14.Name = "label14";
            label14.Size = new Size(74, 20);
            label14.TabIndex = 8;
            label14.Text = "ZIP Code:";
            // 
            // comboBoxCittaDestinatario
            // 
            comboBoxCittaDestinatario.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxCittaDestinatario.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxCittaDestinatario.FormattingEnabled = true;
            comboBoxCittaDestinatario.Location = new Point(102, 80);
            comboBoxCittaDestinatario.Margin = new Padding(3, 2, 3, 2);
            comboBoxCittaDestinatario.Name = "comboBoxCittaDestinatario";
            comboBoxCittaDestinatario.Size = new Size(186, 23);
            comboBoxCittaDestinatario.TabIndex = 6;
            comboBoxCittaDestinatario.SelectedIndexChanged += comboBoxCittaDestinatario_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label8.Location = new Point(3, 82);
            label8.Name = "label8";
            label8.Size = new Size(36, 20);
            label8.TabIndex = 6;
            label8.Text = "City";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.Location = new Point(3, 45);
            label6.Name = "label6";
            label6.Size = new Size(68, 20);
            label6.TabIndex = 4;
            label6.Text = "Country:";
            // 
            // comboBoxNazioneDestinatario
            // 
            comboBoxNazioneDestinatario.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxNazioneDestinatario.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxNazioneDestinatario.FormattingEnabled = true;
            comboBoxNazioneDestinatario.Items.AddRange(new object[] { "Afghanistan - AF", "Albania - AL", "Algeria - DZ", "Andorra - AD", "Angola - AO", "Antigua e Barbuda - AG", "Argentina - AR", "Armenia - AM", "Australia - AU", "Austria - AT", "Azerbaigian - AZ", "Bahamas - BS", "Bahrein - BH", "Bangladesh - BD", "Barbados - BB", "Bielorussia - BY", "Belgio - BE", "Belize - BZ", "Benin - BJ", "Bhutan - BT", "Bolivia - BO", "Bosnia ed Erzegovina - BA", "Botswana - BW", "Brasile - BR", "Brunei - BN", "Bulgaria - BG", "Burkina Faso - BF", "Burundi - BI", "Cambogia - KH", "Camerun - CM", "Canada - CA", "Capo Verde - CV", "Repubblica Centrafricana - CF", "Ciad - TD", "Cile - CL", "Cina - CN", "Colombia - CO", "Comore - KM", "Costa Rica - CR", "Croazia - HR", "Cuba - CU", "Cipro - CY", "Repubblica Ceca - CZ", "Danimarca - DK", "Gibuti - DJ", "Dominica - DM", "Repubblica Dominicana - DO", "Ecuador - EC", "Egitto - EG", "El Salvador - SV", "Guinea Equatoriale - GQ", "Eritrea - ER", "Estonia - EE", "Eswatini - SZ", "Etiopia - ET", "Figi - FJ", "Finlandia - FI", "Francia - FR", "Gabon - GA", "Gambia - GM", "Georgia - GE", "Germania - DE", "Ghana - GH", "Grecia - GR", "Grenada - GD", "Guatemala - GT", "Guinea - GN", "Guinea-Bissau - GW", "Guyana - GY", "Haiti - HT", "Honduras - HN", "Ungheria - HU", "Islanda - IS", "India - IN", "Indonesia - ID", "Iran - IR", "Iraq - IQ", "Irlanda - IE", "Israele - IL", "Italia - IT", "Giamaica - JM", "Giappone - JP", "Giordania - JO", "Kazakistan - KZ", "Kenya - KE", "Kiribati - KI", "Kuwait - KW", "Kirghizistan - KG", "Laos - LA", "Lettonia - LV", "Libano - LB", "Lesotho - LS", "Liberia - LR", "Libia - LY", "Liechtenstein - LI", "Lituania - LT", "Lussemburgo - LU", "Madagascar - MG", "Malawi - MW", "Malesia - MY", "Maldive - MV", "Mali - ML", "Malta - MT", "Isole Marshall - MH", "Mauritania - MR", "Mauritius - MU", "Messico - MX", "Micronesia - FM", "Moldavia - MD", "Monaco - MC", "Mongolia - MN", "Montenegro - ME", "Marocco - MA", "Mozambico - MZ", "Myanmar - MM", "Namibia - NA", "Nauru - NR", "Nepal - NP", "Paesi Bassi - NL", "Nuova Zelanda - NZ", "Nicaragua - NI", "Niger - NE", "Nigeria - NG", "Corea del Nord - KP", "Macedonia del Nord - MK", "Norvegia - NO", "Oman - OM", "Pakistan - PK", "Palau - PW", "Panama - PA", "Papua Nuova Guinea - PG", "Paraguay - PY", "Perù - PE", "Filippine - PH", "Polonia - PL", "Portogallo - PT", "Qatar - QA", "Romania - RO", "Russia - RU", "Ruanda - RW", "Saint Kitts e Nevis - KN", "Santa Lucia - LC", "Saint Vincent e Grenadine - VC", "Samoa - WS", "San Marino - SM", "São Tomé e Príncipe - ST", "Arabia Saudita - SA", "Senegal - SN", "Serbia - RS", "Seychelles - SC", "Sierra Leone - SL", "Singapore - SG", "Slovacchia - SK", "Slovenia - SI", "Isole Salomone - SB", "Somalia - SO", "Sudafrica - ZA", "Corea del Sud - KR", "Sud Sudan - SS", "Spagna - ES", "Sri Lanka - LK", "Sudan - SD", "Suriname - SR", "Svezia - SE", "Svizzera - CH", "Siria - SY", "Taiwan - TW", "Tagikistan - TJ", "Tanzania - TZ", "Thailandia - TH", "Togo - TG", "Tonga - TO", "Trinidad e Tobago - TT", "Tunisia - TN", "Turchia - TR", "Turkmenistan - TM", "Tuvalu - TV", "Uganda - UG", "Ucraina - UA", "Emirati Arabi Uniti - AE", "Regno Unito - GB", "Stati Uniti - US", "Uruguay - UY", "Uzbekistan - UZ", "Vanuatu - VU", "Città del Vaticano - VA", "Venezuela - VE", "Vietnam - VN", "Yemen - YE", "Zambia - ZM", "Zimbabwe - ZW" });
            comboBoxNazioneDestinatario.Location = new Point(102, 43);
            comboBoxNazioneDestinatario.Margin = new Padding(3, 2, 3, 2);
            comboBoxNazioneDestinatario.Name = "comboBoxNazioneDestinatario";
            comboBoxNazioneDestinatario.Size = new Size(187, 23);
            comboBoxNazioneDestinatario.TabIndex = 3;
            comboBoxNazioneDestinatario.SelectedIndexChanged += comboBoxNazioneDestinatario_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Symbol", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(102, -1);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 1;
            label3.Text = "Receiver";
            label3.Click += label3_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonFace;
            panel2.BackgroundImageLayout = ImageLayout.None;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(comboBoxCAPMittente);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(comboBoxCittaMittente);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(comboBoxNazioneMittente);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(21, 79);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(292, 187);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // comboBoxCAPMittente
            // 
            comboBoxCAPMittente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxCAPMittente.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxCAPMittente.FormattingEnabled = true;
            comboBoxCAPMittente.Location = new Point(102, 112);
            comboBoxCAPMittente.Margin = new Padding(3, 2, 3, 2);
            comboBoxCAPMittente.Name = "comboBoxCAPMittente";
            comboBoxCAPMittente.Size = new Size(186, 23);
            comboBoxCAPMittente.TabIndex = 7;
            comboBoxCAPMittente.SelectedIndexChanged += comboBoxCAPMittente_SelectedIndexChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label13.Location = new Point(3, 114);
            label13.Name = "label13";
            label13.Size = new Size(74, 20);
            label13.TabIndex = 6;
            label13.Text = "ZIP Code:";
            // 
            // comboBoxCittaMittente
            // 
            comboBoxCittaMittente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxCittaMittente.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxCittaMittente.FormattingEnabled = true;
            comboBoxCittaMittente.Location = new Point(102, 79);
            comboBoxCittaMittente.Margin = new Padding(3, 2, 3, 2);
            comboBoxCittaMittente.Name = "comboBoxCittaMittente";
            comboBoxCittaMittente.Size = new Size(186, 23);
            comboBoxCittaMittente.TabIndex = 5;
            comboBoxCittaMittente.SelectedIndexChanged += comboBoxCittaMittente_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label7.Location = new Point(3, 80);
            label7.Name = "label7";
            label7.Size = new Size(40, 20);
            label7.TabIndex = 4;
            label7.Text = "City:";
            label7.Click += label7_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(3, 42);
            label5.Name = "label5";
            label5.Size = new Size(68, 20);
            label5.TabIndex = 3;
            label5.Text = "Country:";
            // 
            // comboBoxNazioneMittente
            // 
            comboBoxNazioneMittente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxNazioneMittente.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxNazioneMittente.FormattingEnabled = true;
            comboBoxNazioneMittente.Items.AddRange(new object[] { "Afghanistan - AF", "Albania - AL", "Algeria - DZ", "Andorra - AD", "Angola - AO", "Antigua e Barbuda - AG", "Argentina - AR", "Armenia - AM", "Australia - AU", "Austria - AT", "Azerbaigian - AZ", "Bahamas - BS", "Bahrein - BH", "Bangladesh - BD", "Barbados - BB", "Bielorussia - BY", "Belgio - BE", "Belize - BZ", "Benin - BJ", "Bhutan - BT", "Bolivia - BO", "Bosnia ed Erzegovina - BA", "Botswana - BW", "Brasile - BR", "Brunei - BN", "Bulgaria - BG", "Burkina Faso - BF", "Burundi - BI", "Cambogia - KH", "Camerun - CM", "Canada - CA", "Capo Verde - CV", "Repubblica Centrafricana - CF", "Ciad - TD", "Cile - CL", "Cina - CN", "Colombia - CO", "Comore - KM", "Costa Rica - CR", "Croazia - HR", "Cuba - CU", "Cipro - CY", "Repubblica Ceca - CZ", "Danimarca - DK", "Gibuti - DJ", "Dominica - DM", "Repubblica Dominicana - DO", "Ecuador - EC", "Egitto - EG", "El Salvador - SV", "Guinea Equatoriale - GQ", "Eritrea - ER", "Estonia - EE", "Eswatini - SZ", "Etiopia - ET", "Figi - FJ", "Finlandia - FI", "Francia - FR", "Gabon - GA", "Gambia - GM", "Georgia - GE", "Germania - DE", "Ghana - GH", "Grecia - GR", "Grenada - GD", "Guatemala - GT", "Guinea - GN", "Guinea-Bissau - GW", "Guyana - GY", "Haiti - HT", "Honduras - HN", "Ungheria - HU", "Islanda - IS", "India - IN", "Indonesia - ID", "Iran - IR", "Iraq - IQ", "Irlanda - IE", "Israele - IL", "Italia - IT", "Giamaica - JM", "Giappone - JP", "Giordania - JO", "Kazakistan - KZ", "Kenya - KE", "Kiribati - KI", "Kuwait - KW", "Kirghizistan - KG", "Laos - LA", "Lettonia - LV", "Libano - LB", "Lesotho - LS", "Liberia - LR", "Libia - LY", "Liechtenstein - LI", "Lituania - LT", "Lussemburgo - LU", "Madagascar - MG", "Malawi - MW", "Malesia - MY", "Maldive - MV", "Mali - ML", "Malta - MT", "Isole Marshall - MH", "Mauritania - MR", "Mauritius - MU", "Messico - MX", "Micronesia - FM", "Moldavia - MD", "Monaco - MC", "Mongolia - MN", "Montenegro - ME", "Marocco - MA", "Mozambico - MZ", "Myanmar - MM", "Namibia - NA", "Nauru - NR", "Nepal - NP", "Paesi Bassi - NL", "Nuova Zelanda - NZ", "Nicaragua - NI", "Niger - NE", "Nigeria - NG", "Corea del Nord - KP", "Macedonia del Nord - MK", "Norvegia - NO", "Oman - OM", "Pakistan - PK", "Palau - PW", "Panama - PA", "Papua Nuova Guinea - PG", "Paraguay - PY", "Perù - PE", "Filippine - PH", "Polonia - PL", "Portogallo - PT", "Qatar - QA", "Romania - RO", "Russia - RU", "Ruanda - RW", "Saint Kitts e Nevis - KN", "Santa Lucia - LC", "Saint Vincent e Grenadine - VC", "Samoa - WS", "San Marino - SM", "São Tomé e Príncipe - ST", "Arabia Saudita - SA", "Senegal - SN", "Serbia - RS", "Seychelles - SC", "Sierra Leone - SL", "Singapore - SG", "Slovacchia - SK", "Slovenia - SI", "Isole Salomone - SB", "Somalia - SO", "Sudafrica - ZA", "Corea del Sud - KR", "Sud Sudan - SS", "Spagna - ES", "Sri Lanka - LK", "Sudan - SD", "Suriname - SR", "Svezia - SE", "Svizzera - CH", "Siria - SY", "Taiwan - TW", "Tagikistan - TJ", "Tanzania - TZ", "Thailandia - TH", "Togo - TG", "Tonga - TO", "Trinidad e Tobago - TT", "Tunisia - TN", "Turchia - TR", "Turkmenistan - TM", "Tuvalu - TV", "Uganda - UG", "Ucraina - UA", "Emirati Arabi Uniti - AE", "Regno Unito - GB", "Stati Uniti - US", "Uruguay - UY", "Uzbekistan - UZ", "Vanuatu - VU", "Città del Vaticano - VA", "Venezuela - VE", "Vietnam - VN", "Yemen - YE", "Zambia - ZM", "Zimbabwe - ZW" });
            comboBoxNazioneMittente.Location = new Point(102, 43);
            comboBoxNazioneMittente.Margin = new Padding(3, 2, 3, 2);
            comboBoxNazioneMittente.Name = "comboBoxNazioneMittente";
            comboBoxNazioneMittente.Size = new Size(187, 23);
            comboBoxNazioneMittente.TabIndex = 2;
            comboBoxNazioneMittente.SelectedIndexChanged += comboBoxNazioneMittente_SelectedIndexChangedAsync;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Symbol", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(102, 0);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 0;
            label2.Text = "Sender";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Franklin Gothic Heavy", 19.8000011F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(332, 7);
            label1.Name = "label1";
            label1.Size = new Size(274, 34);
            label1.TabIndex = 0;
            label1.Text = "Shipping Finder v1.0";
            label1.Click += label1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(972, 490);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel3;
        private Panel panel2;
        private Label label2;
        private Label label3;
        private Panel panel4;
        private Label label4;
        private ComboBox comboBoxNazioneMittente;
        private Label label6;
        private ComboBox comboBoxNazioneDestinatario;
        private Label label5;
        private Label label7;
        private ComboBox comboBoxCittaMittente;
        private ComboBox comboBoxCittaDestinatario;
        private Label label8;
        private TextBox textBox1;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label9;
        private Label label11;
        private Label label10;
        private Label label12;
        private Button button1;
        private ComboBox comboBoxCAPMittente;
        private Label label13;
        private ComboBox comboBoxCAPDestinatario;
        private Label label14;
        private Button button2;
    }
}
