namespace WoS_Server.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;



    public class GalaxyPosition
    {
        [Key]
        public int Id_GalaxyMap { get; set; }
        public int Id_GalaxyPosition { get; set; }

        public int Id_Sector { get; set; }
        public int Position_X { get; set; }
        public int Position_Y { get; set; }
    }

}
