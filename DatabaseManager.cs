using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace AplikasiPencatatanWarga
{
    public class DatabaseManager
    {
        private readonly string dbPath;

        public DatabaseManager()
        {
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string dataFolder = Path.Combine(appDirectory, "Data");

            if (!Directory.Exists(dataFolder))
            {
                Directory.CreateDirectory(dataFolder);
            }

            dbPath = Path.Combine(dataFolder, "warga.db");
            InitializeDatabase();
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection($"Data Source={dbPath};Version=3;");
        }

        private void InitializeDatabase()
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            using var conn = GetConnection();
            try
            {
                conn.Open();
                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Warga (
                        NIK TEXT PRIMARY KEY UNIQUE NOT NULL,
                        NamaLengkap TEXT NOT NULL,
                        TanggalLahir TEXT,
                        JenisKelamin TEXT NOT NULL,
                        Alamat TEXT,
                        Pekerjaan TEXT,
                        StatusPerkawinan TEXT
                    );";

                using var cmd = new SQLiteCommand(createTableQuery, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error saat inisialisasi database: {ex.Message}",
                    "Error Database",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        public bool SaveWarga(string nik, string namaLengkap, DateTime tanggalLahir,
        string jenisKelamin, string alamat, string pekerjaan, string statusPerkawinan)
        {
            using var conn = GetConnection();
            try
            {
                conn.Open();
                string insertQuery = @"
                INSERT OR REPLACE INTO Warga (NIK, NamaLengkap, TanggalLahir, JenisKelamin, 
                    Alamat, Pekerjaan, StatusPerkawinan)
                VALUES (@NIK, @NamaLengkap, @TanggalLahir, @JenisKelamin, 
                    @Alamat, @Pekerjaan, @StatusPerkawinan)";

                using var cmd = new SQLiteCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@NIK", nik);
                cmd.Parameters.AddWithValue("@NamaLengkap", namaLengkap);
                cmd.Parameters.AddWithValue("@TanggalLahir", tanggalLahir.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@JenisKelamin", jenisKelamin);
                cmd.Parameters.AddWithValue("@Alamat", alamat);
                cmd.Parameters.AddWithValue("@Pekerjaan", pekerjaan);
                cmd.Parameters.AddWithValue("@StatusPerkawinan", statusPerkawinan);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat menyimpan data: {ex.Message}",
                    "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool UpdateWarga(string nik, string namaLengkap, DateTime tanggalLahir,
            string jenisKelamin, string alamat, string pekerjaan, string statusPerkawinan)
        {
            using var conn = GetConnection();
            try
            {
                conn.Open();
                string updateQuery = @"
                UPDATE Warga 
                SET NamaLengkap = @NamaLengkap,
                    TanggalLahir = @TanggalLahir,
                    JenisKelamin = @JenisKelamin,
                    Alamat = @Alamat,
                    Pekerjaan = @Pekerjaan,
                    StatusPerkawinan = @StatusPerkawinan
                WHERE NIK = @NIK";

                using var cmd = new SQLiteCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@NIK", nik);
                cmd.Parameters.AddWithValue("@NamaLengkap", namaLengkap);
                cmd.Parameters.AddWithValue("@TanggalLahir", tanggalLahir.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@JenisKelamin", jenisKelamin);
                cmd.Parameters.AddWithValue("@Alamat", alamat);
                cmd.Parameters.AddWithValue("@Pekerjaan", pekerjaan);
                cmd.Parameters.AddWithValue("@StatusPerkawinan", statusPerkawinan);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat mengupdate data: {ex.Message}",
                    "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool DeleteWarga(string nik)
        {
            using var conn = GetConnection();
            try
            {
                conn.Open();
                string deleteQuery = "DELETE FROM Warga WHERE NIK = @NIK";

                using var cmd = new SQLiteCommand(deleteQuery, conn);
                cmd.Parameters.AddWithValue("@NIK", nik);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat menghapus data: {ex.Message}",
                    "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataRow GetWargaByNIK(string nik)
        {
            using var conn = GetConnection();
            try
            {
                conn.Open();
                string selectQuery = "SELECT * FROM Warga WHERE NIK = @NIK";

                using var cmd = new SQLiteCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@NIK", nik);

                using var adapter = new SQLiteDataAdapter(cmd);
                var dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat mengambil data: {ex.Message}",
                    "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable GetAllWarga()
        {
            var dataTable = new DataTable();
            using var conn = GetConnection();
            try
            {
                conn.Open();
                string selectQuery = "SELECT * FROM Warga ORDER BY NamaLengkap";

                using var cmd = new SQLiteCommand(selectQuery, conn);
                using var adapter = new SQLiteDataAdapter(cmd);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat mengambil data: {ex.Message}",
                    "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataTable;
        }

        public bool IsNIKExists(string nik)
        {
            using var conn = GetConnection();
            try
            {
                conn.Open();
                string checkQuery = "SELECT COUNT(1) FROM Warga WHERE NIK = @NIK";

                using var cmd = new SQLiteCommand(checkQuery, conn);
                cmd.Parameters.AddWithValue("@NIK", nik);

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat memeriksa NIK: {ex.Message}",
                    "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}