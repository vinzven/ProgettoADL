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
            comboBox2 = new ComboBox();
            label3 = new Label();
            panel2 = new Panel();
            comboBoxCAPMittente = new ComboBox();
            label13 = new Label();
            comboBoxCittaMittente = new ComboBox();
            label7 = new Label();
            label5 = new Label();
            comboBox1 = new ComboBox();
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
            panel1.Controls.Add(button1);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1114, 656);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(192, 255, 192);
            button1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(461, 440);
            button1.Name = "button1";
            button1.Size = new Size(197, 82);
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
            panel4.Location = new Point(751, 105);
            panel4.Name = "panel4";
            panel4.Size = new Size(334, 249);
            panel4.TabIndex = 2;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label12.Location = new Point(3, 203);
            label12.Name = "label12";
            label12.Size = new Size(110, 25);
            label12.TabIndex = 10;
            label12.Text = "Height (cm):";
            label12.Click += label12_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label11.Location = new Point(3, 152);
            label11.Name = "label11";
            label11.Size = new Size(105, 25);
            label11.TabIndex = 9;
            label11.Text = "Width (cm):";
            label11.Click += label11_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label10.Location = new Point(3, 98);
            label10.Name = "label10";
            label10.Size = new Size(111, 25);
            label10.TabIndex = 8;
            label10.Text = "Length (cm):";
            label10.Click += label10_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label9.Location = new Point(3, 52);
            label9.Name = "label9";
            label9.Size = new Size(109, 25);
            label9.TabIndex = 7;
            label9.Text = "Weight (kg):";
            label9.Click += label9_Click;
            // 
            // textBox4
            // 
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.Location = new Point(134, 201);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(139, 27);
            textBox4.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Location = new Point(134, 154);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(139, 27);
            textBox3.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Location = new Point(134, 100);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(139, 27);
            textBox2.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(134, 54);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(139, 27);
            textBox1.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Symbol", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(68, -1);
            label4.Name = "label4";
            label4.Size = new Size(182, 25);
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
            panel3.Controls.Add(comboBox2);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(387, 105);
            panel3.Name = "panel3";
            panel3.Size = new Size(334, 249);
            panel3.TabIndex = 2;
            panel3.Paint += panel3_Paint;
            // 
            // comboBoxCAPDestinatario
            // 
            comboBoxCAPDestinatario.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxCAPDestinatario.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxCAPDestinatario.FormattingEnabled = true;
            comboBoxCAPDestinatario.Location = new Point(116, 149);
            comboBoxCAPDestinatario.Name = "comboBoxCAPDestinatario";
            comboBoxCAPDestinatario.Size = new Size(212, 28);
            comboBoxCAPDestinatario.TabIndex = 8;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label14.Location = new Point(3, 152);
            label14.Name = "label14";
            label14.Size = new Size(88, 25);
            label14.TabIndex = 8;
            label14.Text = "ZIP Code:";
            // 
            // comboBoxCittaDestinatario
            // 
            comboBoxCittaDestinatario.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxCittaDestinatario.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxCittaDestinatario.FormattingEnabled = true;
            comboBoxCittaDestinatario.Location = new Point(116, 106);
            comboBoxCittaDestinatario.Name = "comboBoxCittaDestinatario";
            comboBoxCittaDestinatario.Size = new Size(212, 28);
            comboBoxCittaDestinatario.TabIndex = 6;
            comboBoxCittaDestinatario.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label8.Location = new Point(3, 109);
            label8.Name = "label8";
            label8.Size = new Size(43, 25);
            label8.TabIndex = 6;
            label8.Text = "City";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.Location = new Point(3, 60);
            label6.Name = "label6";
            label6.Size = new Size(79, 25);
            label6.TabIndex = 4;
            label6.Text = "Country:";
            // 
            // comboBox2
            // 
            comboBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Afghanistan - AF", "Albania - AL", "Algeria - DZ", "Andorra - AD", "Angola - AO", "Antigua and Barbuda - AG", "Argentina - AR", "Armenia - AM", "Australia - AU", "Austria - AT", "Azerbaijan - AZ", "Bahamas - BS", "Bahrain - BH", "Bangladesh - BD", "Barbados - BB", "Belarus - BY", "Belgium - BE", "Belize - BZ", "Benin - BJ", "Bhutan - BT", "Bolivia - BO", "Bosnia and Herzegovina - BA", "Botswana - BW", "Brazil - BR", "Brunei - BN", "Bulgaria - BG", "Burkina Faso - BF", "Burundi - BI", "Cambodia - KH", "Cameroon - CM", "Canada - CA", "Cape Verde - CV", "Central African Republic - CF", "Chad - TD", "Chile - CL", "China - CN", "Colombia - CO", "Comoros - KM", "Costa Rica - CR", "Croatia - HR", "Cuba - CU", "Cyprus - CY", "Czech Republic - CZ", "Denmark - DK", "Djibouti - DJ", "Dominica - DM", "Dominican Republic - DO", "Ecuador - EC", "Egypt - EG", "El Salvador - SV", "Equatorial Guinea - GQ", "Eritrea - ER", "Estonia - EE", "Eswatini - SZ", "Ethiopia - ET", "Fiji - FJ", "Finland - FI", "France - FR", "Gabon - GA", "Gambia - GM", "Georgia - GE", "Germany - DE", "Ghana - GH", "Greece - GR", "Grenada - GD", "Guatemala - GT", "Guinea - GN", "Guinea-Bissau - GW", "Guyana - GY", "Haiti - HT", "Honduras - HN", "Hungary - HU", "Iceland - IS", "India - IN", "Indonesia - ID", "Iran - IR", "Iraq - IQ", "Ireland - IE", "Israel - IL", "Italy - IT", "Jamaica - JM", "Japan - JP", "Jordan - JO", "Kazakhstan - KZ", "Kenya - KE", "Kiribati - KI", "Kuwait - KW", "Kyrgyzstan - KG", "Laos - LA", "Latvia - LV", "Lebanon - LB", "Lesotho - LS", "Liberia - LR", "Libya - LY", "Liechtenstein - LI", "Lithuania - LT", "Luxembourg - LU", "Madagascar - MG", "Malawi - MW", "Malaysia - MY", "Maldives - MV", "Mali - ML", "Malta - MT", "Marshall Islands - MH", "Mauritania - MR", "Mauritius - MU", "Mexico - MX", "Micronesia - FM", "Moldova - MD", "Monaco - MC", "Mongolia - MN", "Montenegro - ME", "Morocco - MA", "Mozambique - MZ", "Myanmar - MM", "Namibia - NA", "Nauru - NR", "Nepal - NP", "Netherlands - NL", "New Zealand - NZ", "Nicaragua - NI", "Niger - NE", "Nigeria - NG", "North Korea - KP", "North Macedonia - MK", "Norway - NO", "Oman - OM", "Pakistan - PK", "Palau - PW", "Panama - PA", "Papua New Guinea - PG", "Paraguay - PY", "Peru - PE", "Philippines - PH", "Poland - PL", "Portugal - PT", "Qatar - QA", "Romania - RO", "Russia - RU", "Rwanda - RW", "Saint Kitts and Nevis - KN", "Saint Lucia - LC", "Saint Vincent and the Grenadines - VC", "Samoa - WS", "San Marino - SM", "Sao Tome and Principe - ST", "Saudi Arabia - SA", "Senegal - SN", "Serbia - RS", "Seychelles - SC", "Sierra Leone - SL", "Singapore - SG", "Slovakia - SK", "Slovenia - SI", "Solomon Islands - SB", "Somalia - SO", "South Africa - ZA", "South Korea - KR", "South Sudan - SS", "Spain - ES", "Sri Lanka - LK", "Sudan - SD", "Suriname - SR", "Sweden - SE", "Switzerland - CH", "Syria - SY", "Taiwan - TW", "Tajikistan - TJ", "Tanzania - TZ", "Thailand - TH", "Togo - TG", "Tonga - TO", "Trinidad and Tobago - TT", "Tunisia - TN", "Turkey - TR", "Turkmenistan - TM", "Tuvalu - TV", "Uganda - UG", "Ukraine - UA", "United Arab Emirates - AE", "United Kingdom - GB", "United States - US", "Uruguay - UY", "Uzbekistan - UZ", "Vanuatu - VU", "Vatican City - VA", "Venezuela - VE", "Vietnam - VN", "Yemen - YE", "Zambia - ZM", "Zimbabwe - ZW" });
            comboBox2.Location = new Point(116, 57);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(213, 28);
            comboBox2.TabIndex = 3;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Symbol", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(116, -1);
            label3.Name = "label3";
            label3.Size = new Size(85, 25);
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
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(24, 105);
            panel2.Name = "panel2";
            panel2.Size = new Size(334, 249);
            panel2.TabIndex = 1;
            // 
            // comboBoxCAPMittente
            // 
            comboBoxCAPMittente.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxCAPMittente.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxCAPMittente.FormattingEnabled = true;
            comboBoxCAPMittente.Location = new Point(116, 149);
            comboBoxCAPMittente.Name = "comboBoxCAPMittente";
            comboBoxCAPMittente.Size = new Size(212, 28);
            comboBoxCAPMittente.TabIndex = 7;
            comboBoxCAPMittente.SelectedIndexChanged += comboBoxCAPMittente_SelectedIndexChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label13.Location = new Point(3, 152);
            label13.Name = "label13";
            label13.Size = new Size(88, 25);
            label13.TabIndex = 6;
            label13.Text = "ZIP Code:";
            // 
            // comboBoxCittaMittente
            // 
            comboBoxCittaMittente.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxCittaMittente.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxCittaMittente.FormattingEnabled = true;
            comboBoxCittaMittente.Location = new Point(117, 105);
            comboBoxCittaMittente.Name = "comboBoxCittaMittente";
            comboBoxCittaMittente.Size = new Size(212, 28);
            comboBoxCittaMittente.TabIndex = 5;
            comboBoxCittaMittente.SelectedIndexChanged += comboBoxCitta_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label7.Location = new Point(3, 106);
            label7.Name = "label7";
            label7.Size = new Size(47, 25);
            label7.TabIndex = 4;
            label7.Text = "City:";
            label7.Click += label7_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(3, 56);
            label5.Name = "label5";
            label5.Size = new Size(79, 25);
            label5.TabIndex = 3;
            label5.Text = "Country:";
            // 
            // comboBox1
            // 
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Afghanistan - AF", "Albania - AL", "Algeria - DZ", "Andorra - AD", "Angola - AO", "Antigua and Barbuda - AG", "Argentina - AR", "Armenia - AM", "Australia - AU", "Austria - AT", "Azerbaijan - AZ", "Bahamas - BS", "Bahrain - BH", "Bangladesh - BD", "Barbados - BB", "Belarus - BY", "Belgium - BE", "Belize - BZ", "Benin - BJ", "Bhutan - BT", "Bolivia - BO", "Bosnia and Herzegovina - BA", "Botswana - BW", "Brazil - BR", "Brunei - BN", "Bulgaria - BG", "Burkina Faso - BF", "Burundi - BI", "Cambodia - KH", "Cameroon - CM", "Canada - CA", "Cape Verde - CV", "Central African Republic - CF", "Chad - TD", "Chile - CL", "China - CN", "Colombia - CO", "Comoros - KM", "Costa Rica - CR", "Croatia - HR", "Cuba - CU", "Cyprus - CY", "Czech Republic - CZ", "Denmark - DK", "Djibouti - DJ", "Dominica - DM", "Dominican Republic - DO", "Ecuador - EC", "Egypt - EG", "El Salvador - SV", "Equatorial Guinea - GQ", "Eritrea - ER", "Estonia - EE", "Eswatini - SZ", "Ethiopia - ET", "Fiji - FJ", "Finland - FI", "France - FR", "Gabon - GA", "Gambia - GM", "Georgia - GE", "Germany - DE", "Ghana - GH", "Greece - GR", "Grenada - GD", "Guatemala - GT", "Guinea - GN", "Guinea-Bissau - GW", "Guyana - GY", "Haiti - HT", "Honduras - HN", "Hungary - HU", "Iceland - IS", "India - IN", "Indonesia - ID", "Iran - IR", "Iraq - IQ", "Ireland - IE", "Israel - IL", "Italy - IT", "Jamaica - JM", "Japan - JP", "Jordan - JO", "Kazakhstan - KZ", "Kenya - KE", "Kiribati - KI", "Kuwait - KW", "Kyrgyzstan - KG", "Laos - LA", "Latvia - LV", "Lebanon - LB", "Lesotho - LS", "Liberia - LR", "Libya - LY", "Liechtenstein - LI", "Lithuania - LT", "Luxembourg - LU", "Madagascar - MG", "Malawi - MW", "Malaysia - MY", "Maldives - MV", "Mali - ML", "Malta - MT", "Marshall Islands - MH", "Mauritania - MR", "Mauritius - MU", "Mexico - MX", "Micronesia - FM", "Moldova - MD", "Monaco - MC", "Mongolia - MN", "Montenegro - ME", "Morocco - MA", "Mozambique - MZ", "Myanmar - MM", "Namibia - NA", "Nauru - NR", "Nepal - NP", "Netherlands - NL", "New Zealand - NZ", "Nicaragua - NI", "Niger - NE", "Nigeria - NG", "North Korea - KP", "North Macedonia - MK", "Norway - NO", "Oman - OM", "Pakistan - PK", "Palau - PW", "Panama - PA", "Papua New Guinea - PG", "Paraguay - PY", "Peru - PE", "Philippines - PH", "Poland - PL", "Portugal - PT", "Qatar - QA", "Romania - RO", "Russia - RU", "Rwanda - RW", "Saint Kitts and Nevis - KN", "Saint Lucia - LC", "Saint Vincent and the Grenadines - VC", "Samoa - WS", "San Marino - SM", "Sao Tome and Principe - ST", "Saudi Arabia - SA", "Senegal - SN", "Serbia - RS", "Seychelles - SC", "Sierra Leone - SL", "Singapore - SG", "Slovakia - SK", "Slovenia - SI", "Solomon Islands - SB", "Somalia - SO", "South Africa - ZA", "South Korea - KR", "South Sudan - SS", "Spain - ES", "Sri Lanka - LK", "Sudan - SD", "Suriname - SR", "Sweden - SE", "Switzerland - CH", "Syria - SY", "Taiwan - TW", "Tajikistan - TJ", "Tanzania - TZ", "Thailand - TH", "Togo - TG", "Tonga - TO", "Trinidad and Tobago - TT", "Tunisia - TN", "Turkey - TR", "Turkmenistan - TM", "Tuvalu - TV", "Uganda - UG", "Ukraine - UA", "United Arab Emirates - AE", "United Kingdom - GB", "United States - US", "Uruguay - UY", "Uzbekistan - UZ", "Vanuatu - VU", "Vatican City - VA", "Venezuela - VE", "Vietnam - VN", "Yemen - YE", "Zambia - ZM", "Zimbabwe - ZW" });
            comboBox1.Location = new Point(116, 57);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(213, 28);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChangedAsync;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Symbol", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(116, 0);
            label2.Name = "label2";
            label2.Size = new Size(73, 25);
            label2.TabIndex = 0;
            label2.Text = "Sender";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Franklin Gothic Heavy", 19.8000011F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(379, 9);
            label1.Name = "label1";
            label1.Size = new Size(342, 39);
            label1.TabIndex = 0;
            label1.Text = "Shipping Finder v1.0";
            label1.Click += label1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1111, 654);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
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
        private ComboBox comboBox1;
        private Label label6;
        private ComboBox comboBox2;
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
    }
}
