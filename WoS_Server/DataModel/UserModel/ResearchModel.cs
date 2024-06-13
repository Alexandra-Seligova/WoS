namespace WoS_Server.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ResearchModel
    {
        public int Id_User { get; set; } = 0; // id serveru

        [Key]
        public int Id_Research { get; set; }

        [Required]
        public ResearchType Id_Research_Type { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }


        [Required]
        public int Research_level { get; set; }


    }
}

