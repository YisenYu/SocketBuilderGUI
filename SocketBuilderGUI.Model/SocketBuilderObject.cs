using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using System.ComponentModel;
namespace Model
{
    public class SocketBuilderObject : INotifyPropertyChanged
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






        Guid id;
        public Guid Id
        {
            get { return id; }
            set { id = value; Notify("Id"); }
        }


        #region 1.PROJECT

        string user_id;
        public string UserID
        {
            get { return user_id; }
            set { user_id = value; Notify("UserID"); }
        }

        string company_id;
        public string CompanyID
        {
            get { return company_id; }
            set { company_id = value; Notify("CompanyID"); }
        }

        string prj_name;
        public string PrjName
        {
            get { return prj_name; }
            set { prj_name = value; Notify("PrjName"); }
        }

        double nominal_pitch;
        public double NominalPitch
        {
            get { return nominal_pitch; }
            set { nominal_pitch = value; Notify("NominalPitch"); }
        }

        double x_pitch;
        public double XPitch
        {
            get { return x_pitch; }
            set { x_pitch = value; Notify("XPitch"); }
        }

        double y_pitch;
        public double YPitch
        {
            get { return y_pitch; }
            set { y_pitch = value; Notify("YPitch"); }
        }

        double x_offset;
        public double XOffset
        {
            get { return x_offset; }
            set { x_offset = value; Notify("XOffset"); }
        }

        double port_impedance;
        public double PortImpedance
        {
            get { return port_impedance; }
            set { port_impedance = value; Notify("PortImpedance"); }
        }

        double term_impedance;
        public double TermImpedance
        {
            get { return term_impedance; }
            set { term_impedance = value; Notify("TermImpedance"); }
        }


        double se_spec_IL;
        public double SeSpecIL
        {
            get { return se_spec_IL; }
            set { se_spec_IL = value; Notify("SeSpecIL"); }
        }

        double se_spec_RL;
        public double SeSpecRL
        {
            get { return se_spec_RL; }
            set { se_spec_RL = value; Notify("SeSpecRL"); }
        }

        double se_spec_NEXT;
        public double SeSpecNEXT
        {
            get { return se_spec_NEXT; }
            set { se_spec_NEXT = value; Notify("SeSpecNEXT"); }
        }

        double se_spec_FEXT;
        public double SeSpecFEXT
        {
            get { return se_spec_FEXT; }
            set { se_spec_FEXT = value; Notify("SeSpecFEXT"); }
        }

        double se_spec_freq;
        public double SeSpecFreq
        {
            get { return se_spec_freq; }
            set { se_spec_freq = value; Notify("SeSpecFreq"); }
        }

        double diff_spec_IL;
        public double DiffSpecIL
        {
            get { return diff_spec_IL; }
            set { diff_spec_IL = value; Notify("DiffSpecIL"); }
        }

        double diff_spec_RL;
        public double DiffSpecRL
        {
            get { return diff_spec_RL; }
            set { diff_spec_RL = value; Notify("DiffSpecRL"); }
        }

        double diff_spec_NEXT;
        public double DiffSpecNEXT
        {
            get { return diff_spec_NEXT; }
            set { diff_spec_NEXT = value; Notify("DiffSpecNEXT"); }
        }

        double diff_spec_FEXT;
        public double DiffSpecFEXT
        {
            get { return diff_spec_FEXT; }
            set { diff_spec_FEXT = value; Notify("DiffSpecFEXT"); }
        }

        double diff_spec_freq;
        public double DiffSpecFreq
        {
            get { return diff_spec_freq; }
            set { diff_spec_freq = value; Notify("DiffSpecFreq"); }
        }
        #endregion


        #region 2.SOCKET
        int total_layers;
        public int TotalLayers
        {
            get { return total_layers; }
            set { total_layers = value; Notify("TotalLayers"); }
        }

        double total_height;
        public double TotalHeight
        {
            get { return total_height; }
            set { total_height = value; Notify("TotalHeight"); }
        }

        
        // no data binding for this section: socket layers
        Dictionary<string, string> DictOneSocketLayer = new Dictionary<string, string>();
        List<Dictionary<string, string>> ListSocketLayers = new List<Dictionary<string, string>>();


        #endregion



        #region 3.PINCAV
        // no data binding for this section: pin types 1,2,3
        Dictionary<string, string> DictOnePinType = new Dictionary<string, string>();
        List<Dictionary<string, string>> ListPinTypes = new List<Dictionary<string, string>>(3);

        // no data binding for this section: cav types 1,2,3
        Dictionary<string, string> DictOneCavType = new Dictionary<string, string>();
        List<Dictionary<string, string>> ListCavTypes = new List<Dictionary<string, string>>(3);

        #endregion


        #region 4.PCB

        string part_number_pcb;
        public string PartNumberPCB
        {
            get { return part_number_pcb; }
            set { part_number_pcb = value; Notify("PartNumberPCB"); }
        }

        string description_pcb;
        public string DescriptionPCB
        {
            get { return description_pcb; }
            set { description_pcb = value; Notify("DescriptionPCB"); }
        }

        int npoly_pcb;
        public int NpolyPCB
        {
            get { return npoly_pcb; }
            set { npoly_pcb = value; Notify("NpolyPCB"); }
        }

        string orientation_pcb;
        public string OrientationPCB
        {
            get { return orientation_pcb; }
            set { orientation_pcb = value; Notify("OrientationPCB"); }
        }

        double dpad_pcb;
        public double DpadPCB
        {
            get { return dpad_pcb; }
            set { dpad_pcb = value; Notify("DpadPCB"); }
        }

        double tpad_pcb;
        public double TpadPCB
        {
            get { return tpad_pcb; }
            set { tpad_pcb = value; Notify("TpadPCB"); }
        }

        string matpad_pcb;
        public string MatpadPCB
        {
            get { return matpad_pcb; }
            set { matpad_pcb = value; Notify("MatpadPCB"); }
        }

        double twidth_pcb;
        public double TwidthPCB
        {
            get { return twidth_pcb; }
            set { twidth_pcb = value; Notify("TwidthPCB"); }
        }
        double nvoffx_pcb;
        public double NvoffxPCB
        {
            get { return nvoffx_pcb; }
            set { nvoffx_pcb = value; Notify("NvoffxPCB"); }
        }
        double nvoffy_pcb;
        public double NvoffyPCB
        {
            get { return nvoffy_pcb; }
            set { nvoffy_pcb = value; Notify("NvoffyPCB"); }
        }
        double td1_pcb;
        public double Td1PCB
        {
            get { return td1_pcb; }
            set { td1_pcb = value; Notify("NvoffyPCB"); }
        }
        string diel_mat_name_pcb;
        public string DielMatNamePCB
        {
            get { return diel_mat_name_pcb; }
            set { diel_mat_name_pcb = value; Notify("DielMatNamePCB"); }
        }
        double tcu2_pcb;
        public double Tcu2PCB
        {
            get { return tcu2_pcb; }
            set { tcu2_pcb = value; Notify("NvoffyPCB"); }
        }

        #endregion


        #region 5.PACKAGE
        string type_pkg;
        public string TypePKG
        {
            get { return type_pkg; }
            set { type_pkg = value; Notify("TypePKG"); }
        }
        string part_number_pkg;
        public string PartNumberPKG
        {
            get { return part_number_pkg; }
            set { part_number_pkg = value; Notify("PartNumberPKG"); }
        }



        string description_pkg;
        public string DescriptionPKG
        {
            get { return description_pkg; }
            set { description_pkg = value; Notify("DescriptionPKG"); }
        }

        int npoly_pkg;
        public int NpolyPKG
        {
            get { return npoly_pkg; }
            set { npoly_pkg = value; Notify("NpolyPKG"); }
        }

        string orientation_pkg;
        public string OrientationPKG
        {
            get { return orientation_pkg; }
            set { orientation_pkg = value; Notify("OrientationPKG"); }
        }

        double dpad_pkg;
        public double DpadPKG
        {
            get { return dpad_pkg; }
            set { dpad_pkg = value; Notify("DpadPKG"); }
        }

        double tpad_pkg;
        public double TpadPKG
        {
            get { return tpad_pkg; }
            set { tpad_pkg = value; Notify("TpadPKG"); }
        }

        string matpad_pkg;
        public string MatpadPKG
        {
            get { return matpad_pkg; }
            set { matpad_pkg = value; Notify("MatpadPKG"); }
        }

        double twidth_pkg;
        public double TwidthPKG
        {
            get { return twidth_pkg; }
            set { twidth_pkg = value; Notify("TwidthPKG"); }
        }
        double nvoffx_pkg;
        public double NvoffxPKG
        {
            get { return nvoffx_pkg; }
            set { nvoffx_pkg = value; Notify("NvoffxPKG"); }
        }
        double nvoffy_pkg;
        public double NvoffyPKG
        {
            get { return nvoffy_pkg; }
            set { nvoffy_pkg = value; Notify("NvoffyPKG"); }
        }
        double td1_pkg;
        public double Td1PKG
        {
            get { return td1_pkg; }
            set { td1_pkg = value; Notify("NvoffyPKG"); }
        }
        string diel_mat_name_pkg;
        public string DielMatNamePKG
        {
            get { return diel_mat_name_pkg; }
            set { diel_mat_name_pkg = value; Notify("DielMatNamePKG"); }
        }
        double tcu2_pkg;
        public double Tcu2PKG
        {
            get { return tcu2_pkg; }
            set { tcu2_pkg = value; Notify("NvoffyPKG"); }
        }



        double bga_diameter;
        public double BGADiameter
        {
            get { return bga_diameter; }
            set { bga_diameter = value; Notify("BGADiameter"); }
        }
        double bga_height;
        public double BGAHeight
        {
            get { return bga_height; }
            set { bga_height = value; Notify("BGAHeight"); }
        }
        string ball_type;
        public string BallType
        {
            get { return ball_type; }
            set { ball_type = value; Notify("BallType"); }
        }
        int ball_poly;
        public int BallPoly
        {
            get { return ball_poly; }
            set { ball_poly = value; Notify("BallPoly"); }
        }
        string bga_orientation;
        public string BGAOrientation
        {
            get { return bga_orientation; }
            set { bga_orientation = value; Notify("BGAOrientation"); }
        }
        #endregion


        #region 6.ARRAY
        int nx_array;
        public int NXArray
        {
            get { return nx_array; }
            set { nx_array = value; Notify("NXArray"); }
        }
        int ny_array;
        public int NYArray
        {
            get { return ny_array; }
            set { ny_array = value; Notify("NYArray"); }
        }
        double xedge_min;
        public double XedgeMin
        {
            get { return xedge_min; }
            set { xedge_min = value; Notify("XedgeMin"); }
        }
        double xedge_max;
        public double XedgeMax
        {
            get { return xedge_max; }
            set { xedge_max = value; Notify("XedgeMax"); }
        }
        double yedge_min;
        public double YedgeMin
        {
            get { return yedge_min; }
            set { yedge_min = value; Notify("YedgeMin"); }
        }
        double yedge_max;
        public double YedgeMax
        {
            get { return yedge_max; }
            set { yedge_max = value; Notify("YedgeMax"); }
        }

        string pin_array;
        public string PinArray
        {
            get { return pin_array; }
            set { pin_array = value; Notify("PinArray"); }
        }

        string PCB_terminals;
        public string PCBTerminals
        {
            get { return PCB_terminals; }
            set { PCB_terminals = value; Notify("PCBTerminals"); }
        }

        string diffports;
        public string Diffports
        {
            get { return diffports; }
            set { diffports = value; Notify("Diffports"); }
        }
        #endregion


        #region 7.ANALYSIS
        double start_freq;
        public double StartFreq
        {
            get { return start_freq; }
            set { start_freq = value; Notify("StartFreq"); }
        }
        double stop_freq;
        public double StopFreq
        {
            get { return stop_freq; }
            set { stop_freq = value; Notify("StopFreq"); }
        }
        double step_freq;
        public double StepFreq
        {
            get { return step_freq; }
            set { step_freq = value; Notify("StepFreq"); }
        }
        double mesh_freq;
        public double MeshFreq
        {
            get { return mesh_freq; }
            set { mesh_freq = value; Notify("MeshFreq"); }
        }
        string sweep_type;
        public string SweepType
        {
            get { return sweep_type; }
            set { sweep_type = value; Notify("SweepType"); }
        }
        string boundary;
        public string Boundary
        {
            get { return boundary; }
            set { boundary = value; Notify("Boundary"); }
        }
        string accuracy;
        public string Accuracy
        {
            get { return accuracy; }
            set { accuracy = value; Notify("Accuracy"); }
        }

        #endregion


        #region 8.MATERIAL
        List<Material> PrjMaterials;
        List<Material> SysMaterials;
        #endregion



        #region 9.PINCAVLIB
        // no data binding in this section

        // no data binding for this section: socket layers
        List<Dictionary<string, string>> ListSocketLayers = new List<Dictionary<string, string>>();
        #endregion


        // constructor
        public SocketBuilderObject()
        {
            Id = new Guid();
        }

    }
}
