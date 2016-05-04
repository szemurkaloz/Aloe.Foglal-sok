using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace Aloe.Foglalások.Services
{
    public class XmlNodeItem
    {
        public XmlNodeItem()
        {
            this.Items = new ObservableCollection<XmlNodeItem>();
        }
        [XmlAttribute(AttributeName = "Header")]
        public string Header
        {
            get;
            set;
        }

        [XmlAttribute(AttributeName = "Tag")]
        public string Tag
        {
            get;
            set;
        }
        public ObservableCollection<XmlNodeItem> Items
        {
            get;
            set;
        }
    }

    [XmlRoot(ElementName = "Items")]
    public class XmlNodeItemList : ObservableCollection<XmlNodeItem>
    {
        public void AddRange(IEnumerable<XmlNodeItem> range)
        {
            foreach (XmlNodeItem node in range)
            {
                this.Add(node);
            }
        }
    }

    public class RadTreeViewXmlDataSource : XmlNodeItemList
    {
        private string source;
        public string Source
        {
            get
            {
                return this.source;
            }
            set
            {
                this.source = value;
                AddRange(RetrieveData(Application.GetResourceStream(new Uri(value, UriKind.Relative)).Stream));
            }
        }
        private XmlNodeItemList RetrieveData(Stream xmlStream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XmlNodeItemList));
            StreamReader reader = new StreamReader(xmlStream);
            XmlNodeItemList list = (XmlNodeItemList)serializer.Deserialize(reader);
            return list;
        }
    }
}
