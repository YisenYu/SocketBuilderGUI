using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.ComponentModel;
namespace Model
{
    public class Material : INotifyPropertyChanged, IEquatable<Material>
    {
        #region INotifyPropertyChanged Implement
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        #endregion



        #region IEquatable Implement
        public bool Equals(Material other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(this, other)) return true;
            return Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            int hashMaterialName = Name == null ? 0 : Name.GetHashCode();
            return hashMaterialName;
        }
        #endregion


        public object Clone()
        {
            return this.MemberwiseClone();
        }



        // sqlite will generate id automatically
        Guid id;
        public Guid ID
        {
            get { return id; }
            set { id = value; Notify("ID"); }
        }

        bool selected;
        public bool Selected
        {
            get { return selected; }
            set { selected = value; Notify("Selected"); }
        }
        string category;
        public string Category
        {
            get { return category; }
            set { category = value; Notify("Category"); }
        }
        string type;
        public string Type
        {
            get { return type; }
            set { type = value; Notify("Type"); }
        }
        string name;
        public string Name
        {
            get { return name; }
            set { 
                name = value;
                if (name.Contains(" "))
                {
                    name = name.Trim();
                }
                Notify("Name"); 
            }
        }
        double permittivity;
        public double Permittivity
        {
            get { return permittivity; }
            set { permittivity = value; Notify("Permittivity"); }
        }
        double permeability;
        public double Permeability
        {
            get { return permeability; }
            set { permeability = value; Notify("Permeability"); }
        }
        double conductivity;
        public double Conductivity
        {
            get { return conductivity; }
            set { conductivity = value; Notify("Conductivity"); }
        }
        double loss_tangent;
        public double LossTangent
        {
            get { return loss_tangent; }
            set { loss_tangent = value; Notify("LossTangent"); }
        }



        public Material()
        {
            Category = "system";
            Selected = false;
        }

        public string AttributeString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(category).Append(", ").Append(type).Append(", ").Append(name).Append(", ");
            str.Append(permittivity).Append(", ").Append(permeability).Append(", ");
            str.Append(conductivity).Append(", ").Append(loss_tangent);
            return str.ToString();
        }
    }
}
