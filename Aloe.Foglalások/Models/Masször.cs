using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Abstracts;

namespace Aloe.Foglalások.Models
{
    /// <summary>
    /// Business Entity for Masszor
    /// </summary>
    public class Masszor : MongoEntity
    {
        public Masszor()
        {
        }

        [BsonElement("Nev")]
        public string Név { get; set; }
    }

    /// <summary>
    /// Business Entity for Masszázs fajták
    /// </summary>
    public class Kezeles : MongoEntity
    {
        public Kezeles()
        {
        }

        [BsonElement("Nev")]
        public string Név { get; set; }

        [BsonElement("RovidNev")]
        public string RövidNév { get; set; }

        [BsonElement("KezelesArak")]
        public IList<KezelésÁr> KezelésÁrak { get; set; }

        [BsonElement("KezelesHelyek")]
        public IList<string> KezelésHelyek { get; set; }
    }

    /// <summary>
    /// Business Entity for Kezelés helye
    /// </summary>
    public class KezelesHely : MongoEntity
    {
        public KezelesHely()
        {
        }

        [BsonElement("Nev")]
        public string Név { get; set; }
    }

    public class KezelésÁr
    {
        [BsonElement("osszeg")]
        [BsonDefaultValue(0)]
        public decimal Összeg { get; set; }

        [BsonElement("BerletOsszeg")]
        [BsonDefaultValue(0)]
        public decimal BérletÖsszeg { get; set; }

        [BsonElement("AlkalmakSzama")]
        [BsonDefaultValue(0)]
        public int AlkalmakSzáma { get; set; }

        [BsonElement("Artipusa")]
        public string Ártipusa { get; set; }

        public int TartamaPerc { get; set; }

        public string Tartama { get; set; }

        [BsonElement("ErvenyesTol")]
        public DateTime Érvényestől { get; set; }

        [BsonElement("ErvenyesIg")]
        public DateTime ÉrvényesIg { get; set; }
    }

    /// <summary>
    /// Business Entity for Ártipusok
    /// </summary>
    public class Artipusok : MongoEntity
    {
        public Artipusok()
        {
        }

        [BsonElement("Nev")]
        public string Név { get; set; }
    }

    /// <summary>
    /// Business Entity for Idöpontok
    /// </summary>
    public class Idopont : MongoEntity
    {
        public Idopont()
        {
        }

        [BsonElement("Ido")]
        public TimeSpan Idő { get; set; }
    }

    /// <summary>
    /// Business Entity for Bérlet fajták
    /// </summary>
    public class BerletTipus : MongoEntity
    {
        public BerletTipus()
        {
        }

        [BsonElement("BerletTipus")]
        public string BérletTipus { get; set; }

        [BsonElement("BerletNev")]
        public string BérletNév { get; set; }
    }

    /// <summary>
    /// Business Entity for Kezelés fajták
    /// </summary>
    public class SzolgaltatasTipus : MongoEntity
    {
        public SzolgaltatasTipus()
        {
        }

        [BsonElement("TipusNev")]
        public string TipusNév { get; set; }

        [BsonElement("RovidTipusNev")]
        public string RövidTipusNév { get; set; }
    }

    /// <summary>
    /// Business Entity for Kezelés fajták
    /// </summary>
    public class SzolgaltatasTartam : MongoEntity
    {
        public SzolgaltatasTartam()
        {
        }

        public int TartamaPerc { get; set; }

        public string Tartama { get; set; }
    }

    /// <summary>
    /// Business Entity for Bérlet fajták
    /// </summary>
    public class Dolgozo : MongoEntity
    {
        public Dolgozo()
        {
        }

        [BsonElement("Nev")]
        public string Név { get; set; }

        [BsonElement("Jelszo")]
        public string Jelszó { get; set; }

        [BsonElement("Engedelyek")]
        public List<Engedély> Engedélyek { get; set; }
    }

    /// <summary>
    /// Business Entity for Bérlet fajták
    /// </summary>
    public class Engedély 
    {
        public Engedély()
        {
        }
        
        public string Ablak { get; set; }

        [BsonElement("Irja")]
        public bool Írja { get; set; }

        [BsonElement("Olvas")]
        public bool Olvas { get; set; }
    }

    /// <summary>
    /// Business Entity for Foglalasok
    /// </summary>
    public class EloFoglalas : MongoEntity
    {
        public EloFoglalas()
        {
        }

        [BsonElement("Datum")]
        public DateTime Dátum { get; set; }

        [BsonElement("PultosNev")]
        public string PultosNév { get; set; }

        [BsonElement("Valto")]
        public decimal Váltó { get; set; }

        [BsonElement("ZaroOsszeg")]
        public decimal ZáróÖsszeg { get; set; }

        [BsonElement("Foglalasok")]
        public List<Foglalás> Foglalások { get; set; }
    }

    public class Foglalás   
    {
        [BsonElement("MasszorNev")]
        public string MasszőrNév { get; set; }

        [BsonElement("VendegNev")]
        public string VendégNév { get; set; }

        [BsonElement("Elerhetoseg")]
        public string Elérhetőség { get; set; }

        [BsonElement("BerletTipus")]
        public IList<string> BérletTipus { get; set; }

        [BsonElement("Osszeg")]
        public decimal Összeg { get; set; }

        [BsonElement("Megjegyzes")]
        public string Megjegyzés { get; set; }

        [BsonElement("KezelesNev")]
        public string KezelésNév { get; set; }

        [BsonElement("KezelesRovidNev")]
        public string KezelésRövidNév { get; set; }

        public string Tartama { get; set; }

        public int TartamaPerc { get; set; }

        [BsonElement("DatumTol")]
        public DateTime IdőTól { get; set; }

        [BsonElement("DatumIg")]
        public DateTime IdőIg { get; set; }

    }
}
