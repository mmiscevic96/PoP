using System;
using System.ComponentModel;

namespace SF52016.Model{


public enum TipKorisnika
{
    Admin,
    Prodavac
}

public class User : INotifyPropertyChanged, ICloneable
{

    private int ID;

    public int Id
    {
        get { return ID; }
        set { ID = value;
            OnPropertyChanged("Id");
        }
    }
    private bool obrisan;
    public bool Obrisan
    {
        get { return obrisan; }
        set { obrisan = value;
            OnPropertyChanged("Obrisan");
        }
    }

    private string userName;

    public string UserName
    {
        get { return userName; }
        set
        {
            userName = value;
            OnPropertyChanged("UserName");
        }
    }

    private string password;

    public string Password
    {
        get { return password; }
        set
        {
            password = value;
            OnPropertyChanged("Password");
        }
    }

    private string ime;

    public string Ime
    {
        get { return ime; }
        set
        {
            ime = value;
            OnPropertyChanged("Ime");
        }
    }

    private string prezime;

    public string Prezime
    {
        get { return prezime; }
        set
        {
            prezime = value;
            OnPropertyChanged("Prezime");
        }
    }

    private TipKorisnika tipKorisnika;

    public TipKorisnika TipKorisnika
    {
        get { return tipKorisnika; }
        set
        {
            tipKorisnika = value;
            OnPropertyChanged("TipKorisnika");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public override string ToString()
    {
        if (!obrisan)
        {
            return $"{Ime}, {Prezime}, {UserName}, {Password}, {TipKorisnika}";
        }
        return null;
    }
    public User()
    {
        tipKorisnika = TipKorisnika.Prodavac;
    }
    public static User PronadjiUsera(string uName)
    {
        foreach (var user in Projekat.Instance.Korsnici)
        {
            if (user.UserName == uName)
            {
                return user;
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
        User copy = new User();
        copy.Ime = Ime;
        copy.Prezime = Prezime;
        copy.UserName = UserName;
        copy.Password = Password;
        copy.TipKorisnika = TipKorisnika;
        return copy;

    }
}
}



  
