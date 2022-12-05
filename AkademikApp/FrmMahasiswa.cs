using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkademikApp
{
    public partial class FrmMahasiswa : Form
    {

        private IList<Mahasiswa> listOfMahasiswa = new List<Mahasiswa>();
        // constructor
        public FrmMahasiswa()
        {
            InitializeComponent();
            InisialisasiListView();
        }

        // atur kolom listview
        private void InisialisasiListView()
        {
            lvwMahasiswa.View = View.Details;
            lvwMahasiswa.FullRowSelect = true;
            lvwMahasiswa.GridLines = true;
            lvwMahasiswa.Columns.Add("No.", 30, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Option",100, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nilai A", 100, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Nilai B", 100, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Hasil", 100, HorizontalAlignment.Center);
        }

        // method event handler untuk merespon event OnCreate,
        // ketika di panggil dari form entry mahasiswa
        private void FrmEntry_OnCreate(Mahasiswa mhs)
        {
            // tambahkan objek mhs yang baru ke dalam collection
            listOfMahasiswa.Add(mhs);
            int noUrut = lvwMahasiswa.Items.Count + 1;
            // tampilkan data mhs yg baru ke list view
            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(mhs.Npm);
            item.SubItems.Add(mhs.Nama);
            item.SubItems.Add(mhs.Angkatan);
            item.SubItems.Add(mhs.Hasil);

            lvwMahasiswa.Items.Add(item);
        }
        // method event handler untuk merespon event OnUpdate,
        // ketika di panggil dari form entry mahasiswa
       

        private void btnTambah_Click(object sender, EventArgs e)
        {
            // buat objek form entry data mahasiswa
            FrmEntryMahasiswa frmEntry = new FrmEntryMahasiswa("Calculator");
           // mendaftarkan method event handler utk merespon event OnCreate(subscribe)
           
            frmEntry.OnCreate += FrmEntry_OnCreate;
            // tampilkan form entry mahasiswa
            frmEntry.ShowDialog();
        }

     

  

      

        private void FrmMahasiswa_Load(object sender, EventArgs e)
        {

        }
    }
}
