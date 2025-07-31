namespace pencatatanwarga;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.Windows.Forms.DataGridView dgvWarga;
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.GroupBox grpDataWarga;
    private System.Windows.Forms.Label lblNIK;
    private System.Windows.Forms.TextBox txtNIK;
    private System.Windows.Forms.Label lblNamaLengkap;
    private System.Windows.Forms.TextBox txtNamaLengkap;
    private System.Windows.Forms.Label lblTanggalLahir;
    private System.Windows.Forms.DateTimePicker dtpTanggalLahir;
    private System.Windows.Forms.Label lblJenisKelamin;
    private System.Windows.Forms.ComboBox cmbJenisKelamin;
    private System.Windows.Forms.Label lblAlamat;
    private System.Windows.Forms.TextBox txtAlamat;
    private System.Windows.Forms.Label lblPekerjaan;
    private System.Windows.Forms.TextBox txtPekerjaan;
    private System.Windows.Forms.Label lblStatusPerkawinan;
    private System.Windows.Forms.ComboBox cmbStatusPerkawinan;
    private System.Windows.Forms.Button btnSimpan;
    private System.Windows.Forms.Button btnReset;
    private System.Windows.Forms.Button btnHapus;
    private System.Windows.Forms.Button btnUbah;
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
        this.components = new System.ComponentModel.Container();

        this.grpDataWarga = new System.Windows.Forms.GroupBox();
        this.SuspendLayout();

        // 
        // grpDataWarga
        // 
        this.grpDataWarga.Location = new System.Drawing.Point(12, 12);
        this.grpDataWarga.Name = "grpDataWarga";
        this.grpDataWarga.Size = new System.Drawing.Size(760, 500);
        this.grpDataWarga.TabIndex = 0;
        this.grpDataWarga.Text = "Data Warga";

        // Initialize DataGridView
        this.dgvWarga = new System.Windows.Forms.DataGridView();
        ((System.ComponentModel.ISupportInitialize)(this.dgvWarga)).BeginInit();

        this.dgvWarga.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWarga_CellClick);

        // Configure DataGridView
        this.dgvWarga.Location = new System.Drawing.Point(12, 290);
        this.dgvWarga.Name = "dgvWarga";
        this.dgvWarga.Size = new System.Drawing.Size(760, 225);
        this.dgvWarga.TabIndex = 5;
        this.dgvWarga.ReadOnly = true;
        this.dgvWarga.AllowUserToAddRows = false;
        this.dgvWarga.AllowUserToDeleteRows = false;
        this.dgvWarga.Anchor = ((System.Windows.Forms.AnchorStyles)((((
            System.Windows.Forms.AnchorStyles.Top |
            System.Windows.Forms.AnchorStyles.Bottom) |
            System.Windows.Forms.AnchorStyles.Left) |
            System.Windows.Forms.AnchorStyles.Right)));
        this.dgvWarga.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvWarga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvWarga.MultiSelect = false;
        this.dgvWarga.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

        // Add DataGridView to form's controls
        this.Controls.Add(this.dgvWarga);

        // Update form properties to accommodate DataGridView
        this.ClientSize = new System.Drawing.Size(784, 561); // Standard 800x600 form size

        this.btnSimpan = new System.Windows.Forms.Button();
        this.btnReset = new System.Windows.Forms.Button();
        this.btnHapus = new System.Windows.Forms.Button();
        this.btnUbah = new System.Windows.Forms.Button();

        // Initialize buttons
        this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
        this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
        this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
        this.btnUbah.Click += new System.EventHandler(this.btnUbah_Click);

        // Configure buttons
        // Simpan button
        this.btnSimpan.Location = new System.Drawing.Point(12, 520);
        this.btnSimpan.Name = "btnSimpan";
        this.btnSimpan.Size = new System.Drawing.Size(75, 30);
        this.btnSimpan.TabIndex = 1;
        this.btnSimpan.Text = "Simpan";
        this.btnSimpan.UseVisualStyleBackColor = true;

        // Reset button
        this.btnReset.Location = new System.Drawing.Point(93, 520);
        this.btnReset.Name = "btnReset";
        this.btnReset.Size = new System.Drawing.Size(75, 30);
        this.btnReset.TabIndex = 2;
        this.btnReset.Text = "Reset";
        this.btnReset.UseVisualStyleBackColor = true;

        // Hapus button
        this.btnHapus.Location = new System.Drawing.Point(174, 520);
        this.btnHapus.Name = "btnHapus";
        this.btnHapus.Size = new System.Drawing.Size(75, 30);
        this.btnHapus.TabIndex = 3;
        this.btnHapus.Text = "Hapus";
        this.btnHapus.UseVisualStyleBackColor = true;

        // Ubah button
        this.btnUbah.Location = new System.Drawing.Point(255, 520);
        this.btnUbah.Name = "btnUbah";
        this.btnUbah.Size = new System.Drawing.Size(75, 30);
        this.btnUbah.TabIndex = 4;
        this.btnUbah.Text = "Ubah";
        this.btnUbah.UseVisualStyleBackColor = true;

        // Add buttons to form
        this.Controls.AddRange(new System.Windows.Forms.Control[] {
            this.btnSimpan,
            this.btnReset,
            this.btnHapus,
            this.btnUbah
        });

        // 
        // Form1
        // 
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 600);
        this.Controls.Add(this.grpDataWarga);
        this.Name = "Form1";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Aplikasi Pencatatan Data Warga";
        this.ResumeLayout(false);

        this.lblNIK = new System.Windows.Forms.Label();
        this.txtNIK = new System.Windows.Forms.TextBox();
        this.lblNamaLengkap = new System.Windows.Forms.Label();
        this.txtNamaLengkap = new System.Windows.Forms.TextBox();
        this.lblTanggalLahir = new System.Windows.Forms.Label();
        this.dtpTanggalLahir = new System.Windows.Forms.DateTimePicker();
        this.lblJenisKelamin = new System.Windows.Forms.Label();
        this.cmbJenisKelamin = new System.Windows.Forms.ComboBox();
        this.lblAlamat = new System.Windows.Forms.Label();
        this.txtAlamat = new System.Windows.Forms.TextBox();
        this.lblPekerjaan = new System.Windows.Forms.Label();
        this.txtPekerjaan = new System.Windows.Forms.TextBox();
        this.lblStatusPerkawinan = new System.Windows.Forms.Label();
        this.cmbStatusPerkawinan = new System.Windows.Forms.ComboBox();

        // NIK
        this.lblNIK.Location = new System.Drawing.Point(20, 30);
        this.lblNIK.Size = new System.Drawing.Size(100, 23);
        this.lblNIK.Text = "NIK:";

        this.txtNIK.Location = new System.Drawing.Point(150, 30);
        this.txtNIK.Size = new System.Drawing.Size(200, 23);
        this.txtNIK.MaxLength = 16;

        // Nama Lengkap
        this.lblNamaLengkap.Location = new System.Drawing.Point(20, 60);
        this.lblNamaLengkap.Size = new System.Drawing.Size(100, 23);
        this.lblNamaLengkap.Text = "Nama Lengkap:";

        this.txtNamaLengkap.Location = new System.Drawing.Point(150, 60);
        this.txtNamaLengkap.Size = new System.Drawing.Size(200, 23);

        // Tanggal Lahir
        this.lblTanggalLahir.Location = new System.Drawing.Point(20, 90);
        this.lblTanggalLahir.Size = new System.Drawing.Size(100, 23);
        this.lblTanggalLahir.Text = "Tanggal Lahir:";

        this.dtpTanggalLahir.Location = new System.Drawing.Point(150, 90);
        this.dtpTanggalLahir.Size = new System.Drawing.Size(200, 23);
        this.dtpTanggalLahir.Format = System.Windows.Forms.DateTimePickerFormat.Long;

        // Jenis Kelamin
        this.lblJenisKelamin.Location = new System.Drawing.Point(20, 120);
        this.lblJenisKelamin.Size = new System.Drawing.Size(100, 23);
        this.lblJenisKelamin.Text = "Jenis Kelamin:";

        this.cmbJenisKelamin.Location = new System.Drawing.Point(150, 120);
        this.cmbJenisKelamin.Size = new System.Drawing.Size(200, 23);
        this.cmbJenisKelamin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbJenisKelamin.Items.AddRange(new object[] { "Laki-laki", "Perempuan" });

        // Alamat
        this.lblAlamat.Location = new System.Drawing.Point(20, 150);
        this.lblAlamat.Size = new System.Drawing.Size(100, 23);
        this.lblAlamat.Text = "Alamat:";

        this.txtAlamat.Location = new System.Drawing.Point(150, 150);
        this.txtAlamat.Size = new System.Drawing.Size(200, 60);
        this.txtAlamat.Multiline = true;
        this.txtAlamat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

        // Pekerjaan
        this.lblPekerjaan.Location = new System.Drawing.Point(20, 220);
        this.lblPekerjaan.Size = new System.Drawing.Size(100, 23);
        this.lblPekerjaan.Text = "Pekerjaan:";

        this.txtPekerjaan.Location = new System.Drawing.Point(150, 220);
        this.txtPekerjaan.Size = new System.Drawing.Size(200, 23);

        // Status Perkawinan
        this.lblStatusPerkawinan.Location = new System.Drawing.Point(20, 250);
        this.lblStatusPerkawinan.Size = new System.Drawing.Size(100, 23);
        this.lblStatusPerkawinan.Text = "Status Perkawinan:";

        this.cmbStatusPerkawinan.Location = new System.Drawing.Point(150, 250);
        this.cmbStatusPerkawinan.Size = new System.Drawing.Size(200, 23);
        this.cmbStatusPerkawinan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbStatusPerkawinan.Items.AddRange(new object[] {
            "Belum Kawin",
            "Kawin",
            "Cerai Hidup",
            "Cerai Mati"
        });

        this.grpDataWarga.Controls.AddRange(new System.Windows.Forms.Control[] {
            this.lblNIK,
            this.txtNIK,
            this.lblNamaLengkap,
            this.txtNamaLengkap,
            this.lblTanggalLahir,
            this.dtpTanggalLahir,
            this.lblJenisKelamin,
            this.cmbJenisKelamin,
            this.lblAlamat,
            this.txtAlamat,
            this.lblPekerjaan,
            this.txtPekerjaan,
            this.lblStatusPerkawinan,
            this.cmbStatusPerkawinan
        });
        ((System.ComponentModel.ISupportInitialize)(this.dgvWarga)).EndInit();
    }

    #endregion
}
