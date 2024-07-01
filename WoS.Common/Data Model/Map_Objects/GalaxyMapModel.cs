namespace WoS_Server.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GalaxyMapModel
    {
        [Key]
        public int Id_GalaxyMap { get; set; }
        public int Id_GalaxyType { get; set; }
        public int Id_GalaxyPosition { get; set; }

        public string Name { get; set; }
        public string Designation { get; set; } = "Ship";


        /*

        list  GalaxyPositionModel
            list MapModel
        */
    }



    /*
    Slouží jako základní rozcestník map, jejich pozic v galaxii






    */
}
