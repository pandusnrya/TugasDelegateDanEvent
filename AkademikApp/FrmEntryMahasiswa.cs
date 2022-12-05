using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AkademikApp
{
    public partial class FrmEntryMahasiswa : Form
    {

        // deklarasi tipe data untuk event OnCreate dan OnUpdate
        public delegate void CreateUpdateEventHandler(Mahasiswa mhs);
        // deklarasi event ketika terjadi proses input data baru
        public event CreateUpdateEventHandler OnCreate;
        // deklarasi event ketika terjadi proses update data
        public event CreateUpdateEventHandler OnUpdate;
        // deklarasi variabel untuk menyimpan status entry data (input baru atau update)
        private bool isNewData = true;
        // deklarasi variabel/objek mhs untuk meyimpan data mahasiswa
        private Mahasiswa mhs;
        // Constructor default
        public FrmEntryMahasiswa()
        {
            InitializeComponent();
        }

        private int Penambahan(int a, int b)
        {
            return a + b;
        }
        private int Pengurangan(int a, int b)
        {
            return a - b;
        }

        private int Perkalian(int a, int b)
        {
            return a * b;
        }
        private int Pembagian(int a, int b)
        {
            return a / b;
        }

        // Constructor untuk inisialisasi data ketika entri data baru
        public FrmEntryMahasiswa(string title)
         : this()
        {
            // ganti text/judul form
            this.Text = title;
        }


        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // jika data baru, inisialisasi objek mahasiswa
            if (isNewData) mhs = new Mahasiswa();
            // set nilai property objek mahasiswa yg diambil dari TextBox
            mhs.Npm = txtNpm.Text;
            mhs.Nama = txtNama.Text;
            mhs.Angkatan = txtAngkatan.Text;

            var a = int.Parse(txtNama.Text);
            var b = int.Parse(txtAngkatan.Text);


            if(txtNpm.Text == "Penambahan")
            {
                mhs.Hasil = string.Format("{0}", Penambahan(a, b));
            }else if (txtNpm.Text == "Pengurangan")
            {
                mhs.Hasil = string.Format("{0}", Pengurangan(a, b));
            }
            else if (txtNpm.Text == "Pembagian")
            {
                mhs.Hasil = string.Format("{0}", Pembagian(a, b));
            }
            else if(txtNpm.Text == "Perkalian")
            {
                mhs.Hasil = string.Format("{0}", Perkalian(a, b));
            }
            else
            {
                MessageBox.Show("Inputkan Operasi !");
            }

            if (isNewData) // data baru
            {
                OnCreate(mhs); // panggil event OnCreate
                               // reset form input, utk persiapan input data berikutnya
     
                txtNama.Clear();
                txtAngkatan.Clear();
                txtNpm.Focus();
            }
            else // update
            {
                OnUpdate(mhs); // panggil event OnUpdate
                this.Close();
            }



        }



        private void FrmEntryMahasiswa_Load(object sender, EventArgs e)
        {

        }

        private void txtNama_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar!= (char)Keys.Back;
        }

        private void txtAngkatan_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }
    }
}
