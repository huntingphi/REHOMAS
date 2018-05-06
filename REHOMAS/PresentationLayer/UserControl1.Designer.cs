namespace REHOMAS.PresentationLayer
{
    partial class UserControl1
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl1));
            this.label1 = new System.Windows.Forms.Label();
            this.paymentLabel = new System.Windows.Forms.Label();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.guestIDLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxBookingSearch = new System.Windows.Forms.ComboBox();
            this.dateTimePickerCheckIn = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerCheckOut = new System.Windows.Forms.DateTimePicker();
            this.labelBookingStatus = new System.Windows.Forms.Label();
            this.labelTotalCost = new System.Windows.Forms.Label();
            this.labelDeposit = new System.Windows.Forms.Label();
            this.buttonMakePayment = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.labelDailyCost = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonChanges = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxRefNo = new System.Windows.Forms.TextBox();
            this.numericUpDownNoGuests = new System.Windows.Forms.NumericUpDown();
            this.comboBoxGuestID = new System.Windows.Forms.ComboBox();
            this.buttonAddGuest = new System.Windows.Forms.Button();
            this.buttonToggleEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNoGuests)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 354);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 34);
            this.label1.TabIndex = 53;
            this.label1.Text = "Booking Status";
            // 
            // paymentLabel
            // 
            this.paymentLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentLabel.Location = new System.Drawing.Point(62, 265);
            this.paymentLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.paymentLabel.Name = "paymentLabel";
            this.paymentLabel.Size = new System.Drawing.Size(75, 18);
            this.paymentLabel.TabIndex = 51;
            this.paymentLabel.Text = "Total Cost";
            // 
            // phoneLabel
            // 
            this.phoneLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneLabel.Location = new System.Drawing.Point(62, 176);
            this.phoneLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(83, 19);
            this.phoneLabel.TabIndex = 50;
            this.phoneLabel.Text = "Check Out";
            // 
            // guestIDLabel
            // 
            this.guestIDLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestIDLabel.Location = new System.Drawing.Point(380, 106);
            this.guestIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.guestIDLabel.Name = "guestIDLabel";
            this.guestIDLabel.Size = new System.Drawing.Size(72, 33);
            this.guestIDLabel.TabIndex = 49;
            this.guestIDLabel.Text = "Number of people";
            // 
            // nameLabel
            // 
            this.nameLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(62, 120);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(83, 19);
            this.nameLabel.TabIndex = 48;
            this.nameLabel.Text = "Check In";
            // 
            // idLabel
            // 
            this.idLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idLabel.Location = new System.Drawing.Point(62, 64);
            this.idLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(75, 19);
            this.idLabel.TabIndex = 47;
            this.idLabel.Text = "Guest ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 20);
            this.label3.TabIndex = 42;
            this.label3.Text = "Search Bookings";
            // 
            // comboBoxBookingSearch
            // 
            this.comboBoxBookingSearch.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.comboBoxBookingSearch.FormattingEnabled = true;
            this.comboBoxBookingSearch.Location = new System.Drawing.Point(149, 14);
            this.comboBoxBookingSearch.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxBookingSearch.Name = "comboBoxBookingSearch";
            this.comboBoxBookingSearch.Size = new System.Drawing.Size(181, 21);
            this.comboBoxBookingSearch.TabIndex = 41;
            this.comboBoxBookingSearch.Text = "#REF";
            this.comboBoxBookingSearch.SelectedIndexChanged += new System.EventHandler(this.comboBoxBookingSearch_SelectedIndexChanged);
            // 
            // dateTimePickerCheckIn
            // 
            this.dateTimePickerCheckIn.Location = new System.Drawing.Point(149, 122);
            this.dateTimePickerCheckIn.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerCheckIn.Name = "dateTimePickerCheckIn";
            this.dateTimePickerCheckIn.Size = new System.Drawing.Size(197, 20);
            this.dateTimePickerCheckIn.TabIndex = 60;
            this.dateTimePickerCheckIn.ValueChanged += new System.EventHandler(this.dateTimePickerCheckIn_ValueChanged);
            // 
            // dateTimePickerCheckOut
            // 
            this.dateTimePickerCheckOut.Location = new System.Drawing.Point(149, 178);
            this.dateTimePickerCheckOut.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerCheckOut.Name = "dateTimePickerCheckOut";
            this.dateTimePickerCheckOut.Size = new System.Drawing.Size(197, 20);
            this.dateTimePickerCheckOut.TabIndex = 61;
            this.dateTimePickerCheckOut.ValueChanged += new System.EventHandler(this.dateTimePickerCheckOut_ValueChanged);
            // 
            // labelBookingStatus
            // 
            this.labelBookingStatus.AutoSize = true;
            this.labelBookingStatus.ForeColor = System.Drawing.Color.Lime;
            this.labelBookingStatus.Location = new System.Drawing.Point(149, 363);
            this.labelBookingStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBookingStatus.Name = "labelBookingStatus";
            this.labelBookingStatus.Size = new System.Drawing.Size(64, 13);
            this.labelBookingStatus.TabIndex = 62;
            this.labelBookingStatus.Text = "AVAILABLE";
            // 
            // labelTotalCost
            // 
            this.labelTotalCost.AutoSize = true;
            this.labelTotalCost.Location = new System.Drawing.Point(147, 266);
            this.labelTotalCost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTotalCost.Name = "labelTotalCost";
            this.labelTotalCost.Size = new System.Drawing.Size(15, 13);
            this.labelTotalCost.TabIndex = 63;
            this.labelTotalCost.Text = "R";
            // 
            // labelDeposit
            // 
            this.labelDeposit.AutoSize = true;
            this.labelDeposit.Location = new System.Drawing.Point(147, 315);
            this.labelDeposit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDeposit.Name = "labelDeposit";
            this.labelDeposit.Size = new System.Drawing.Size(15, 13);
            this.labelDeposit.TabIndex = 66;
            this.labelDeposit.Text = "R";
            // 
            // buttonMakePayment
            // 
            this.buttonMakePayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.buttonMakePayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMakePayment.Location = new System.Drawing.Point(250, 313);
            this.buttonMakePayment.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMakePayment.Name = "buttonMakePayment";
            this.buttonMakePayment.Size = new System.Drawing.Size(107, 27);
            this.buttonMakePayment.TabIndex = 65;
            this.buttonMakePayment.Text = "Pay Deposit";
            this.buttonMakePayment.UseVisualStyleBackColor = false;
            this.buttonMakePayment.Click += new System.EventHandler(this.buttonMakePayment_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(62, 313);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 41);
            this.label6.TabIndex = 64;
            this.label6.Text = "Due to confirm";
            // 
            // labelDailyCost
            // 
            this.labelDailyCost.AutoSize = true;
            this.labelDailyCost.Location = new System.Drawing.Point(147, 227);
            this.labelDailyCost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDailyCost.Name = "labelDailyCost";
            this.labelDailyCost.Size = new System.Drawing.Size(15, 13);
            this.labelDailyCost.TabIndex = 68;
            this.labelDailyCost.Text = "R";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(62, 225);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 15);
            this.label8.TabIndex = 67;
            this.label8.Text = "Cost daily";
            // 
            // buttonChanges
            // 
            this.buttonChanges.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.buttonChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChanges.Location = new System.Drawing.Point(250, 360);
            this.buttonChanges.Margin = new System.Windows.Forms.Padding(2);
            this.buttonChanges.Name = "buttonChanges";
            this.buttonChanges.Size = new System.Drawing.Size(107, 27);
            this.buttonChanges.TabIndex = 71;
            this.buttonChanges.Text = "Remove Booking";
            this.buttonChanges.UseVisualStyleBackColor = false;
            this.buttonChanges.Click += new System.EventHandler(this.buttonChanges_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(375, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 19);
            this.label2.TabIndex = 73;
            this.label2.Text = "Ref. No";
            // 
            // textBoxRefNo
            // 
            this.textBoxRefNo.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRefNo.Location = new System.Drawing.Point(462, 60);
            this.textBoxRefNo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxRefNo.Multiline = true;
            this.textBoxRefNo.Name = "textBoxRefNo";
            this.textBoxRefNo.Size = new System.Drawing.Size(127, 25);
            this.textBoxRefNo.TabIndex = 72;
            // 
            // numericUpDownNoGuests
            // 
            this.numericUpDownNoGuests.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDownNoGuests.Location = new System.Drawing.Point(462, 119);
            this.numericUpDownNoGuests.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownNoGuests.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNoGuests.Name = "numericUpDownNoGuests";
            this.numericUpDownNoGuests.Size = new System.Drawing.Size(34, 16);
            this.numericUpDownNoGuests.TabIndex = 74;
            this.numericUpDownNoGuests.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNoGuests.ValueChanged += new System.EventHandler(this.numericUpDownNoGuests_ValueChanged);
            // 
            // comboBoxGuestID
            // 
            this.comboBoxGuestID.FormattingEnabled = true;
            this.comboBoxGuestID.Location = new System.Drawing.Point(152, 61);
            this.comboBoxGuestID.Name = "comboBoxGuestID";
            this.comboBoxGuestID.Size = new System.Drawing.Size(121, 21);
            this.comboBoxGuestID.TabIndex = 75;
            this.comboBoxGuestID.SelectedIndexChanged += new System.EventHandler(this.comboBoxGuestID_SelectedIndexChanged);
            // 
            // buttonAddGuest
            // 
            this.buttonAddGuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddGuest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(16)))));
            this.buttonAddGuest.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddGuest.Image")));
            this.buttonAddGuest.Location = new System.Drawing.Point(364, 14);
            this.buttonAddGuest.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddGuest.Name = "buttonAddGuest";
            this.buttonAddGuest.Size = new System.Drawing.Size(21, 19);
            this.buttonAddGuest.TabIndex = 70;
            this.buttonAddGuest.UseVisualStyleBackColor = true;
            this.buttonAddGuest.Click += new System.EventHandler(this.buttonAddGuest_Click);
            // 
            // buttonToggleEdit
            // 
            this.buttonToggleEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToggleEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(16)))));
            this.buttonToggleEdit.Image = global::REHOMAS.Properties.Resources._lock;
            this.buttonToggleEdit.Location = new System.Drawing.Point(339, 12);
            this.buttonToggleEdit.Margin = new System.Windows.Forms.Padding(2);
            this.buttonToggleEdit.Name = "buttonToggleEdit";
            this.buttonToggleEdit.Size = new System.Drawing.Size(21, 19);
            this.buttonToggleEdit.TabIndex = 69;
            this.buttonToggleEdit.UseVisualStyleBackColor = true;
            this.buttonToggleEdit.Click += new System.EventHandler(this.buttonToggleEdit_Click_1);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(16)))));
            this.Controls.Add(this.comboBoxGuestID);
            this.Controls.Add(this.numericUpDownNoGuests);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxRefNo);
            this.Controls.Add(this.buttonChanges);
            this.Controls.Add(this.buttonAddGuest);
            this.Controls.Add(this.buttonToggleEdit);
            this.Controls.Add(this.labelDailyCost);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelDeposit);
            this.Controls.Add(this.buttonMakePayment);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelTotalCost);
            this.Controls.Add(this.labelBookingStatus);
            this.Controls.Add(this.dateTimePickerCheckOut);
            this.Controls.Add(this.dateTimePickerCheckIn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.paymentLabel);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.guestIDLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxBookingSearch);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(747, 398);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNoGuests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ButtonToggleEdit_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label paymentLabel;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.Label guestIDLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxBookingSearch;
        private System.Windows.Forms.DateTimePicker dateTimePickerCheckIn;
        private System.Windows.Forms.DateTimePicker dateTimePickerCheckOut;
        private System.Windows.Forms.Label labelBookingStatus;
        private System.Windows.Forms.Label labelTotalCost;
        private System.Windows.Forms.Label labelDeposit;
        private System.Windows.Forms.Button buttonMakePayment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelDailyCost;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonAddGuest;
        private System.Windows.Forms.Button buttonToggleEdit;
        private System.Windows.Forms.Button buttonChanges;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxRefNo;
        private System.Windows.Forms.NumericUpDown numericUpDownNoGuests;
        private System.Windows.Forms.ComboBox comboBoxGuestID;
    }
}
