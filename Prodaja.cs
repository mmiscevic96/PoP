using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using SF52016.Model;
using System.Xml.Serialization;
using ComponentModel;

public class Prodaja: INotifyPropertyChanged, ICloneable
{
	public Prodaja()
	{
        dateSell = DateTime.Today;
        itemi = new ObservableCollection<itemi>();
	}
    private int id;

    public int ID
    {
        get { return id;}
        set { id = value; OnPropertyChanged("ID"); }
    }
    private List<int> itemiId;

    public List<int> ItemiId
    {
        get { return itemiId; }
        set { itemiId = value; OnPropertyChanged("Id"); }

    }
    private ObservableCollection<Itemi> itemi;

    public ObservableCollection<Itemi> Itemi
    {
        get
        {
            if (itemi == null) itemi = StavkaProdaje.PronadjiStavke(stavkaProdajeId);
            return itemi;

        }
        set
        {
            itemi = value;
            for (int i = 0; i < itemi.Count; i++)
                itemiId.Add(StavkaProdaje.Count[i].Id);
            OnPropertyChanged("StavkeProdaje");
        }
    }
    private DateTime datumProdaje;

    public DateTime DatumProdaje

    {
        get { return datumProdaje; }
        set
        {
            datumProdaje = value;
            OnPropertyChanged("DatumProdaje");
        }
    }

    private int brojRacuna;

    public int BrojRacuna
    {
        get { return brojRacuna; }
        set
        {
            brojRacuna = value;
            OnPropertyChanged("BrojRacuna");
        }
    }
    private string kupac;

    public string Kupac
    {
        get { return kupac; }
        set
        {
            kupac = value;
            OnPropertyChanged("Kupac");
        }
    }

    public const double PDV = 0.02;

    public event PropertyChangedEventHandler PropertyChanged;



    private double total;

    public double Total
    {
        get { return total; }
        set
        {
            total = value;
            if (stavkeProdaje != null)
                for (int i = 0; i < stavkeProdaje.Count; i++)
                    ukupanIznos += stavkeProdaje[i].Cena;
            else
                ukupanIznos = 0;

            OnPropertyChanged("Total");

        }
    }

    private bool obrisan;

    public bool Obrisan
    {
        get { return obrisan; }
        set
        {
            obrisan = value;
            OnPropertyChanged("Obrisan");
        }
    }
    public static ProdajaNamestaja PronadjiProdaju(int id)
    {
        foreach (var prodaja in Projekat.Instance.Prodaja)
        {
            if (prodaja.Id == id)
            {
                return prodaja;
            }

        }
        return null;
    }
    protected void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public object Clone()
    {
        ProdajaNamestaja kopija = new ProdajaNamestaja();
        kopija.Id = id;
        kopija.Kupac = kupac;
        kopija.UkupanIznos = ukupanIznos;
        kopija.BrojRacuna = brojRacuna;
        kopija.StavkeProdaje = stavkeProdaje;
        return kopija;
    }
}

