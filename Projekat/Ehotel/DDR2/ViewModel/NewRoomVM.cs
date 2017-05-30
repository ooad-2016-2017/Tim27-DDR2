using DDR2.Helper;
using DDR2.HotelBaza.Models;
using DDR2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.Storage.Pickers;
using static DDR2.Model.Soba;

namespace DDR2.ViewModel
{
    class NewRoomVM : MainViewModelBase
    {
        public string Naziv { get; set; } = "";
        int broj, djeca, odrasli;
        public string Broj { get { return broj.ToString(); } set { broj = Convert.ToInt32(value); } }
        tip_sobe tip;
        public string Tip { get { return tip.ToString(); } set { tip = (tip_sobe)Enum.Parse(typeof(tip_sobe), value); } }
        double cijena;
        public string Cijena { get { return cijena.ToString(); } set { cijena = Convert.ToDouble(value); } } 
        public string Djeca { get { return djeca.ToString(); } set { djeca = Convert.ToInt32(value); } }//kako ovo uzeti sa korisnicke kontrole
        public string Odrasli { get { return odrasli.ToString(); } set { odrasli = Convert.ToInt32(value); } }//kako ovo uzeti sa korisnicke kontrole
        public string Opis { get; set; } = "";
        public byte[] Slika { get; set; }
        public List<string> Tipovi { get; set; }
        public ICommand UploadSlike { get; set; }
        public ICommand AddRoom { get; set; }

        public NewRoomVM()
        {
            Tipovi = new List<string> { "Single", "Double", "Triple", "Family" };
            UploadSlike = new RelayCommand<object>(upload, parametar => true);
            AddRoom = new RelayCommand<object>(dodaj, parametar => true);
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
        public void dodaj(object p)
        {
            Soba nova = new Soba(Naziv, broj, cijena, true, true, tip, 0, 0, Opis);
            nova.Slika = Slika;
            using(var db=new HotelDbContext())
            {
                db.Sobe.Add(nova);
                db.SaveChanges();
            }
        }
    }
}
