using Catel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aloe.Foglalások.Models
{
    public class EngedélyDto : ModelBase
    {
        /// <summary>
        /// Gets or sets the property value.
        /// </summary>
        public string Ablak
        {
            get { return GetValue<string>(AblakProperty); }
            set { SetValue(AblakProperty, value); }
        }

        /// <summary>
        /// Register the Ablak property so it is known in the class.
        /// </summary>
        public static readonly PropertyData AblakProperty = RegisterProperty("Ablak", typeof(string), null);

        /// <summary>
        /// Gets or sets the property value.
        /// </summary>
        public bool Írja
        {
            get { return GetValue<bool>(ÍrjaProperty); }
            set { SetValue(ÍrjaProperty, value); }
        }

        /// <summary>
        /// Register the Írja property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ÍrjaProperty = RegisterProperty("Írja", typeof(bool), false);

        /// <summary>
        /// Gets or sets the property value.
        /// </summary>
        public bool Olvas
        {
            get { return GetValue<bool>(OlvasProperty); }
            set { SetValue(OlvasProperty, value); }
        }

        /// <summary>
        /// Register the Olvas property so it is known in the class.
        /// </summary>
        public static readonly PropertyData OlvasProperty = RegisterProperty("Olvas", typeof(bool), false);
    }

    public class DolgozóDto : ModelBase
    {
        public DolgozóDto()
        {
            Engedélyek = new List<EngedélyDto>();
        }

        /// <summary>
        /// Gets or sets the property value.
        /// </summary>
        public string Név
        {
            get { return GetValue<string>(NévProperty); }
            set { SetValue(NévProperty, value); }
        }

        /// <summary>
        /// Register the Név property so it is known in the class.
        /// </summary>
        public static readonly PropertyData NévProperty = RegisterProperty("Név", typeof(string), false);

        /// <summary>
        /// Gets or sets the property value.
        /// </summary>
        public string Jelszó
        {
            get { return GetValue<string>(JelszóProperty); }
            set { SetValue(JelszóProperty, value); }
        }

        /// <summary>
        /// Register the Jelszó property so it is known in the class.
        /// </summary>
        public static readonly PropertyData JelszóProperty = RegisterProperty("Jelszó", typeof(string), false);

        public List<EngedélyDto> Engedélyek { get; set; }
    }
}
