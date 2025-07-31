using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using AplikasiPencatatanWarga;

namespace pencatatanwarga
{
    public partial class Form1 : Form
    {
        private readonly DatabaseManager dbManager;
        private string selectedNIK = string.Empty;

        public Form1()
        {
            InitializeComponent();
            dbManager = new DatabaseManager();

            // Register form load event
            this.Load += new EventHandler(Form1_Load);

            // Initial button state
            btnHapus.Enabled = false;
            btnUbah.Enabled = false;
        }

        private void LoadDataToGrid()
        {
            DataTable dtWarga = dbManager.GetAllWarga();
            dgvWarga.DataSource = dtWarga;

            // Optimize column widths
            dgvWarga.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            // Reset selection state
            dgvWarga.ClearSelection();
            selectedNIK = string.Empty;
            btnHapus.Enabled = false;
            btnUbah.Enabled = false;
            txtNIK.ReadOnly = false;
        }
        // Event handler saat form dimuat pertama kali 

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNIK.Text) ||
            string.IsNullOrWhiteSpace(txtNamaLengkap.Text) ||
            string.IsNullOrWhiteSpace(cmbJenisKelamin.Text))
            {
                MessageBox.Show("NIK, Nama Lengkap, dan Jenis Kelamin harus diisi.", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Ambil data dari input form
            string nik = txtNIK.Text.Trim();
            string namaLengkap = txtNamaLengkap.Text.Trim();
            DateTime tanggalLahir = dtpTanggalLahir.Value;
            string jenisKelamin = cmbJenisKelamin.Text;
            string alamat = txtAlamat.Text.Trim();
            string pekerjaan = txtPekerjaan.Text.Trim();
            string statusPerkawinan = cmbStatusPerkawinan.Text;
            // Panggil metode SaveWarga dari DatabaseManager
            bool success = dbManager.SaveWarga(nik, namaLengkap, tanggalLahir, jenisKelamin, alamat, pekerjaan,
            statusPerkawinan);
            if (success)
            {
                MessageBox.Show("Data warga berhasil disimpan!", "Sukses", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                LoadDataToGrid(); // Muat ulang data ke grid setelah penyimpanan
                ResetForm(); // Bersihkan form
            }
        }

        private void ResetForm(object sender, EventArgs e)
        {
            txtNIK.Text = string.Empty;
            txtNamaLengkap.Text = string.Empty;
            dtpTanggalLahir.Value = DateTime.Now; // Mengatur ke tanggal saat ini
            if (cmbJenisKelamin.Items.Count > 0) cmbJenisKelamin.SelectedIndex = 0;
            if (cmbStatusPerkawinan.Items.Count > 0) cmbStatusPerkawinan.SelectedIndex = 0;
            txtAlamat.Text = string.Empty;
            txtPekerjaan.Text = string.Empty;
            selectedNIK = string.Empty; // Reset NIK yang sedang diedit
            txtNIK.ReadOnly = false; // NIK bisa diubah lagi untuk input baru
            btnSimpan.Enabled = true; // Tombol simpan selalu aktif (untuk tambah/update)
            btnHapus.Enabled = false; // Nonaktifkan hapus
            btnUbah.Enabled = false; // Nonaktifkan ubah
            dgvWarga.ClearSelection(); // Hilangkan seleksi di grid
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void dgvWarga_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Pastikan baris yang diklik valid (bukan header kolom) 
            {
                DataGridViewRow row = dgvWarga.Rows[e.RowIndex];
                // Ambil NIK dari baris yang dipilih 
                selectedNIK = row.Cells["NIK"].Value.ToString();
                // Isi form dengan data dari baris yang dipilih 
                txtNIK.Text = selectedNIK;
                txtNamaLengkap.Text = row.Cells["NamaLengkap"].Value.ToString();
                // Konversi string tanggal ke DateTime untuk DateTimePicker 
                DateTime tglLahir;
                if (DateTime.TryParse(row.Cells["TanggalLahir"].Value.ToString(), out tglLahir))
                {
                    dtpTanggalLahir.Value = tglLahir;
                }
                else
                {
                    dtpTanggalLahir.Value = DateTime.Now; // Default jika gagal konversi 
                }
                cmbJenisKelamin.Text = row.Cells["JenisKelamin"].Value.ToString();
                txtAlamat.Text = row.Cells["Alamat"].Value.ToString();
                txtPekerjaan.Text = row.Cells["Pekerjaan"].Value.ToString();
                cmbStatusPerkawinan.Text = row.Cells["StatusPerkawinan"].Value.ToString();
                // Setelah data terpilih, NIK tidak boleh diubah langsung di textbox 
                // Agar NIK menjadi kunci unik untuk update/delete



                txtNIK.ReadOnly = true;
                // Aktifkan tombol Hapus dan Ubah 
                btnHapus.Enabled = true;
                btnUbah.Enabled = true;
                // Tombol simpan tetap aktif karena bisa berfungsi sebagai "Update" 
            }
        }


        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedNIK))
            {
                MessageBox.Show("Pilih data warga yang ingin dihapus terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Konfirmasi penghapusan 
            DialogResult dialogResult = MessageBox.Show($"Anda yakin ingin menghapus data warga dengan NIK: {selectedNIK}?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                bool success = dbManager.DeleteWarga(selectedNIK);
                if (success)
                {
                    MessageBox.Show("Data warga berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataToGrid(); // Muat ulang data ke grid 
                    ResetForm(); // Bersihkan form 
                }
            }
        }


        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedNIK))
            {
                MessageBox.Show("Pilih data warga yang ingin diubah terlebih dahulu.", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Karena logika SaveWarga sudah menangani update, tombol Ubah hanya perlu memastikan form siap
            MessageBox.Show("Silakan ubah data di formulir, lalu klik 'Simpan' untuk memperbarui.", "Siap Mengubah", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // NIK sudah diset ReadOnly di CellClick, jadi tidak perlu lagi di sini.
            // btnSimpan sudah aktif
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load initial data
            LoadDataToGrid();

            // Set default ComboBox selections
            if (cmbJenisKelamin.Items.Count > 0)
                cmbJenisKelamin.SelectedIndex = 0;

            if (cmbStatusPerkawinan.Items.Count > 0)
                cmbStatusPerkawinan.SelectedIndex = 0;
        }

        private void ResetForm()
        {
            txtNIK.Clear();
            txtNamaLengkap.Clear();
            dtpTanggalLahir.Value = DateTime.Now;
            cmbJenisKelamin.SelectedIndex = 0;
            txtAlamat.Clear();
            txtPekerjaan.Clear();
            cmbStatusPerkawinan.SelectedIndex = 0;

            txtNIK.ReadOnly = false;
            selectedNIK = string.Empty;

            btnHapus.Enabled = false;
            btnUbah.Enabled = false;
            btnSimpan.Text = "Simpan";
        }

        // Add event handlers for the DataGridView
        private void dgvWarga_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvWarga.CurrentRow != null)
            {
                selectedNIK = dgvWarga.CurrentRow.Cells["NIK"].Value.ToString();
                DataRow row = dbManager.GetWargaByNIK(selectedNIK);

                if (row != null)
                {
                    txtNIK.Text = row["NIK"].ToString();
                    txtNamaLengkap.Text = row["NamaLengkap"].ToString();
                    dtpTanggalLahir.Value = DateTime.Parse(row["TanggalLahir"].ToString());
                    cmbJenisKelamin.Text = row["JenisKelamin"].ToString();
                    txtAlamat.Text = row["Alamat"].ToString();
                    txtPekerjaan.Text = row["Pekerjaan"].ToString();
                    cmbStatusPerkawinan.Text = row["StatusPerkawinan"].ToString();

                    txtNIK.ReadOnly = true;
                    btnHapus.Enabled = true;
                    btnUbah.Enabled = true;
                    btnSimpan.Text = "Update";
                }
            }
        }
    }
}