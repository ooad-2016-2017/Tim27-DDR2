using DDR2.Helper;
using DDR2.HotelBaza.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using static DDR2.Model.Soba;

namespace DDR2.ViewModel
{
    class EditRoomVM : MainViewModelBase
    {
        public string Naziv { get; set; } = "";
        int broj, djeca, odrasli;
        public string Broj { get { return broj.ToString(); } set { broj = Convert.ToInt32(value); } }
        tip_sobe tip;
        public string Tip { get { return tip.ToString(); } set { tip = (tip_sobe)Enum.Parse(typeof(tip_sobe), value); } }
        double cijena;
        public string Cijena { get { return cijena.ToString(); } set { cijena = Convert.ToDouble(value); } }
        public string Djeca { get { return djeca.ToString(); } set { djeca = Convert.ToInt32(value); } }
        public string Odrasli { get { return odrasli.ToString(); } set { odrasli = Convert.ToInt32(value); } }
        public string Opis { get; set; } = "";
        public byte[] Slika { get; set; }
        public List<string> Tipovi { get; set; }
        public ICommand UploadSlike { get; set; }
        public ICommand Save { get; set; }
        public RoomsVM ListaRoditelj { get; set; }

        public EditRoomVM(RoomsVM parent)
        {
            ListaRoditelj = parent;
            InicijalizirajPodatke();
            Tipovi = new List<string> { "Single", "Double", "Triple", "Family" };
            UploadSlike = new RelayCommand<object>(upload, parametar => true);
            Save = new RelayCommand<object>(spasi, parametar => true);
        }

        public void InicijalizirajPodatke()
        {
            using (var db = new HotelDbContext())
            {
                var soba = db.Sobe.FirstOrDefault(x => x == ListaRoditelj.Selektovana);
                Naziv = soba.Naziv;
                Broj = soba.Broj.ToString();
                Tip = soba.Tip.ToString();
                Djeca = soba.Max_djece.ToString();
                Odrasli = soba.Max_odraslih.ToString();
                Cijena = soba.Cijena.ToString();
                Slika = soba.Slika;
                Opis = soba.Opis;
            }
        }

        public async void upload(object p)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");
            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                Slika = (await FileIO.ReadBufferAsync(file)).ToArray(); ;
            }
        }

        public async void spasi(object p)
        {
            using(var db=new HotelDbContext())
            {
                var promijeniti = db.Sobe.FirstOrDefault(x => x == ListaRoditelj.Selektovana);
                promijeniti.Naziv = Naziv;
                promijeniti.Broj = broj;
                promijeniti.Cijena = cijena;
                promijeniti.Tip = tip;
                promijeniti.Opis = Opis;
                promijeniti.Slika = Slika;
                promijeniti.Max_djece = djeca;
                promijeniti.Max_odraslih = odrasli;

                db.Entry(promijeniti).State = EntityState.Modified;
                db.SaveChanges();
                var dialog = new MessageDialog("Changes saved!");
                await dialog.ShowAsync();
            }
        }
    }
}
