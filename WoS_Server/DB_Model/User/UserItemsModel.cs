namespace WoS_Server.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserItemsModel
    {
        [Key]
        public int Id_User { get; set; } = 0; // id serveru


        public int Id_Item { get; set; }
        public int Id_ItemType { get; set; }

        public string ItemName { get; set; }
        public int Level { get; set; }

    }
}
