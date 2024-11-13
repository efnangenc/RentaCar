using Accessibility;
using RentAndSell.Car.Models;
using RentAndSell.Car.Models.Commons.Enums;
using System.Net.Http.Json;
using System.Reflection;

namespace RentAndSell.Car
{
    public partial class Form1 : Form
    {
        private HttpClient _httpClient;
        private const string _endpoint = "Cars";
        public Form1()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7027/api/");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cBoxYakitTuru.DataSource = Enum.GetValues(typeof(YakitTuru));
            cBoxMotorTipi.DataSource = Enum.GetValues(typeof(MotorTipi));
            cBoxSanzimanTipi.DataSource = Enum.GetValues(typeof(SanzimanTipi));

            nbrUpDownYil.Maximum = DateTime.Now.Year;
            //nbrUpDownYil.Minimum = DateTime.Now.Year - 50; // son 50 yýllýk iþ

            //MessageBox.Show(cBoxYakitTuru.SelectedValue.ToString());
            //MessageBox.Show(cBoxMotorTipi.SelectedValue.ToString());
            //MessageBox.Show(cBoxSanzimanTipi.SelectedValue.ToString());

            //MessageBox.Show("" + (int)cBoxYakitTuru.SelectedValue);
            //MessageBox.Show("" + (int)cBoxMotorTipi.SelectedValue);
            //MessageBox.Show("" + (int)cBoxSanzimanTipi.SelectedValue);

            for (short i = 1940; i <= DateTime.Now.Year; i++)
                cBoxYil.Items.Add(i);

            cBoxYil.SelectedIndex = 0;


            ReloadedDataView();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ArabaViewModel model = new ArabaViewModel();
            model.Marka = txtMarka.Text;
            model.Model = txtModel.Text;
            model.Yili = (short)cBoxYil.SelectedItem;
            model.YakitTuru = (YakitTuru)cBoxYakitTuru.SelectedItem;
            model.MotorTipi = (MotorTipi)cBoxMotorTipi.SelectedItem;
            model.SanzimanTipi = (SanzimanTipi)cBoxSanzimanTipi.SelectedItem;

            HttpResponseMessage responseMessage = _httpClient.PostAsJsonAsync(_endpoint, model).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                MessageBox.Show("Kayýt baþarýlý" + responseMessage.Content.ReadAsStringAsync().Result);
                ReloadedDataView();
            }
            else
                MessageBox.Show("Kayýt yapýlamadý");

        }
        private void ReloadedDataView()
        {
            List<ArabaViewModel> arabaViewModels = _httpClient.GetFromJsonAsync<List<ArabaViewModel>>(_endpoint).Result;
            dgvArabaList.DataSource = arabaViewModels;
            ClearForm();
        }

        private void dgvArabaList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //List<ArabaViewModel> arabaViewModels = _httpClient.GetFromJsonAsync<List<ArabaViewModel>>(_endpoint).Result;  //her kayýt okumayý servise tekrar sormmakta fayda vra tutarlýlýk için

            ArabaViewModel selectedAraba = (ArabaViewModel)dgvArabaList.SelectedRows[0].DataBoundItem;

            txtId.Text = selectedAraba.Id.ToString();
            txtMarka.Text = selectedAraba.Marka;
            txtModel.Text = selectedAraba.Model;
            cBoxYil.SelectedItem = selectedAraba.Yili;
            cBoxYakitTuru.SelectedItem = selectedAraba.YakitTuru;
            cBoxMotorTipi.SelectedItem = selectedAraba.MotorTipi;
            cBoxMotorTipi.SelectedItem = selectedAraba.SanzimanTipi;

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ArabaViewModel model = new ArabaViewModel();
            model.Marka = txtMarka.Text;
            model.Model = txtModel.Text;
            model.Yili = (short)cBoxYil.SelectedItem;
            model.YakitTuru = (YakitTuru)cBoxYakitTuru.SelectedItem;
            model.MotorTipi = (MotorTipi)cBoxMotorTipi.SelectedItem;
            model.SanzimanTipi = (SanzimanTipi)cBoxSanzimanTipi.SelectedItem;

            string id = txtId.Text;


            HttpResponseMessage responseMessage = _httpClient.PutAsJsonAsync(_endpoint + $"/{id}", model).Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                MessageBox.Show("Güncelleme baþarýlýdýr. Yanýt: " + responseMessage.Content.ReadAsStringAsync().Result);

                ReloadedDataView();
            }

            else
                MessageBox.Show("Kayýt yapýlamadý");


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;

            HttpResponseMessage responseMessage = _httpClient.DeleteAsync(_endpoint + $"/{id}").Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                MessageBox.Show("Silme baþarýlýdýr. Yanýt: " + responseMessage.Content.ReadAsStringAsync().Result);

                ReloadedDataView();
            }

            else
                MessageBox.Show("Kayýt yapýlamadý");


        }
        private void ClearForm()
        {
            txtId.Text = "";
            txtMarka.Text = "";
            txtModel.Clear();
            cBoxYil.SelectedIndex = 0;
            cBoxYakitTuru.SelectedIndex = 0;
            cBoxMotorTipi.SelectedIndex = 0;
            cBoxSanzimanTipi.SelectedIndex = 0;
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            string carId = txtCarId.Text;

            ArabaViewModel model = _httpClient.GetFromJsonAsync<ArabaViewModel>(_endpoint + $"/{carId}").Result;

            if (model != null)
            {
                string metin = $@"
                                 Marka : {model.Marka},
                                 Model: {model.Model},
                                 Yýlý: {model.Yili},
                                 Þanýzman tipi: {model.SanzimanTipi},
                                 Motor türü: {model.MotorTipi},
                                 YAkýt türü: {model.YakitTuru}";

                MessageBox.Show(metin);
            }

            else
                MessageBox.Show("Kayýt yapýlamadý");
        }
    }
}
